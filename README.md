# 🚗 Plataforma de Carros

Bem-vindo(a) à **Plataforma de Carros**, um projeto de demonstração e estudo para gestão de um inventário de veículos. Esta aplicação é desenvolvida em **C#** utilizando o framework **.NET Core** e o **Entity Framework Core (EF Core)** para manipulação de dados.

## 🌟 Visão Geral do Projeto

O objetivo principal desta aplicação é fornecer um *backend* robusto para:

* **Registar:** Novos carros no inventário.
* **Consultar:** A lista completa de carros ou carros específicos.
* **Atualizar:** Informações de um veículo existente.
* **Excluir:** Carros do sistema.

### 🛠️ Tecnologias Utilizadas

| Tecnologia | Descrição |
| :--- | :--- |
| **C# / .NET Core** | Linguagem e Framework principal para o desenvolvimento da aplicação. |
| **Entity Framework Core (EF Core)** | ORM (Object-Relational Mapper) para abstrair a comunicação com a base de dados. |
| **SQLite** | Base de dados leve e baseada em ficheiros, ideal para desenvolvimento e testes. |
| **Git & GitHub** | Sistema de controlo de versões. |

## 🏗️ Estrutura da Solução

O projeto segue um padrão de organização limpo, separando responsabilidades em *namespaces*:

* **`Models/`**: Contém as **Classes de Entidade** (ex: `Carro`), que mapeiam diretamente para as tabelas da base de dados.
* **`Data/`**: Contém o **Contexto da Base de Dados** (`PlataformaContext`), que herda de `DbContext` e gere a conexão e as operações de dados.
* **`Migrations/`**: Pasta gerada pelo EF Core, que contém o histórico de alterações no esquema da base de dados.

## 🚀 Como Executar o Projeto Localmente

Siga estes passos para configurar e executar a aplicação no seu ambiente.

### Pré-requisitos

Certifique-se de que tem o seguinte instalado:

* [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior recomendada).
* Uma IDE (como [Visual Studio](https://visualstudio.microsoft.com/) ou [JetBrains Rider](https://www.jetbrains.com/rider/)).

### 1. Clonar o Repositório

Abra o seu terminal e clone o projeto:

```bash
git clone [https://github.com/RafaelPIgatto2008/PlataformaDeCarros.git](https://github.com/RafaelPIgatto2008/PlataformaDeCarros.git)
cd PlataformaDeCarros
