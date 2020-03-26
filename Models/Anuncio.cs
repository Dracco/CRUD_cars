using System.Collections.Generic;

namespace Models
{
    public class Anuncio
    {
        public int ID { get; set; }
        //public string Make { get; set; }
        //public string Model { get; set; }
        //public string Version { get; set; }
        //public string Image { get; set; }
        //public int KM { get; set; }
        //public double Price { get; set; }
        //public int Year { get; set; }
        //public int YearModel { get; set; }
        //public int YearFab { get; set; }
        //public string Color { get; set; }
        //public string Obs { get; set; }
        //public List<Ws> Makes { get; set; }
        //public List<Ws> Models { get; set; }
        //public List<Ws> Versions { get; set; }

        public string marca { get; set; }
        public List<Ws> marcas { get; set; }
        public string modelo { get; set; }
        public List<Ws> modelos { get; set; }
        public string versao { get; set; }
        public List<Ws> versoes { get; set; }
        public int ano { get; set; }
        public int quilometragem { get; set; }
        public string observacao { get; set; }

        public Anuncio()
        {
            marcas = new List<Ws>();
            modelos = new List<Ws>();
            versoes = new List<Ws>();
        }
    }
}
