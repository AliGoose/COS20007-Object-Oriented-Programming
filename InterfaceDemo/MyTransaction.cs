using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    public class MyTransaction : ITransaction
    {
        private string _code;
        private string _date;
        private double _amount;

        public MyTransaction(string code, string date, double amount)
        {
            _code = code;
            _date = date;
            _amount = amount;
        }
        public void ShowTransaction()
        {
            Console.WriteLine("Code is {0}", _code);
            Console.WriteLine("Date is {0}", _date);
            Console.WriteLine("Amount is {0}", _amount);
        }
        public double GetAmount()
        {
            return _amount;
        }
    }
}
