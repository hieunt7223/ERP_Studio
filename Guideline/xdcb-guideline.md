# Guideline

## Code 
### 1. Pull code from Server

``` bash
git clone --progress --recursive -v "https://bitbucket.org/toancauxanh/core-service"

cd core-service/aspnet-core

dotnet restore

dotnet build

cd src/xdcb.Web

dotnet run

```

### 2. Update code

``` bash

git pull --recurse-submodules
dotnet run

```

## Style 
### Project
- src/xdcb.Web
    - Static resource (css, js) đặt tại wwwroot của xdcb.Web
    - Themes
- modules/../...Web
    - Pages