using Microsoft.EntityFrameworkCore;

public class ConnectionContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = 
                    "Server=localhost;" +
                    "Database=CRUD_API;" +
                    "User=SA;" +
                    "Password=992534@Tx;" +
                    "Encrypt=false;TrustServerCertificate=true;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        
    }

    