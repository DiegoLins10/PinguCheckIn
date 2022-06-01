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
  mensagem: any;
  Isloading: any;

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
    this.Isloading = true;
    this.mensagem = [];
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
      if(error.error.message){
        this.mensagem.push(error.error.message);
        this.Isloading = false;
      }
      else{
        this.mensagem.push(error.message);
        this.Isloading = false;
      }
      console.log(error)
      this.Isloading = false;
    });
  }

}
