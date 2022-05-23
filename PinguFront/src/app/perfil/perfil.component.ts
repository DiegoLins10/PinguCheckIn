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

  nome: any
  format: any = 'yyyy-MM-dd';
  locale: any = 'en-US';
  data: any;

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
      Logradouro: ['', Validators.required],
      cep: ['', Validators.required],
      uf: ['', Validators.required],
      complemento: ['', Validators.required],
      senha: ['', [Validators.minLength(6), Validators.nullValidator]],
      confirmeSenha: ['', Validators.nullValidator]
    }, formOptions);
  }
  get f(): any { return this.form.controls; }

  onSubmit(): void {

    if (this.form.invalid) {
      return;
    }
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.form.reset();
  }


GetUser(){
    this.service.GetUsuario(this.authenticationService._credentials?.idUsuario).subscribe({
      next: res => { 
        this.usuario = res
        console.log(this.usuario);
        this.usuario.DataNascimento = formatDate(this.usuario.dataNascimento, this.format, this.locale);
        console.log(this.usuario.dataNascimento);
        // this.usuario.complemento = "cu";
      },
      error: error => {         
        this.mensagem.push(error.error);
        console.log(error);
      }
    });
  }

}
