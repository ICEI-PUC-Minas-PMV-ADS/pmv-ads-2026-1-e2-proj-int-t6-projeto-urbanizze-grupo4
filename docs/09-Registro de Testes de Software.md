# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

## Evidências dos Testes

| **Caso de Teste** | **CT01 – Cadastrar cidadão** |
|:---:|:---:|
| Requisito Associado | RF-01 - Gerenciar cadastro de cidadãos |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Acessou-se a rota `/Registrar` a partir do link "Criar conta" na tela de login. Foram preenchidos os campos: Nome ("Teste Silva"), CPF ("44444444444"), Telefone ("11999990009"), E-mail ("teste@email.com"), Senha e Confirmação de senha ("123456"). O tipo de conta selecionado foi "Cidadão". Ao clicar em "Registrar", o sistema criou o registro na tabela `CIDADAO` e redirecionou para a tela de login (`/Login`). <br><br> **Verificação:** Confirmou-se que o cidadão foi inserido no banco de dados com os campos preenchidos corretamente e o campo `Ativo` definido como `true`. |

| **Caso de Teste** | **CT02 – Cadastrar funcionário** |
|:---:|:---:|
| Requisito Associado | RF-01 - Gerenciar cadastro de cidadãos; RF-06 - Gerenciar funcionários |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Acessou-se a tela de registro e foram preenchidos os dados pessoais. Ao selecionar tipo de conta "Funcionário", o campo "Departamento" foi exibido dinamicamente via JavaScript. Selecionou-se o departamento "Iluminação - São Paulo". Ao clicar em "Registrar", o sistema criou o registro de cidadão e o vínculo de funcionário com o departamento selecionado, redirecionando para a tela de login. <br><br> **Verificação:** Confirmou-se que foram criados registros nas tabelas `CIDADAO` e `FUNCIONARIO`, com o `DepartamentoId` correspondente ao departamento selecionado. |

| **Caso de Teste** | **CT03 – Efetuar login como cidadão** |
|:---:|:---:|
| Requisito Associado | RF-02 - Cidadão/funcionário realizar login |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Acessou-se a tela de login (`/Login`) e foram informados o e-mail "maria@email.com" e a senha "123456" (cidadão seed). Ao clicar em "Entrar", o sistema autenticou o usuário, criou a sessão com `UsuarioPerfil = "Cidadao"` e redirecionou para `/Denuncias`. <br><br> **Verificação:** O sidebar exibiu apenas "Início" e "Minhas Denúncias". A lista de denúncias filtrou apenas as denúncias do cidadão autenticado (CidadaoId correspondente). O nome do usuário foi exibido na barra lateral e na topbar. <br><br> **Teste de falha:** Ao informar credenciais inválidas, o sistema exibiu a mensagem "Email ou senha inválidos." e permaneceu na tela de login. |

| **Caso de Teste** | **CT04 – Efetuar login como funcionário** |
|:---:|:---:|
| Requisito Associado | RF-02 - Cidadão/funcionário realizar login; RF-10 - Diferenciar perfis de acesso |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Acessou-se a tela de login e foram informados o e-mail "carlos@email.com" e a senha "123456" (funcionário seed, vinculado ao departamento Pavimentação - São Paulo). Ao clicar em "Entrar", o sistema identificou o vínculo na tabela `FUNCIONARIO`, definiu `UsuarioPerfil = "Funcionario"` na sessão e redirecionou para `/Funcionarios`. <br><br> **Verificação:** O sidebar exibiu os menus: Cidadãos, Denúncias, Prefeituras, Departamentos e Funcionários. A lista de denúncias mostrou todas as denúncias do sistema (sem filtro por cidadão). O perfil "Funcionário" foi exibido na barra lateral. |

| **Caso de Teste** | **CT05 – Recuperar senha** |
|:---:|:---:|
| Requisito Associado | RF-03 - Cidadão/funcionário recuperar senha |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** A partir da tela de login, clicou-se no link "Esqueceu a senha?" que redirecionou para `/RecuperarSenha`. Informou-se o e-mail "maria@email.com", a nova senha "novaSenha123" e a confirmação. Ao clicar em "Alterar senha", o sistema localizou o cidadão pelo e-mail, atualizou o campo `Senha` no banco e exibiu a mensagem "Senha alterada com sucesso!" em verde. <br><br> **Verificação:** Realizou-se login com o e-mail e a nova senha, confirmando que a alteração foi persistida. <br><br> **Teste de falha (senhas diferentes):** Ao informar senhas que não conferem, o sistema exibiu "As senhas não conferem." <br> **Teste de falha (e-mail inexistente):** Ao informar e-mail não cadastrado, o sistema exibiu "E-mail não encontrado." |

| **Caso de Teste** | **CT06 – Registrar denúncia** |
|:---:|:---:|
| Requisito Associado | RF-07 - Gerenciar denúncias |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Autenticou-se como cidadão e acessou-se a tela de criação de denúncia via botão "Nova denúncia". Preencheu-se o título ("Semáforo quebrado"), a descrição detalhada, selecionou-se a categoria "Iluminação - São Paulo (SP)" e informou-se a localização "Rua Teste, 100 - Centro". A opção de denúncia anônima não foi marcada. Ao clicar em "Enviar Denúncia", o sistema criou o registro com `StatusDenuncia = ABERTA` e redirecionou para a lista de denúncias. <br><br> **Verificação:** A nova denúncia apareceu na lista com status "Aberto", título correto e data de criação do dia atual. O `CidadaoId` correspondeu ao cidadão autenticado. |

| **Caso de Teste** | **CT07 – Interagir na denúncia (mensagens)** |
|:---:|:---:|
| Requisito Associado | RF-09 - Realizar interações dentro da denúncia (envio de mensagens) |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Autenticou-se como cidadão (joao@email.com) e acessou-se os detalhes da denúncia "Buraco grande na pista" (que já possuía 3 mensagens seed). Digitou-se "Alguma atualização?" no campo de mensagem e clicou-se em "Enviar". A mensagem apareceu no histórico com o nome "João Souza" e o horário de envio. <br> Em seguida, encerrou-se a sessão e autenticou-se como funcionário (carlos@email.com). Acessou-se a mesma denúncia e a mensagem do cidadão estava visível. Respondeu-se com "Estamos trabalhando na solução". A mensagem do funcionário apareceu à direita com fundo laranja, enquanto as do cidadão ficaram à esquerda com fundo bege. <br><br> **Verificação:** As mensagens foram persistidas na tabela `MENSAGEM` com `CidadaoId` ou `FuncionarioId` preenchido conforme o perfil. O histórico exibiu nome do remetente e horário de cada mensagem. |

| **Caso de Teste** | **CT08 – Pesquisar e filtrar denúncias** |
|:---:|:---:|
| Requisito Associado | RF-12 - Permitir pesquisas e filtros de denúncias |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Autenticou-se como funcionário e acessou-se a lista de denúncias (8 registros seed). <br> **Filtro por categoria:** Selecionou-se "Iluminação" no dropdown de categorias. A lista foi atualizada exibindo apenas a denúncia "Poste sem luz na esquina". <br> **Filtro por status:** Selecionou-se "Abertos". A lista exibiu apenas denúncias com `StatusDenuncia = ABERTA` (3 registros). <br> **Busca por palavra-chave:** Digitou-se "vazamento" no campo de busca. A lista filtrou para exibir apenas "Vazamento na via principal". <br><br> **Verificação:** Os filtros de categoria e status utilizam query parameters (`filtroCategoria`, `filtroStatus`, `busca`) e a filtragem é aplicada via LINQ no controller. Todos os filtros funcionaram corretamente e puderam ser combinados. |

| **Caso de Teste** | **CT09 – Diferenciar perfis de acesso** |
|:---:|:---:|
| Requisito Associado | RF-10 - Diferenciar perfis de acesso: cidadão e funcionário |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** <br> **Perfil Cidadão:** Autenticou-se com credenciais de cidadão. O sidebar exibiu apenas "Início" e "Minhas Denúncias". A lista de denúncias mostrou somente as denúncias criadas pelo próprio cidadão (filtro `CidadaoId == usuarioId`). Ao tentar acessar manualmente a URL `/Cidadaos` ou `/Departamentos`, o sistema carregou as páginas através do layout autenticado, porém o sidebar manteve apenas os menus do cidadão. <br><br> **Perfil Funcionário:** Encerrou-se a sessão e autenticou-se como funcionário. O sidebar exibiu: Cidadãos, Denúncias, Prefeituras, Departamentos e Funcionários. A lista de denúncias mostrou todas as denúncias do sistema, sem filtro por cidadão. O funcionário teve acesso às funcionalidades de gestão (CRUD de departamentos, visualização de cidadãos, alteração de status). <br><br> **Verificação:** A diferenciação é feita pela variável de sessão `UsuarioPerfil`, verificada no `_Layout.cshtml` para renderizar os menus e no `DenunciasController` para filtrar as denúncias. |

| **Caso de Teste** | **CT10 – Atualizar status da denúncia** |
|:---:|:---:|
| Requisito Associado | RF-07 - Gerenciar denúncias |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Autenticou-se como funcionário e acessou-se os detalhes da denúncia "Poste sem luz na esquina" (status inicial "Aberto"). No seletor de status, alterou-se para "Em andamento". O formulário foi submetido automaticamente via `onchange`. A página recarregou e o badge de status exibiu "Em andamento" com a cor correspondente (laranja). <br> Voltou-se à lista de denúncias e o status atualizado foi confirmado na coluna STATUS da tabela. <br><br> **Verificação:** O campo `StatusDenuncia` foi atualizado no banco e o campo `AtualizadoEm` recebeu o timestamp da alteração. A ação `AlterarStatus` do controller processou corretamente a conversão do enum via `Enum.TryParse`. |

| **Caso de Teste** | **CT11 – Gerenciar departamentos** |
|:---:|:---:|
| Requisito Associado | RF-05 - Gerenciar departamentos |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Autenticou-se como funcionário e acessou-se "Departamentos" no menu. A lista exibiu os 7 departamentos seed. <br> **Criar:** Clicou-se em "Create New", preencheu-se Nome ("Transporte"), Descrição ("Transporte público municipal") e selecionou-se a Prefeitura "Belo Horizonte". Ao salvar, o departamento apareceu na lista. <br> **Editar:** Clicou-se em "Edit" no departamento criado, alterou-se a descrição para "Transporte público e mobilidade" e salvou-se. A alteração foi refletida na lista. <br> **Excluir:** Clicou-se em "Delete" no departamento criado, confirmou-se a exclusão e o registro foi removido da lista. <br><br> **Verificação:** As operações CRUD foram realizadas corretamente nas páginas Razor `Create`, `Edit` e `Delete` do módulo Departamentos, com validação de campos obrigatórios e seleção de prefeitura via dropdown. |

| **Caso de Teste** | **CT12 – Portal de Transparência** |
|:---:|:---:|
| Requisito Associado | RF-07 - Gerenciar denúncias |
| Registro de evidência | **Resultado: APROVADO** <br><br> **Descrição do teste:** Acessou-se a rota raiz (`/`) do sistema sem estar autenticado. O portal carregou com o layout público (header com logo "URBANIZZE" e botão "Entrar", sem sidebar). A hero section exibiu "Acompanhe as denúncias da sua cidade" e o dropdown de cidades. <br> **Estado vazio:** Sem cidade selecionada, o portal exibiu o ícone de localização e a mensagem "Selecione uma cidade". <br> **Com cidade selecionada:** Ao selecionar "São Paulo - SP", a página recarregou com `?cidadeId=1`. Foram exibidos 4 cards de estatísticas: Total (5), Abertas (2), Em Análise (0), Resolvidas (1). O grid de denúncias mostrou os 5 registros de São Paulo com título, badge de status colorido, categoria (departamento) e data. <br> **Troca de cidade:** Ao trocar para "Rio de Janeiro - RJ", as estatísticas e denúncias foram atualizadas para refletir apenas os dados daquela cidade. <br><br> **Verificação:** A filtragem por cidade é feita via `Departamento.PrefeituraCidadeId` no PageModel. O layout `_LayoutPortal` não exige sessão autenticada. Os dados seed foram corretamente distribuídos entre as cidades. |

## Relatório de Testes de Software

### Pontos Fortes

- **Autenticação e perfis de acesso:** O sistema diferencia corretamente os perfis de cidadão e funcionário, exibindo menus e funcionalidades adequados a cada tipo de usuário. A sessão é gerenciada de forma consistente em todas as páginas.
- **Fluxo de denúncias completo:** O ciclo de vida da denúncia funciona integralmente: criação, listagem, detalhes, troca de mensagens e alteração de status. Os filtros de busca, categoria e status funcionam corretamente e podem ser combinados.
- **Portal de Transparência:** A funcionalidade pública permite que qualquer pessoa visualize as denúncias por cidade sem necessidade de cadastro, promovendo a transparência da gestão pública.
- **Comunicação cidadão-funcionário:** O sistema de mensagens dentro da denúncia permite a troca de informações entre as partes, com identificação clara do remetente e horário.
- **CRUD de departamentos e funcionários:** As operações de criação, edição e exclusão funcionam corretamente com validação de campos obrigatórios.

### Pontos a Melhorar

- **Anexos e fotos (RF-08):** A funcionalidade de adicionar fotos ou anexos às denúncias ainda não foi implementada na interface. O modelo de dados (`Anexo`) existe, mas não há tela de upload.
- **Sistema de notificações (RF-11):** O modelo `Notificacao` existe no banco, porém não há mecanismo de geração ou exibição de notificações ao cidadão quando o status de sua denúncia é alterado.
- **Segurança de senhas:** As senhas são armazenadas em texto plano no banco de dados. Recomenda-se implementar hashing (ex: BCrypt) para proteger as credenciais.
- **Validação no registro:** O formulário de registro não valida unicidade de CPF ou e-mail antes de submeter, podendo gerar erros de banco de dados duplicados.
- **Busca de funcionários (RF-13):** A funcionalidade de pesquisa e filtro na lista de funcionários ainda não está implementada.

### Melhorias Planejadas

- Implementar upload de fotos/anexos nas denúncias utilizando armazenamento local ou em nuvem.
- Criar sistema de notificações em tempo real ou por polling para alertar cidadãos sobre atualizações em suas denúncias.
- Aplicar hash de senha com BCrypt no cadastro e na recuperação de senha.
- Adicionar validação de unicidade de CPF e e-mail no formulário de registro.
- Implementar filtros e busca na lista de funcionários.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
