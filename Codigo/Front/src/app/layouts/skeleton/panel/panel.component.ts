import { Component, OnInit } from '@angular/core';
import { Idatauder } from '@pdata/interfaces/itoken';
import { AuthenticationService } from '@pdata/services/authentication.service';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.scss']
})
export class PanelComponent implements OnInit {
  userdata:Idatauder|null;
  constructor(public srv:AuthenticationService){
    this.userdata = srv.getUser;
    
  }
  
  ngOnInit(): void {
    this.curentUrl=(window.location.pathname.split('/'))
    this.curentUrl=this.curentUrl.slice(1,this.curentUrl.length);
    this.totalSeccions = this.curentUrl.length-1;
  }  
  
  curentUrl:string[]=[];
  totalSeccions:number=0;
  logOut(){
    
  }
}
