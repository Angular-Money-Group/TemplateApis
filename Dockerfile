FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/published-app /app
ENV MONGOURL="mongodb+srv://angularmoneygroup:5139bpOk9VR1GeI7@ingressosaqui.t49bdes.mongodb.net/ingressosAqui?retryWrites=true&w=majority"
ENTRYPOINT [ "dotnet", "/app/Amg-Ingressos-aqui-notificacao-api.dll" ]