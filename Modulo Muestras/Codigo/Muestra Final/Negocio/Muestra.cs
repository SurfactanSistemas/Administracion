using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassConexion;
using System.Data;

namespace Negocio
{
    public class Muestra
    {
        Conexion ce = new Conexion();
        int _Codigo;

        public int Codigo 
        {
            set { _Codigo = value; }
            get { return _Codigo; }
        }

        char _Producto;

        public char Producto
        {
            set { _Producto = value; }
            get { return _Producto; }
        }

        char _Articulo;

        public char Articulo
        {
            set { _Articulo = value; }
            get { return _Articulo; }
        }
        
        char _Ensayo;

        public char Ensayo
        {
            set { _Ensayo = value; }
            get { return _Ensayo; }
        }

        char _Nombre;

        public char Nombre
        {
            set { _Nombre = value; }
            get { return _Nombre; }
        }

        char _Fecha;

        public char Fecha
        {
            set { _Fecha = value; }
            get { return _Fecha; }
        }

        char _OrdFecha;

        public char OrdFecha
        {
            set { _OrdFecha = value; }
            get { return _OrdFecha; }
        }

        char _Cantidad;

        public char Cantidad
        {
            set { _Cantidad = value; }
            get { return _Cantidad; }
        }

        char _Cliente;

        public char Cliente
        {
            set { _Cliente = value; }
            get { return _Cliente; }
        }

        char _Razon;

        public char Razon
        {
            set { _Razon = value; }
            get { return _Razon; }
        }

        char _DescriCliente;

        public char DescriCliente
        {
            set { _DescriCliente = value; }
            get { return _DescriCliente; }
        }

        int _Vendedor;

        public int Vendedor
        {
            set { _Vendedor = value; }
            get { return _Vendedor; }
        }

        char _DesVendedor;

        public char DesVendedor
        {
            set { _DesVendedor = value; }
            get { return _DesVendedor; }
        }

        char _Obervaciones;

        public char Obervaciones
        {
            set { _Obervaciones = value; }
            get { return _Obervaciones; }
        }

        char _Producto2;

        public char Producto2
        {
            set { _Producto2 = value; }
            get { return _Producto2; }
        }

        char _Articulo2;
        
        public char Articulo2
        {
            set { _Articulo2 = value; }
            get { return _Articulo2; }
        }

        char _Ensayo2;

        public char Ensayo2
        {
            set { _Ensayo2 = value; }
            get { return _Ensayo2; }
        }

        char _Nombre2;

        public char Nombre2
        {
            set { _Nombre2 = value; }
            get { return _Nombre2; }
        }

        char _Fecha2;

        public char Fecha2
        {
            set { _Fecha2 = value; }
            get { return _Fecha2; }
        }

        char _OrdFecha2;

        public char OrdFecha2
        {
            set { _OrdFecha2 = value; }
            get { return _OrdFecha2; }
        }

        char _Cantidad2;

        public char Cantidad2
        {
            set { _Cantidad2 = value; }
            get { return _Cantidad2; }
        }

        char _Lote2;

        public char Lote2
        {
            set { _Lote2 = value; }
            get { return _Lote2; }
        }

        char _Observaciones2;

        public char Observaciones2
        {
            set { _Observaciones2 = value; }
            get { return _Observaciones2; }
        }

        int _Stock2;

        public int Stock2
        {
            set { _Stock2 = value; }
            get { return _Stock2; }
        }

        char _Autoriza;

        public char Autoriza
        {
            set { _Autoriza = value; }
            get { return _Autoriza; }
        }

        char _Impresion;

        public char Impresion
        {
            set { _Impresion = value; }
            get { return _Impresion; }
        }

        int _Pedido;

        public int Pedido
        {
            set { _Pedido = value; }
            get { return _Pedido; }
        }

        int _Remito;

        public int Remito
        {
            set { _Remito = value; }
            get { return _Remito; }
        }

        char _ClaveStock;

        public char ClaveStock
        {
            set { _ClaveStock = value; }
            get { return _ClaveStock; }
        }

        int _DirEntrega;

        public int DirEntrega
        {
            set { _DirEntrega = value; }
            get { return _DirEntrega; }
        }

        char _DescriDirEntrega;

        public char DescriDirEntrega
        {
            set { _DescriDirEntrega = value; }
            get { return _DescriDirEntrega; }
        }

        int _OrdenTrabajo;

        public int OrdenTrabajo
        {
            set { _OrdenTrabajo = value; }
            get { return _OrdenTrabajo; }
        }

        char _Peligroso;

        public char Peligroso
        {
            set { _Peligroso = value; }
            get { return _Peligroso; }
        }

        char _Peligroso2;

        public char Peligroso2
        {
            set { _Peligroso2 = value; }
            get { return _Peligroso2; }
        }

        int _HojaRuta;

        public int HojaRuta
        {
            set { _HojaRuta = value; }
            get { return _HojaRuta; }
        }

        int _Partida;

        public int Partida
        {
            set { _Partida = value; }
            get { return _Partida; }
        }

        char _ClavePedido;

        public char ClavePedido
        {
            set { _ClavePedido = value; }
            get { return _ClavePedido; }
        }

        public void ActualizarMuestra(string consulta)
        {
            ce.ActualizarMuestraLab(consulta);
        }

        public DataTable TraerLista(string desde, string hasta)
        {
            return ce.TraerLista(desde, hasta);
        }
    }
}
