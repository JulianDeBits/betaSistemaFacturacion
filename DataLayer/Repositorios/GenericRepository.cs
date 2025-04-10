
public class GenericRepository<T> where T {

    private readonly string context;

    public GenericRepository(SistemaFacturacionContext context) {

        context = context
    }

    // FindAll || GetALl

    public async Task<IEnumerable<T>> GetAll() {

        return context.Set<T>().ToListAsync();
    }

    // FindOneById || GetOneById

    // Create

    // Update

    // Delete
}