import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoutsNavigation } from '@pdata/constants/navigations';
import { HomeComponent } from './home/home.component';
import { InventrylistComponent } from './inventory/inventrylist/inventrylist.component';
import { InvoicelistComponent } from './invoices/invoicelist/invoicelist.component';
import { ArticlelistComponent } from './articles/articlelist/articlelist.component';
import { PersonlistComponent } from './persons/personlist/personlist.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { SalelistComponent } from './sales/salelist/salelist.component';
const Nav=RoutsNavigation.Operations;
const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:Nav.configurations.Path,
    children:[
      {
        path:Nav.configurations.Inventory.Url,
        component:InventrylistComponent
      },
      {
        path:Nav.configurations.Invoice.Url,
        component:InvoicelistComponent
        
      },
      {
        path:Nav.configurations.Items.Url,
        component:ArticlelistComponent
        
      },
      {
        path:Nav.configurations.Pepols.Url,
        component:PersonlistComponent
        
      },{
        path:Nav.configurations.Users.Url,
        component:UserlistComponent
        
      },{
        path:Nav.configurations.Ventas.Url,
        component:SalelistComponent
        
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OperationsRoutingModule { }
