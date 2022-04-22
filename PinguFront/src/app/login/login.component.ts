import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  autenticado: any;

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    if(this.autenticado){
      this.router.navigate(['/home'])
    }else{
      this.router.navigate([''])
    }
  }

  login(){
    this.loading = true;
    var exp = {
      email: this.user,
      senha: this.senha
    }
    this.authenticationService.login(exp)
    .subscribe(res =>{
      this.autenticado = this.authenticationService.isAuthenticated();
      if(this.autenticado){
        this.router.navigate(['/home'])
     }
     console.log(res);
    }, error =>{
      console.log(error)
    });
  }

}
