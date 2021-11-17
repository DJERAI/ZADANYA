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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
      
        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass";
            conn = new MySqlConnection(connStr);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int ded = 0;
            string sql = $"SELECT id,fio,age,theme_kurs FROM t_stud";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add("ID студента - " + reader[0].ToString());
                listBox1.Items.Add("Фио студента - " + reader[1].ToString());
                listBox1.Items.Add("Возраст студента - " + reader[2].ToString());
                listBox1.Items.Add("Тема курсовой работы - " + reader[3].ToString());
                listBox1.Items.Add("--------------------------------------");
                if (Convert.ToInt32(reader[2])>ded)
                {
                    ded = Convert.ToInt32(reader[2]);
                }
            }

            MessageBox.Show($"Возраст самого старшего студента - {ded}");
            reader.Close();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
     
            conn.Open();
            string sql = $"SELECT id,fio,age,theme_kurs FROM t_stud WHERE fio='{textBox1.Text}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
           
           
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                listBox2.Items.Add("Фамилия студента - " + reader[0].ToString());
                listBox2.Items.Add("Возраст студента - " + reader[1].ToString());
                listBox2.Items.Add("Тема курсовой работы - "  + reader[2].ToString());
            }
            reader.Close();
            conn.Close();
        }
    }
}
