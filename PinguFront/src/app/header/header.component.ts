import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  autenticado: any
  nome: any;
  funcionario: any
  @Input() home: any
  @Input() quartos: any
  @Input() historico: any
  @Input() reservas: any

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    console.log(this.autenticado)
    this.nome = this.authenticationService.credentials?.nome
    console.log(this.nome)
    this.funcionario = this.authenticationService._credentials?.funcionario;
  }

  logout(){
    this.authenticationService.logout();
    window.location.reload();
  }
}
