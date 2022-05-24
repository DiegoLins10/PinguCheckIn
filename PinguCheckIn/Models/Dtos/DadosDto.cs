﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Models.Dtos
{
    public class DadosDto
    {
        public char? Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCliente { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Funcionario { get; set; }
        public int? Reservas { get; set; }
        public int? ReservasFinalizadas { get; set; }
    }
}
