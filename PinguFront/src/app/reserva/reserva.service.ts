import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://pinguapi.azurewebsites.net/';

  Disponivel(data: any){
    return this.httpClient
    .post<any>(this.url + `Quartos/QuartoDisponivel`, data)
    .pipe(map((body: any) => body));
  } 

  Salvar(data: any){
    return this.httpClient
    .post<any>(this.url + `Reserva/salvar`, data)
    .pipe(map((body: any) => body));
  } 

  GetEstados(){
    return this.httpClient
    .get<any>(this.url + `Reserva/estados`)
    .pipe(map((body: any) => body));
  } 

}
