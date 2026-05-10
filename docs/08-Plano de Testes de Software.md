# Plano de Testes de Software

## Casos de Teste

|  **Caso de Teste**  |                                                                                                **CT01 – Cadastrar cidadão**                                                                                                |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                           RF-01 - Gerenciar cadastro de cidadãos                                                                                           |
|  Objetivo do Teste  |                                                                                Verificar se o cidadão consegue se cadastrar na plataforma.                                                                                 |
|       Passos        | - Acessar o navegador <br> - Informar o endereço do sistema (conforme seção 07) <br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (nome, CPF, e-mail, senha, confirmação) <br> - Confirmar o cadastro |
|  Critério de Êxito  |                                                                                        - O sistema cria a conta e informa sucesso.                                                                                         |

|  **Caso de Teste**  |                                                                     **CT02 – Efetuar login (cidadão)**                                                                     |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                 RF-02 - Cidadão/funcionário realizar login                                                                 |
|  Objetivo do Teste  |                                                              Verificar se o cidadão consegue realizar login.                                                               |
|       Passos        | - Acessar o navegador <br> - Informar o endereço do sistema (conforme seção 07) <br> - Clicar em "Entrar" <br> - Preencher e-mail e senha válidos <br> - Confirmar o login |
|  Critério de Êxito  |                                                       - O usuário é autenticado e direcionado ao painel do cidadão.                                                        |

|  **Caso de Teste**  |                                                   **CT03 – Recuperar senha**                                                    |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                           RF-03 - Cidadão/funcionário recuperar senha                                           |
|  Objetivo do Teste  |                                 Verificar se o usuário consegue solicitar recuperação de senha.                                 |
|       Passos        | - Acessar a tela de login <br> - Clicar em "Esqueci minha senha" <br> - Informar e-mail cadastrado <br> - Confirmar solicitação |
|  Critério de Êxito  |                                  - O sistema informa que a recuperação foi enviada ao e-mail.                                   |

|  **Caso de Teste**  |                                                                                     **CT04 – Registrar denúncia**                                                                                     |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                      RF-07 - Gerenciar denúncias                                                                                      |
|  Objetivo do Teste  |                                                          Verificar se o cidadão consegue registrar uma denúncia com os campos obrigatórios.                                                           |
|       Passos        | - Autenticar como cidadão <br> - Acessar "Nova denúncia" <br> - Preencher título, descrição, categoria e localização <br> - Informar se a denúncia é anônima ou identificada <br> - Enviar a denúncia |
|  Critério de Êxito  |                                                                       - A denúncia é registrada e aparece na lista do cidadão.                                                                        |

|  **Caso de Teste**  |                                                                  **CT05 – Anexar foto à denúncia**                                                                  |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                              RF-08 - Adicionar fotos/anexos a denúncia                                                              |
|  Objetivo do Teste  |                                               Verificar se o cidadão consegue anexar imagem ao registrar a denúncia.                                                |
|       Passos        | - Autenticar como cidadão <br> - Acessar "Nova denúncia" <br> - Preencher campos obrigatórios <br> - Anexar uma imagem válida (JPG ou PNG) <br> - Enviar a denúncia |
|  Critério de Êxito  |                                                        - O anexo é salvo e exibido nos detalhes da denúncia.                                                        |

|  **Caso de Teste**  |                                                                 **CT06 – Interagir na denúncia (mensagens)**                                                                  |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                      RF-09 - Realizar interações dentro da denúncia (envio de mensagens)                                                      |
|  Objetivo do Teste  |                                                  Verificar se cidadão e funcionário conseguem trocar mensagens na denúncia.                                                   |
|       Passos        | - Autenticar como cidadão <br> - Acessar uma denúncia criada <br> - Enviar uma mensagem na área de comunicação <br> - Autenticar como funcionário <br> - Responder à mensagem |
|  Critério de Êxito  |                                                          - As mensagens ficam registradas no histórico da denúncia.                                                           |

|  **Caso de Teste**  |                                                                      **CT07 – Pesquisar e filtrar denúncias**                                                                      |
| :-----------------: | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                 RF-12 - Permitir pesquisas e filtros de denúncias                                                                  |
|  Objetivo do Teste  |                                                   Verificar se é possível pesquisar e filtrar denúncias por categoria e status.                                                    |
|       Passos        | - Autenticar como funcionário <br> - Acessar a lista de denúncias <br> - Aplicar filtro por categoria <br> - Aplicar filtro por status <br> - Realizar uma busca por palavra-chave |
|  Critério de Êxito  |                                                               - A lista é atualizada conforme os filtros e a busca.                                                                |

|  **Caso de Teste**  |                                                                                           **CT08 – Diferenciar perfis de acesso**                                                                                            |
| :-----------------: | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                 RF-10 - Diferenciar perfis de acesso: cidadão e funcionário                                                                                  |
|  Objetivo do Teste  |                                                                             Verificar se cada perfil acessa somente funcionalidades permitidas.                                                                              |
|       Passos        | - Autenticar como cidadão <br> - Verificar acesso ao painel do cidadão e ausência de gestão administrativa <br> - Encerrar sessão <br> - Autenticar como funcionário <br> - Verificar acesso ao painel de gestão e denúncias |
|  Critério de Êxito  |                                                                                 - As permissões são aplicadas corretamente para cada perfil.                                                                                 |

|  **Caso de Teste**  |                                                                                             **CT09 – Atualizar status e notificar cidadão**                                                                                             |
| :-----------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                   RF-07 - Gerenciar denúncias; RF-11 - Notificar cidadão/funcionário                                                                                    |
|  Objetivo do Teste  |                                                                                     Verificar se a alteração de status gera notificação ao cidadão.                                                                                     |
|       Passos        | - Autenticar como funcionário <br> - Acessar uma denúncia aberta <br> - Atualizar o status (ex.: Em análise, Resolvido) <br> - Salvar a alteração <br> - Autenticar como cidadão <br> - Verificar notificações ou histórico da denúncia |
|  Critério de Êxito  |                                                                                        - O status é atualizado e o cidadão recebe a notificação.                                                                                        |

|  **Caso de Teste**  |                                                                    **CT10 – Gerenciar departamentos**                                                                     |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                      RF-05 - Gerenciar departamentos                                                                      |
|  Objetivo do Teste  |                                               Verificar se o funcionário administrador consegue cadastrar um departamento.                                                |
|       Passos        | - Autenticar como funcionário administrador <br> - Acessar a gestão de departamentos <br> - Clicar em "Novo departamento" <br> - Preencher nome e descrição <br> - Salvar |
|  Critério de Êxito  |                                                               - O departamento é criado e aparece na lista.                                                               |

|  **Caso de Teste**  |                                                                                      **CT11 – Gerenciar funcionários**                                                                                       |
| :-----------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                        RF-06 - Gerenciar funcionários                                                                                        |
|  Objetivo do Teste  |                                                                       Verificar se o administrador consegue cadastrar um funcionário.                                                                        |
|       Passos        | - Autenticar como funcionário administrador <br> - Acessar a gestão de funcionários <br> - Clicar em "Novo funcionário" <br> - Informar dados obrigatórios (nome, e-mail, cargo, departamento) <br> - Salvar |
|  Critério de Êxito  |                                                                                 - O funcionário é criado e aparece na lista.                                                                                 |

> **Links Úteis**:
>
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> - [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
