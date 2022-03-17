import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService, Credentials } from '../authentication/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: string;
  senha: string;
  loading!: boolean;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
  }

  login(){
    this.loading = true;
    var exp = {
      userName: this.user,
      senha: this.senha
    }
    this.authenticationService.login(exp)
    .subscribe(res =>{
      console.log(res);
    })
  }

}
