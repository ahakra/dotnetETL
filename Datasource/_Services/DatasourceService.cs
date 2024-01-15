using DataSource.Contracts;

public class DatasourceService:IDatasourceService {
    private readonly IRepositoryManager _repository;
    
    public DatasourceService(IRepositoryManager repository) {
        _repository = repository;
        
    }
 
}

