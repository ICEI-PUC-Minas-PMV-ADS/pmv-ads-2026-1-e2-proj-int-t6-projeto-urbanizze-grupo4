# Plano de Testes de Software

## Casos de Teste

|  **Caso de Teste**  |                                                                                                **CT01 – Cadastrar cidadão**                                                                                                |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                           RF-01 - Gerenciar cadastro de cidadãos                                                                                           |
|  Objetivo do Teste  |                                                                                Verificar se o cidadão consegue se cadastrar na plataforma.                                                                                 |
|       Passos        | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Clicar em "Entrar" <br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (nome, CPF, telefone, e-mail, senha, confirmação de senha) <br> - Selecionar tipo de conta "Cidadão" <br> - Clicar em "Registrar" |
|  Critério de Êxito  |                                                                  - O sistema cria a conta e redireciona para a tela de login.                                                                                         |

|  **Caso de Teste**  |                                                                                                **CT02 – Cadastrar funcionário**                                                                                                |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                           RF-01 - Gerenciar cadastro de cidadãos; RF-06 - Gerenciar funcionários                                                           |
|  Objetivo do Teste  |                                                                                Verificar se é possível cadastrar um funcionário via tela de registro.                                                                       |
|       Passos        | - Acessar a tela de registro <br> - Preencher os campos obrigatórios (nome, CPF, telefone, e-mail, senha, confirmação de senha) <br> - Selecionar tipo de conta "Funcionário" <br> - Selecionar o departamento correspondente <br> - Clicar em "Registrar" |
|  Critério de Êxito  |                                                                  - O sistema cria a conta de cidadão e o vínculo de funcionário com o departamento selecionado, redirecionando para a tela de login.                        |

|  **Caso de Teste**  |                                                                     **CT03 – Efetuar login como cidadão**                                                                     |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                 RF-02 - Cidadão/funcionário realizar login                                                                 |
|  Objetivo do Teste  |                                                              Verificar se o cidadão consegue realizar login e é direcionado ao painel correto.                              |
|       Passos        | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Clicar em "Entrar" <br> - Preencher e-mail e senha de um cidadão válido <br> - Clicar em "Entrar" |
|  Critério de Êxito  |                                                       - O usuário é autenticado e direcionado à lista de denúncias (painel do cidadão).                                    |

|  **Caso de Teste**  |                                                                     **CT04 – Efetuar login como funcionário**                                                                     |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                 RF-02 - Cidadão/funcionário realizar login; RF-10 - Diferenciar perfis de acesso                           |
|  Objetivo do Teste  |                                                              Verificar se o funcionário consegue realizar login e é direcionado ao painel administrativo.                   |
|       Passos        | - Acessar a tela de login <br> - Preencher e-mail e senha de um funcionário válido <br> - Clicar em "Entrar" |
|  Critério de Êxito  |                                                       - O usuário é autenticado e direcionado à lista de funcionários (painel administrativo com sidebar de Cidadãos, Denúncias, Prefeituras, Departamentos e Funcionários). |

|  **Caso de Teste**  |                                                   **CT05 – Recuperar senha**                                                    |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                           RF-03 - Cidadão/funcionário recuperar senha                                           |
|  Objetivo do Teste  |                                 Verificar se o usuário consegue redefinir sua senha.                                            |
|       Passos        | - Acessar a tela de login <br> - Clicar em "Esqueceu a senha?" <br> - Informar o e-mail cadastrado <br> - Digitar a nova senha e a confirmação <br> - Clicar em "Alterar senha" |
|  Critério de Êxito  |                                  - O sistema atualiza a senha e exibe mensagem de confirmação.                                  |

|  **Caso de Teste**  |                                                                                     **CT06 – Registrar denúncia**                                                                                     |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                      RF-07 - Gerenciar denúncias                                                                                      |
|  Objetivo do Teste  |                                                          Verificar se o cidadão consegue registrar uma denúncia com os campos obrigatórios.                                                           |
|       Passos        | - Autenticar como cidadão <br> - Clicar em "Nova denúncia" <br> - Preencher título, descrição e selecionar categoria (departamento) <br> - Informar localização (opcional) <br> - Marcar ou não "Denúncia anônima" <br> - Clicar em "Enviar Denúncia" |
|  Critério de Êxito  |                                                                       - A denúncia é registrada com status "Aberto" e aparece na lista de denúncias.                                                  |

|  **Caso de Teste**  |                                                                 **CT07 – Interagir na denúncia (mensagens)**                                                                  |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                      RF-09 - Realizar interações dentro da denúncia (envio de mensagens)                                                      |
|  Objetivo do Teste  |                                                  Verificar se cidadão e funcionário conseguem trocar mensagens na denúncia.                                                   |
|       Passos        | - Autenticar como cidadão <br> - Acessar uma denúncia existente via "Ver detalhes" <br> - Digitar uma mensagem no campo de comunicação <br> - Clicar em "Enviar" <br> - Autenticar como funcionário <br> - Acessar a mesma denúncia <br> - Responder à mensagem |
|  Critério de Êxito  |                                                          - As mensagens ficam registradas no histórico de comunicação da denúncia, exibindo nome do remetente e horário.       |

|  **Caso de Teste**  |                                                                      **CT08 – Pesquisar e filtrar denúncias**                                                                      |
| :-----------------: | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                 RF-12 - Permitir pesquisas e filtros de denúncias                                                                  |
|  Objetivo do Teste  |                                                   Verificar se é possível pesquisar e filtrar denúncias por categoria e status.                                                    |
|       Passos        | - Autenticar como funcionário <br> - Acessar a lista de denúncias <br> - Selecionar um filtro de categoria (ex: "Iluminação") <br> - Selecionar um filtro de status (ex: "Abertos") <br> - Realizar uma busca por palavra-chave no campo de busca |
|  Critério de Êxito  |                                                               - A lista é atualizada exibindo apenas denúncias que correspondem aos filtros e à busca aplicados.                    |

|  **Caso de Teste**  |                                                                                           **CT09 – Diferenciar perfis de acesso**                                                                                            |
| :-----------------: | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                 RF-10 - Diferenciar perfis de acesso: cidadão e funcionário                                                                                  |
|  Objetivo do Teste  |                                                                             Verificar se cada perfil acessa somente funcionalidades permitidas.                                                                              |
|       Passos        | - Autenticar como cidadão <br> - Verificar que o sidebar exibe apenas "Início" e "Minhas Denúncias" <br> - Verificar que o cidadão só visualiza suas próprias denúncias <br> - Encerrar sessão <br> - Autenticar como funcionário <br> - Verificar que o sidebar exibe "Cidadãos", "Denúncias", "Prefeituras", "Departamentos" e "Funcionários" <br> - Verificar acesso a todas as denúncias e ao painel de gestão |
|  Critério de Êxito  |                                                                                 - As permissões e menus são aplicados corretamente para cada perfil.                                                                          |

|  **Caso de Teste**  |                                                                                             **CT10 – Atualizar status da denúncia**                                                                                             |
| :-----------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                   RF-07 - Gerenciar denúncias                                                                                                                          |
|  Objetivo do Teste  |                                                                                     Verificar se o funcionário consegue alterar o status de uma denúncia.                                                                               |
|       Passos        | - Autenticar como funcionário <br> - Acessar a lista de denúncias <br> - Clicar em "Ver detalhes" de uma denúncia <br> - Alterar o status no seletor (ex: de "Aberto" para "Em andamento") <br> - Verificar que o status foi atualizado na tela de detalhes e na listagem |
|  Critério de Êxito  |                                                                                        - O status é atualizado corretamente e refletido na interface.                                                                                    |

|  **Caso de Teste**  |                                                                    **CT11 – Gerenciar departamentos**                                                                     |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                      RF-05 - Gerenciar departamentos                                                                      |
|  Objetivo do Teste  |                                               Verificar se o funcionário consegue criar, editar e excluir um departamento.                                                 |
|       Passos        | - Autenticar como funcionário <br> - Acessar a gestão de departamentos <br> - Clicar em "Create New" <br> - Preencher nome, descrição e selecionar a prefeitura <br> - Salvar <br> - Verificar que o departamento aparece na lista <br> - Editar o departamento criado <br> - Excluir o departamento |
|  Critério de Êxito  |                                                               - O departamento é criado, editado e excluído corretamente.                                                  |

|  **Caso de Teste**  |                                                                                      **CT12 – Portal de Transparência**                                                                                       |
| :-----------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                        RF-07 - Gerenciar denúncias                                                                                           |
|  Objetivo do Teste  |                                                       Verificar se o portal público exibe as denúncias por cidade sem necessidade de login.                                                                   |
|       Passos        | - Acessar o navegador <br> - Informar o endereço raiz do sistema (/) <br> - Verificar que a página do portal carrega sem exigir login <br> - Selecionar uma cidade no dropdown <br> - Verificar que os cards de estatísticas (Total, Abertas, Em Análise, Resolvidas) são exibidos <br> - Verificar que as denúncias da cidade selecionada aparecem no grid |
|  Critério de Êxito  |                                                                                 - O portal exibe corretamente as denúncias e estatísticas da cidade selecionada, sem exigir autenticação.                      |

> **Links Úteis**:
>
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> - [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
