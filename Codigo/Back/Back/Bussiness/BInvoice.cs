using HirCasa.Back.Models;
using HirCasa.Back.Persistence.Dal;
using HirCasa.Back.Persistence.Dao;
using HirCasa.Back.Uils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Bussiness
{
    public class BInvoice : BBase
    {
        public BInvoice()
        {
        }

        public BInvoice(DbHirCasa fAST_POS) : base(fAST_POS)
        {
        }
        public Result<List<MInvoiceFull>> GetList()
        {
            Result<List<MInvoiceFull>> result = new Result<List<MInvoiceFull>>() { data = new List<MInvoiceFull>() };

            try
            {
                List<MInvoiceFull> list = new List<MInvoiceFull>();
                this.dbContext.Invoices.ToList().ForEach(f => {
                    list.Add(Reflection.ChangeObject<MInvoiceFull, Invoice>(f));
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
        public Result<string> Create(MInvoice model)
        {
            Result<string> result = new Result<string>();
            try
            {

                if (!this.dbContext.Invoices.Where(w => w.Sale == model.Sale).Any())
                {
                    if (this.dbContext.SalesHeaders.Where(w=>w.Id == model.Sale).Any()) {
                        var mInsert = Reflection.ChangeObject<Invoice, MInvoice>(model);
                        mInsert.Folio = Guid.NewGuid().ToString();
                        this.dbContext.Invoices.Add(mInsert);
                        if (this.dbContext.SaveChanges() == 1)
                        {
                            result.data = mInsert.Folio;
                        }
                    }
                    else {
                        result.SetError(404, $"La venta {model.Sale} no existe");
                    }
                }
                else
                {
                    result.SetError(400, $"La venta {model.Sale} ya tiene un registro de factura");
                }
            }
            catch (Exception ex)
            {
                result.SetError(500, JsonConvert.SerializeObject(ex));
            }
            return result;
        }

        public Result<int> Update(MInvoiceFull model)
        {
            Result<int> result = new Result<int>();
            try
            {

                if (this.dbContext.Invoices.Where(w => w.Sale == model.Sale).Any())
                {
                    var mInsert = Reflection.ChangeObject<Invoice, MInvoice>(model);
                   
                    this.dbContext.Invoices.Update(mInsert);
                    result.data = this.dbContext.SaveChanges();
                }
                else
                {
                    result.SetError(400, $"La venta {model.Sale} no tiene un registro de factura");
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