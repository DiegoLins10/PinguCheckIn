import { formatDate } from '@angular/common';
import { ThisReceiver } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication/authentication.service';
import { QuartosService } from 'src/app/quartos/quartos.service';
import { ReservaService } from '../reserva.service';

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
  mensagem: any;
  disponivel: any;
  mensagemErro: any;
  Isloading: any

  constructor(private authenticationService: AuthenticationService, private router: Router,
    private service: QuartosService, private reservaService: ReservaService) { }

  @Input() dados: any;
  @Output() retornaDados = new EventEmitter();

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    if (this.autenticado) {
      this.router.navigate(['/reserva'])
    } else {
      this.router.navigate([''])
    }
    this.diaHoje = formatDate(this.myDate, this.format, this.locale);
    this.diaHojeFormatado = formatDate(this.myDate, 'dd-MM-yy', this.locale);
    this.DifData();
  }

  Pagamento() {
    this.Isloading = true;
    if((this.mensagemErro && this.mensagemErro.length > 0) || (this.mensagem && this.mensagem.length > 0)){
      this.mensagemErro.push("Não foi possivel prosseguir, existem erros")
      this.Isloading = false;
    }
    else{
      this.dados.valorTotal = this.valorTotal;
      this.retornaDados.emit(this.dados);
      this.Isloading = false;
    }

  }


  DifData() {
    this.Isloading = true;
    this.mensagem = []
    this.mensagemErro = []

    if (this.dados.DataEntrada !== undefined && this.dados.DataSaida !== undefined) {

      if(this.dados.DataEntrada < this.diaHoje || this.dados.DataEntrada > this.dados.DataSaida){
        this.mensagemErro.push("Data invalida")
      }

      var data = {
        DataEntrada: this.dados.DataEntrada,
        DataSaida: this.dados.DataSaida,
        idQuarto: this.dados.quarto.idQuarto
      }

      this.reservaService.Disponivel(data).subscribe({
        next: res => {
          this.disponivel = res.disponivel;
          console.log(res);
          if(this.disponivel == true){
            var date1 = new Date(this.dados.DataEntrada);
            var date2 = new Date(this.dados.DataSaida);
            var timeDiff = Math.abs(date2.getTime() - date1.getTime());
            this.diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    
            console.log(this.diffDays);
            this.valorTotal = this.dados.quarto.valor + (this.dados.quarto.valor * this.diffDays);
            this.Isloading = false;
          }
          else if(this.disponivel == false){
            this.valorTotal = this.dados.quarto.valor;
            this.mensagemErro.push("Esse quarto não está disponivel na data escolhida.")
            this.Isloading = false;
          } 
        },
        error: error =>{
          console.log(error);
          //this.mensagemErro.push(error.message)
          this.Isloading = false;
        }
      });       
    }
    else {
      this.valorTotal = this.dados.quarto.valor;
      this.mensagem.push("Escolha uma data para prosseguir.")
      this.Isloading = false;
    }
  }

}
