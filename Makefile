
.PHONY: all build clean


containers:
	docker-compose up -d


buildEntities:
	dotnet build SharedEntities/SharedEntities.sln --configuration Release  --output DLL/sharedEntitiesDll

buildServiceMesh:
	dotnet build ServiceMesh/ServiceMesh/ServiceMesh.csproj

buildDataSource:
	dotnet build Datasource/Datasource.sln
# 	dotnet build  Datasource/DataSource.Api
# 	dotnet build  Datasource/DataSource.Entities
# 	dotnet build  Datasource/DataSource.Contracts
# 	dotnet build  Datasource/Datasource.Services

runDataSource:
	dotnet run --project Datasource/DataSource/DataSource.csproj

runServiceMesh:
	dotnet run --project ServiceMesh/ServiceMesh/ServiceMesh.csproj

