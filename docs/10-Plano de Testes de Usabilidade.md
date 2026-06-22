# Plano de Testes de Usabilidade

Este plano de testes refere-se ao sistema Urbanizze, uma plataforma digital desenvolvida para facilitar a comunicação entre a população e as prefeituras, permitindo o registro e acompanhamento de problemas urbanos como buracos em vias, falta de iluminação pública, lixo acumulado, entre outros. O sistema também inclui um portal público de transparência para que qualquer pessoa possa acompanhar as denúncias por cidade.

## Definição do(s) objetivo(s)

Antes de iniciar os testes, é essencial definir o que se deseja avaliar na usabilidade do sistema.
Neste projeto, os objetivos são:

    • Verificar se os usuários conseguem utilizar o sistema de forma intuitiva e sem dificuldades significativas.

    • Avaliar a facilidade de cadastro e autenticação (login, registro e recuperação de senha).

    • Identificar possíveis dificuldades no processo de criação de denúncias.

    • Avaliar a eficiência da comunicação entre cidadãos e funcionários por meio das mensagens na denúncia.

    • Verificar a compreensão dos diferentes perfis de acesso (cidadão e funcionário).

    • Testar a usabilidade das funcionalidades de busca e filtros de denúncias.

    • Avaliar a navegabilidade do portal público de transparência.

## Seleção dos participantes

Para garantir que o teste reflita o uso real do sistema, foram definidos participantes representativos do público-alvo.
Critérios para selecionar participantes:
    • Usuários comuns (cidadãos), incluindo moradores de áreas urbanas e regiões de risco.
    • Funcionários vinculados a prefeituras ou departamentos responsáveis pela análise de denúncias.
    • Diferentes níveis de familiaridade com tecnologia.

    • Quantidade recomendada:
Mínimo: 5 participantes.
Ideal: Entre 8 e 12 participantes.

## Definição de cenários de teste

Os cenários representam tarefas reais que os usuários executam no sistema. Neste projeto, foram definidos seis cenários principais:

Cenário 1: Primeiro acesso (Cidadão)

Objetivo: Avaliar funcionalidades de cadastro, login e recuperação de senha.

Contexto: Um novo usuário acessa a plataforma pela primeira vez e precisa criar uma conta para utilizar o sistema.

Tarefa(s):
    • Acessar a tela de login a partir do portal.
    • Clicar em "Criar conta" e preencher o formulário de registro como cidadão.
    • Realizar login com as credenciais criadas.
    • Simular recuperação de senha informando e-mail e nova senha.

Critério(s) de Sucesso(s):
    • O usuário consegue criar a conta sem dificuldades.
    • O login é realizado corretamente e redireciona ao painel do cidadão.
    • O processo de recuperação de senha é compreendido e concluído.
    • As ações são concluídas sem necessidade de ajuda.

Cenário 2: Registro de denúncia

Objetivo: Avaliar o processo de criação de denúncias.

Contexto: O cidadão autenticado deseja registrar um problema urbano, como um buraco na rua ou falta de iluminação.

Tarefa(s):
    • Clicar em "Nova denúncia" na lista de denúncias.
    • Preencher título e descrição do problema.
    • Selecionar a categoria (departamento) e a localização.
    • Marcar ou desmarcar a opção de denúncia anônima.
    • Enviar a denúncia.

Critério(s) de Sucesso(s):
    • A denúncia é registrada corretamente com status "Aberto".
    • O usuário compreende os campos obrigatórios e opcionais.
    • A denúncia aparece na lista após o envio.
    • O processo é concluído de forma rápida e clara.

Cenário 3: Interação em denúncia

Objetivo: Avaliar a comunicação entre cidadão e funcionário dentro de uma denúncia.

Contexto: O cidadão deseja acompanhar uma denúncia já registrada e trocar mensagens com o funcionário responsável.

Tarefa(s):
    • Acessar uma denúncia existente pela lista.
    • Visualizar as informações da denúncia (cidadão, categoria, localização, data, descrição).
    • Enviar uma mensagem na área de comunicação.
    • Verificar se a mensagem aparece no histórico com nome e horário.

Critério(s) de Sucesso(s):
    • O usuário consegue acessar os detalhes da denúncia.
    • A mensagem é enviada com sucesso e aparece no histórico.
    • O layout do chat é compreensível (mensagens do cidadão à esquerda, do funcionário à direita).

Cenário 4: Busca e filtros

Objetivo: Avaliar funcionalidades de pesquisa e filtragem de denúncias.

Contexto: O funcionário precisa localizar denúncias específicas na lista.

Tarefa(s):
    • Buscar uma denúncia por palavra-chave no campo de busca.
    • Aplicar filtro por categoria (departamento).
    • Aplicar filtro por status (Abertos, Em andamento, Resolvidos).

Critério(s) de Sucesso(s):
    • A busca retorna resultados relevantes.
    • Os filtros atualizam a lista corretamente.
    • O usuário encontra a informação desejada com facilidade.

Cenário 5: Acesso como funcionário

Objetivo: Avaliar funcionalidades administrativas e a diferenciação de perfis.

Contexto: Um funcionário da prefeitura acessa o sistema para gerenciar denúncias e visualizar informações do sistema.

Tarefa(s):
    • Acessar o sistema com perfil de funcionário.
    • Visualizar a lista de denúncias com estatísticas (Total, Abertas, Em Análise, Resolvidas).
    • Acessar detalhes de uma denúncia e alterar seu status.
    • Responder uma denúncia via mensagem.
    • Visualizar a lista de usuários e a lista de cidadãos.

Critério(s) de Sucesso(s):
    • O funcionário acessa corretamente o painel administrativo.
    • As denúncias e estatísticas são visualizadas sem dificuldade.
    • A alteração de status é realizada com sucesso.
    • As diferenças entre os perfis de cidadão e funcionário são compreendidas.

Cenário 6: Portal de Transparência (acesso público)

Objetivo: Avaliar a usabilidade do portal público de transparência, acessível sem login.

Contexto: Um cidadão que não possui conta no sistema deseja consultar as denúncias da sua cidade.

Tarefa(s):
    • Acessar a página inicial do sistema (rota /).
    • Verificar que o portal carrega sem exigir login.
    • Selecionar uma cidade no dropdown.
    • Visualizar os cards de estatísticas (Total, Abertas, Em Análise, Resolvidas).
    • Navegar pelos cards de denúncias da cidade selecionada.
    • Trocar para outra cidade e verificar a atualização dos dados.

Critério(s) de Sucesso(s):
    • O portal é acessado sem necessidade de autenticação.
    • O dropdown de cidades é intuitivo e funcional.
    • As estatísticas e denúncias são exibidas corretamente para a cidade selecionada.
    • O estado vazio ("Selecione uma cidade") é compreendido pelo usuário.
    • A troca de cidade atualiza os dados sem dificuldade.

## Métodos de coleta de dados

Os dados coletados devem ajudar a entender a experiência dos usuários.
Serão utilizadas:

    • Métricas quantitativas:
        ◦ Taxa de sucesso nas tarefas
        ◦ Tempo de execução
        ◦ Número de erros
        ◦ Taxa de abandono

    • Métricas qualitativas:
        ◦ Nível de dificuldade percebida
        ◦ Clareza da interface
        ◦ Satisfação do usuário

Além disso, será utilizado o método Think Aloud (pensar em voz alta), com testes moderados, realizados presencialmente ou remotamente, com duração de 20 a 30 minutos por participante.

Também serão aplicadas perguntas pós-teste para coleta de feedback.
Para cada participante, os dados serão coletados respeitando a LGPD, sem identificação de informações sensíveis.
