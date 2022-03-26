using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_Software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            PriductText.Clear();
            QuantitText.Clear();
            txtPrice.Clear();
            txtToatalPrice.Clear();
       
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            UpdateIndex();

        }

        private void UpdateIndex()
        {

            if (QuantitText.Text != "" && txtPrice.Text != "")
            {
                double TotalPrice = Convert.ToInt64(QuantitText.Text) * Convert.ToInt64(txtPrice.Text);
                txtToatalPrice.Text = TotalPrice.ToString() + ".00";
            }
            else
            {
                txtToatalPrice.Text = "0";
            }


        }

        private void comboQuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateIndex();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            PtintPriview.Document = PrintDoc;
            PtintPriview.Show();
            this.Hide();
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("...................Hello Programmer...................\n" + "\n\n Customar Name :"+txtName.Text+ "\n\n Product Name :"+ PriductText.Text+ "\n\n Quantity :" + QuantitText.Text+ "\n\n Price :" + txtPrice.Text
                + "\n\n Total Price  :" + txtToatalPrice.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(140, 160));

            saveData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void saveData()
        {

            try
            {
                //TextWriter txt = new StreamWriter("C:\\demo\\demo.txt");
                TextWriter txt = new StreamWriter("All Data.txt");
                if (txt != null)
                {
                    txt.Write("NAME:-"+txtName.Text + "\n");
                    txt.Write("PRODUCT NAME:-" + PriductText.Text + "\n");
                    txt.Write("QUANTITY:-" + QuantitText.Text + "\n");
                    txt.Write("PRICE:-" + txtPrice.Text + "\n");
                    txt.Write("TOTAL PRICE:-" + txtToatalPrice.Text + "\n");
                    txt.Close();
                   // MessageBox.Show("Save Successfully");
                }
                else
                {
                    MessageBox.Show("Please Fil The Box");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

            
            



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();

        }
    }
}
