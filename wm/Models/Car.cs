namespace Webmotors.ViewModels
{
    public class Anuncio_old
    {
        public Models.AnuncioWebmotors Car { get; set; }
        public Models.Ws Ws { get; set; }

        public Anuncio_old()
        {
            Car = new Models.AnuncioWebmotors();
            Ws = new Models.Ws();
        }
    }
}
