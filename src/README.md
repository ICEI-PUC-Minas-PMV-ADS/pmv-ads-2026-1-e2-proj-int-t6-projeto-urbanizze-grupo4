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

## Renomear tag docker

```
docker tag pmv-ads-2026-1-e2-proj-int-t6-projeto-urbanizze-grupo4-app:latest andrecabral21/pmv-ads-2026-1-e2-proj-int-t6-projeto-urbanizze-grupo4-app:latest
```

## Subir imagem para o docker hub

```
docker push andrecabral21/pmv-ads-2026-1-e2-proj-int-t6-projeto-urbanizze-grupo4-app:latest
```
