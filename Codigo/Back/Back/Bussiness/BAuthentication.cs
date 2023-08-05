using HirCasa.Back.Models;
using HirCasa.Back.Persistence.Dal;
using HirCasa.Back.Persistence.Dao;
using HirCasa.Back.Uils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace HirCasa.Back.Bussiness
{
    public class BAuthentication : BBase
    {
        public string Key { get;set;}
        public string SecretJWT { get; set; }
        public double TimeJWT { get; set; }
        public BAuthentication()
        {
        }

        public BAuthentication(DbHirCasa fAST_POS) : base(fAST_POS)
        {
            
        }

        public Result<JWToken> Login(MLogin login) {
            Result<JWToken> result = new Result<JWToken>();
            try
            {
                var us = dbContext.Users.Where(w => w.UserName.ToLower() == login.user.ToLower() && w.Password == Crypto.EncodeCadSha256(login.password, Key)).FirstOrDefault();
                if (us != null)
                {
                    JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
                    var exp = DateTime.UtcNow.AddMinutes(TimeJWT);
                    SecurityTokenDescriptor description = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name,login.user ),
                            new Claim(ClaimTypes.Role,us.Rol),
                            new Claim(ClaimTypes.Expired,exp.ToString("yyyy-MM-dd HH:mm:ss"))
                        }),
                        Expires = exp,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Converts.ToArrayByte(Converts.ReverseString(SecretJWT))), SecurityAlgorithms.HmacSha256Signature)
                    };
                    string token = tokenhandler.WriteToken(tokenhandler.CreateToken(description));
                    Session s = new Session
                    {
                        CheckIn = DateTime.Now,
                        Token = token,
                        IdUser = us.Id
                    };
                    dbContext.Sessions.Add(s);
                    var r = dbContext.SaveChanges();
                    if (r > 0)
                    {
                        result.data = new JWToken
                        {
                            Token = token,
                            DataUser = new MAuthentication
                            {
                                Expired = exp.Ticks,
                                Rol = us.Rol,
                                Person = us.Person,
                                User = us.UserName
                            }
                        };
                    }
                    else {
                        result.SetError(500, "No se pudo iniciar sesion, intentalo mas tarde");
                    }                    
                }
                else
                {
                    result.SetError(404, "Usuario contraseña no validos");
                }
            }
            catch (Exception ex)
            {
                result.SetError(500,ex.Message);
            }


            return result;
        }
    }
}
