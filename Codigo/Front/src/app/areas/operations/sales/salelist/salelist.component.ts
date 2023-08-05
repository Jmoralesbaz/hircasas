import { Component } from '@angular/core';
import { IsalesDetals, SalesDetails } from '@pdata/interfaces/isales';
import { BaseForm } from '@pdata/schemas/baseform';
import { SalesService } from '@pdata/services/sales.service';

@Component({
  selector: 'app-salelist',
  templateUrl: './salelist.component.html',
  styleUrls: ['./salelist.component.scss']
})
export class SalelistComponent extends BaseForm<IsalesDetals> {
  constructor(private srvSales: SalesService) {
    super(SalesDetails);
  }
  override async loadData() {
    var r = await this.executeValue<IsalesDetals[]>(this.srvSales.getAll());
    if (!this.error) {
      this.list = r;
    }
  }
  viewDetails(element: IsalesDetals) {

    this.model = element;
    
  }
}
