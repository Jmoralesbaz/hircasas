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
    public class BInventory : BBase
    {
        public BInventory()
        {
        }

        public BInventory(DbHirCasa fAST_POS) : base(fAST_POS)
        {
        }

       
        public Result<List<MInventoryFull>> GetList()
        {
            Result<List<MInventoryFull>> result = new Result<List<MInventoryFull>>() { data = new List<MInventoryFull>() };

            try
            {
                List<MInventoryFull> list = new List<MInventoryFull>();
                this.dbContext.Inventories.ToList().ForEach(f => {
                    list.Add(Reflection.ChangeObject<MInventoryFull, Inventory>(f));
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
        public Result<int> Create(MInventory model)
        {
            Result<int> result = new Result<int>();
            try
            {
                var item= this.dbContext.Items.Where(w => w.Id == model.Item).FirstOrDefault();
                if (item != null)
                {
                    item.Stock += model.Quantity;
                    var mInsert = Reflection.ChangeObject<Inventory, MInventory>(model);
                    mInsert.ItemNavigation = item;
                    this.dbContext.Inventories.Add(mInsert);
                    if (this.dbContext.SaveChanges() == 1)
                    {
                        result.data = mInsert.Id;
                    }
                }
                else
                {
                    result.SetError(400, $"El Articulo que trataas de agregar no existe");
                }
            }
            catch (Exception ex)
            {
                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        
    }
}
