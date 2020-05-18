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
    public partial class Login : Form
    {
        SqlConnection sqlConnection;
        public Login()
        {
            InitializeComponent();
        }
        Point lastPoint;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\black\source\repos\ProjectTRPO Kabanen\ProjectTRPO Kabanen\Database3.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE [Login] = @Login AND [Password] = @Password", sqlConnection);
            command.Parameters.AddWithValue("Login", loginTextBox.Text);
            command.Parameters.AddWithValue("Password", passwordTextBox.Text);
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);
            await command.ExecuteNonQueryAsync();
            if (dataTable.Rows.Count>0)
            {
                Menu menu = new Menu();
                menu.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Авторизация не удалась.");
                loginTextBox.Clear();
                passwordTextBox.Clear();
            }
            sqlConnection.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Hide();
        }
    }
}
