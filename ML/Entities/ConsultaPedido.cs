using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Entities
{
    public class ConsultaPedido
    {
        public Pedido Pedido { get; set; }
        public PedidoDetalle PedidoDetalle { get; set; }
    }
}
