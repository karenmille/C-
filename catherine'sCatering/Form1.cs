using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catherine_sCatering
{
    public partial class Form1 : Form
    {
        //class level variables
        double subtotal, total, dinners, openBar, wine, tax, guestNumber;
        string name;
        //declare constans
        const double TAX = 0.07;

        const double PRIME_RIB = 25.95;
        const double CHICKEN = 18.95;
        const double PASTA = 12.95;
        private void cleaReceipt()
        {
            //this.txtOrderNameImput.Text = " ";
            this.lblTotalOutout.Text = "";
            this.lblDinnersOutpu.Text = "";
            this.lblOpenBarOutpu.Text =  "";
            this.lblWineOutput.Text = "";
            this.lblSubTotalOutput.Text = "";
            this.lblTaxOutpu.Text = "";

        }
        private void reset()
        {
            this.openBar = 0.0;
            this.wine = 0.0;
            this.dinners = 0.0;
            this.guestNumber = 0;
            this.subtotal = 0.00;
            this.total = 0.00;

        }
        private void displayDetailedReceiptTotals()
        {
            cleaReceipt();
            calculateTotals();
          //  this.txtOrderNameImput.Text = this.name;
            this.lblDinnersOutpu.Text = this.dinners.ToString("C");
            this.lblOpenBarOutpu.Text = this.openBar.ToString("C");
            this.lblWineOutput.Text = this.wine.ToString("C");
            this.lblSubTotalOutput.Text = this.subtotal.ToString("C");
            this.lblTaxOutpu.Text = this.tax.ToString("C");


        }
        private void calculateTotals()
        {

            reset();

            // Text Boxes

            if (this.txtNumberGestImput.Text.Length == 0)
            {
                this.guestNumber = 0;

            }
            else
            {
                try
                {
                    this.guestNumber = Convert.ToDouble(this.txtNumberGestImput.Text);
                }
                catch
                {
                    MessageBox.Show(name + " Please Enter  Number of Guest ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNumberGestImput.Text = "";
                    this.guestNumber = 0;
                }
            }

            // radio buttons
            if (this.rdoChicken.Checked)
            {
                this.dinners = this.guestNumber * CHICKEN;
            }
            else if (this.rdoPasta.Checked)
            {
                this.dinners = this.guestNumber * PASTA;
            }
            else if(this.rdoPrime.Checked){

                this.dinners = this.guestNumber * PRIME_RIB;
            }

            // check boxes
            if (this.chkBar.Checked)
            {
                 this.openBar = this.guestNumber * OPEN_BAR;
            }
            if (this.chkWine.Checked)
            {
                this.wine = WINE_TABLE * this.guestNumber;
            }
            this.subtotal =  this.wine + this.openBar + this.dinners;
            this.tax = this.subtotal * TAX;
            this.total = this.subtotal + this.tax;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to Exit " + name + "? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();

        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.calculateTotals();
            this.lblTotalOutout.Text = this.total.ToString("C");


        }

        private void rdoPrime_CheckedChanged(object sender, EventArgs e)
        {
            displayDetailedReceiptTotals();
            this.grbDrinks.Visible = true;
            this.picWaiter.Visible = false;

        }
        private void rdoChicken_CheckedChanged(object sender, EventArgs e)
        {
            displayDetailedReceiptTotals();
            this.grbDrinks.Visible = true;
            this.picWaiter.Visible = false;

        }

        private void rdoPasta_CheckedChanged(object sender, EventArgs e)
        {
            displayDetailedReceiptTotals();
            this.grbDrinks.Visible = true;
            this.picWaiter.Visible = false;
        }

        private void txtNumberGestImput_TextChanged(object sender, EventArgs e)
        {
           
            displayDetailedReceiptTotals();
            if (this.guestNumber>0) {
                this.grbMenu.Visible = true;
            }
            this.picWaiter.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleaReceipt();
            txtNumberGestImput.Text = "";
            txtOrderNameImput.Text = "";
            rdoChicken.Checked = false;
            rdoPasta.Checked = false;
            rdoPrime.Checked = false;
            chkBar.Checked = false;
            chkWine.Checked = false;
            this.grbDrinks.Visible = false;
            this.grbMenu.Visible = false;
            this.picWaiter.Visible = true;
        }

        
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void txtOrderNameImput_TextChanged(object sender, EventArgs e)
        {
            //displayDetailedReceiptTotals();
            this.name = this.txtOrderNameImput.Text;
        }

        private void lblDinnersRecipt_Click(object sender, EventArgs e)
        {

        }

        private void lblOpenBarRecipt_Click(object sender, EventArgs e)
        {

        }

        const double OPEN_BAR = 25.00;

        private void chkBar_CheckedChanged(object sender, EventArgs e)
        {

            displayDetailedReceiptTotals();
        }

        private void chkWine_CheckedChanged(object sender, EventArgs e)
        { 

            displayDetailedReceiptTotals();
        }

        const double WINE_TABLE = 8.00;


        public Form1()
        {
            InitializeComponent();
            //init variables
            guestNumber = 0;
            subtotal = total = openBar = dinners = wine  = 0;

            this.grbDrinks.Visible = false;
            this.grbMenu.Visible = false;
            this.picWaiter.Visible = true;
            
        }

        

    
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
