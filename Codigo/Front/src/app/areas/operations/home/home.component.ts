import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CONFIG } from '@pdata/constants/config';
import { Iitem } from '@pdata/interfaces/iitem';
import { Isales, Sales } from '@pdata/interfaces/isales';
import { BaseForm } from '@pdata/schemas/baseform';
import { ItemsService } from '@pdata/services/items.service';
import { SalesService } from '@pdata/services/sales.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseForm<Isales> {
  @ViewChild('closeModalPay') closeModalPay!:ElementRef;
  totalproducts:number=0;
  totalSum:number=0;
  lstItems:Iitem[]=[];
  constructor(private fb: FormBuilder, private srvItem: ItemsService, private srvSales: SalesService) {
    super(Sales);
  }

  override async loadData() {
    var r = await this.executeValue<Iitem[]>(this.srvItem.getAll());
    if(!this.error){
      this.lstItems = r;      
    }
  }

  addItem(item:Iitem){
    var i = this.model.items.findIndex(f=>{return f.item == item.id});
    if(i <0){
      this.model.items = [...this.model.items,{...{item:item.id,itemName:item.item1,quantity:1, price:item.price}}];
    }else{
      var m = this.model.items[i];
      m.quantity=m.quantity+1;
      this.model.items[i] = m;
      this.model.items = [...this.model.items];
    }
     item.stock=item.stock-1;    
  }
  removeItem(ind:number){
    var m = this.model.items[ind];
    var d = this.model.items.splice(ind, 1);
    this.model.items = [...this.model.items];
    var i=this.lstItems.findIndex(f=>{return f.id == m.item});
    var modstock = this.lstItems[i];
    modstock.stock=modstock.stock+m.quantity;
    this.lstItems[i] = modstock;
    this.lstItems = [...this.lstItems];
  }
  getTotales(){
    this.totalproducts=0;this.totalSum=0;
    this.model.items.forEach(f=>{
      this.totalproducts=(Number(this.totalproducts) + Number(f.quantity));
      this.totalSum = Number(this.totalSum) + (Number(f.price) * Number(f.quantity));
    });
  }

  override async save() {
    if(this.index==-1){
      var usd =  JSON.parse(atob(localStorage.getItem(CONFIG.DATAUSER)??''));
      this.model.person = usd.person;
      var r =await this.executeValue(this.srvSales.add(this.model));
      if(!this.error){
        this.closeModalPay.nativeElement.click();
        this.reset();
      }
    }
  }
}
