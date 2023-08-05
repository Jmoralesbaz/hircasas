import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationComponent } from './layouts/skeleton/authentication/authentication.component';
import { PanelComponent } from './layouts/skeleton/panel/panel.component';
import { SharedModule } from '@pshared/shared.module';
import { CoreModule } from './core/core.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    AuthenticationComponent,
    PanelComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
