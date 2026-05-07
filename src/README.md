# Instruções de utilização

## Instalação do Site

```
cd src/Urbanizze

dotnet build

dotnet run
```

## Criar migration para o banco de dados

```
dotnet ef migrations add InitialCreate
```

## Aplicar as migrations e criar o banco de dados

```
dotnet ef database update
```
