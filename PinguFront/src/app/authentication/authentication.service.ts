import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of } from "rxjs";
import { map, observable } from "rxjs";
import { Router } from "@angular/router";

export interface Credentials {
  
    email: string;
    senha: string;
    token: string;
    nome: string;
    sobrenome: string;
    idUsuario: any;
    funcionario: any;
  }

const credentialsKey = 'credentials';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService{

    _credentials: Credentials | null;
     url = 'https://localhost:44354/';

    constructor(private httpClient: HttpClient, private router: Router) {
        const savedCredentials = sessionStorage.getItem(credentialsKey) || localStorage.getItem(credentialsKey);
        if (savedCredentials) {
          this._credentials = JSON.parse(savedCredentials);
        }
        // if(!this.isAuthenticated()){
        //   this.redirectTo('/');
        //   location.reload();
        // }
        if(this.isAuthenticated()){
        this.httpClient.get<any>(this.url + 'api/Usuarios', {observe: 'response'}).
        pipe(map(body => body))
        .subscribe(res => {
          
          },
          error =>{
            if(error.status == 401){
              this.logout();  
              }
           });
          }
          
      }

      /**
   * Authenticates the user.
   * @param context The login parameters.
   * @return The user credentials.
   */
  /*login(context: LoginContext): Observable<Credentials> {

  }
*/

// login(credenciais: Credentials){
//     return this.httpClient.post<any>('/login', credenciais)
//     .pipe(
//         map(data => {
//             if(data && data.token){
//                 const creden ={
   
//                 }
//             }
//         }));
// }

login(credenciais: any){
    return this.httpClient.post<any>(this.url + 'login', credenciais, {observe: 'response'})
    .pipe(
        map(body => {
          const cred = {
            email: body.body.user.email,
            senha: body.body.user.senha,
            nome: body.body.user.nome,
            sobrenome: body.body.user.sobrenome,
            token: body.body.token,
            idUsuario: body.body.user.idUsuario,
            funcionario: body.body.user.funcionario,
          }
        this.setCredentials(cred, false)
        return body;
        })
      );
}

/**
   * Sets the user credentials.
   * The credentials may be persisted across sessions by setting the `remember` parameter to true.
   * Otherwise, the credentials are only persisted for the current session.
   * @param credentials The user credentials.
   * @param remember True to remember credentials across sessions.
   */
private setCredentials(credentials?: Credentials, remember?: boolean) {
 this.clearCredentials();
 this._credentials = credentials || null;
 if (credentials) {
   const storage = remember ? localStorage : sessionStorage;
   storage.setItem(credentialsKey, JSON.stringify(credentials));
 }
}

private clearCredentials() {
 this._credentials =  null;
 sessionStorage.removeItem(credentialsKey);
 localStorage.removeItem(credentialsKey);
 this.redirectTo('/')
}


  /**
   * Logs out the user and clear credentials.
   * @return True if the user was logged out successfully.
   */
   logout(): Observable<boolean> {
    // Customize credentials invalidation here
    this.clearCredentials();
  
    return of(true);
  }

  /**
   * Checks is the user is authenticated.
   * @return True if the user is authenticated.
   */
  isAuthenticated(): boolean {
    return !!this.credentials;
  }
 
  /**
   * Gets the user credentials.
   * @return The user credentials or null if the user is not authenticated.
   */
  get credentials(): Credentials | null {
    return this._credentials;
  }

  /**
   * Sets the user credentials.
   * The credentials may be persisted across sessions by setting the `remember` parameter to true.
   * Otherwise, the credentials are only persisted for the current session.
   * @param credentials The user credentials.
   * @param remember True to remember credentials across sessions.*/


   redirectTo(uri:string){
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>
    this.router.navigate([uri]));
 }

 teste(){
   return this.httpClient.get<any>(this.url + 'api/Usuarios', {observe: 'response'})
   .pipe(map(body => body))
 }
}