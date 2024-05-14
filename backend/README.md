## O que é o TaskManagement?
TaskManagement é um aplicativo para gerenciamento de tarefas.

## Objetivo
Esse projeto tem por objetivo passar conhecimentos e técnicas de desenvolvimento para desenvolvedores C# .NET

## Tecnologias utilizadas

- C# .NET
- Banco de dados Postgres
- Docker
- DDD.
- Arquitetura Limpa
- Migrations
- Testes de Unidade
- Testes de Integração.
  
## Como rodar o projeto?

>**Note:** Será preciso o Docker e o .NET 8 instalado na sua máquina.

Abra o terminal e rode os comandos abaixo.

1 - Na raiz do projeto execute o comando `docker-compose up` para subir a infraestrutura;
2 - Na pasta `src.Infrastructure.TaskManagement.PostgreSql` excute o comando `dotnet ef database update para gerar o banco de dados;
3 - Na raiz do projeto execute o comando `dotnet test` para testar se o projeto esta funcionando sem quebras. 

Basta rodar o projeto e brincar com as APIs.

>**Note:** Lembre - se isso é so um meio de como fazer, não significa que estará certo pra o seu contexto.