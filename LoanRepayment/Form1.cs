using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanRepayment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            textBox3.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || 
                Convert.ToInt32(textBox1.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0 || Convert.ToInt32(textBox3.Text) == 0)
            {
                MessageBox.Show("Input strings are not in correct Format");
                Form1_Load(sender, e);
            }
           
            else
            {
                long amount = Convert.ToInt32(textBox1.Text);
                double interest = (Convert.ToDouble(textBox2.Text)) / 1200;
                int noofmonths = 0;
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                    noofmonths = Convert.ToInt32(textBox3.Text) * 12;
                else
                    noofmonths = Convert.ToInt32(textBox3.Text);

                DataTable dt = new DataTable();
                ///DataColumn dc = new DataColumn();
                DataRow dr;

                dt.Columns.Add(new DataColumn("PaymentNo"));
                dt.Columns.Add(new DataColumn("Payment Amount"));
                dt.Columns.Add(new DataColumn("Principal Amount Paid"));
                dt.Columns.Add(new DataColumn("Interest Amount Paid"));
                dt.Columns.Add(new DataColumn("Loan Outstanding Balance"));
                for (int i = 1; i <= noofmonths; i++)
                {

                    double Payment1 = ((interest * amount) * Math.Pow((1 + interest), noofmonths)) / (Math.Pow((1 + interest), noofmonths) - 1);
                    double PP1 = Payment1 * Math.Pow((1 + interest), -(1 + noofmonths - i));
                    double Int1 = Payment1 - PP1;
                    double OB1 = (Int1 / interest) - PP1;


                    dr = dt.NewRow();
                    dr[0] = i;
                    dr[1] = Math.Round(Payment1, 2);
                    dr[2] = Math.Round(PP1, 2);
                    dr[3] = Math.Round(Int1, 2);
                    dr[4] = Math.Round(OB1, 2);

                    dt.Rows.Add(dr);
                    dr.EndEdit();
                }
                dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Enabled = true;
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox3.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
       
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox3.Enabled = true;
                    
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox3.Enabled = true;

            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
