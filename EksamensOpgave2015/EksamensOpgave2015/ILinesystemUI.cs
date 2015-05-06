﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public interface ILinesystemUI
    {
        void DisplayUserNotFound();
        void DisplayProductNotFound();
        void DisplayUserInfo();
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage();
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count);
        void Close();
        void DisplayInsufficientCash();
        void DisplayGeneralError(string errorString);
    }
}