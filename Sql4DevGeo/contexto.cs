using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql4DevGeo
{
    public class contexto : DbContext
    {
        public contexto() : base("name=ContextoDB") { }

        public DbSet<Loja> Lojas { get; set; }
    }
}
