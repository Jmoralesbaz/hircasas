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
    public class BPerson : BBase
    {
        public BPerson()
        {
        }

        public BPerson(DbHirCasa fAST_POS) : base(fAST_POS)
        {
        }
        public Result<MPersonFull> getById(int id)
        {
            Result<MPersonFull> result = new Result<MPersonFull>();
            try
            {
                var data = this.dbContext.Persons.Where(w => w.Id == id).FirstOrDefault();
                if (data != null)
                {
                    result.data = Reflection.ChangeObject<MPersonFull, Person>(data);
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
        public Result<List<MPersonFull>> GetList()
        {
            Result<List<MPersonFull>> result = new Result<List<MPersonFull>>() { data = new List<MPersonFull>() };

            try
            {
                List<MPersonFull> list = new List<MPersonFull>();
                this.dbContext.Persons.ToList().ForEach(f => {
                    list.Add(Reflection.ChangeObject<MPersonFull, Person>(f));
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
        public Result<int> Create(MPerson model)
        {
            Result<int> result = new Result<int>();
            try
            {
                
                if (!this.dbContext.Persons.Where(w => w.Name.ToLower() == model.Name.ToLower() || w.Email.ToLower() == model.Email.ToLower()).Any())
                {
                    var mInsert = Reflection.ChangeObject<Person, MPerson>(model);
                    this.dbContext.Persons.Add(mInsert);
                    if (this.dbContext.SaveChanges() == 1)
                    {
                        result.data = mInsert.Id;
                    }
                }
                else
                {
                    result.SetError(400, $"Ya existe una persona con el nombre {model.Name} o correo {model.Email}");
                }
            }
            catch (Exception ex)
            {
                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<int> Update(MPersonFull model)
        {
            Result<int> result = new Result<int>(204);
            
            if (!this.dbContext.Persons.Where(w => w.Id != model.Id && (w.Name.ToLower() == model.Name.ToLower() || w.Email.ToLower() == model.Email.ToLower())).Any())
            {
                this.dbContext.Persons.Update(Reflection.ChangeObject<Person, MPerson>(model));
                result.data = 1;
            }
            else
            {
                result.SetError(400, $"Ya existe una persona con el nombre {model.Name} o correo {model.Email}");
            }
            return result;
        }
        public Result<int> Asset(int id)
        {
            Result<int> result = new Result<int>(204);
            var model = this.dbContext.Persons.Where(w => w.Id == id).FirstOrDefault();
            if (model != null)
            {
                model.Asset = !model.Asset;

                this.dbContext.Persons.Update(model);
                result.data = 1;
            }
            else
            {
                result.SetError(400, $"Ya existe una persona con el nombre {model.Name} o correo {model.Email}");
            }
            return result;
        }
    }
}
