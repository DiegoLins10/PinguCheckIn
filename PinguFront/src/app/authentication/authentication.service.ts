import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, of } from "rxjs";
import { map, observable } from "rxjs";

export interface Credentials {
  
    user: string;
    senha: string;
    token: string;
  }

const credentialsKey = 'credentials';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService{

    _credentials: Credentials | null;
     url = 'https://localhost:44354/';

    constructor(private httpClient: HttpClient) {
        const savedCredentials = sessionStorage.getItem(credentialsKey) || localStorage.getItem(credentialsKey);
        if (savedCredentials) {
          this._credentials = JSON.parse(savedCredentials);
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
    return this.httpClient.post<any>(this.url + 'login', credenciais)
    .pipe(
        map(body => {
          const cred = {
            user: body.userName,
            senha: body.senha,
            token: body.token
          }
        this.setCredentials(cred, false);
         return body
        }),
        catchError(() =>  of('Error acessar metodo da Api'))
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
}
}