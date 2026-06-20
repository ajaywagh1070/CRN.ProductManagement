import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

  userName = '';
  password = '';

  login() {

    console.log(this.userName);
    console.log(this.password);

  }
}
