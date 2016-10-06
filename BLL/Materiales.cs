using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Materiales : ClaseMaestra
    {
        public int MaterialesId { get; set; }
        public string Razon { get; set; }
        public List<MaterialesDetalle> Detalle { get; set; }
        public Materiales()
        {
            this.MaterialesId = 0;
            this.Razon = "";
            this.Detalle = new List<MaterialesDetalle>();
        }
        public void AgregarMateriales(string material, int cantidad)
        {
            Detalle.Add(new MaterialesDetalle(material, cantidad));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            try
            {
                int.TryParse(conexion.ObtenerValor(string.Format("insert into Materiales(Razon) values('{0}'); scope_identity()", this.Razon)).ToString(), out retorno);
                
                if (retorno>0)
                {
                    foreach (MaterialesDetalle material in Detalle)
                    {
                        conexion.Ejecutar(string.Format("insert into MaterialesDetalle(MatrialesId,Materia,Cantidad) values({0},'{1}',{2})",retorno,material.Material,material.Cantidad));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("update Materiales set Razon='{0}' where MaterialesId={1}", this.Razon, this.MaterialesId));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("delete from MaterialesDetalle where MaterialesId={0}", this.MaterialesId));
                    foreach (MaterialesDetalle material in Detalle)
                    {
                        conexion.Ejecutar(string.Format("insert into MaterialesDetalle(MatrialesId,Material,Cantidad) values({0},'{1}',{2})", this.MaterialesId, material.Material, material.Cantidad));
                    }
                }
            }
            catch (Exception ex)
            {

                lthrow ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                
                  retorno = conexion.Ejecutar(string.Format("delete from MaterialesDetalle where MaterialesId={0};" + "delete from Materiales where MaterialesId={0}", this.MaterialesId));
                   
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable detalle = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Materiales where MaterialesId={0}",IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.MaterialesId = (int)dt.Rows[0]["MaterialesId"];
                    this.Razon = dt.Rows[0]["Razon"].ToString();

                    detalle = conexion.ObtenerDatos(string.Format("select * from MaterialesDetalle where MaterialesId={0}", IdBuscado));
                    foreach (DataRow row in detalle.Rows)
                    {
                        AgregarMateriales(row["Material"].ToString(), (int)row["Cantidad"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt.Rows.Count > 0;
        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            return dt = conexion.ObtenerDatos(string.Format("select " + Campos + " from Materiales where" + Condicion + "" + Orden));
        }
    }
}
