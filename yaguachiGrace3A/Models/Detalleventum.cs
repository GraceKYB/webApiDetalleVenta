using System;
using System.Collections.Generic;

namespace yaguachiGrace3A.Models
{
    public partial class Detalleventum
    {
        public int CodigoDetalle { get; set; }
        public int? CodigoVenta { get; set; }
        public int? CodigoProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Descuento { get; set; }

        public virtual Producto? CodigoProductoNavigation { get; set; }
        public virtual Ventum? CodigoVentaNavigation { get; set; }
    }
}
