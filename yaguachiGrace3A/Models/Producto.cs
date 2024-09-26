using System;
using System.Collections.Generic;

namespace yaguachiGrace3A.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalleventa = new HashSet<Detalleventum>();
        }

        public int CodigoProducto { get; set; }
        public string? NombreProducto { get; set; }
        public decimal? PrecioProducto { get; set; }

        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
    }
}
