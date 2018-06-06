using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        //class level variables
        double salesAmount, grossPay, netPay, totalDeductions, totalComission;
       
        //declare constans
        const double SALE_COMMISSION = 0.06;
        const double DEDUCTION = 0.18;
        const double BASE_PAY = 900.0;

        public Form1()
        {
            InitializeComponent();
            //init variables
            salesAmount = grossPay = netPay = totalDeductions = totalComission = 0.00;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtEmployeeName.Clear();
            txtSaleAmount.Clear();
            lblDeduction.Text = "";
            lblGrossPay.Text = "";
            lblNetPay.Text = "";
            salesAmount = grossPay = netPay = totalDeductions = totalComission = 0.00;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            salesAmount = Convert.ToDouble(txtSaleAmount.Text);
            if (txtEmployeeName.Text.Length > 0)
            {
               str = txtEmployeeName.Text + ", Please Enter A Positive Amount! ";
            }
            else
            {
                str = "Please Enter A Positive Amount! ";
            }
            if (salesAmount < 0)
            {
                MessageBox.Show(str, "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
                return;

            }
            totalComission = salesAmount * SALE_COMMISSION;
            grossPay = BASE_PAY + totalComission;
            totalDeductions = grossPay * DEDUCTION;
            netPay = grossPay - totalDeductions;

            lblDeduction.Text = String.Format("{0:C}", Convert.ToInt32(totalDeductions)); 
            lblGrossPay.Text = String.Format("{0:C}", Convert.ToInt32(grossPay));
            lblNetPay.Text = String.Format("{0:C}", Convert.ToInt32(netPay));


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
