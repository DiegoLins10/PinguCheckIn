import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reserva',
  templateUrl: './reserva.component.html',
  styleUrls: ['./reserva.component.css']
})
export class ReservaComponent implements OnInit {
  pagina: any;
  dadosReserva: any

  constructor() { }

  ngOnInit(): void {
    this.pagina = 'quarto'
  }

   AtualizaDadosPedido(dados: any){
    this.dadosReserva = dados;
    this.pagina = 'pagamento';
   }

   voltarPedidos(){
     this.pagina = 'pedido'
   }

  getDados(dados: any){
    this.dadosReserva = dados;
    console.log(dados);
    this.pagina = 'pedido';
  }

  Finish(){
    this.pagina = 'sucesso';
  }
}
