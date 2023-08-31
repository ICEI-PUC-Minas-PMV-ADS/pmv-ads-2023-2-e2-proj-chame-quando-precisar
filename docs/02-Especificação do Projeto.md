# Especificações do Projeto

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas abaixo. 

Pessoas essas que são deficientes visuais parcial ou total, que tem como falas e histórias do cotidiano que mostra a necessidade de ter um apoio de outra pessoa.

Primeiro caso é do Renato Machado, deficiente visual total que perdeu a visão após uma doença aos seus 43 anos de vida. Sua história traz na fala a dificuldade de acessibilidade e mobilidade dentro e fora de casa, pois com apenas 2 anos convivendo com a perda da visão, passa por muitas dificuldades ainda. 

Segundo caso é da Cecília Fernandez, deficiente visual parcial, que perdeu a visão após a descoberta de uma doença aos seus 37 anos de vida. Sua história traz na fala a dificuldade de acessibilidade fora de casa, pois com apenas 1 ano convivendo com a perda da visão parcial, passa por muitas dificuldades na leitura de rótulos, uso de telefone e leitura de informações de trânsito exemplo placa do ônibus. 

Terceiro caso é do Givanildo de Souza, deficiente visual total, que perdeu a visão após acidente de trabalho aos seus 29 anos de vida. Sua história traz na fala a dificuldade de acessibilidade fora de casa e arrumar emprego que realmente se preocupem, pois com 10 anos convivendo com a perda da visão total, passa por muitas dificuldades de mobilidade e transtornos com pessoas que não são compreensivas com sua situação atual. 

O quarto caso é da Sara Bianchi, deficiente visual parcial, nasceu com a visão comprometida por uma doença aos seus 18 anos de vida. Sua história traz na fala a dificuldade de acessibilidade fora de casa pois seus pais preparam todo o ambiente da casa para melhor confortá-la, passa por muitas dificuldades na leitura de rótulos, o uso de telefone computadores e outros dispositivos que não seja o dela dificulta muito.

O quinto caso é do Pedro Moraes, deficiente visual total, nasceu com a visão comprometida por uma doença aos seus 31 anos de vida. Sua história traz na fala a dificuldade de acessibilidade dentro e fora de casa, pois seus pais não tiveram condições financeiras e nem a possibilidade de um acompanhamento médico, passa por muitas dificuldades na mobilidade urbana, deslocamentos para as consultas, pois sofre de outras doenças.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

A tabela a seguir apresenta os requisitos do projeto, identificando a prioridade em que os mesmos devem ser entregues.

| **ID** | **Descrição** | **Prioridade** |
|---|---|---|
| RF-01 | O sistema deve permitir que pessoas com deficiência visual se cadastrem no sistema, fornecendo informações como nome, contato, tipo de deficiência e preferências de assistência. | Alta |
| RF-02 | O sistema deve permitir que voluntários se cadastrem, fornecendo informações como nome, contato, habilidades relevantes, disponibilidade e área de atuação. |  |
| RF-03 | O sistema deve fornecer ferramentas de análise do cadastros de voluntários submetidos a uma validação pelos administradores do sistema antes de se tornarem ativos.  |  |
| RF-04 | O sistema deve permitir que pessoas com deficiência visual solicitem assistência para tarefas específicas tais como orientação em ambientes desconhecidos ou suporte para atividades cotidianas. |  |
| RF-05 | O sistema deve ser capaz de atribuir voluntários adequados com base em suas habilidades, disponibilidade e proximidade geográfica. |  |
| RF-06 | O sistema deve fornecer um mecanismo de avaliação para que ambos os lados possam fornecer feedback sobre a qualidade da assistência prestada. |  |
| RF-07 | O sistema deve permitir que pessoas cadastradas como contato seguro do usuário com deficiência visual acompanhem o progresso das tarefas de assistência. |  |
| RF-08 | O sistema deve garantir que pessoas que cumprem o papel de acompanhantes, não tenham agendas conflitantes. |  |
| RF-09 | O sistema deve garantir que um agendamento possa ser cadastrado, atualizada ou deletado pelo usuário. |  |
| RF-10 | O sistema deve fornecer um acesso aos históricos e registros do usuário deficiente visual ou acompanhante em caso de necessidade. |  |

### Requisitos não Funcionais

A tabela a seguir apresenta os requisitos não funcionais que o projeto deverá atender.

| **ID** | **Descrição** | **Prioridade** |
|---|---|---|
| RNF-01 | O sistema deve ser projetado levando em consideração os princípios de acessibilidade, garantindo que seja utilizável para pessoas com deficiência visual. Isso inclui o uso de leitores de tela, suporte a comandos de voz e teclado, contraste adequado, tamanhos de fonte ajustáveis e outras diretrizes de acessibilidade. | Alta |
| RNF-02 | Dado que as informações pessoais e sensíveis serão coletadas, o sistema deve adotar medidas robustas de segurança para proteger os dados dos usuários. Isso envolve criptografia, proteção contra ameaças cibernéticas e políticas claras de privacidade. |  |
| RNF-03 | O sistema deve ser compatível com diversas tecnologias assistivas utilizadas por pessoas com deficiência visual, como leitores de tela, teclados especiais e dispositivos de entrada alternativos. Isso permitirá que os usuários tenham uma experiência otimizada. |  |
| RNF-04 | O sistema deve ser intuitivo e de fácil utilização, especialmente para pessoas com deficiência visual que podem ter necessidades diferentes de interação. A interface deve ser clara, organizada e amigável, garantindo uma experiência positiva para todos os usuários. |  |
| RNF-05 | O sistema deve garantir que toda transação, seja financeira ou não, seja segura e de alta confiabilidade pelos usuários ou acompanhantes. |  |
| RNF-06 | O sistema deve garantir que seja factível a troca ou reagendamento de evento notificando os usuários envolvidos |  |

## Regras de Negócio

O projeto está restrito pelos itens apresentados na tabela a seguir.

| **ID** | **Descrição** |
|---|---|
| RN-01 | Cadastros de voluntários precisam ser validados por administradores antes de se tornarem ativos. Levando em consideração requisitos que não comprometem o serviço de acompanhamento. |
| RN-02 | Ao atribuir voluntários a tarefas de assistência, o sistema deve considerar as habilidades específicas dos voluntários em relação às necessidades das pessoas com deficiência visual. |
| RN-03 | Cada voluntário pode estar envolvido em um número limitado de tarefas simultaneamente para garantir que a qualidade do suporte não seja comprometida. |

## Regras de Gestão

| **ID** | **Descrição** |
|---|---|
| RG-01 | Estabeleça uma comunicação transparente e respeitosa entre todos os membros envolvidos, incentivando a troca de ideias, feedback e informações. |
| RG-02 | Atividades claras, estabelecendo marcos ao longo do desenvolvimento para avaliar o progresso. |
| RG-03 | Cada membro da equipe deve ter funções e responsabilidades claramente definidas com base em suas habilidades e especializações. |
| RG-04 | Data limite e outros requisitos. |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.
