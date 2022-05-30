import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { FooterComponent } from './footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationComponent } from './authentication/authentication.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { Interceptor } from './authentication/authentication.Interceptor';
import { CadastroComponent } from './cadastro/cadastro.component';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { QuartosComponent } from './quartos/quartos.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PerfilComponent } from './perfil/perfil.component';
import { ReservaComponent } from './reserva/reserva.component';
import { PedidoComponent } from './reserva/pedido/pedido.component';
import { PagamentoComponent } from './reserva/pagamento/pagamento.component';
import { PerfilService } from './perfil/perfil.service';
import { SucessoComponent } from './reserva/sucesso/sucesso.component';
import { HistoricoComponent } from './historico/historico.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    FooterComponent,
    AuthenticationComponent,
    HomeComponent,
    CadastroComponent,
    QuartosComponent,
    PerfilComponent,
    ReservaComponent,
    PedidoComponent,
    PagamentoComponent,
    SucessoComponent,
    HistoricoComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    Interceptor,
    ReactiveFormsModule.withConfig({warnOnNgModelWithFormControl: 'never'}),
    FormsModule,
    NgxMaskModule.forRoot(),
    
  ],
  providers: [PerfilService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
