using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public interface ILinesystemUI
    {
        void DisplayUserNotFound(string message);
        void DisplayProductNotFound(string message);
        void DisplayUserInfo();
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage(string message);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count);
        void Close();
        void DisplayInsufficientCash(string message);
        void DisplayGeneralError(string message);
    }
}
