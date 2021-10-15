using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hopp
{
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void AddNewUserButton_Click(object sender, EventArgs e)
        {
            String query = "insert into UsersDB(Login,Password) values('"+ newlogBox.Text + "','" + newpassBox.Text + "');";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            MySqlDataReader rd;
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка добавления новой записи пользователя");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
