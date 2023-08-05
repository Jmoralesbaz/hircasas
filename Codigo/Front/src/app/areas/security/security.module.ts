import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { AccessComponent } from './access/access.component';
import { RecoverpasswordComponent } from './recoverpassword/recoverpassword.component';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { SharedModule } from '@pshared/shared.module';


@NgModule({
  declarations: [
    AccessComponent,
    RecoverpasswordComponent,
    ChangepasswordComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SecurityRoutingModule
  ]
})
export class SecurityModule { }
