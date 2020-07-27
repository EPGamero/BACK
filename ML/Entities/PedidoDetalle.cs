using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class PedidoDetalle
    {
        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

    }
}
