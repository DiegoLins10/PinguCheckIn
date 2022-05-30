import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';
import { QuartosService } from '../quartos/quartos.service';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent implements OnInit {
  autenticado: any;
  historico: any;

  format: any = 'dd-MM-yyyy';
  myDate: any = new Date();
  locale: any = 'en-US';
  mensagem: any;

  constructor(private authenticationService: AuthenticationService, private router: Router, private service: QuartosService) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    if(this.autenticado){
      this.router.navigate(['/historico'])
    }else{
      this.router.navigate([''])
    }
    this.GetHistorico();
  }


  GetHistorico(){
    this.mensagem = []
    this.service.GetHistorico(this.authenticationService._credentials?.idUsuario).pipe(
      finalize(() =>{
        this.historico.forEach((element: any) => {
          element.dataEntrada = formatDate(element.dataEntrada, this.format, this.locale);
          element.dataSaida = formatDate(element.dataSaida, this.format, this.locale);
        });
      })
    )
    .subscribe({
      next: res => {
        this.historico = res; 
        console.log(this.historico);            
      },
      error: error =>{
        console.log(error);
        this.mensagem.push(error.error);
      }
    })
  }

  Cancelar(idReserva: any){
    this.service.GetCancelar(idReserva).subscribe({
      next: res =>{
        console.log(res);
        window.location.reload();
      },
      error: error =>{
        console.log(error);
      }
    })
  }

}
