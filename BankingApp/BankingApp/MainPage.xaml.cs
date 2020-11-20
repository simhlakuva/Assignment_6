using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;

namespace BankingAppSH
{
    public partial class MainPage : ContentPage
    {
        private BankAccount _account;
        public MainPage()
        {

            InitializeComponent();
            Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");

            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");

            fnb.AddCustomer(myNewCustomer);



            var account = myNewCustomer.ApplyForBankAccount();

            account.DepositMoney(1500, DateTime.Now, "Stipend");



        }


        private void DMoneyButton_Clicked(object sender, EventArgs e)
        {
            if (EnterDepositAmount.Text != null)
            {
                decimal amount = Decimal.Parse(EnterDepositAmount.Text);
                string description = EnterDepositDescription.Text.ToString();
                _account.DepositMoney(amount, DateTime.Now, description);
            }


        }

        private void WMoneyButton_Clicked(object sender, EventArgs e)
        {
            if (EnterWithdrawAmount.Text != null)
            {
                decimal amount = Decimal.Parse(EnterWithdrawAmount.Text);
                string description = EnterWithdrawDescription.Text.ToString();
                _account.WithdrawMoney(amount, DateTime.Now, description);
            }
        }

        private void THistoryButton_Clicked(object sender, EventArgs e)
        {
            string history = _account.GetTransactionHistory();
            DisplayAlert("Transaction History", history, "Press Enter to exit");

        }
    }

}
