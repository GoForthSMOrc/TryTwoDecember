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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int Count = 0;
            String query = "select count(*) from UsersDB where Login = '" + logBox.Text + "' and Password = '" + passBox.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                Count = Convert.ToInt32(cmDB.ExecuteScalar());
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка авторизации");
                MessageBox.Show(ex.Message);
            }
            if(Count > 0)
            {
                MainMenu win = new MainMenu();
                win.Show();
                this.Hide();
            }
            if (Count == 0)
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
