import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OperationsRoutingModule } from './operations-routing.module';
import { PersonlistComponent } from './persons/personlist/personlist.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { ArticlelistComponent } from './articles/articlelist/articlelist.component';
import { InvoicelistComponent } from './invoices/invoicelist/invoicelist.component';
import { SalelistComponent } from './sales/salelist/salelist.component';
import { InventrylistComponent } from './inventory/inventrylist/inventrylist.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '@pshared/shared.module';


@NgModule({
  declarations: [
    PersonlistComponent,
    UserlistComponent,
    ArticlelistComponent,
    InvoicelistComponent,
    SalelistComponent,
    InventrylistComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    OperationsRoutingModule
  ]
})
export class OperationsModule { }
