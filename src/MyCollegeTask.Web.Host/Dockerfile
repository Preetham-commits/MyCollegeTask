FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MyCollegeTask.Web.Host/MyCollegeTask.Web.Host.csproj", "src/MyCollegeTask.Web.Host/"]
COPY ["src/MyCollegeTask.Web.Core/MyCollegeTask.Web.Core.csproj", "src/MyCollegeTask.Web.Core/"]
COPY ["src/MyCollegeTask.Application/MyCollegeTask.Application.csproj", "src/MyCollegeTask.Application/"]
COPY ["src/MyCollegeTask.Core/MyCollegeTask.Core.csproj", "src/MyCollegeTask.Core/"]
COPY ["src/MyCollegeTask.EntityFrameworkCore/MyCollegeTask.EntityFrameworkCore.csproj", "src/MyCollegeTask.EntityFrameworkCore/"]
WORKDIR "/src/src/MyCollegeTask.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MyCollegeTask.Web.Host", "src/MyCollegeTask.Web.Host"]
COPY ["src/MyCollegeTask.Web.Core", "src/MyCollegeTask.Web.Core"]
COPY ["src/MyCollegeTask.Application", "src/MyCollegeTask.Application"]
COPY ["src/MyCollegeTask.Core", "src/MyCollegeTask.Core"]
COPY ["src/MyCollegeTask.EntityFrameworkCore", "src/MyCollegeTask.EntityFrameworkCore"]
WORKDIR "/src/src/MyCollegeTask.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyCollegeTask.Web.Host.dll"]
