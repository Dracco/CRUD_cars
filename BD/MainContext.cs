using Microsoft.EntityFrameworkCore;

namespace BD
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        public DbSet<Models.Anuncio> tb_Anuncio { get; set; }



        public void Dispose()
        {

        }
    }
}
