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

        //public void ParseCommand(string command)
        //{
        //    string[] commands = command.Split(' ');
        //    if (commands[0].ElementAtOrDefault(0) != ':')
        //    {
        //        switch (command.Length)
        //        {
        //            case 1:
        //                ExecuteCommandUser(commands[0]);
        //                break;
        //            case 2:
        //                ExecuteCommandUser(commands[0], commands[1]);
        //                break;
        //            case 3:
        //                ExecuteCommandUser(commands[0], commands[1], commands[2]);
        //                break;
        //            default:
        //                LinesystenCLI.DisplayGeneralError("This command is not recognized. Please try again.");
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (commands[0])
        //        {
        //            case ":q":
        //            case ":quit":
        //                LinesystenCLI.Close();
        //                break;
        //            case ":activate":
        //                break;
        //            case ":deactivate":
        //                break;
        //            case ":crediton":
        //                break;
        //            case ":creditoff":
        //                break;
        //            case ":addcredits":
        //                break;
        //            default:
        //                LinesystenCLI.DisplayGeneralError("Something went wrong! Please try again");
        //                break;
        //        }
        //    }
        //}

        public void ExecuteCommandUser(string username)
        {
            User user;
            if (username == "")
            {
                LinesystenCLI.DisplayGeneralError("Incorrect username");
            }
            else
            {
                try
                {
                    user = Linesystem.GetUser(username);
                }
                catch (UserNotFoundException e)
                {
                    LinesystenCLI.DisplayUserNotFound(e.Message);
                }
                catch (Exception e)
                {
                    LinesystenCLI.DisplayGeneralError(e.Message);
                }
            }
        }

        public void ExecuteCommandProduct(string username, string productID)
        {
            User user;
            Product product;
            try
            {
                user = Linesystem.GetUser(username);
            }
            catch (UserNotFoundException e)
            {
                LinesystenCLI.DisplayUserNotFound(e.Message);
            }

            int id;
            bool commandID = Int32.TryParse(productID, out id);
            if (commandID)
            {
                try
                {
                    product = Linesystem.GetProduct(id);
                }
                catch (ProductNotFoundException e)
                {
                    LinesystenCLI.DisplayProductNotFound(e.Message);
                }
                catch (ProductNotActiveException e)
                {
                    LinesystenCLI.DisplayGeneralError(e.Message);
                }
            }
            else
            {
                LinesystenCLI.DisplayProductNotFound("Hvad skal der skrives her? FEJL");
            }
        }
    }
}
