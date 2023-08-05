import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Iperson } from '@pdata/interfaces/iperson';
import { Iusers, Users } from '@pdata/interfaces/iusers';
import { BaseForm } from '@pdata/schemas/baseform';
import { PepolsService } from '@pdata/services/pepols.service';
import { UsersService } from '@pdata/services/users.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.scss']
})
export class UserlistComponent extends BaseForm<Iusers>{
  listP:Iperson[]=[];
  listSelect:Iperson[]=[];
  passwordConfirm:boolean=false;
  constructor(private fb:FormBuilder,private srvPerson:PepolsService,private srvUser:UsersService) {
    super(Users);
    
    this.form = fb.group(
      {
        id: new FormControl(this.model.id),
        person: new FormControl(this.model.person, [Validators.required]),
        userName: new FormControl(this.model.userName, [Validators.required]),
        password: new FormControl(this.model.password, [Validators.required]),
        asset: new FormControl(this.model.asset,),
        rol: new FormControl(this.model.rol, [Validators.required])
      }
    );
    this.srvPerson.getAll().subscribe((d)=>{
      this.listP =d;
    });
  }
  override async loadData() {
    var r = await this.executeValue<Users[]>(this.srvUser.getAll());
    if(!this.error){
      this.list = r;
      this.reset();
    }
  }
  protected override async reset(): Promise<void> {
    this.dataModelString = JSON.stringify(new Users());
    this.index = -1;
    this.setValueForm(); 
    this.resetSelect();
  }
  resetSelect(){
    let tmp:Iperson[]=[];
    this.listP.forEach(f=>{
      if(this.list.find(p=>{return p.person == f.id}) == undefined){
        tmp.push(f);
      }
    });
    this.listSelect=[...tmp];
  }
  getNamePerson(idperson:number){
    var pn = this.listP.find(f=>{return f.id == idperson});
    return `${pn?.name} ${pn?.lastName}`;
  }
  override async saveData() {
    if(this.index==-1){
      var r =await this.executeValue(this.srvUser.add(this.model));
      if(!this.error){
        this.model.id=r;
      }
    }else{
      var r =await this.executeValue(this.srvUser.edit(this.model.id,this.model));
    }
  }
  validatePwd(data:any){
    this.passwordConfirm = false;
    this.code = 0;
    if(data.target.value != this.model.password){      
      this.code = 400;
      this.passwordConfirm=true;
      this.getDataAlert();
    }
  }
}
