# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

```mermaid
classDiagram
direction LR

class Prefeitura_Cidade {
	+int id
	+string nome
	+string uf
}

class Cidadao {
	+int id
	+string nome
	+string email
	+string senha
	+string telefone
    +string cpf
	+bool ativo
    +DateTime criadoEm
	+DateTime atualizadoEm
	+login(email, senha)
	+recuperarSenha(email)
    +registrarDenuncia()
	+acompanharDenuncia()
}

class Funcionario {
    +int id
    +int idCidadao
    +DateTime criadoEm
	+DateTime atualizadoEm
	+atualizarStatusDenuncia()
	+encaminharDenuncia()
}

class Departamento {
	+int id
	+string nome
	+string descricao
    +DateTime criadoEm
	+DateTime atualizadoEm
}

class Denuncia {
	+int id
	+string titulo
	+string descricao
	+DateTime criadoEm
	+DateTime atualizadoEm
	+StatusDenuncia status
	+bool anonima
    +int idCidadao
    +int idDepartamento
	+abrir()
	+atualizarStatus()
}

class Anexo {
	+int id
	+string nomeArquivo
	+string url
	+DateTime criadoEm
    +int idMensagem
}

class Mensagem {
	+int id
	+int idCidadao
    +int idFuncionario
	+string mensagem
	+DateTime criadoEm
    +int idDenuncia
}

class Notificacao {
	+int id
	+int idCidadao
	+string mensagem
	+DateTime criadoEm
	+bool lida
}

class StatusDenuncia {
	<<enumeration>>
	ABERTA
	EM_ANALISE
	ENCAMINHADA
	EM_ATENDIMENTO
	CONCLUIDA
	INDEFERIDA
}

Cidadao <|-- Funcionario

Prefeitura_Cidade "1" *-- "1..*" Departamento : possui

Departamento "1" --> "0..*" Funcionario : lota
Cidadao "1" --> "0..*" Denuncia : cria
Funcionario "0..1" --> "0..*" Denuncia : atende
Departamento "1" --> "0..*" Denuncia : responsavel

Denuncia "1" *-- "0..*" Mensagem : historico
Mensagem "1" *-- "0..*" Anexo : contem
Mensagem "1" --> "1" Cidadao : remetente

Denuncia "1" --> "1" StatusDenuncia : status
Cidadao "1" --> "0..*" Notificacao : recebe
Notificacao "0..*" --> "1" Cidadao : destinatario
Notificacao "0..*" --> "0..1" Denuncia : referente_a
```

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.

A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.

Para mais informações, consulte o microfundamento "Modelagem de Dados".

## ATENÇÃO!!!

Os três artefatos — **Diagrama de Classes, Modelo ER e Projeto da Base de Dados** — devem ser desenvolvidos de forma sequencial e integrada, garantindo total coerência e compatibilidade entre eles. O diagrama de classes orienta a estrutura e o comportamento do software; o modelo ER traduz essa estrutura para o nível conceitual dos dados; e o projeto da base de dados materializa essas definições no formato físico (tabelas, colunas, chaves e restrições). A construção isolada ou desconexa desses elementos pode gerar inconsistências, dificultar a implementação e comprometer a qualidade do sistema.

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
