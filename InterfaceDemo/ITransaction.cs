using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    public interface ITransaction
    {
        void ShowTransaction();
        double GetAmount();
    }
}
