using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace EksamensOpgave2015
{
    public class Linesystem
    {
        private const int PRODUCTID = 0;
        private const int PRODUCTNAME = 1; 
        private const int PRODUCTPRICE = 2;
        private const int PRODUCTACTIVE = 3;

        private const int USERID = 0;
        private const int FIRSTNAME = 1;
        private const int LASTNAME = 2;
        private const int USERNAME = 3;
        private const int EMAIL = 4;
        private const int BALANCE = 5;

        private const int BUYORDEPOSIT = 0;
        private const int AMOUNT = 1;
        private const int TRANSLOGNAME = 2;
        private const int DATE = 3;
        private const int ID = 4;
        private const int PRODUCTTIME = 5;

        public User user { get; set; }
        public Product product { get; set; }
        public Transaction transaction { get; set; }

        public List<User> UserList = new List<User>();
        public List<Product> ProductList = new List<Product>();
        public List<Transaction> TransactionList = new List<Transaction>();

        public DateTime Today = DateTime.Today;

        public string SetFormatDateTime(DateTime date)
        {
            return date.ToString("MM-dd");
        }

        public Linesystem()
        {
            ReadFile();
            ReadUser();
            ReadTransactionLog();
        }

        public void ReadFile()
        {
            List<string[]> stringArrList = ReadCharSeparatedFile("products.csv", ';');
            foreach (string[] stringArr in stringArrList)
            {
                stringArr[PRODUCTNAME] = Regex.Replace(stringArr[PRODUCTNAME], @"<[^>]*>", string.Empty);
                ProductList.Add(new Product(Int32.Parse(stringArr[PRODUCTID]), stringArr[PRODUCTNAME].Trim('"'),
                    decimal.Parse(stringArr[PRODUCTPRICE]), Int32.Parse(stringArr[PRODUCTACTIVE]) == 1 ? true : false));
            }
        }

        public void ReadUser()
        {
            List<string[]> stringArrList = ReadCharSeparatedFile("User.txt", ';');
            foreach (string[] stringArr in stringArrList)
            {
                UserList.Add(new User(Int32.Parse(stringArr[USERID]), stringArr[FIRSTNAME], stringArr[LASTNAME],
                    stringArr[USERNAME], stringArr[EMAIL], Decimal.Parse(stringArr[BALANCE])));
            }
        }

        public void ReadTransactionLog()
        {
            List<string[]> stringArrList = ReadCharSeparatedFile("transactionLog.txt", ' ');
            foreach (string[] stringArr in stringArrList)
            {
                if (stringArr[BUYORDEPOSIT] == "Payment")
                {
                    TransactionList.Add(new InsertCashTransaction(Int32.Parse(stringArr[ID]), GetUser(stringArr[TRANSLOGNAME]),
                        stringArr[DATE], GetProduct(Int32.Parse(stringArr[AMOUNT])).price));
                }
                else if (stringArr[BUYORDEPOSIT] == "Buy")
                {
                    TransactionList.Add(new BuyTransaction(Int32.Parse(stringArr[ID]), GetUser(stringArr[TRANSLOGNAME]),
                        stringArr[DATE], decimal.Parse(stringArr[AMOUNT]), GetProduct(Int32.Parse(stringArr[PRODUCTTIME]))));
                }
                else
                    throw new ArgumentOutOfRangeException("Value");
            }
        }

        public List<string[]> ReadCharSeparatedFile(string path, char separator)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            List<string[]> fileLineList = new List<string[]>();
            string line;
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                fileLineList.Add(values);
            }
            reader.Close();
            return fileLineList;
        }

        public void MakeUserFile()
        {
            string text = "";
            foreach (User user in UserList)
            {
                text += user.ID + ";" + user.firstName + ";" + user.lastName + ";" + user.userName + ";" + user.email + ";" + user.balance + "\n";
            }
            System.IO.File.WriteAllText("User.txt", text);
        }
        
        public void BuyProduct(User user, Product product)
        {
            TransactionList.Add(new BuyTransaction(TransactionList.Count + 1, user, Today.ToShortDateString(), product.price, product));
            ExecuteTransaction(TransactionList[TransactionList.Count - 1]);
        }

        public void AddCreditsToAccount(User user, decimal amount)
        {
            TransactionList.Add(new InsertCashTransaction(TransactionList.Count + 1, user, Today.ToShortDateString(), amount));
            ExecuteTransaction(TransactionList[TransactionList.Count - 1]);
        }

        public void ExecuteTransaction(Transaction transaction) 
        {
            try
            {
                transaction.Execute();
                using (StreamWriter writer = new StreamWriter("transactionLog.txt", true))
                {
                    writer.WriteLine(transaction.ToString());
                }
                MakeUserFile();
            }
            catch (InsufficientCreditsException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public Product GetProduct(int productId)
        {
            return ProductList.Find(c => c.productId == productId);
        }

        public User GetUser(string userName)
        {
            if (UserList.Exists(c => c.userName == userName))
            {
                return UserList.Find(c => c.userName == userName);
            }
            else
                throw new ArgumentOutOfRangeException("Not found");
        }

        public List<Transaction> GetTransactionList(User user, int amount)
        {
            return TransactionList.FindAll(c => c.user == user && c.transactionID < TransactionList.Count - 1 && c.transactionID > TransactionList.Count - amount);
        }

        public List<Product> GetActiveProducts()
        {
            return ProductList.FindAll(c => c.active == true);
        }

        public void AddUser(int ID, string firstName, string lastName, string userName, string email, decimal balance)
        {
            UserList.Add(new User(ID, firstName, lastName, userName, email, balance));
            MakeUserFile();
        }
        //public void ReadProductData()
        //{

        //}

        //public void MakeProductCatalogFile()
        //{
        //    string text = "";
        //    foreach (Product product in ProductList)
        //    {
        //        text += product.productId + ";" + product.name + ";" + 
        //            product.price + ";" + product.active + ";" + product.canBeBoughtOnCredit;
        //    }
        //    System.IO.File.WriteAllText("Products.txt", text);
        //}
    }
}

