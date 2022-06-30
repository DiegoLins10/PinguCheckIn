import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://localhost:44354/';
  urlViaCep = 'https://viacep.com.br/ws/'

  GetUsuario(idUsuario: any){
    return this.httpClient
    .get<any>(this.url + `api/usuarios/${idUsuario}`)
    .pipe(map((body: any) => body));
  }

  getEndereco(cep: any){
    return this.httpClient
    .get<any>(this.urlViaCep + `${cep}/json/`)
    .pipe(map((body: any) => body));
  }

  Atualizar(dados: any){
    return this.httpClient
    .post<any>(this.url + `api/usuarios/atualizar`, dados)
    .pipe(map((body: any) => body));
  }






  
}
