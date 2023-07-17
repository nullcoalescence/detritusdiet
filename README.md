# detritusdiet
diet in detritus mode idk

## install & run
### install
- dotnet 6 runtime
- visual studio
- docker

### clone repo, install packages
```
$ git clone https://github.com/nullcoalescence/detritusdiet ~/detritusdiet
$ cd ~/detritusdiet
$ dotnet install
```

### configure db
currently I am connecting to a locally hosted sqlserver dev instance. I need to configure an EF provider for a local sqlite db but for now connet to sqlserver.

1. add connection string to appsettings.json
2. store username and password locally in dotnet-secrets

```
$ dotnet user-secrets set "DetritusDietUser:DbUser" "DB_USER"
$ dotnet user-secrets set "DetritusDietSecrets:DbPass" "DB_PASSWORD_HERE"
```

run migrations
```
dotnet ef database update
```

### run in docker
```
$ cd ~/detritusdiet
$ docker build -t detritusdiet -f Dockerfile .
$ docker run -it --rm detritusdiet
```
