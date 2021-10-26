using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATM
{
    public partial class WithdrawForm : Form
    {
        ATMEntities dbContext = new ATMEntities();
        Account account = null;

        public WithdrawForm(Account account)
        {
            InitializeComponent();
            this.account = account;
            Load();
        }
        
        private void Load()
        {
            txtAmount.Text = "";
            txtBalance.Text = account.Balance.ToString();
            txtBalance.Enabled = false;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {

        }
    }
}
