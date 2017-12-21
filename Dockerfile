FROM microsoft/aspnetcore-build:2.0.3 AS build-env
WORKDIR /app

COPY  ScheduleApi.sln ./
RUN dotnet restore ./ScheduleApi.sln

COPY . ./
RUN dotnet publish ./ScheduleApi.sln -c Release -o out
CMD dotnet ef migrations add init && dotnet ef database update




FROM microsoft/aspnetcore:2.0.3
#ENV ASPNETCORE_URLS="http://*:5000"
WORKDIR /app
COPY --from=build-env /app/App/out .

#ENTRYPOINT [ "dotnet", "App.dll" ]
CMD ASPNETCORE_URLS=http://*:$PORT HEROKU_STRING=$DATABASE_URL dotnet App.dll