using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrap.Model
{
    internal interface IModelo
    {
        string Precio { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }
        string image { get; set; }
    }
}
