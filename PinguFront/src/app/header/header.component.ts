import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  autenticado: any

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.autenticado = this.authenticationService.isAuthenticated();
    console.log(this.autenticado)

  }

}
