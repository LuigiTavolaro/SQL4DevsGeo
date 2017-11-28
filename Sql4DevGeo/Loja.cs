using System.Data.Entity.Spatial;

namespace Sql4DevGeo
{
    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DbGeography Localizacao { get; set; }
    }
}
