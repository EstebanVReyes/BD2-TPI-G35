using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class DetalleArticulo
    {

        public int IdDetalle { get; set; }
        public int IdArticulo { get; set; }

        public string SKU { get; set; }
        public decimal Precio { get; set; }

    }
}
