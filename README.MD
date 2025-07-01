# Catálogo API 📖

![Linguagem](https://img.shields.io/badge/C%23-12.0-239120?logo=c-sharp&logoColor=white)
![Framework](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/status-conclu%C3%ADdo-brightgreen)
![Licença](https://img.shields.io/badge/licen%C3%A7a-MIT-blue)

## 📝 Sobre o Projeto

**Catálogo API** é uma API RESTful desenvolvida em C# com .NET 9 para gerenciar um catálogo de livros. Este projeto demonstra os conceitos fundamentais de uma aplicação backend moderna, incluindo operações CRUD (Create, Read, Update, Delete), persistência de dados com Entity Framework Core e uma arquitetura baseada em controllers.

Este projeto foi criado como uma peça de portfólio para demonstrar habilidades em desenvolvimento backend com o ecossistema .NET.

---

## ✨ Funcionalidades

A API permite realizar as seguintes operações:

- ✔️ Listar todos os livros cadastrados.
- ✔️ Obter um livro específico pelo seu ID.
- ✔️ Adicionar um novo livro ao catálogo.
- ✔️ Atualizar os dados de um livro existente.
- ✔️ Deletar um livro do catálogo.

---

## 🛠️ Tecnologias Utilizadas

As seguintes ferramentas e tecnologias foram usadas na construção do projeto:

- **C#**: Linguagem de programação principal.
- **.NET 9**: Framework de desenvolvimento.
- **ASP.NET Core Web API**: Para a construção da API RESTful.
- **Entity Framework Core 9**: ORM para a comunicação com o banco de dados.
- **SQLite**: Banco de dados local para desenvolvimento e testes.
- **Swashbuckle (Swagger)**: Para documentação e testes interativos dos endpoints.

---

## 🚀 Como Executar o Projeto

Para executar este projeto localmente, siga os passos abaixo.

### Pré-requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/pt-br/download) ou superior.
- Um editor de código de sua preferência (ex: VS Code, Visual Studio 2022).
- Git instalado na sua máquina.

### Passos

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/CatalogoApi.git](https://github.com/seu-usuario/CatalogoApi.git)
    ```

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd CatalogoApi
    ```

3.  **Restaure as dependências do projeto:**
    ```bash
    dotnet restore
    ```

4.  **Aplique as migrations para criar o banco de dados:**
    Este passo é crucial para criar o arquivo do banco de dados SQLite (`catalogo.db`) com a tabela de livros.
    ```bash
    dotnet ef database update
    ```

5.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

6.  **Acesse a documentação:**
    Após executar, a API estará rodando. Abra seu navegador e acesse a URL da documentação do Swagger para testar os endpoints:
    `https://localhost:XXXX/swagger` (substitua `XXXX` pela porta informada no seu terminal, ex: 7020).

---

## Endpoints da API

Abaixo estão os endpoints disponíveis na API:

| Método HTTP | Endpoint           | Descrição                                 |
| ----------- | ------------------ | ----------------------------------------- |
| `GET`       | `/api/livros`      | Retorna a lista de todos os livros.       |
| `GET`       | `/api/livros/{id}` | Retorna um livro específico pelo seu ID.  |
| `POST`      | `/api/livros`      | Adiciona um novo livro ao catálogo.       |
| `PUT`       | `/api/livros/{id}` | Atualiza os dados de um livro existente.  |
| `DELETE`    | `/api/livros/{id}` | Remove um livro do catálogo.              |

---

## 👨‍💻 Autor

Desenvolvido por **Johnathan M. Andrade**.

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/johnathan-martins-andrade-8250a3222/)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/johnathanfox)

---

## 📜 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.