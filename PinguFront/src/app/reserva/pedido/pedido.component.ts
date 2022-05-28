import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication/authentication.service';
import { QuartosService } from 'src/app/quartos/quartos.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {
  autenticado: any;
  quartoDados: any;
  format: any = 'yyyy-MM-dd';
  myDate: any = new Date();
  locale: any = 'en-US';
  diaHoje: any;
  diaHojeFormatado: any

  constructor(private authenticationService: AuthenticationService, private router: Router, 
    private service: QuartosService) { }

    @Input() dados: any;
    @Output() retornaDados = new EventEmitter();

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    if(this.autenticado){
      this.router.navigate(['/reserva'])
    }else{
      this.router.navigate([''])
    }
    this.diaHoje = formatDate(this.myDate, this.format, this.locale);
    this.diaHojeFormatado = formatDate(this.myDate, 'dd-MM-yy', this.locale);
  }

  Pagamento(){

    this.retornaDados.emit(this.dados);
  }



}
