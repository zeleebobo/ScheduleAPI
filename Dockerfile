#FROM microsoft/aspnetcore-build:2.0.0 AS build
#WORKDIR /code
#COPY . .
#RUN dotnet restore ./ScheduleApi.sln
#RUN dotnet publish ./ScheduleApi.sln --output /output --configuration Release

FROM microsoft/aspnetcore-build:2.0.3 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY  ScheduleApi.sln ./
RUN dotnet restore ./ScheduleApi.sln

# Copy everything else and build
COPY . ./
RUN dotnet publish ./ScheduleApi.sln -c Release -o out

FROM microsoft/aspnetcore:2.0.3
WORKDIR /app
COPY --from=build-env /app/App/out .

RUN dotnet ef migrations add init
RUN dotnet ef database update

ENTRYPOINT [ "dotnet", "App.dll" ]
CMD ["ipconfig"]