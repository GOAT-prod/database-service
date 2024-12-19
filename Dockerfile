FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Установим рабочую директорию внутри контейнера
WORKDIR /app
COPY . .
EXPOSE 80
WORKDIR /app/database-service

RUN dotnet restore
RUN dotnet publish -c Release -o ./out

# Создаем финальный образ на основе runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 
EXPOSE 80
# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем собранное приложение из предыдущего образа
COPY --from=build-env /app/database-service/out .

# Указываем порт, который будет использоваться контейнером
ENV ASPNETCORE_HTTP_PORTS 80

# Команда по умолчанию для запуска приложения
ENTRYPOINT ["dotnet", "database-service.dll"]
