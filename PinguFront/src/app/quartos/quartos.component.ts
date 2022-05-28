
import { formatDate } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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

  @Output() quartoInfo = new EventEmitter();

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
    this.mensagem = []

    this.service.GetQuartos().subscribe(res =>{
      this.quartos = res
    }, error =>{
      this.mensagem.push(error.error)
      console.log(error);
    });
  }

  Reserva(item: any){

    var dados = {
      DataEntrada : this.de,
      DataSaida : this.ate,
      quarto: item
    }

    this.quartoInfo.emit(dados)

  }


  getQuartosFiltro(){
    this.mensagem = []

    var data = {
      DataEntrada: this.de,
      DataSaida: this.ate
    }

    

    this.service.GetQuartosFilter(data).subscribe({
      next: res =>{
        this.quartos = res;
        console.log(res);
      },
      error: error => {
        this.quartos = []
        this.mensagem.push(error.error);
        console.log(error);
      }
    });
  }

}
