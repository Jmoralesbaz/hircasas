import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Ilogin, Login } from '@pdata/interfaces/ilogin';
import { BaseForm } from '@pdata/schemas/baseform';
import { AuthenticationService } from '@pdata/services/authentication.service';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-access',
  templateUrl: './access.component.html',
  styleUrls: ['./access.component.scss']
})
export class AccessComponent extends BaseForm<Ilogin> {
  constructor(private fb: FormBuilder, private srvAuth: AuthenticationService) {
    super(Login);
    this.form = fb.group({
      user: new FormControl(this.model.user, [Validators.required]),
      password: new FormControl(this.model.password, [Validators.required]),
    });
  }
  override async saveData() {
    this.message = "Validadno sesion";
    this.code = 404;
    this.classalert += "info";
    var e = await lastValueFrom(this.srvAuth.login(this.model)).catch((e: any) => {
      this.error = true;
      this.code = (e.status == 0) ? 500 : e.status;
      this.message = e.error.message;
    });
    this.getDataAlert();
    if (!this.error) {
      this.srvAuth.setUserLocalStorage(e);
    }
  }
}
