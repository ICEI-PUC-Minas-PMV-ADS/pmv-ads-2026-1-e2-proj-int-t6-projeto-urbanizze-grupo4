# Projeto de Interface

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Visão geral da interação do usuário pelas telas do sistema e protótipo interativo das telas com as funcionalidades que fazem parte do sistema (wireframes).

Apresente as principais interfaces da plataforma. Discuta como ela foi elaborada de forma a atender os requisitos funcionais, não funcionais e histórias de usuário abordados nas <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a>.

## Diagrama de Fluxo

O diagrama apresenta o estudo do fluxo de interação do usuário com o sistema interativo e muitas vezes sem a necessidade do desenho do design das telas da interface. Isso permite que o design das interações seja bem planejado e gere impacto na qualidade no design do wireframe interativo que será desenvolvido logo em seguida.

```mermaid
flowchart TB
		start([Acesso a plataforma]) --> home[Tela inicial]
		home --> choose{Perfil de acesso}

		choose -- Visitante --> guest[Explorar denuncias publicas]
		guest --> filtro[Pesquisar e filtrar denuncias]
		filtro --> convite{Quer registrar denuncia?}
		convite -- Sim --> cadastro[Criar conta]
		convite -- Nao --> guest

		choose -- Cidadao --> loginCid[Login do cidadao]
		choose -- Funcionario --> loginFunc[Login do funcionario]
		cadastro --> loginCid

		subgraph Jornada_Cidadao
			direction TB
			loginCid --> dashCid[Painel do cidadao]
			dashCid --> acaoCid{O que deseja fazer?}

			acaoCid -- Nova denuncia --> nova[Formulario de denuncia]
			nova --> dados[Preencher titulo, descricao e local]
			dados --> anexar[Adicionar fotos e anexos]
			anexar --> anon{Enviar anonimamente?}
			anon -- Sim --> enviarAnon[Enviar denuncia anonima]
			anon -- Nao --> enviarId[Enviar denuncia identificada]
			enviarAnon --> listaMinhas[Minhas denuncias]
			enviarId --> listaMinhas

			acaoCid -- Acompanhar denuncia --> listaMinhas
			listaMinhas --> detalheCid[Detalhe da denuncia]
			detalheCid --> status[Ver status atualizado]
			detalheCid --> chatCid[Enviar/ler mensagens]
			detalheCid --> notifCid[Receber notificacoes]

			acaoCid -- Editar perfil --> perfilCid[Tela de perfil]
			acaoCid -- Recuperar senha --> recCid[Fluxo recuperar senha]
			recCid --> loginCid
		end

		subgraph Jornada_Funcionario
			direction TB
			loginFunc --> dashFunc[Painel de atendimento]
			dashFunc --> fila[Lista de denuncias por filtro]
			fila --> detalheFunc[Detalhe da denuncia]
			detalheFunc --> analisar[Analisar denuncia]
			analisar --> decisao{Denuncia apta?}
			decisao -- Sim --> encaminhar[Encaminhar para setor responsavel]
			decisao -- Nao --> indeferir[Indeferir com justificativa]
			encaminhar --> atualizar[Atualizar status]
			atualizar --> chatFunc[Responder mensagens do cidadao]
			chatFunc --> concluir{Resolvida?}
			concluir -- Sim --> fechar[Concluir denuncia]
			concluir -- Nao --> manter[Manter em atendimento]
			manter --> atualizar
			indeferir --> notFunc[Disparar notificacao]
			fechar --> notFunc
			acaoAdm[Gerenciar departamentos e funcionarios] --> dashFunc
		end

		enviarAnon --> fila
		enviarId --> fila
		chatCid <--> chatFunc
		notFunc --> notifCid
		status --> fim([Encerramento da jornada])

```

> **Links Úteis**:
>
> - [Fluxograma online: seis sites para fazer gráfico sem instalar nada | Produtividade | TechTudo](https://www.techtudo.com.br/listas/2019/03/fluxograma-online-seis-sites-para-fazer-grafico-sem-instalar-nada.ghtml)

## Wireframes

![Exemplo de Wireframe](img/wireframe-example.png)

Os wireframes são protótipos utilizados no design de interfaces para representar a estrutura de um site e o relacionamento entre suas páginas. Eles funcionam como ilustrações do layout e da disposição dos elementos essenciais da interface.

Nesta seção, é FUNDAMENTAL indicar, para cada tela/wireframe proposto, quais requisitos do projeto estão sendo contemplados por aquela tela.

> **Links Úteis**:
>
> - [Protótipos vs Wireframes](https://www.nngroup.com/videos/prototypes-vs-wireframes-ux-projects/)
> - [Ferramentas de Wireframes](https://rockcontent.com/blog/wireframes/)
> - [MarvelApp](https://marvelapp.com/developers/documentation/tutorials/)
> - [Figma](https://www.figma.com/)
> - [Adobe XD](https://www.adobe.com/br/products/xd.html#scroll)
> - [Axure](https://www.axure.com/edu) (Licença Educacional)
> - [InvisionApp](https://www.invisionapp.com/) (Licença Educacional)
