
public ProductoRepository : GenericRepository {

    private genericRepository

    public ProductoRepository(GenericRepository genericRepository) {
        
        this.genericRepository = genericRepository;
    }
    
    public async Task<Producto> GetAll(){

        return
    }
}