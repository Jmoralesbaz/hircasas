using HirCasa.Back.Models;
using HirCasa.Back.Uils;
using HirCasa.Back.Persistence.Dal;
using HirCasa.Back.Persistence.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Bussiness
{
    
    public class BUser : BBase
    {
        public string Key { get; set; }
        public BUser()
        {
        }

        public BUser(DbHirCasa fAST_POS) : base(fAST_POS)
        {
        }
        public Result<MUserFull> getById(int id)
        {
            Result<MUserFull> result = new Result<MUserFull>();
            try
            {
                var data= this.dbContext.Users.Where(w => w.Id == id).FirstOrDefault();
                if (data != null)
                {
                    result.data = Reflection.ChangeObject<MUserFull, User>(data);
                }
                else
                {
                    result.SetError(404, $"No hay datos asociados al {id}");
                }
            }
            catch (Exception ex)
            {

                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<List<MUserFull>> GetList()
        {
            Result<List<MUserFull>> result = new Result<List<MUserFull>>() { data = new List<MUserFull>() };

            try
            {
                List<MUserFull> list = new List<MUserFull>();
                this.dbContext.Users.ToList().ForEach(f => {
                    list.Add(Reflection.ChangeObject<MUserFull, User>(f));
                });
                result.data = list;
                if (!list.Any())
                {
                    result.SetError(404, "No hay datos");
                }
            }
            catch (Exception ex)
            {

                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<int> Create(MUser model)
        {
            Result<int> result = new Result<int>();
            try
            {
                var mUser = this.dbContext.Users.Where(w => w.UserName.ToLower() == model.UserName.ToLower()).FirstOrDefault();
                if (mUser is null)
                {
                    var mInsert = Reflection.ChangeObject<User, MUser>(model);
                    mInsert.Password = Crypto.EncodeCadSha256(model.Password, Key);
                    //mInsert.Rol = Enum.GetName(typeof(Roles), model.Rol);
                    this.dbContext.Users.Add(mInsert);
                    if (this.dbContext.SaveChanges() == 1)
                    {
                        result.data = mInsert.Id;
                    }
                }
                else
                {
                    result.SetError(400, $"Ya existe un Usuario  con el nombre {model.UserName}");
                }
            }
            catch (Exception ex)
            {
                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<int> Update(MUserFull data)
        {
            Result<int> result = new Result<int>(204);
            
            if (!this.dbContext.Users.Where(w => w.Id != data.Id && w.UserName.ToLower() == data.UserName.ToLower()).Any())
            {
                var mUser = this.dbContext.Users.Where(w => w.Id == data.Id ).FirstOrDefault();
                mUser.Asset = data.Asset;
                mUser.Rol = data.Rol;
                mUser.Person = data.Person;
                mUser.UserName = data.UserName;
                if (mUser.Password != data.Password && !string.IsNullOrEmpty(data.Password)) {
                    mUser.Password = Crypto.EncodeCadSha256(data.Password, Key);
                }
                this.dbContext.Users.Update(mUser);
                result.data = this.dbContext.SaveChanges();
            }
            else
            {
                result.SetError(400, $"Ya existe un Usuario  con el nombre {data.UserName}");
            }
            return result;
        }
    }
}
