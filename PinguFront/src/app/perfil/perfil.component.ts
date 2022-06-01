import { ValidatorField } from './ValidatorField';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { PerfilService } from './perfil.service';
import { AuthenticationService } from '../authentication/authentication.service';
import { Router } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;
  autenticado!: boolean;
  usuario: any;
  mensagem: any;
  sucesso: any;

  nome: any
  format: any = 'yyyy-MM-dd';
  locale: any = 'en-US';
  data: any;

  Isloading: any;

  constructor(private fb: FormBuilder, private service: PerfilService, private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    this.validation();

    this.autenticado = this.authenticationService.isAuthenticated();
    if(this.autenticado){
      this.router.navigate(['/perfil'])
    }else{
      this.router.navigate([''])
    }

    this.GetUser();


  }
  private validation(): void {
    const formOptions = { Validators: ValidatorField.MustMatch('senha', 'confirmeSenha') };

    this.form = this.fb.group({
      titulo: ['', Validators.required],
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required],
      nascimento: ['', Validators.required],
      cpf: ['', Validators.required],
      rg: ['', Validators.required],
      nacionalidade: ['', Validators.required],
      logradouro: ['', Validators.required],
      bairro: ['', Validators.required],
      cep: ['', Validators.required],
      cidade: ['', Validators.required],
      numero: ['', Validators.required],
      uf: ['', Validators.required],
      complemento: [''],
      senha: ['', [Validators.minLength(6), Validators.nullValidator]],
      confirmeSenha: ['', Validators.nullValidator]
    }, formOptions);
  }
  get f(): any { return this.form.controls; }

  onSubmit(): void {

    if (this.form.invalid) {
      return
    }
    else{
      
    }
  }

  Salvar(){
    this.mensagem = []
    this.sucesso =[]
    this.Isloading = true;
    if(this.form.invalid){
      this.mensagem.push("Erro no formulário, Verifique seus dados")
      this.Isloading = false;
    }
    else{
      this.service.Atualizar(this.usuario).subscribe({
        next: res => {
          this.sucesso.push(res.msg);  
          this.Isloading = false;
        },
        error: error =>{
          this.mensagem.push(error.error);
          this.Isloading = false;
        }
      })
    }
    
  }

  // public resetForm(event: any): void {
  //   event.preventDefault();
  //   this.form.reset();
  // }


GetUser(){
    this.Isloading = true;
    this.service.GetUsuario(this.authenticationService._credentials?.idUsuario).subscribe({
      next: res => { 
        this.usuario = res
        console.log(this.usuario);
        this.usuario.DataNascimento = formatDate(this.usuario.dataNascimento, this.format, this.locale);
        console.log(this.usuario.dataNascimento);
        this.Isloading = false;
        // this.usuario.complemento = "cu";
      },
      error: error => {         
        this.mensagem.push(error.error);
        console.log(error);
        this.Isloading = false;
      }
    });
  }


  BuscarEndereco(){
    this.service.getEndereco(this.usuario.cep)
    .subscribe({
      next: res => {
        console.log(res);
        this.usuario.logradouro = res.logradouro;
        this.usuario.complemento = res.complemento;
        this.usuario.bairro = res.bairro;
        this.usuario.uf = res.uf;
        this.usuario.cidade = res.localidade;
      },
      error: error => {
        console.log(error);
      }
    });
  }

}
