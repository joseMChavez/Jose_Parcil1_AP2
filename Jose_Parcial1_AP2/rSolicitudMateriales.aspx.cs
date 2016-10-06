using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace Jose_Parcial1_AP2
{
    public partial class rSolicitudMateriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (!IsPostBack)
            {
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Material"), new DataColumn("Cantidad") });
                Session["Materiales"] = dt;
            }
        }
        public void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            RazonTextBox.Text = string.Empty;
            DataTable dt = (DataTable)Session["Materiales"];
            //dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Material"), new DataColumn("Cantidad") });
            //Session["Materiales"] = dt;
        }
        public void LlenarDatos(Materiales material)
        {
            int Id = 0;
            int.TryParse(IdTextBox.Text, out Id);
            material.MaterialesId = Id;
            material.Razon = RazonTextBox.Text;
            foreach (GridViewRow fila in MaterialesGridView.Rows)
            {
                material.AgregarMateriales(fila.Cells[0].Text, Convert.ToInt32(fila.Cells[1].Text));
            }

        }
        //public void CargarGrid()
        //{
        //    MaterialesGridView.DataSource = Session["Materiales"];
        //    MaterialesGridView.DataBind();
        //}
        public void DevolverDatos( Materiales material)
        {
            DataTable dt = (DataTable)Session["Materiales"];
            IdTextBox.Text = material.MaterialesId.ToString();
            RazonTextBox.Text = material.Razon;
            foreach (MaterialesDetalle item in material.Detalle)
            {
                dt.Rows.Add(item.Material, item.Cantidad);
                Session["Materiales"] = dt;
                MaterialesGridView.DataSource = dt;
                MaterialesGridView.DataBind();
                
            }
        }
      
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();
            LlenarDatos(material);
            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                if (material.Insertar())
                {
                    Response.Write("Inseto bien");
                }
            }
            else
            {
                if (material.Editar())
                {
                    Response.Write("Modifico bien");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();
            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                LlenarDatos(material);
                if (material.Eliminar())
                {
                    Response.Write("Elimino bien");
                }
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Materiales"];
            dt.Rows.Add(MateriaTextBox.Text, CantidadTextBox.Text);
            Session["Materiales"] = dt;
            MaterialesGridView.DataSource = dt;
            MaterialesGridView.DataBind();
            
            MateriaTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                
                if (material.Buscar(id))
                {
                    DevolverDatos(material);
                    RazonTextBox.Focus();
                    Response.Write("Elimino bien");
                }
            }
        }
    }
}