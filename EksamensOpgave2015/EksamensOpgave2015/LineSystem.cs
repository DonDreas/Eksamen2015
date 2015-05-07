using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace EksamensOpgave2015
{
    public class LineSystem
    {
        private const int PRODUCTID = 0;
        private const int PRODUCTNAME = 1; 
        private const int PRODUCTPRICE = 2;
        private const int PRODUCTACTIVE = 3;

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
        
        public void BuyProduct(User user, Product product)
        {
            TransactionList.Add(new BuyTransaction(TransactionList.Count + 1, user, Today.ToShortDateString(), product));
        }

        public void AddCreditsToAccount(User user, decimal amount)
        {
            TransactionList.Add(new InsertCashTransaction(TransactionList.Count + 1, user, Today.ToShortDateString(), amount));
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
            return UserList.Find(c => c.userName == userName);
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
            string text = "";
            foreach (User user in UserList)
            {
                text += user.ID + " " + user.firstName + " " + user.lastName + " " + user.userName + " " + user.email + " " + user.balance + "\n";
            }
            System.IO.File.WriteAllText("User.txt", text);
        }

        public void ReadUser()
        {

        }

        public void ReadProductData()
        {

        }

        public void ReadFile()
        {
            StreamReader reader = new StreamReader(@"products.csv", Encoding.Default);
            List<string> ListReader = new List<string>();
            string line;
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                values[PRODUCTNAME] = Regex.Replace(values[PRODUCTNAME], @"<[^>]*>", string.Empty);

                ProductList.Add(new Product(Int32.Parse(values[PRODUCTID]), values[PRODUCTNAME].Trim('"'), decimal.Parse(values[PRODUCTPRICE]), Int32.Parse(values[PRODUCTACTIVE]) == 1 ? true : false));
            }
            reader.Close();
        }
    }
}

