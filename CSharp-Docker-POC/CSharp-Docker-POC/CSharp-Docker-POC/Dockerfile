FROM mcr.microsoft.com/dotnet/aspnet:3.1

COPY bin/Release/netcoreapp3.1/publish/ app/

WORKDIR /app

ENTRYPOINT ["dotnet", "CSharp-Docker-POC.dll"]

CMD ["1"]