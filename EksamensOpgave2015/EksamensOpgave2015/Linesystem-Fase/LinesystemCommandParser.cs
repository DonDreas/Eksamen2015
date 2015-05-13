using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class LinesystemCommandParser
    {
        ILinesystemUI LinesystemCLI;
        Linesystem Linesystem;

        public LinesystemCommandParser(ILinesystemUI linesystemCLI, Linesystem linesystem)
        {
            this.LinesystemCLI = linesystemCLI;
            this.Linesystem = linesystem;
        }

        public void ParseCommand(string command)
        {
            string[] commands = command.Split(' ');
            if (commands[0].ElementAtOrDefault(0) != ':')
            {
                switch (command.Length)
                {
                    case 1:
                        ExecuteCommandUser(commands[0]);
                        break;
                    default:
                        LinesystemCLI.DisplayGeneralError("This command is not recognized. Please try again.");
                        break;
                }
            }
            else
            {
                switch (commands[0])
                {
                    case ":q":
                    case ":quit":
                        LinesystemCLI.Close();
                        break;
                    case ":activate":
                    case ":deactivate":
                        AdminCommandActivate(commands);
                        break;
                    case ":crediton":

                    case ":creditoff":
                        BuyOnCredit(commands);
                        break;
                    case ":addcredits":
                        AddCredit(commands);
                        break;
                    default:
                        LinesystemCLI.DisplayGeneralError("Something went wrong! Please try again");
                        break;
                }
            }
        }

        public void ExecuteCommandUser(string username)
        {
            User user;
            if (username == "")
            {
                LinesystemCLI.DisplayGeneralError("Incorrect username");
            }
            else
            {
                try
                {
                    user = Linesystem.GetUser(username);
                }
                catch (UserNotFoundException e)
                {
                    LinesystemCLI.DisplayUserNotFound(e.Message, username);
                }
                catch (Exception e)
                {
                    LinesystemCLI.DisplayGeneralError(e.Message);
                }
            }
        }

        public void ExecuteCommandProduct(string username, string productID)
        {
            User user;
            Product product;
            int id;
            try
            {
                user = Linesystem.GetUser(username);
                if (Int32.TryParse(productID, out id))
                {
                    product = Linesystem.GetProduct(id);
                    Linesystem.BuyProduct(user, product);
                    LinesystemCLI.DisplayUserBuysProduct((BuyTransaction)Linesystem.GetTransactionList(user, 1).Last());
                }
                else
                {
                    LinesystemCLI.DisplayGeneralError("Something went wrong");
                }
            }
            catch (UserNotFoundException e)
            {
                LinesystemCLI.DisplayUserNotFound(e.Message, username);
            }
            catch (ProductNotFoundException e)
            {
                LinesystemCLI.DisplayProductNotFound(e.Message, productID);
            }
            catch (InsufficientCreditsException e)
            {
                LinesystemCLI.DisplayInsufficientCash(e.Message);
            }
            catch (Exception e)
            {
                LinesystemCLI.DisplayGeneralError(e.Message);
            }
        }

        public void AdminCommandActivate(string[] commands)
        {
            Product product;
            int id;
            switch (commands.Length)
            {
                case 1:
                    LinesystemCLI.DisplayGeneralError("Cannot activate the product.");
                    break;
                case 2:
                    try
                    {
                        if (Int32.TryParse(commands[1], out id))
                        {
                            product = Linesystem.GetProduct(id);
                            switch (commands[0])
                            {
                                case ":activate":
                                    product.active = true;
                                    LinesystemCLI.PrintActiveMenu();
                                    break;
                                case ":deactivate":
                                    product.active = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            LinesystemCLI.DisplayGeneralError("Something went wrong.");
                        }
                    }
                    catch (ProductNotFoundException e)
                    {
                        LinesystemCLI.DisplayProductNotFound(commands[1], e.Message);
                    }
                    catch (ProductNotActiveException e)
                    {
                        LinesystemCLI.DisplayGeneralError(e.Message);
                    }
                    catch (Exception e)
                    {
                        LinesystemCLI.DisplayGeneralError(e.Message);
                    }
                    break;
                default:
                    LinesystemCLI.DisplayTooManyArgumentsError("Too many arguments!");
                    break;
            }
        }

        public void AddCredit(string[] commands)
        {
            User user;
            decimal amount;
            switch (commands.Length)
            {
                case 1:
                    LinesystemCLI.DisplayGeneralError("Cannot and credit username and amount.");
                    break;
                case 2:
                    try
                    {
                        user = Linesystem.GetUser(commands[1]);
                        if (user != null)
                        {
                            if (Decimal.TryParse(commands[2], out amount))
                            {
                                Linesystem.AddCreditsToAccount(user, amount);
                            }
                        }
                        else
                        {
                            LinesystemCLI.DisplayGeneralError("Something went wrong");
                        }
                    }
                    catch (UserNotFoundException e)
                    {
                        LinesystemCLI.DisplayUserNotFound(commands[1], e.Message);
                    }
                    catch (Exception e)
                    {
                        LinesystemCLI.DisplayGeneralError(e.Message);
                    }
                    break;
                default:
                    LinesystemCLI.DisplayTooManyArgumentsError("Something went wrong. Wrong format.");
                    break;
            }
        }
        public void BuyOnCredit(string[] commands)
        {
            Product product;
            int id;
            switch (commands.Length)
            {
                case 1:
                    LinesystemCLI.DisplayGeneralError("Cannot activate credit.");
                    break;
                case 2:
                    try
                    {
                        if (Int32.TryParse(commands[1], out id))
                        {
                            product = Linesystem.GetProduct(id);
                            switch (commands[0])
                            {
                                case ":crediton":
                                    product.canBeBoughtOnCredit = true;
                                    break;
                                case ":creditoff":
                                    product.canBeBoughtOnCredit = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            LinesystemCLI.DisplayGeneralError("Something went wrong");
                        }
                    }
                    catch (ProductNotFoundException e)
                    {
                        LinesystemCLI.DisplayProductNotFound(commands[1], e.Message);
                    }
                    catch (ProductNotActiveException e)
                    {
                        LinesystemCLI.DisplayGeneralError(e.Message);
                    }
                    catch (Exception e)
                    {
                        LinesystemCLI.DisplayGeneralError(e.Message);
                    }
                    break;
                default:
                    LinesystemCLI.DisplayTooManyArgumentsError("Too many arguments!");
                    break;
            }
        }
    }
}
