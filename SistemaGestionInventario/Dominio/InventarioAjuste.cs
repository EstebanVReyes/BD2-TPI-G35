using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class InventarioAjuste
    {


        public int IdDetalle { get; set; }
        public string SKU { get; set; }

        public int StockSistema { get; set; }
        public int StockFisico { get; set; }

        public int Diferencia
        {
            get { return StockFisico - StockSistema; }
        }

    }
}
