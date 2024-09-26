using System;
using System.Collections.Generic;

namespace yaguachiGrace3A.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            Detalleventa = new HashSet<Detalleventum>();
        }

        public int CodigoVenta { get; set; }
        public string? Cliente { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
    }
}
