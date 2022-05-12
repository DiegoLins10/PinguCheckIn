import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';
import { Cadastro } from './cadastro.model';
import { CadastroService } from './cadastro.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  autenticado: any;
  cadastro!: Cadastro;
  mensagem: any = [];
  senha: any;
  dataNascimento!: string

  constructor(private authenticationService: AuthenticationService, private router: Router, private cadastroService: CadastroService) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    if(this.autenticado){
      this.router.navigate(['/home'])
    }
    this.cadastro = new Cadastro();
    this.cadastro.Email = ''
    this.cadastro.Senha = ''
    this.cadastro.Nome = ''
    this.cadastro.Sobrenome = ''
    this.cadastro.Cpf = ''
    this.cadastro.Rg = ''
    this.cadastro.Celular = ''

  }

  Cadastrar(){
    this.mensagem = [];
    if(this.cadastro.Email == ''){
      this.mensagem.push("Email está vazio")
    }   
    if(this.cadastro.Senha == ''){
      this.mensagem.push("Senha está vazia")
    }   
    if(this.cadastro.Nome == ''){
      this.mensagem.push("Nome não foi preenchido")
    }
    if(this.cadastro.Sobrenome == ''){
      this.mensagem.push("Sobrenome não foi preenchido")
    }
    if(this.cadastro.Cpf == ''){
      this.mensagem.push("Cpf não foi preenchido")
    }
    if(this.cadastro.Rg == ''){
      this.mensagem.push("Rg não foi preenchido")
    }
    if(this.cadastro.Celular == ''){
      this.mensagem.push("Celular não foi preenchido")
    }
    if(!this.cadastro.DataNascimento){
      this.mensagem.push("Data de nascimento invalida")
    }
    if(this.senha != this.cadastro.Senha){
      this.mensagem.push("A senha digitada está diferente da confirmação")
    }
    else{
      this.cadastro.Nome.trim();
      this.cadastroService.CadastrarUsuario(this.cadastro)
    .subscribe(res => {
      this.router.navigate(["/"])
      console.log(res.mensagem);
    },
    error =>{
      this.mensagem.push(error.error)
      console.log(this.mensagem)
    });
    }
    
  }
}


