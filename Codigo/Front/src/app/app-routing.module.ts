import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoutsNavigation } from '@pdata/constants/navigations';
import { PanelComponent } from './layouts/skeleton/panel/panel.component';
import { AuthenticationComponent } from './layouts/skeleton/authentication/authentication.component';
import { AuthenticatedGuards } from './core/guards/authenticated.guards';
import { AuthGuards } from './core/guards/auth.guards';
const Navigation = RoutsNavigation;
const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: Navigation.Operations.Path
  },
  {
    path: Navigation.Operations.Path,
    canActivate:[AuthGuards],
    component: PanelComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('@pmodules/operations/operations.module').then((m) => m.OperationsModule)
      }
    ]
  },
  {
    path: Navigation.Access.Path,
    canActivate:[AuthenticatedGuards],
    component: AuthenticationComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('@pmodules/security/security.module').then((m) => m.SecurityModule)
      }
    ]
  },
  {
    path:'**',
    redirectTo: Navigation.Operations.Path
 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
