FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Установим рабочую директорию внутри контейнера
WORKDIR /app
EXPOSE 80
COPY . ./
WORKDIR /app/database-service

RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# Создаем финальный образ на основе runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем собранное приложение из предыдущего образа
COPY --from=build-env /app/out .

# Указываем порт, который будет использоваться контейнером
EXPOSE 80
EXPOSE 443

# Команда по умолчанию для запуска приложения
ENTRYPOINT ["dotnet", "database-service.dll"]
