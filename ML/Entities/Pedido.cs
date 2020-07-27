using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal MontoPedido { get; set; }
        public DateTime Fecha { get; set; }
    }
}
