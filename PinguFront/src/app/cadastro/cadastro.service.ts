import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Cadastro } from './cadastro.model';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://pinguapi.azurewebsites.net/';

  CadastrarUsuario(usuario: Cadastro){
    return this.httpClient
    .post<any>(this.url + `Cadastro`, usuario)
    .pipe(map((body: any) => body));
  }
}
