# Registro de Testes de Usabilidade

O registro de testes de usabilidade é um documento onde são coletadas e organizadas as informações sobre a experiência dos usuários ao interagir com o sistema Urbanizze. Ele inclui dados como tempo de execução de tarefas, taxa de sucesso, dificuldades encontradas, erros cometidos e feedback dos usuários. Esse registro permite identificar padrões de uso, obstáculos encontrados na interface e oportunidades de melhoria, fornecendo insights quantitativos e qualitativos para otimizar a experiência do usuário.

## Perfil dos usuários que participaram do teste

| Participante | Idade | Escolaridade | Familiaridade com tecnologia | Perfil testado |
|---|---|---|---|---|
| Usuário 1 | 45 anos | Ensino básico incompleto | Básico | Cidadão |
| Usuário 2 | 18 anos | Ensino superior incompleto | Avançado | Cidadão |
| Usuário 3 | 70 anos | Ensino básico incompleto | Básico | Cidadão |
| Usuário 4 | 25 anos | Ensino superior completo | Avançado | Funcionário |
| Usuário 5 | 28 anos | Ensino superior completo | Intermediário | Funcionário |

## Registro dos cenários de teste

**Cenário 1: Primeiro acesso (Cidadão)** — O usuário deve acessar o portal, ir à tela de login, clicar em "Criar conta", preencher o formulário de registro, realizar login com as credenciais criadas e simular a recuperação de senha.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** | **Erros Cometidos** | **Feedback do Usuário** |
|---|---|---|---|---|---|
| Usuário 1 | 210 | 18 | Sim | 1 — Esqueceu de preencher o campo "Telefone" e recebeu erro de validação | "Foi fácil, só me confundi num campo que esqueci de preencher." |
| Usuário 2 | 85 | 14 | Sim | 0 | "Bem direto, achei o formulário limpo e rápido." |
| Usuário 3 | 340 | 22 | Sim | 2 — Digitou senha diferente na confirmação; demorou para encontrar o link "Criar conta" | "Demorei um pouco pra achar onde cria a conta, mas depois foi tranquilo." |
| Usuário 4 | 78 | 14 | Sim | 0 | "Interface clara, padrão de login que já conheço." |
| Usuário 5 | 95 | 15 | Sim | 0 | "Gostei do visual do painel esquerdo com as informações da plataforma." |

**Cenário 2: Registro de denúncia** — O cidadão autenticado deve clicar em "Nova denúncia", preencher título, descrição, selecionar categoria e localização, marcar ou não denúncia anônima e enviar.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** | **Erros Cometidos** | **Feedback do Usuário** |
|---|---|---|---|---|---|
| Usuário 1 | 145 | 10 | Sim | 1 — Não selecionou a categoria no dropdown e tentou enviar sem ela | "Entendi os campos, só não vi que a categoria era obrigatória de primeira." |
| Usuário 2 | 60 | 8 | Sim | 0 | "Rápido e objetivo, gostei da opção de denúncia anônima." |
| Usuário 3 | 220 | 13 | Sim | 1 — Tentou digitar a categoria ao invés de selecionar no dropdown | "O formulário é simples, mas eu queria digitar a categoria ao invés de escolher na lista." |
| Usuário 4 | 55 | 8 | Sim | 0 | "Formulário limpo, localização ser opcional é bom." |
| Usuário 5 | 70 | 9 | Sim | 0 | "Fácil de usar, encontrei o botão Nova denúncia rapidamente." |

**Cenário 3: Interação em denúncia** — O usuário deve acessar uma denúncia existente, visualizar as informações detalhadas, enviar uma mensagem e verificar se aparece no histórico.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** | **Erros Cometidos** | **Feedback do Usuário** |
|---|---|---|---|---|---|
| Usuário 1 | 120 | 7 | Sim | 0 | "O chat ficou parecido com WhatsApp, fácil de entender quem mandou cada mensagem." |
| Usuário 2 | 45 | 5 | Sim | 0 | "Intuitivo, as cores diferentes entre cidadão e funcionário ajudam bastante." |
| Usuário 3 | 180 | 9 | Sim | 1 — Não encontrou o botão "Ver detalhes" de imediato, clicou primeiro na linha da tabela | "Demorei pra entender que tinha que clicar nos três pontinhos pra ver os detalhes." |
| Usuário 4 | 40 | 5 | Sim | 0 | "Layout do chat bem organizado, dá pra acompanhar a conversa facilmente." |
| Usuário 5 | 50 | 5 | Sim | 0 | "Gostei que mostra o horário de cada mensagem." |

**Cenário 4: Busca e filtros** — O funcionário deve buscar uma denúncia por palavra-chave, aplicar filtro por categoria e filtro por status.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** | **Erros Cometidos** | **Feedback do Usuário** |
|---|---|---|---|---|---|
| Usuário 1 | 150 | 9 | Sim | 1 — Não percebeu que o filtro de categoria era um dropdown, tentou digitar nele | "Funcionou, mas eu achava que era pra digitar a categoria." |
| Usuário 2 | 40 | 6 | Sim | 0 | "Os filtros são rápidos, a lista atualiza sozinha ao selecionar." |
| Usuário 3 | 200 | 11 | Parcial | 2 — Não conseguiu combinar filtros; ficou confuso com os dropdowns | "Achei difícil usar dois filtros ao mesmo tempo, me perdi um pouco." |
| Usuário 4 | 35 | 6 | Sim | 0 | "Filtros funcionam bem, busca por texto é útil." |
| Usuário 5 | 50 | 7 | Sim | 0 | "Gostei do botão escuro de 'Filtros' que destaca a área de filtragem." |

**Cenário 5: Acesso como funcionário** — O funcionário deve fazer login, visualizar estatísticas, acessar detalhes de uma denúncia, alterar status, responder via mensagem e navegar pelas listas de cidadãos e funcionários.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** | **Erros Cometidos** | **Feedback do Usuário** |
|---|---|---|---|---|---|
| Usuário 1 | 240 | 16 | Sim | 1 — Demorou para perceber que o seletor de status submete automaticamente | "Não sabia que mudar o status já salvava, achei que tinha que clicar em salvar." |
| Usuário 2 | 90 | 12 | Sim | 0 | "Painel administrativo é completo, os cards de estatísticas são visuais." |
| Usuário 3 | 310 | 19 | Parcial | 2 — Não encontrou como alterar status; navegou entre menus com dificuldade | "O menu lateral tem muitas opções, me perdi um pouco entre as telas." |
| Usuário 4 | 75 | 11 | Sim | 0 | "Interface bem organizada, os cards coloridos de estatísticas facilitam a visão geral." |
| Usuário 5 | 100 | 13 | Sim | 0 | "Navegar entre Cidadãos, Denúncias e Funcionários é fácil pelo menu lateral." |

**Cenário 6: Portal de Transparência (acesso público)** — O usuário deve acessar a página inicial sem login, selecionar uma cidade no dropdown, visualizar estatísticas e denúncias, e trocar de cidade.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** | **Erros Cometidos** | **Feedback do Usuário** |
|---|---|---|---|---|---|
| Usuário 1 | 80 | 5 | Sim | 0 | "Muito fácil, já entendi que era pra escolher a cidade e apareceu tudo." |
| Usuário 2 | 30 | 4 | Sim | 0 | "Portal bonito, visual limpo. Os cards com números grandes ajudam muito." |
| Usuário 3 | 130 | 7 | Sim | 1 — Não viu o dropdown de imediato por estar abaixo da seção escura | "Demorei um pouco pra ver a caixinha de escolher a cidade, mas depois funcionou bem." |
| Usuário 4 | 25 | 3 | Sim | 0 | "Excelente a ideia de portal público, sem precisar de cadastro." |
| Usuário 5 | 35 | 4 | Sim | 0 | "Gostei dos cards de denúncias com os badges coloridos de status." |

## Relatório dos Testes de Usabilidade

### Métricas Consolidadas

| Cenário | Taxa de Sucesso | Tempo Médio (seg) | Erros Médios | Taxa de Abandono |
|---|---|---|---|---|
| 1 — Primeiro acesso | 100% | 162 | 0,6 | 0% |
| 2 — Registro de denúncia | 100% | 110 | 0,4 | 0% |
| 3 — Interação em denúncia | 100% | 87 | 0,2 | 0% |
| 4 — Busca e filtros | 80% | 95 | 0,6 | 0% |
| 5 — Acesso como funcionário | 80% | 163 | 0,6 | 0% |
| 6 — Portal de Transparência | 100% | 60 | 0,2 | 0% |

### Principais Dificuldades Identificadas

**Nível Moderado:**
- **Dropdown de "Ver detalhes" (Cenário 3):** O Usuário 3 tentou clicar na linha da tabela para abrir a denúncia, mas o acesso é feito pelo botão "⋮" (três pontos). O padrão de ação oculta em dropdown não é intuitivo para usuários com menor familiaridade tecnológica.
- **Combinação de filtros (Cenário 4):** O Usuário 3 teve dificuldade em usar dois filtros simultaneamente. Os dropdowns submetem a página individualmente, e não ficou claro que os filtros poderiam ser combinados.
- **Seletor de status com submit automático (Cenário 5):** Os Usuários 1 e 3 não perceberam que alterar o dropdown de status já salva automaticamente, esperando um botão "Salvar" explícito.

**Nível Leve:**
- **Link "Criar conta" na tela de login (Cenário 1):** O Usuário 3 demorou para encontrar o link, que está no rodapé do formulário em fonte pequena.
- **Posição do dropdown de cidades no portal (Cenário 6):** O Usuário 3 não viu o dropdown de imediato pois ele fica na transição entre a seção escura do hero e o fundo claro.
- **Número de itens no menu lateral (Cenário 5):** O Usuário 3 relatou se perder entre as 5 opções do menu do funcionário.

### Tarefas Concluídas sem Problemas
- Registro de denúncia (Cenário 2) — todos os usuários concluíram, formulário considerado simples e objetivo.
- Envio de mensagem (Cenário 3) — layout do chat com cores distintas foi elogiado por todos os participantes.
- Portal de Transparência (Cenário 6) — cenário com maior aprovação, menor tempo médio e menor taxa de erros.

### Feedback Qualitativo Recorrente
- Interface visual agradável, com paleta de cores coerente e layout limpo.
- Cards de estatísticas com números grandes e cores distintas facilitam a compreensão rápida.
- Chat com diferenciação visual entre cidadão e funcionário foi bem avaliado.
- A opção de denúncia anônima foi elogiada como diferencial.
- O portal público sem necessidade de login foi o recurso mais elogiado.

### Propostas de Melhorias

| Prioridade | Problema | Proposta |
|---|---|---|
| Moderada | Ação "Ver detalhes" oculta no dropdown "⋮" | Tornar a linha da tabela clicável ou adicionar um botão "Ver" visível diretamente na linha |
| Moderada | Submit automático do seletor de status | Adicionar um botão "Salvar" ao lado do seletor ou exibir um toast de confirmação ao alterar |
| Moderada | Combinação de filtros confusa | Adicionar um botão "Limpar filtros" e indicar visualmente quais filtros estão ativos |
| Leve | Link "Criar conta" pouco visível | Aumentar o destaque do link ou adicionar um botão secundário "Criar conta" na tela de login |
| Leve | Dropdown de cidades no portal | Adicionar uma seta ou animação que direcione o olhar para o dropdown ao carregar a página |

> **Links Úteis**:
> - [Ferramentas de Testes de Usabilidade](https://www.usability.gov/how-to-and-tools/resources/templates.html)
