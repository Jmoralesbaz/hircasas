import { Component } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Iinvoice, Invoice } from '@pdata/interfaces/iinvoice';
import { IsalesDetals } from '@pdata/interfaces/isales';
import { BaseForm } from '@pdata/schemas/baseform';
import { InvoicesService } from '@pdata/services/invoices.service';
import { SalesService } from '@pdata/services/sales.service';

@Component({
  selector: 'app-invoicelist',
  templateUrl: './invoicelist.component.html',
  styleUrls: ['./invoicelist.component.scss']
})
export class InvoicelistComponent extends BaseForm<Iinvoice>{
  listSales:IsalesDetals[]=[];
  listSelect:IsalesDetals[]=[];
  constructor(private fb: FormBuilder, private srvSales: SalesService,private srvInv: InvoicesService) {
    super(Invoice);

    this.srvSales.getAll().subscribe((d)=>{
      this.listSales =d;      
    });

    this.form = fb.group(
      {
        sale:new FormControl(this.model.sale),
        rfc:new FormControl(this.model.rfc),
        razonSocial:new FormControl(this.model.razonSocial),
        codigoPostal:new FormControl(this.model.codigoPostal),
        regimenFiscal:new FormControl(this.model.regimenFiscal),
        usoCfdi:new FormControl(this.model.usoCfdi),
        folio:new FormControl(this.model.folio),
      }
    );
  }

  override async loadData() {
    var r = await this.executeValue<Invoice[]>(this.srvInv.getAll());
    if(!this.error){
      this.list = r;  
      this.resetSelect();    
    }
  }

  resetSelect(){
    let tmp:IsalesDetals[]=[];
    this.listSales.forEach(f=>{
      if(this.list.find(p=>{return p.sale == f.id}) == undefined){
        tmp.push(f);
      }
    });
    this.listSelect=[...tmp];
  }
  override async saveData() {
    if(this.index==-1){
      var r =await this.executeValue(this.srvInv.add(this.model));
      if(!this.error){
        this.model.folio=r;
      }
    }else{
      var r =await this.executeValue(this.srvInv.edit(this.model.folio,this.model));
    }
    if(!this.error){
      this.resetSelect();
    }
  }
}
