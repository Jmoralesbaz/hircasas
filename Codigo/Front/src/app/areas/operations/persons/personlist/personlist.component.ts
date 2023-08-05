import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Iperson, Person } from '@pdata/interfaces/iperson';
import { BaseForm } from '@pdata/schemas/baseform';
import { PepolsService } from '@pdata/services/pepols.service';

@Component({
  selector: 'app-personlist',
  templateUrl: './personlist.component.html',
  styleUrls: ['./personlist.component.scss']
})
export class PersonlistComponent extends BaseForm<Iperson>{
  constructor(private fb:FormBuilder,private srvPerson:PepolsService) {
    super(Person);
    
    this.form = fb.group(
      {
        id: new FormControl(this.model.id),
        name: new FormControl(this.model.name, [Validators.required]),
        lastName: new FormControl(this.model.lastName),
        asset: new FormControl(this.model.asset,),
        email: new FormControl(this.model.email),
      }
    );
  }
  override async loadData() {
    var r = await this.executeValue(this.srvPerson.getAll());
    if(!this.error){
      this.list = r;
    }
  }
  override async saveData() {
    if(this.index==-1){
      var r =await this.executeValue(this.srvPerson.add(this.model));
      if(!this.error){
        this.model.id=r;
      }
    }else{
      var r =await this.executeValue(this.srvPerson.edit(this.model.id,this.model));
    }
  }
}
