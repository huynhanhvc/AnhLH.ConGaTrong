FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

COPY . .
COPY nuget.config ./
RUN dotnet restore "/host/AnhLH.ConGaTrong.HttpApi.Host/AnhLH.ConGaTrong.HttpApi.Host.csproj" --configfile nuget.config -nowarn:msb3202,nu1503 --force

RUN dotnet publish "/host/AnhLH.ConGaTrong.HttpApi.Host/AnhLH.ConGaTrong.HttpApi.Host.csproj" --no-restore -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV TZ=Asia/Ho_Chi_Minh
WORKDIR /app
COPY --from=build-env /out /app
ENTRYPOINT ["dotnet", "AnhLH.ConGaTrong.HttpApi.Host.dll"]