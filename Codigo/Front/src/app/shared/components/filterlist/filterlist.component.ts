import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-filterlist',
  templateUrl: './filterlist.component.html',
  styleUrls: ['./filterlist.component.scss']
})
export class FilterlistComponent {

  @Input() list:any[]=[];
  @Output() onFilter= new EventEmitter<any[]>();
  filter(data:any){
    console.log(data.target.value);
  }

}
