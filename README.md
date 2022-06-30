## Projeto Pingu CheckIn- Sistema de Reservas
### Centro Paula Souza - Fatec Ferraz - Curso de Análise e Desenvolvimento de Sistemas
### Disciplina – Laboratório de Engenharia de Software – Prof. PATRICIA SARNO MENDES

- Diego Fernandes Lins
- Vinicius Santos
- Nathan

### Objetivo
Este projeto tem como objetivo implementar uma aplicação de reservas de hotel onde um usuario conseguirá se cadastrar no hotel e reservar um quarto da sua propria casa.
### Processo de Desenvolvimento
O processo de desenvolvimento segue uma adaptação do Scrum. Cada interação tem a duração de 4 aulas. Ao final da interação o
código é avaliado pelo time junto com o professor na atividade de revisão da sprint. Em seguida a reunião de restrospectiva do sprint é
realizada pelo grupo e uma ata é publicada no Teams.
###Tecnologias
- ASP NET CORE
- Angular
- SQL Server
!()
### Backlog do produto
- Requisito 1: Cadastrar Usuario
O sistema deve permitir o cadastro de novos usuarios recebendo seus dados (nome, CPF, data de
nascimento, etc...)
- Requisitos 2: Login do Usuário
Permitir que um usuário cadastrado consiga utilizar o sistema utilizando suas credencias já cadastradas
- Requisitos 3: Visualizar Quartos disponíveis
Permitir que um cliente autenticado no sistema consiga visualizar os quartos disponibilizados pelo hotel e
suas informações como disponibilidade de horários, valores, etc...

- Requisitos 4: Efetuar a reserva
Permitir que um usuário-cliente autenticado no sistema possa escolher um quarto de sua preferencia onde
enha disponibilidade de horário, efetuando assim a reserva caso todos os critérios sejam atendidos ele
receberá
- Requisitos 5: Permitir o cancelamento reserva
Permitir que um usuário-cliente autenticado no sistema possa cancelar sua reserva já feita.

### 1. Planejamento da Sprint
Durante a fase de planejamento as funcionalidades nesta interação são selecionadas do backlog do produto.
### 2. Estratégia de desenvolvimento.
Na primeira interação a meta é criar um baseline (base de sustentação) da arquitetura do sistema a fim de definir como o código será
organizado nas próximas interações. A arquitetura se desenvolve a partir de um exame dos requisitos mais significativos (aqueles que
têm grande impacto na arquitetura do sistema) e de uma avaliação de risco. A estabilidade da arquitetura é avaliada através de um ou
mais protótipos de arquitetura. O projeto do “Sistema de Reservas” deve se utilizar de uma arquitetura que
permita flexibilidade na configuração do sistema de persistência (mudança do sistema de gerenciamento de banco de dados) e
manutenções na interface de usuário com poucos efeitos colaterais. A arquitetura selecionada para atender esta necessidade é a
arquitetura MVC.
A estratégia de construção e integração do software será ascendente na hierarquia de controle, ou seja, da base de dados (backend) para
a interface de interação homem máquina (frontend).
## Telas sistema
### Reservar quarto
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/imagem.png)

### Quartos
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/imagem2.png)

### Confirmação reserva
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/imagem3.png)

### Historico de reservas
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/imagem4.png)

### Login
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/login.png)

### Perfil editar
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/Perfil.png)

### Diagrama de classes
![](https://github.com/DiegoLins10/PinguCheckIn/blob/master/Diagrama%20Pingu.png)

