# Arquitetura da Solução

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Classes”.

> - [Diagramas de Classes - Documentação da IBM](https://www.ibm.com/docs/pt-br/rational-soft-arch/9.6.1?topic=diagrams-class)
> - [O que é um diagrama de classe UML? | Lucidchart](https://www.lucidchart.com/pages/pt/o-que-e-diagrama-de-classe-uml)

## Modelo ER (Projeto Conceitual)
![projetoBD](/docs/img/)

## Projeto da Base de Dados

BdCQP

Descrição do Projeto:

O projeto "Chame quando precisar" é uma plataforma online destinada a promover a interação e colaboração entre pessoas com deficiência visual e colaboradores que desejam oferecer assistência e apoio. A plataforma oferece recursos específicos para atender às necessidades de ambos os grupos, criando uma comunidade inclusiva e de apoio.

Objetivos Principais:

Facilitar a Comunicação e Interação: A plataforma permitirá que deficientes visuais e colaboradores se comuniquem e interajam de maneira eficaz. Os deficientes visuais poderão compartilhar suas experiências, desafios e necessidades, enquanto os colaboradores poderão oferecer ajuda e apoio.

Agendamento de Tarefas e Assistência: Uma das principais características da plataforma é a capacidade de agendar tarefas e assistência. Os deficientes visuais podem registrar suas rotinas diárias, horários disponíveis e solicitar assistência para tarefas específicas, como leitura de documentos, orientação em locais públicos, etc.

Registro de Horários Agendados: A plataforma permitirá o registro de horários agendados entre deficientes visuais e colaboradores. Isso facilitará a coordenação e garantirá que ambas as partes estejam cientes dos compromissos agendados.

Compartilhamento de Recursos e Informações: Os usuários poderão compartilhar recursos úteis, como materiais de leitura em formato acessível, informações sobre serviços e eventos voltados para deficientes visuais, entre outros.

Componentes Principais do Banco de Dados:

O banco de dados do projeto é projetado para suportar as funcionalidades mencionadas. Ele inclui as seguintes tabelas:

 "Usuarios": Armazena informações sobre os usuários da plataforma, incluindo nome, sobrenome, email, login, senha, perfil de usuário, status de ativação e datas de inclusão e alteração.

"Calendario": Registra as atividades agendadas dos deficientes visuais, incluindo o dia da semana, o ID do usuário associado, a hora de início e a hora de término.

 "HorariosAgendados": Registra os horários agendados entre deficientes visuais e colaboradores, incluindo o ID do usuário deficiente visual, o ID do usuário colaborador, a data e hora do agendamento, bem como os detalhes específicos do agendamento.

 "Perfil": Registra os perfis que podem ser ligados aos usuários

  "Notificacoes": Registra as mensagens diparadas pelo sistema para usuário

  "Agendamento": Registra a valiação de um agendamento, podendo ser feita pelo deficiente visual ou o seu colborador.

  "AvaliacaodoAgendamento": Registra a valiação de um agendamento, podendo ser feita pelo deficiente visual ou o seu colborador.

  "DadosDoUsuario " : Tabela reservada para guardar informações especificas do usuário, como tipo de deficiência, dados de endereço, etc.

  "Amigos " : Registra o relacionamento entre dois usuário, criando um vinculo

  "Deficiencia " : Registra os tipos de deficiências visuais para serem ligadas a um usário deficiente

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

