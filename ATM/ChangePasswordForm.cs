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
    public partial class ChangePasswordForm : Form
    {
        ATMEntities dbContext = new ATMEntities();
        Account account = new Account();
        public ChangePasswordForm(Account account)
        {
            InitializeComponent();
            this.account = account;
            txtPassword.Text = "";
            txtNewPassword1.Text = "";
            txtNewPassword2.Text = "";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Account _account = dbContext.Accounts.FirstOrDefault(acc => acc.AccountNumber.Equals(account.AccountNumber));
            if (txtPassword.Text == _account.Pass_word)
            {
                if (txtNewPassword1.Text == txtNewPassword2.Text)
                {
                    if (txtNewPassword1.Text.Length == 6)
                    {
                        _account.Pass_word = txtNewPassword1.Text;
                        dbContext.SaveChanges();
                        MessageBox.Show("Password is changed.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password's length is 6.");
                    }
                }
                else
                {
                    MessageBox.Show("Two new password is not equal.");
                }
            }
            else
            {
                MessageBox.Show("Password is error");
            }
        }
    }
}
