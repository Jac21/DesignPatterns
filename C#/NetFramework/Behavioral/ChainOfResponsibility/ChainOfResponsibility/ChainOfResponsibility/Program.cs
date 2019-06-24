using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// It helps building a chain of objects. Request enters from one end and keeps going from object to object till it finds the suitable handler.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            // Let's prepare a chain like below
            //      $bank->$paypal->$bitcoin
            //
            // First priority bank
            //      If bank can't pay then paypal
            //      If paypal can't pay then bit coin

            var bank = new Bank(3.50m);
            var payPal = new PayPal(27.50m);
            var bitcoin = new Bitcoin(1000000m);

            bank.SetNext(payPal);
            payPal.SetNext(bitcoin);

            bank.Pay(1020m);
        }
    }

    /// <summary>
    /// First of all we have a base account having the logic for chaining the accounts together and some accounts
    /// </summary>
    public abstract class Account
    {
        private Account successor;
        protected decimal Balance;

        public void SetNext(Account account)
        {
            successor = account;
        }

        public void Pay(decimal amountToPay)
        {
            if (CanPay(amountToPay))
            {
                Console.WriteLine($"Paid {amountToPay:C} using {GetType().Name}.");
            }
            else if (successor != null)
            {
                Console.WriteLine($"Cannot pay using {GetType().Name}. Proceeding...");
                successor.Pay(amountToPay);
            }
            else
            {
                throw new Exception("No accounts have enough balance");
            }
        }

        private bool CanPay(decimal amount)
        {
            return Balance >= amount;
        }
    }

    public class Bank : Account
    {
        public Bank(decimal balance)
        {
            Balance = balance;
        }
    }

    public class PayPal : Account
    {
        public PayPal(decimal balance)
        {
            Balance = balance;
        }
    }

    public class Bitcoin : Account
    {
        public Bitcoin(decimal balance)
        {
            Balance = balance;
        }
    }
}