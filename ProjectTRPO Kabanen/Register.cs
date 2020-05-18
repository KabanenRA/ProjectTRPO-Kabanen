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
    public partial class Register : Form
    {
        SqlConnection sqlConnection;
        public Register()
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
            if (label2.Visible)
                label2.Visible = false;

            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrEmpty(cashTextBox.Text) && !string.IsNullOrWhiteSpace(cashTextBox.Text) &&
                !string.IsNullOrEmpty(loginTextBox.Text) && !string.IsNullOrWhiteSpace(loginTextBox.Text) &&
                !string.IsNullOrEmpty(passwordTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [User] (Name, Score, Login, Password)VALUES(@Name, @Score, @Login, @Password)", sqlConnection);
                command.Parameters.AddWithValue("Name", nameTextBox.Text);
                command.Parameters.AddWithValue("Score", cashTextBox.Text);
                command.Parameters.AddWithValue("Login", loginTextBox.Text);
                command.Parameters.AddWithValue("Password", passwordTextBox.Text);
                await command.ExecuteNonQueryAsync();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан.");
                    Login log = new Login();
                    log.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан.");
                    nameTextBox.Clear();
                    cashTextBox.Clear();
                    loginTextBox.Clear();
                    passwordTextBox.Clear();
                }
                //sqlConnection.Close();
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Поля 'Name', 'Score', 'Login' и 'Password' должны быть заполнены!";
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            Hide();
        }
    }
}
