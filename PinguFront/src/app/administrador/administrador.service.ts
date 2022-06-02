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


  GetReservas(){
    return this.httpClient
    .get<any>(this.url + `Reserva/GetAdmReservas`)
    .pipe(map((body: any) => body));
  } 


}
