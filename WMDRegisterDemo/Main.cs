using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMDRegisterDemo.src;
using MySql.Data.MySqlClient;

namespace WMDRegisterDemo
{
    public partial class Main : Form
    {
        Crud crud = new Crud();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Insert
            INSERT();
            READ();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update
            UPDATE();
            READ();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete
            DELETE();
            READ();
        }

        // Read
        public void READ()
        {
            registerDataView.DataSource = null;
            crud.ReadData();
            registerDataView.DataSource = crud.dataTable;
        }

        // Insert
        public void INSERT()
        {
            crud.name = textName.Text;
            crud.cnpj = textCnpj.Text;

            crud.InsertData();
        }

        // Update
        public void UPDATE()
        {
            crud.name = textUpName.Text;
            crud.cnpj = textUpCnpj.Text;
            crud.id = Int32.Parse(lbId.Text);
            crud.UpdateData();
        }

        // Delete
        public void DELETE()
        {
            crud.id = Int32.Parse(lbId.Text);
            crud.DeleteData();
        }

        private void lbId_Click(object sender, EventArgs e)
        {

        }

        private void registerDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get Data
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if(registerDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    lbId.Text = (registerDataView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    textUpName.Text = (registerDataView.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textUpCnpj.Text = (registerDataView.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Não clique no cabeçalho.");
            }
        }
    }
}
