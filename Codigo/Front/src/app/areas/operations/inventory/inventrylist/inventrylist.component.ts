import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Iinventory, Inventory } from '@pdata/interfaces/iinventory';
import { Iitem } from '@pdata/interfaces/iitem';
import { BaseForm } from '@pdata/schemas/baseform';
import { InventoryService } from '@pdata/services/inventory.service';
import { ItemsService } from '@pdata/services/items.service';

@Component({
  selector: 'app-inventrylist',
  templateUrl: './inventrylist.component.html',
  styleUrls: ['./inventrylist.component.scss']
})
export class InventrylistComponent extends BaseForm<Iinventory>  {
  lstItem:Iitem[]=[];
  constructor(private fb: FormBuilder, private srvInv: InventoryService, private srvItem: ItemsService) {
    super(Inventory);
    this.form=fb.group({
        item:new FormControl(this.model.item,[Validators.required]),
        quantity:new FormControl(this.model.quantity,[Validators.required]),
        checkIn:new FormControl(this.model.checkIn),
    });
    this.srvItem.getAll().subscribe((d)=>{
      this.lstItem =d;
    });
  }
  getNameItem(id:number){
    return this.lstItem.find(f=>{return f.id == id})?.item1;
  }
  override async loadData() {
    var r = await this.executeValue<Iinventory[]>(this.srvInv.getAll());
    if(!this.error){
      this.list = r;      
    }
  }
  override async saveData() {
    if(this.index==-1){
      var r =await this.executeValue(this.srvInv.add(this.model));          
    }
  }
}
