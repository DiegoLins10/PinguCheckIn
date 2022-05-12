import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { FooterComponent } from './footer/footer.component';
import { FormsModule } from '@angular/forms';
import { AuthenticationComponent } from './authentication/authentication.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { Interceptor } from './authentication/authentication.Interceptor';
import { CadastroComponent } from './cadastro/cadastro.component';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { HotelReservaComponent } from './hotel-reserva/hotel-reserva.component';
import { NavComponent } from './shared/nav/nav.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    FooterComponent,
    AuthenticationComponent,
    HomeComponent,
    CadastroComponent,
      HotelReservaComponent,NavComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    Interceptor,
    NgxMaskModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
