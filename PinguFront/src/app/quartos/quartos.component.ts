
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';
import { Quarto } from './quarto.model';
import { QuartosService } from './quartos.service';

@Component({
  selector: 'app-quartos',
  templateUrl: './quartos.component.html',
  styleUrls: ['./quartos.component.css']
})
export class QuartosComponent implements OnInit {

  autenticado!: boolean;
  quartos: any;
  mensagem: any;
  format: any = 'yyyy-MM-dd';
  myDate: any = new Date();
  locale: any = 'en-US';
  diaHoje: any 
  de: any
  ate: any

  constructor(private authenticationService: AuthenticationService, private router: Router, private service: QuartosService) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    this.getQuartos();
    if(this.autenticado){
      this.router.navigate(['/quartos'])
    }else{
      this.router.navigate([''])
    }

    this.diaHoje = formatDate(this.myDate, this.format, this.locale);
    console.log(this.diaHoje);
    console.log(this.de);
    
  }


  getQuartos(){
    this.service.GetQuartos().subscribe(res =>{
      this.quartos = res
    }, error =>{
      this.mensagem = error;
      console.log(error);
    });
  }

}
