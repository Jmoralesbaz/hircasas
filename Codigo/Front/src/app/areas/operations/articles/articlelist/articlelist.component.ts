import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Iitem, Item } from '@pdata/interfaces/iitem';
import { BaseForm } from '@pdata/schemas/baseform';
import { ItemsService } from '@pdata/services/items.service';

@Component({
  selector: 'app-articlelist',
  templateUrl: './articlelist.component.html',
  styleUrls: ['./articlelist.component.scss']
})
export class ArticlelistComponent extends BaseForm<Iitem> {
  constructor(private fb:FormBuilder,private srvItems:ItemsService){
    super(Item);
    this.form = fb.group({
      id:new FormControl(this.model.id),
      item1:new FormControl(this.model.item1,[Validators.required]),
      price:new FormControl(this.model.price),
      stock:new FormControl(this.model.stock),
      asset:new FormControl(this.model.asset),
    });
  }
  override async loadData() {
    var r = await this.executeValue(this.srvItems.getAll());
    if(!this.error){
      this.list = r;
    }
  }
  protected override async saveData() {
    if(this.index==-1){
      var r =await this.executeValue(this.srvItems.add(this.model));
      if(!this.error){
        this.model.id=r;
      }
    }else{
      var r =await this.executeValue(this.srvItems.edit(this.model.id,this.model));
    }
  }
}
