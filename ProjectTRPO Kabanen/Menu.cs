using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTRPO_Kabanen
{
    public partial class Menu : Form
    {
        SqlConnection sqlConnection;        
        public Menu()
        {
            InitializeComponent();
        }

        private void ProductsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void BindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\black\source\repos\ProjectTRPO Kabanen\ProjectTRPO Kabanen\Database3.mdf;Integrated Security=True";
            //sqlConnection = new SqlConnection(connectionString);
            //SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [Id]=@Id", sqlConnection);
            //command.Parameters.AddWithValue("Id",this.dataGridViewTextBoxColumn1);
        }

        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Point lastPoint;
        private void ProductsBindingNavigator_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void ProductsBindingNavigator_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.ShowDialog();
        }

        private void ProductsDataGridView_DoubleClick(object sender, EventArgs e)
        {
            Update update = new Update();
            update.ShowDialog();
        }

        private void productsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database3DataSet);

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
