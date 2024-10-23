using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulario
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; Database = ecya; User Id=root; password=");

            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                throw;
            }

            string sql = "insert into usuarios(nombre,apellido,usuario,pass,correo electronico,matricula) values('" + txtnombre + "','" + txtapellido + "','" + txtusuario + "','" + txtpass + "','" + txtcorreo + "','"+txtmatricula+"')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario Registrado");
                this.Hide();
                Form1 r = new Form1();
                r.Show();
            }
            catch (MySqlException ex)
            {   
                MessageBox.Show("Error" + ex.ToString());
            }
        }
    }
}
