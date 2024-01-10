
.PHONY: all build clean


containers:
	docker-compose up -d


buildEntities:
	dotnet build SharedEntities/SharedEntities.sln --configuration Release  --output sharedEntitiesDll


