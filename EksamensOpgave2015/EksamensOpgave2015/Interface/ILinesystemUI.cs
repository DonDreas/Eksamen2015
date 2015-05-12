using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public interface ILinesystemUI
    {
        //Interface over linesystemCLIs metoder
        void PrintActiveMenu();
        void DisplayUserNotFound(string message, string username);
        void DisplayProductNotFound(string message, string productID);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string message);
        void DisplayAdminCommandNotFoundMessage(string message);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count);
        void Close();
        void DisplayInsufficientCash(string message);
        void DisplayGeneralError(string message);
    }
}
