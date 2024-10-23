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
    public partial class docente : Form
    {
        public docente()
        {
            InitializeComponent();
            comboBox1.Items.Add("Soy Estudiante");

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar qué opción fue seleccionada
            string selectedOption = comboBox1.SelectedItem.ToString();

            if (selectedOption == "Abrir Formulario 2")
            {
                // Mostrar Form2
                Registro form2 = new Registro();
                form2.Show();
                this.Hide();  // Ocultar el formulario actual si es necesario
            }
            
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
            
            string sql = "insert into usuarios(nombre,apellido,usuario,pass,correo electronico,matricula) values('" + txtnombre + "','" + txtapellido + "','" + txtusuario + "','" + txtpass + "','" + txtcorreo + "','" + txtmatricula + "')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario Registrado");
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error"+ ex.ToString());
            }
            
            this.Hide();
            Form1 r = new Form1();
            r.Show();
        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void cbxdocente_CheckedChanged(object sender, EventArgs e)
        {

        }*/
    }
}
