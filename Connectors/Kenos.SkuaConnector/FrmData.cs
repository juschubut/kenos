using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.IO;

namespace Kenos.SkuaConnector
{
    public partial class FrmData : Form
    {
        public SkuaMetadata MetadataResult { get; set; }
        

        public FrmData()
        {
            InitializeComponent();
        }

        #region Eventos


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();     
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
            Buscar();

            GridAudiencias.Columns[0].Visible = false;
            GridAudiencias.Columns[1].Width = 90;
            GridAudiencias.Columns[2].Width = 50;
            GridAudiencias.Columns[3].Width = 200;
            GridAudiencias.Columns[4].Width = 300;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.GridAudiencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una audiencia","Kenos - Skua",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow dr = this.GridAudiencias.SelectedRows[0];
                        
            this.MetadataResult = new SkuaMetadata();
            
            this.MetadataResult.IdAudiencia = ConvertirAEntero(dr.Cells["IdAudiencia"].Value.ToString());
            this.MetadataResult.Etiqueta = dr.Cells["Etiqueta"].Value.ToString();
            this.MetadataResult.Caratula = dr.Cells["Caratula"].Value.ToString();
            this.MetadataResult.Descripcion =  dr.Cells["Tipo"].Value.ToString();        
            
            /*Fin Prueba*/
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Metodos Locales
        private void Buscar() {
            int nroCarpeta = ConvertirAEntero(txtCarpJud.Text);
            int nroSolicitud = ConvertirAEntero(txtSolJur.Text);
            int nroCooperacion = ConvertirAEntero(txtCoopJud.Text);
            int nroIncidente = ConvertirAEntero(txtInc.Text);
            int nroSolicitudInc = ConvertirAEntero(txtSolJurInc.Text);

            String strConnString = Properties.Settings.Default.Conexion;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pAudienciaPendienteGrabacion";
                cmd.Parameters.Add("@NroCarpeta", SqlDbType.Int).Value = nroCarpeta;
                cmd.Parameters.Add("@NroSolicitud", SqlDbType.Int).Value = nroSolicitud;
                cmd.Parameters.Add("@NroCooperacion", SqlDbType.Int).Value = nroCooperacion;
                cmd.Parameters.Add("@NroIncidente", SqlDbType.Int).Value = nroIncidente;
                cmd.Parameters.Add("@NroSolicitudInc", SqlDbType.Int).Value = nroSolicitudInc;
                cmd.Connection = con;

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;

                GridAudiencias.DataSource = bsource;
                GridAudiencias.AutoGenerateColumns = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


        private int ConvertirAEntero(string numero) {
            int entero;
            try
            {
                entero = Convert.ToInt32(numero);
            }
            catch (Exception e) {
                entero = 0;
            }
            return entero;
        }

        #endregion
    }
}
