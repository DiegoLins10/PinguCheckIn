import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private httpClient: HttpClient) { }

  url = 'https://localhost:44354/';

  GetUsuario(idUsuario: any){
    return this.httpClient
    .get<any>(this.url + `api/usuarios/${idUsuario}`)
    .pipe(map((body: any) => body));
  }







  
}
