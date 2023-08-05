using HirCasa.Back.Models;
using HirCasa.Back.Persistence.Dal;
using HirCasa.Back.Persistence.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Bussiness
{
    public class BSales : BBase
    {
        public BSales()
        {
        }

        public BSales(DbHirCasa fAST_POS) : base(fAST_POS)
        {
        }
        public Result<List<MSalesDetails>> GetList()
        {
            Result<List<MSalesDetails>> result = new Result<List<MSalesDetails>>() { data = new List<MSalesDetails>() };

            try
            {
                List<MSalesDetails> list = new List<MSalesDetails>();
                var lstSalesHeaders = this.dbContext.SalesHeaders.ToList();
                if (!lstSalesHeaders.Any())
                {
                    result.SetError(404, "No hay datos");
                }
                else {
                    lstSalesHeaders.ForEach(f=> {
                        list.Add(new MSalesDetails {
                         Amount = f.Amount,
                         Id = f.Id,
                         Person = f.Person,
                         TotalItems = f.TotalItems,
                         DateSale = f.DateSale,
                         Items = dbContext.SalesDetails.Where(w=>w.Sale == f.Id).Select(s=>new MSalesItem { Item = s.Item,ItemName=s.ItemNavigation.Item1, Price=s.Price, Quantity=s.Quantity  }).ToList()
                        });
                    });
                    result.data = list;
                }
            }
            catch (Exception ex)
            {

                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }
        public Result<int> Create(MSales model)
        {
            Result<int> result = new Result<int>();
            try
            {
                
                model.Items.ForEach(f=> {
                var itemdetail = dbContext.Items.Where(w => w.Id == f.Item).FirstOrDefault();
                    if (itemdetail is null) {
                        result.SetError(400, $"El id {f.Item} del articulo no existe");

                    } else if (itemdetail.Stock - f.Quantity < 0) {
                        result.SetError(400, $"El id del articulo ${itemdetail.Item1} tiene un maximo de {itemdetail.Stock} pieza(s)");
                    }
                    
                });

                if (!result.existeError) {
                    dbContext.Database.BeginTransaction();
                    SalesHeader sale = new SalesHeader {
                        Amount = model.Items.Sum(s => (s.Price * s.Quantity)),
                        DateSale = new DateTime(),
                        Person = model.Person,
                        TotalItems  = model.Items.Sum(s=>s.Quantity)               
                    };
                    dbContext.SalesHeaders.Add(sale);
                    dbContext.SaveChanges();
                    var details = model.Items.Select(s => new SalesDetail
                    {
                        Item = s.Item,
                        Price = s.Price,
                        Quantity = s.Quantity,
                        Sale = sale.Id
                    }).ToArray();
                    dbContext.SalesDetails.AddRange(details);

                    dbContext.SaveChanges();
                    List<Item> items = new List<Item>();
                    model.Items.ForEach(f => {
                        var itd = dbContext.Items.Where(w => w.Id == f.Item).First();
                        itd.Stock -= f.Quantity;
                        items.Add(itd);
                    });
                    dbContext.Items.UpdateRange(items);
                    dbContext.SaveChanges();
                    dbContext.Database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dbContext.Database.RollbackTransaction();
                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }

    }
}
