<h1 align="center">🚀 Sistema de Tarefas API</h1>

<p align="center">
  API desenvolvida com <b>ASP.NET Core Web API</b> utilizando <b>C#</b>, com autenticação <b>JWT</b>, <b>Entity Framework Core</b> e integração com API dos Correios.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-ASP.NET%20Core-blue" />
  <img src="https://img.shields.io/badge/C%23-Backend-green" />
  <img src="https://img.shields.io/badge/Database-SQL%20Server-red" />
  <img src="https://img.shields.io/badge/Auth-JWT-orange" />
  <img src="https://img.shields.io/badge/ORM-Entity%20Framework-purple" />
</p>

---

## 🧠 Sobre o Projeto

Esta API foi desenvolvida com foco em boas práticas de arquitetura, segurança e organização de código.

### ✨ Funcionalidades

```bash
✔️ Autenticação com JWT
✔️ Cadastro e login de usuários
✔️ CRUD de tarefas
✔️ Relacionamento entre usuários e tarefas
✔️ Integração com API dos Correios (consulta de CEP)
✔️ Persistência com SQL Server
```
---

🛠️ Tecnologias e Ferramentas
<p align="center"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="50"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="50"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain.svg" width="50"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" width="50"/> </p>


---

## 📂 Estrutura do Projeto

```bash
📁 Controllers
📁 Models
📁 Repositories
📁 Data
📁 Migrations
📁 Services
```
🔐 Autenticação JWT

A API utiliza autenticação baseada em Token JWT.

📌 Fluxo:
1. Usuário faz login
2. API gera um token JWT
3. Cliente envia o token no header

   📌 Header:
Authorization: Bearer SEU_TOKEN_AQUI


🗄️ Banco de Dados

Utilizado SQL Server com abordagem Code First.

📌 Entidades:
```bash
Usuario
- Id
- Nome
- Email
- Senha

Tarefa
- Id
- Titulo
- Descricao
- Status
- UsuarioId
```

⚙️ Migrations (Entity Framework)
➕ Criar migration:
```bash
Add-Migration Inicial
```
🚀 Atualizar banco:
```bash
Update-Database
```
📦 Integração com API dos Correios

Consulta de endereço via CEP:

GET /api/endereco/{cep}

▶️ Como Rodar o Projeto
```bash
# Clone o repositório
git clone https://github.com/seu-usuario/seu-repositorio.git

# Acesse a pasta
cd seu-repositorio

# Abra no Visual Studio 2022
# Configure o appsettings.json com sua connection string

# Execute as migrations
Update-Database

# Rode o projeto
dotnet run
```

🧪 Testando a API
# Swagger (recomendado)
https://localhost:PORTA/swagger

# Ou utilize:
Postman
Insomnia

<p align="center"> 
👨‍💻 Autor
<b>Ruan Luz</b> </p> <p align="center"> <a href="https://github.com/seu-usuario">GitHub</a> • <a href="#">LinkedIn</a> 
</p>

<p align="center"> 
⭐ Se curtiu o projeto
Deixa uma estrela ⭐ no repositório!</p>


<p align="center"> 🔥 Desenvolvido com foco em evolução constante e prática real de mercado 🔥 </p> 
