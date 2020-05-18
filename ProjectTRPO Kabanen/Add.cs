using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTRPO_Kabanen
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void ProductsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.database1DataSet.Products);

        }

        private void ProductsBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
