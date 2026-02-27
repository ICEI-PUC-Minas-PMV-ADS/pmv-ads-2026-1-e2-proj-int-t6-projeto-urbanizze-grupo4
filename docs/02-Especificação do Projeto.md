# Especificações do Projeto

Por meio da técnica de observação e brainstorming foram analisadas as necessidades dos usuários do sistema de forma a atender suas demandas.

A partir das informações coletadas, foram determinadas as personas e histórias de usuários que serão de suma importância para a definição das funcionalidades.

## Personas

As personas, ou seja, os usuários ideais do site foram definidos abaixo:

Persona 1: João Silva – Morador Engajado
Idade: 47 anos
Profissão: Motorista de ônibus
Local: Bairro residencial periferia
Características pessoais: Dedicado à vizinhança, lidera o grupo de WhatsApp do bairro, sempre tenta ajudar os outros.

Persona 2: Maria Fernanda – Jovem Universitária
Idade: 21 anos
Profissão: Estudante de Engenharia Ambiental
Local: Centro urbano
Características pessoais: Tecnológica, conectada às redes sociais, preocupada com questões ambientais.

Persona 3: Anderson Souza – Funcionário da Prefeitura
Idade: 35 anos
Profissão: Técnico em obras públicas
Local: Sede da prefeitura municipal
Características pessoais: Organizado, comprometido, sente-se pressionado pela cobrança pública.

Persona 4: Renata Torres – Mãe Solo Trabalhadora
Idade: 29 anos
Profissão: Caixa de supermercado
Local: Região metropolitana
Características pessoais: Responsável, cheia de tarefas diárias, precisa de soluções rápidas e práticas.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

| EU COMO... `PERSONA` | QUERO/PRECISO ... `FUNCIONALIDADE`                                 | PARA ... `MOTIVO/VALOR`                                                                                     |
| -------------------- | ------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------------------- |
| João Silva           | Registrar uma denúncia sobre buracos nas ruas pelo celular         | Evitar danos ao meu veículo e promover mais segurança no bairro veículo e promover mais segurança no bairro |
| Maria Fernanda       | Anexar fotos à minha denúncia de descarte irregular de lixo        | Facilitar o entendimento e a solução do problema pelos responsáveis                                         |
| Renata Torres        | Fazer denúncia rapidamente, sem muitos cadastros                   | Não perder tempo no meu dia corrido e ainda melhorar a vizinhança                                           |
| Renata Torres        | Avaliar se o problema foi resolvido após o encerramento do chamado | Ter certeza de que minha contribuição realmente fez diferença                                               |
| Anderson Souza       | Receber denúncias detalhadas e organizadas por setor               | Atender demandas com mais eficácia e menos retrabalho                                                       |
| Anderson Souza       | Ter histórico/auditoria completa das interações em cada chamado    | Garantir transparência e poder mostrar a evolução das demandas públicas                                     |
| Anderson Souza       | Delegar e transferir chamados entre departamentos                  | Garantir que cada problema seja tratado pela equipe correta                                                 |
| Renata Torres        | Fazer denúncia anonimamente                                        | Não sofrer represálias caso o problema envolva vizinhos ou conhecidos                                       |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

| ID    | Descrição do Requisito                                                                 | Prioridade |
| ----- | -------------------------------------------------------------------------------------- | ---------- |
| RF-01 | Permitir registrar um cidadão.                                                         | ALTA       |
| RF-02 | Permitir cidadão fazer login.                                                          | ALTA       |
| RF-03 | Permitir gerenciamento de prefeituras                                                  | ALTA       |
| RF-04 | Permitir gerenciamento de departamentos                                                | ALTA       |
| RF-05 | Permitir gerenciamento de funcionários                                                 | ALTA       |
| RF-06 | Permitir o cadastro de denúncias urbanas pelos cidadãos                                | ALTA       |
| RF-07 | Permitir o acompanhamento do status e histórico dos chamados denunciados               | ALTA       |
| RF-08 | Habilitar denúncia anônima para o cidadão                                              | ALTA       |
| RF-09 | Permitir a integração entre setores/departamentos, incluindo transferência de chamados | ALTA       |
| RF-10 | Atribuir prioridade (urgência/gravidade) ao chamado aberto                             | MÉDIA      |
| RF-11 | Disponibilizar histórico detalhado de todas as interações realizadas no chamado        | BAIXA      |
| RF-12 | Permitir feedbacks/replicas do usuário e resposta do poder público sobre chamados      | MÉDIA      |
| RF-13 | Diferenciar perfis de acesso: cidadão e funcionário                                    | ALTA       |

### Requisitos não Funcionais

| ID     | Descrição do Requisito                                                                                                                                          | Prioridade |
| ------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------- |
| RNF-01 | O site deverá ter uma disponibilidade 24/7.                                                                                                                     | ALTA       |
| RNF-02 | O site deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Opera).                                                            | ALTA       |
| RNF-03 | A interface deve ser agradável, intuitiva, de fácil utilização para o usuário e deve ser organizado de tal maneira que os erros dos usuários sejam minimizados. | MÉDIA      |
| RNF-04 | O site deve ser publicado em um ambiente acessível publicamente na Internet.                                                                                    | ALTA       |
| RNF-05 | Os formulários devem informar ao usuário quais são os campos de preenchimento obrigatório.                                                                      | MÉDIA      |
| RNF-06 | Utilizar símbolo e ícone para ajudar no entendimento e conseguir uma associação imediata sobre aplicações de reconhecimento.                                    | MÉDIA      |
| RNF-07 | A aplicação ou parte dela deve ser acessível por pessoas com certo tipo de deficiência ou outra necessidade específica.                                         | ALTA       |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| ID    | Restrição                                                                |
| ----- | ------------------------------------------------------------------------ |
| RE-01 | O projeto deverá ser entregue até o final do semestre                    |
| RE-02 | A equipe não pode contratar terceiros para o desenvolvimento do projeto. |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos.

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
>
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
