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
    public class BItem : BBase
    {
        public BItem()
        {
        }

        public BItem(DbHirCasa fAST_POS) : base(fAST_POS)
        {
        }

        public Result<MItemFull> getById(int id) {
            Result<MItemFull> result = new Result<MItemFull>();
            try
            {
                var item = this.dbContext.Items.Where(w => w.Id == id).FirstOrDefault();
                if (item != null)
                {
                    result.data = Reflection.ChangeObject<MItemFull, Item>(item);
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
        public Result<List<MItemFull>> GetList()
        {
            Result<List<MItemFull>> result = new Result<List<MItemFull>>() { data = new List<MItemFull>() };

            try
            {
                List<MItemFull> list = new List<MItemFull>();
                this.dbContext.Items.ToList().ForEach(f => {
                    list.Add(Reflection.ChangeObject<MItemFull, Item>(f));
                });
                result.data = list;
                if (!list.Any()) {
                    result.SetError(404,"No hay datos");
                }
            }
            catch (Exception ex)
            {

                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<int> Create(MItem model)
        {
            Result<int> result = new Result<int>();
            try
            {
                var mitem = this.dbContext.Items.Where(w => w.Item1.ToLower() == model.Item1.ToLower()).FirstOrDefault();
                if (mitem is null)
                {
                    var mInsert = Reflection.ChangeObject<Item, MItem>(model);
                    this.dbContext.Items.Add(mInsert);
                    if (this.dbContext.SaveChanges() == 1)
                    {
                        result.data = mInsert.Id;
                    }
                }
                else
                {
                    result.SetError(400, $"Ya existe un articulo con el nombre {model.Item1}");
                }
            }
            catch (Exception ex)
            {
                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<int> Update(MItemFull data)
        {
            Result<int> result = new Result<int>(204);            
            var mitem = this.dbContext.Items.Where(w => w.Id != data.Id && w.Item1.ToLower() == data.Item1.ToLower()).FirstOrDefault();
            if (mitem is null)
            {
                this.dbContext.Items.Update(Reflection.ChangeObject<Item, MItem>(data));
                result.data = this.dbContext.SaveChanges();
            }
            else
            {
                result.SetError(400, $"Ya existe un articulo con el nombre {data.Item1}");
            }
            return result;
        }
    }
}
