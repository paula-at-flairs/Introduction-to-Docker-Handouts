#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Step 1/4: pull aspnet:3.1-buster-slim runtime container, [aspnet] is used for deploying AspNet Core apps, version [3.1], [-buster-slim] debian base OS
# Name the step "base"
# Expose port 80 (inside the container) [just for documentation]
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

# Step 2/4: pull sdk:3.1-buster runtime container, [sdk] is used for building any dot net core app, version [3.1], [-buster] debian base OS
# Name the step "build"
# copy .csproj files and restore the packages
# copy everything else
# move inside the SimpleWebAppDockerPOC then build the project
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WhalesAPI/WhalesAPI.csproj", "WhalesAPI/"]
RUN dotnet restore "WhalesAPI/WhalesAPI.csproj"
COPY . .
WORKDIR "/src/WhalesAPI"
RUN dotnet build "WhalesAPI.csproj" -c Release -o /app/build

# Step 3/4: continue from the previous step, use the builder container
# Name the step "publish"
# run the publishing command
FROM build AS publish
RUN dotnet publish "WhalesAPI.csproj" -c Release -o /app/publish

# Step 4/4: use the aspnet container from step 1
# Revert back the working directory to /app where SimpleWebAppDockerPOC.dll was published 
# Copy the contents of the publish folder from the container [publish] / step 3 to the /app folder
# run the application using ENTRYPOINT command (utilizing the aspnet runtime container fetched from step 1)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhalesAPI.dll"]

# Also note the .dockerignore file that was auto generated too, helps in reducing the final container size
# for the optimum production environment.