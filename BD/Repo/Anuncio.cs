using System.Collections.Generic;
using System.Linq;

namespace BD.Repo
{
    public class Anuncio
    {
        public List<Models.Anuncio> Consultar()
        {
            using (var db = new MainContextFactory().CreateDbContext(null))
            {
                return db.tb_Anuncio.ToList();
            }
        }
        public Models.Anuncio Consultar(int id)
        {
            using (var db = new MainContextFactory().CreateDbContext(null))
            {
                return db.tb_Anuncio.Where(x => x.ID == id).FirstOrDefault();
            }
        }
        public void Incluir(Models.Anuncio car)
        {
            using (var db = new MainContextFactory().CreateDbContext(null))
            {
                db.tb_Anuncio.Add(car);
                db.SaveChanges();
            }
        }
        public void Atualizar(Models.Anuncio car)
        {
            using (var db = new MainContextFactory().CreateDbContext(null))
            {
                db.tb_Anuncio.Update(car);
                db.SaveChanges();
            }
        }
        public void Remover(Models.Anuncio car)
        {
            using (var db = new MainContextFactory().CreateDbContext(null))
            {
                db.tb_Anuncio.Remove(car);
                db.SaveChanges();
            }
        }
    }
}
