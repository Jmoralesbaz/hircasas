import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import * as toolsCompnents from './components';
import { FilterlistComponent } from './components/filterlist/filterlist.component';



@NgModule({
  declarations: [
    ...toolsCompnents.components,
    FilterlistComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    ...toolsCompnents.components,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class SharedModule { }
