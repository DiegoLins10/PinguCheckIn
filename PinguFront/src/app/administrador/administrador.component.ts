import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';
import { AdministradorService } from './administrador.service';

@Component({
  selector: 'app-administrador',
  templateUrl: './administrador.component.html',
  styleUrls: ['./administrador.component.css']
})
export class AdministradorComponent implements OnInit {
  autenticado: any;
  reservasNomeFiltro: any = "";
  mensagem: any;
  Isloading: any;

  format: any = 'dd-MM-yyyy';
  myDate: any = new Date();
  locale: any = 'en-US';
  reservasIdFiltro: any = "";
  reservas: any;
  reservaSemFiltro: any;

  periodo: any;
  status: any;

  constructor(private authenticationService: AuthenticationService, private router: Router, private service: AdministradorService) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    if(this.autenticado){
      this.router.navigate(['/adm/reservas'])
    }else{
      this.router.navigate([''])
    }
    this.GetReservas();
    this.periodo = "1";
    this.status = "N";
  }

  GetReservas(){
    this.mensagem = [] 
    this.Isloading = true;
    this.service.GetReservas().pipe(
      finalize(() =>{
        this.reservaSemFiltro.forEach((element: any) => {
          element.entrada = formatDate(element.entrada, this.format, this.locale);
          element.saida = formatDate(element.saida, this.format, this.locale);
          element.dataReserva = formatDate(element.dataReserva, this.format, this.locale);
        });
        this.reservas.forEach((element: any) => {
          element.entrada = formatDate(element.entrada, this.format, this.locale);
          element.saida = formatDate(element.saida, this.format, this.locale);
          element.dataReserva = formatDate(element.dataReserva, this.format, this.locale);
        });
      })
    )
    .subscribe({
      next: res => {
        this.reservas = res;
        this.reservaSemFiltro = res;
        console.log(res)
        this.Isloading = false;
      },
      error: error => {
        console.log(error.error);
        if(error.error.message){
          this.mensagem.push(error.error.message);
          this.Isloading = false;
        }
        else{
          this.mensagem.push(error.message);
          this.Isloading = false;
        }
        console.log(error)
        this.Isloading = false;
      }
    })
  }

  
  FilterFn(){
    var reservasNomeFiltro = this.reservasNomeFiltro;
    var reservasIdFiltro = this.reservasIdFiltro;

    this.reservas = this.reservaSemFiltro.filter(function (el:any){
        return el.idReserva.toString().toLowerCase().includes(
          reservasIdFiltro.toString().trim().toLowerCase()
        )&&
        el.nome.toString().toLowerCase().includes(
          reservasNomeFiltro.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop:any,asc:any){
    this.reservas = this.reservaSemFiltro.sort(function(a:any,b:any){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
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

  Finalizar(idReserva: any){
    this.service.GetFinalizar(idReserva).subscribe({
      next: res =>{
        console.log(res);
        window.location.reload();
      },
      error: error =>{
        console.log(error);
      }
    })
  }
  
  baixar() {
    this.Isloading = true;

   

    // efetua o download do arquivo
    this.service
      .GerarRelatorio(this.status, this.periodo)
      .pipe(
        finalize(() => {
          this.Isloading = false;
        })
      )
      .subscribe((res : any) => {
        var file = new Blob([res], {
          type: res.type
        });

        //IE
        const nav = window.navigator as any;
        if (window.navigator && nav.msSaveOrOpenBlob) {
          nav.msSaveOrOpenBlob(file);
          return;
        }

        var blob = window.URL.createObjectURL(file);

        // Cria um elemento âncora e já clica
        var link = document.createElement('a');
        link.href = blob;
        link.download = `relatorio_pingu_${formatDate(this.myDate, this.format, this.locale)}.csv`
        link.click();

        window.URL.revokeObjectURL(blob);
        link.remove();
      });
  }
  

}
