using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Movimiento
    {

        public int Id { get; set; }
        public int IdDetalle { get; set; }
        public int IdDeposito { get; set; }

        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public int IdTipoMovimiento { get; set; }

    }
}
