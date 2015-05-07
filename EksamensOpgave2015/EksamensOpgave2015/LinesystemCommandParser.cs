using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class LinesystemCommandParser
    {
        ILinesystemUI LinesystenCLI;
        Linesystem Linesystem;

        public LinesystemCommandParser(ILinesystemUI linesystemCLI, Linesystem linesystem)
        {
            this.LinesystenCLI = linesystemCLI;
            this.Linesystem = linesystem;
        }

        //HJÆLP TIL DET NEDENFOR..

        //public void ParseCommand(string command)
        //{
        //    string[] commands = command.Split(' ');
        //    if (commands[0].ElementAtOrDefault(0) != ':')
        //    {
        //        switch (command.Length)
        //        {
        //            case 1:
        //                ExecuteCommand(commands[0]);
        //                break;
        //        }
        //    }
        //}

        //public void ExecuteCommandUser(string username)
        //{
        //    User user;
        //    try
        //    {
        //        user = Linesystem.GetUser(username);
        //    }
        //    catch (UserNotFoundException e)
        //    {
        //        LinesystenCLI.DisplayUserNotFound(e.message);
        //    }             
            
        //}

        //public void ExecuteCommandProduct(string username, string productID)
        //{
        //    User user;
        //    Product product;
        //    try
        //    {
        //        user = Linesystem.GetUser(username);
        //    }
        //    catch (UserNotFoundException e)
        //    {
        //        LinesystenCLI.DisplayUserNotFound(e.message);
        //    }

        //    int id;
        //    bool commandID = Int32.TryParse(productID, out id);
        //    if (commandID)
        //    {
        //        try
        //        {
        //            product = Linesystem.GetProduct(id);
        //        }
        //        catch (ProductNotFoundException e)
        //        {
        //            LinesystenCLI.DisplayProductNotFound(e.message);
        //        }
        //        catch (ProductNotActiveException e)
        //        {
        //            LinesystenCLI.DisplayGeneralError(e.message);
        //        }
        //    }
        //    else
        //    {
        //        LinesystenCLI.DisplayProductNotFound("Hvad skal der skrives her? FEJL");
        //    }
        //}
    }
}
