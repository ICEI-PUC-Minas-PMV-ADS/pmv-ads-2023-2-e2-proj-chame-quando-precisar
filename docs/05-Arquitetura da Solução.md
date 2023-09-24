# Arquitetura da Solução

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Classes”.

> - [Diagramas de Classes - Documentação da IBM](https://www.ibm.com/docs/pt-br/rational-soft-arch/9.6.1?topic=diagrams-class)
> - [O que é um diagrama de classe UML? | Lucidchart](https://www.lucidchart.com/pages/pt/o-que-e-diagrama-de-classe-uml)

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.

A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
 
Para mais informações, consulte o microfundamento "Modelagem de Dados".

## Tecnologias Utilizadas

As tecnologia usada para resolver o problema sistematico apresentado são.:
|||||||
|-|-|-|-|-|-|
|linguagens| serviços web| frameworks| bibliotecas| IDEs de desenvolvimento | ferramentas |
| C# ou C-Sharp| Azure, GitHub Pages| .Net | Microsoft Nuget, Bootstrap | Visual Studio, Visual Studio Code, SQL Server Management Studio  | Azure SQL, Azure App Servece, GitHub | 

A interação do usuário com o sistema vai ser conduzida apartir do momento que o mesmo entrar no site que está hospedado no GitHub Page, em seguida que o mesmo efetuar o login no sitema será conduzido de forma transparente e agil para as ferramentas Azures que se encontra a hospedagem do backend.

![fluxo integração](/docs/img/fluxo_tec_arch.png)

## Hospedagem

* Hospedagem do front-end utilizasse do artefato [Website com GitHub Pages](https://pages.github.com/), seu lançamento se da através da plublicação da branch main via CD "Continuos Delivery" da pipeline após a validaçãos dos testes da plataforma.

* Hospedagem do banck-end utilizasse do artefato [Azure com App Service](https://learn.microsoft.com/pt-br/azure/app-service/overview), seu lançamento se da através da plublicação da branch main via CI "Continuos Integration" da pipeline após a validaçãos dos testes.

* Hospedagem do banco de dados utilizasse do artefato [Azure com Banco de dados SQL](https://azure.microsoft.com/pt-br/products/azure-sql/database), sua construção e implementação foi feita conforme os padrões e orientações dada pela Azure.

