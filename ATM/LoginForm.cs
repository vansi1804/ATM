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
    public partial class LoginForm : Form
    {
        ATMEntities dbContext = new ATMEntities();
        Account account = null;
        public LoginForm()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            txtAccountNumber.Text = "";
            txtPassword.Text = "";
            txtBalance.Text = "";
            txtAccountNumber.Enabled = true;
            txtBalance.Enabled = false;
            btnWithdraw.Enabled = false;
            btnLogout.Enabled = false;
            btnChangePassword.Enabled = false;
            dgvWithdrawHistory.Refresh();
        }

        public bool CheckForAccount()
        {
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Account number or password is invalid. Check for space.");
                return false;
            }

            account = dbContext.Accounts.FirstOrDefault(acc=>acc.AccountNumber.Equals(txtAccountNumber.Text) 
                                                            && acc.Pass_word.Equals(txtPassword.Text));
            if (account == null)
            {
                MessageBox.Show("Account number or password is invalid. Check for space 2. ");
                return false;
            }
            return true;
        }

        private void GetWithdrawHistory(Account account)
        {
            var withdrawHistory = from withdraw in dbContext.Withdraws
                                  where account.AccountCode == withdraw.AccountCode
                                  select new
                                  {
                                      withdraw.WithdrawDate,
                                      withdraw.WithdrawAmount,
                                      account.Balance
                                  };
            dgvWithdrawHistory.DataSource = withdrawHistory.ToList();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckForAccount())
            {
                txtAccountNumber.Enabled = false;
                txtPassword.Enabled = false;
                txtBalance.Text = account.Balance.ToString();
                btnWithdraw.Enabled = true;
                btnChangePassword.Enabled = true;
                btnLogout.Enabled = true;
                GetWithdrawHistory(account);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Form fChangePassword = new ChangePasswordForm(account);
            fChangePassword.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Form fWithdraw = new WithdrawForm(account);
            fWithdraw.ShowDialog();
            txtBalance.Text = account.Balance.ToString();
            GetWithdrawHistory(account);
        }
    }
}
