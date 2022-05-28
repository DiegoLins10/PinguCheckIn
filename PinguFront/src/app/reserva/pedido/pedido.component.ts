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
  diffDays: any;
  valorTotal: any;

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
    this.valorTotal = this.dados.quarto.valor;

  }

  Pagamento(){

    this.retornaDados.emit(this.dados);
  }


  DifData(){
    var date1 = new Date(this.dados.DataEntrada);
    var date2 = new Date(this.dados.DataSaida);
    var timeDiff = Math.abs(date2.getTime() - date1.getTime());
    this.diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 

    console.log(this.diffDays);
    this.valorTotal = this.dados.quarto.valor * this.diffDays;

  }

}
