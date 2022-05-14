import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Quarto } from './quarto.model';

@Injectable({
  providedIn: 'root'
})
export class QuartosService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://localhost:44354/';

  GetQuartos(){
    return this.httpClient
    .get<any>(this.url + `Quartos`)
    .pipe(map((body: any) => body));
  }


  
}
