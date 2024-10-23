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

namespace formulario
{
    public partial class Form1 : Form
    {
       //private conexion mConexion;
        public Form1()
        {
            InitializeComponent();
         //   mConexion = new conexion();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e, MySqlDataReader mySqlDataReader)
        {
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            docente r = new docente();
            r.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string nombre, contraseña;
            nombre = txtuser.Text;
            contraseña = pass.Text;

            MySqlConnection con = new MySqlConnection("server = localhost; Database = ecya; User Id=root; password=");

            try
            {
                con.Open();
            }catch (MySqlException ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                throw;
            }
            String sql = "select usuario,pass from usuarios where usuario = '" + nombre + "'AND pass='" + contraseña + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();

            if(read.Read())
            {
                this.Hide();
                MessageBox.Show("Bienvenido" + nombre);
            }
            else
            {
                MessageBox.Show("No existe este usuario" + nombre);
            } 
        }

        private void mostrar_CheckedChanged(object sender, EventArgs e)
        {
            if(mostrar.Checked ==true)
            {
                pass.UseSystemPasswordChar=false;
            }
            else
            {
                pass.UseSystemPasswordChar=true;
            }
        }
    }
}
