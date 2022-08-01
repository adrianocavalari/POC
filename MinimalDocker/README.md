https://localhost:8001/swagger/index.html

http://localhost:8000/swagger/index.html

run on powershell

docker build . -t minimaldocker

docker run -dt -p 8000:80 -p 8001:443 -v "C:\Users\adria\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro" -v "C:\Users\adria\AppData\Roaming\ASP.NET\Https:/root/.aspnet/https:ro"   -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true" -e "ASPNETCORE_ENVIRONMENT=Development" -e "ASPNETCORE_URLS=https://+:443;http://+:80" --name MinimalDocker minimaldocker


VS generated:
docker run -dt -v "C:\Users\adria\vsdbg\vs2017u5:/remote_debugger:rw" -v "C:\Users\adria\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro" -v "C:\Users\adria\AppData\Roaming\ASP.NET\Https:/root/.aspnet/https:ro" -v "F:\Git\POC\MinimalDocker:/app" -v "F:\Git\POC:/src/" -v "C:\Users\adria\.nuget\packages\:/root/.nuget/fallbackpackages" -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true" -e "ASPNETCORE_ENVIRONMENT=Development" -e "ASPNETCORE_URLS=https://+:443;http://+:80" -e "DOTNET_USE_POLLING_FILE_WATCHER=1" -e "NUGET_PACKAGES=/root/.nuget/fallbackpackages" -e "NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages" -P --name MinimalDocker --entrypoint tail minimaldocker:dev -f /dev/null 
