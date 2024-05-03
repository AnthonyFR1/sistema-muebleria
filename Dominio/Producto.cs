using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contratos;

namespace Dominio
{
    public class Producto:IProductoContrato
    {
        public int IdArticulo { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public Boolean Activo { get; set; }

        public Madera Madera { get; set; }
        public PresentacionProducto PresentacionProducto { get; set; }
        public List<DetalleProducto> ListaDetalleProducto { get; set; }

        public Producto()
        {
            ListaDetalleProducto = new List<DetalleProducto>();
        }

        #region Reglas de negocio
        public bool ValidarStockMinimo()
        {
            bool peligroStock = false;
            foreach (DetalleProducto detalleProducto in ListaDetalleProducto)
            {
                if (detalleProducto.IdDetalleProducto>0)
                {
                    if (detalleProducto.StockMinimo <= 20)
                        peligroStock = true;
                    else
                        peligroStock = false;              
                }   
            }
            return peligroStock;
        }

        #endregion
    }
}
