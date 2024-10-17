# Chapter API

Esta é uma API para gerenciamento de **livros** e **usuários**. O projeto é construído com **ASP.NET Core** e usa **Entity Framework** para comunicação com o banco de dados SQL Server. A API inclui operações CRUD (Create, Read, Update, Delete) para gerenciar informações de livros e usuários, além de implementar autenticação JWT para proteger rotas específicas.

## Funcionalidades

- **CRUD de Livros**: Gerenciamento de informações sobre livros.
- **CRUD de Usuários**: Gerenciamento de usuários com autenticação por e-mail e senha.
- **Autenticação JWT**: As rotas protegidas requerem um token JWT válido para acesso.
- **Política de Cors**: Configuração para permitir acesso ao frontend hospedado em `http://localhost:3000`.

## Estrutura do Projeto

- **Contexts**: Define o contexto do banco de dados, utilizando o Entity Framework Core.
- **Controllers**: Contém as classes que controlam as rotas da API para Livros, Usuários e Login.
- **Interfaces**: Define as interfaces que são implementadas pelos repositórios.
- **Models**: Define as classes de modelo que representam as entidades `Livro` e `Usuario` no banco de dados.
- **Repositories**: Contém as implementações dos repositórios para acesso ao banco de dados.
- **ViewModels**: Modelos usados para receber dados nas requisições, como login de usuário.

## Instalação

### Pré-requisitos

- .NET 6.0 SDK
- SQL Server
- IDE (Visual Studio ou VS Code)

### Passo a passo

1. **Clone o repositório**:
    ```bash
    git clone https://github.com/seu-usuario/seu-repositorio.git
    cd seu-repositorio
    ```

2. **Configuração do banco de dados**:
   Certifique-se de que o SQL Server esteja rodando. O arquivo `ChapterContext.cs` já contém a string de conexão:
   ```csharp
   optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Chapter;Integrated Security=True;TrustServerCertificate=True;");
   ```

   Ajuste conforme necessário.

3. **Execute as migrações**:
    ```bash
    dotnet ef database update
    ```

4. **Inicie a aplicação**:
    ```bash
    dotnet run
    ```

5. A aplicação estará disponível em `https://localhost:5001` e `http://localhost:5000`.

## Autenticação

Para acessar as rotas protegidas, você precisará realizar o login e obter um token JWT.

- **Rota de login**: `POST /api/login`
  - Body:
    ```json
    {
      "email": "usuario@teste.com",
      "senha": "senha"
    }
    ```

- **Uso do token**: Adicione o token no header `Authorization` nas requisições protegidas.
  ```
  Authorization: Bearer {token}
  ```

## Endpoints

### Livros

- `GET /api/livro`: Lista todos os livros (requer autenticação).
- `GET /api/livro/{id}`: Busca livro por ID.
- `POST /api/livro`: Cadastra um novo livro.
- `PUT /api/livro/{id}`: Atualiza um livro existente.
- `DELETE /api/livro/{id}`: Remove um livro.

### Usuários

- `GET /api/usuario`: Lista todos os usuários.
- `GET /api/usuario/{id}`: Busca usuário por ID.
- `POST /api/usuario`: Cadastra um novo usuário.
- `PUT /api/usuario/{id}`: Atualiza um usuário existente.
- `DELETE /api/usuario/{id}`: Remove um usuário.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework principal da aplicação.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **SQL Server**: Banco de dados utilizado.
- **JWT Authentication**: Autenticação baseada em token.
- **Swagger**: Documentação da API.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma _issue_ ou enviar um _pull request_.