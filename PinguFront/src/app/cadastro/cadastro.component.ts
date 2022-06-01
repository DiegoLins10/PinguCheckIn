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
  sucesso: any;
  Isloading: boolean;

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
    this.cadastro.Celular = ''
    this.sucesso = false;
  }

  Cadastrar(){
    this.mensagem = [];
    this.sucesso = [];
    this.Isloading = true;
    if(this.cadastro.Email == ''){
      this.mensagem.push("Email está vazio")
      this.Isloading = false;
    }   
    if(this.cadastro.Senha == ''){
      this.mensagem.push("Senha está vazia")
      this.Isloading = false;
    }   
    if(this.cadastro.Nome == ''){
      this.mensagem.push("Nome não foi preenchido")
      this.Isloading = false;
    }
    if(this.cadastro.Sobrenome == ''){
      this.mensagem.push("Sobrenome não foi preenchido")
      this.Isloading = false;
    }
    if(this.cadastro.Cpf == ''){
      this.mensagem.push("Cpf não foi preenchido")
      this.Isloading = false;
    }
    if(this.cadastro.Celular == ''){
      this.mensagem.push("Celular não foi preenchido")
      this.Isloading = false;
    }
    if(!this.cadastro.DataNascimento){
      this.mensagem.push("Data de nascimento invalida")
      this.Isloading = false;
    }
    if(this.senha != this.cadastro.Senha){
      this.mensagem.push("A senha digitada está diferente da confirmação")
      this.Isloading = false;
    }
    else{
      this.cadastro.Nome.trim();
      this.cadastroService.CadastrarUsuario(this.cadastro)
    .subscribe(res => {
      this.sucesso.push(res.mensagem)
      console.log(res.mensagem);
      this.Isloading = false;
    },
    error =>{
      this.mensagem.push(error.error)
      console.log(this.mensagem)
      this.Isloading = false;
    });
    }
    
  }
}


