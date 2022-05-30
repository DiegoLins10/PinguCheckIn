import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Quarto } from './quarto.model';

@Injectable({
  providedIn: 'root'
})
export class QuartosService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://pinguapi.azurewebsites.net/';

  GetQuartos(){
    return this.httpClient
    .get<any>(this.url + `Quartos`)
    .pipe(map((body: any) => body));
  }

  GetQuartosFilter(data: any){
    return this.httpClient
    .post<any>(this.url + `Quartos/GetQuartosFiltro`, data)
    .pipe(map((body: any) => body));
  } 
}
