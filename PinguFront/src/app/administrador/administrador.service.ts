import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdministradorService {

  constructor(private httpClient: HttpClient) { 

  }

  url = 'https://pinguapi.azurewebsites.net/';
  //  url = 'https://localhost:44354/';


  GetReservas(){
    return this.httpClient
    .get<any>(this.url + `Reserva/GetAdmReservas`)
    .pipe(map((body: any) => body));
  } 

  GetCancelar(idReserva: any){
    return this.httpClient
    .get<any>(this.url + `Historico/GetCancelar?idReserva=${idReserva}`)
    .pipe(map((body: any) => body));
  }

  GetFinalizar(idReserva: any){
    return this.httpClient
    .get<any>(this.url + `Historico/GetFinalizar?idReserva=${idReserva}`)
    .pipe(map((body: any) => body));
  }

  GerarRelatorio(status: any, periodo: any){
    return this.httpClient
    .get<any>(this.url + `Reserva/baixar?status=${status}&periodo=${periodo}`, {
      responseType: 'blob' as 'json'
    })
    .pipe(map((body: any) => body));
  }
}
