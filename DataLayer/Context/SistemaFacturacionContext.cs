using Microsoft.EntityFrameworkCore;

public class SistemaFacturacionContext : DbContext {

    private readonly connString = "Data Source=DESKTOP-4MAIU5B\SQLEXPRESS; Initial Catalog=SistemaFacturacion; Encrypt=true; TrustServerCertificate=true";


    public SistemaFacturacionContext (DbContextOptions<SistemaFacturacionContext> options, string connString){

        connString = connString;
    }

    protected override void DbConfiguring
}