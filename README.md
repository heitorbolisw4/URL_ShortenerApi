


# URL Shortnet API

## Rodando com Docker

Para construir e iniciar a API:

```bash
docker compose up --build
```

A API ficará disponível em:

```text
http://localhost:5198
```

Para parar os containers:

```bash
docker compose down
```

## Modelo inicial

Class Url

int Id
string LargeUrl
string ShortenedUrl
int Accessed
DATE RecordedAt
