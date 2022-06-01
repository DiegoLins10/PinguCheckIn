import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication/authentication.service';
import { PerfilService } from 'src/app/perfil/perfil.service';
import { QuartosService } from 'src/app/quartos/quartos.service';
import { ReservaService } from '../reserva.service';

@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamento.component.html',
  styleUrls: ['./pagamento.component.css']
})
export class PagamentoComponent implements OnInit {
  autenticado: any;
  usuario: any;
  nome: any; 
  sobrenome: any;
  email: any ;
  endereco: any;
  enderecoOpcional: any;
  pais: any;
  estado: any;
  cep: any;

  checkbox = document.getElementById(
    'subscribe',
  ) as HTMLInputElement

  aceito!: boolean;

  nomeCartao: any;
  numeroCartao: any;
  dataExp: any;
  cvv: any;

  format: any = 'yyyy-MM-dd';
  locale: any = 'en-US';
  data: any;
  mensagem: any;
  estados: any;
  sucesso: any;
  Isloading: any

  createForm! :FormGroup;

  constructor(private fb: FormBuilder, private authenticationService: AuthenticationService, private router: Router,
    private service: QuartosService, private reservaService: ReservaService, private perfilService: PerfilService) { }

  @Input() dados: any;
  @Output() retornaDados = new EventEmitter();
  @Output() volta = new EventEmitter();

  ngOnInit(): void {
    this.aceito = false;
    this.sucesso = false;
    this.autenticado = this.authenticationService.isAuthenticated();
    if (this.autenticado) {
      this.router.navigate(['/reserva'])
    } else {
      this.router.navigate([''])
    }
    this.GetEstados(); 
    this.Validar();
  }


 Validar(){
  this.createForm = this.fb.group({
    nome: ['', Validators.required],
    sobrenome: ['', Validators.required],
    email: ["",Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")],
    endereco: ['', Validators.required],
    pais: ['', Validators.required],
    estado: ['', Validators.required],
    cep: ['', Validators.required],
    nomeCartao: ['', Validators.required],
    numeroCartao: ['', Validators.required],
    dataExp: ['', Validators.required],
    cvv: ['', Validators.required],
    aceito: [false, Validators.required],

})
 } 



  BuscarEndereco(){
    this.perfilService.getEndereco(this.usuario.cep)
    .subscribe({
      next: res => {
        console.log(res);
        this.usuario.logradouro = res.logradouro;
        this.usuario.complemento = res.complemento;
        this.usuario.bairro = res.bairro;
        this.usuario.uf = res.uf;
        this.usuario.cidade = res.localidade;
      },
      error: error => {
        console.log(error);
      }
    });
  }

  ValidarPagamento(){
    this.Isloading = true;
    this.mensagem = [];
    if(this.createForm.invalid){
      this.Isloading = false;
      return 
    }
    else{

      var enviar = {
       DataEntrada: this.dados.DataEntrada,
       DataSaida: this.dados.DataSaida,
       idQuarto: this.dados.quarto.idQuarto,
       valorTotal: this.dados.valorTotal,
       nomeCartao : this.nomeCartao,
       numeroCartao : this.numeroCartao,
       dataExp : this.dataExp,
       cvv : this.cvv,
       aceito: this.aceito,
       nome: this.nome,
       sobrenome: this.sobrenome,
       email: this.email,
       endereco: this.endereco,
       endereco2: this.enderecoOpcional,
       pais: this.pais,
       estado: this.estado,
       cep: this.cep,
       tipoPagamento: 1,
       IdUsuario: this.authenticationService._credentials?.idUsuario,

      }

      this.reservaService.Salvar(enviar).subscribe({
        next: res => {
          this.mensagem.push(res.msg);
          this.retornaDados.emit();
          this.Isloading = false;
        },
        error: error => {
          this.mensagem.push(error.message);
          this.Isloading = false;
        }
      })    
      
    }

   
  }

  GetEstados(){
    this.reservaService.GetEstados().subscribe({
      next: res => {
        this.estados = res;
      },
      error: error => {
        console.log(error);
      }
    })
  }

  voltarPedido(){
    this.volta.emit();
  }

}
