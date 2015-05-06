using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EksamensOpgave2015
{
    public class LineSystem
    {
        public User user { get; set; }
        public Product product { get; set; }
        public Transaction transaction { get; set; }

        public List<User> UserList = new List<User>();
        public List<Product> ProductList = new List<Product>();
        public List<Transaction> TransactionList = new List<Transaction>();

        public LineSystem(User user, Product product, Transaction transaction)
        {

        }

        public void BuyProduct(User user, Product product)
        {
            user.balance = user.balance - product.price;
        }

        public void AddCreditsToAccount(User user, Transaction transaction)
        {
            string text = transaction.ToString();

            user.balance = user.balance + transaction.amount;
            System.IO.File.WriteAllText("log.txt", text);
        }

        public void ExecuteTransaction(Transaction transaction) 
        {

        }

        public void GetProduct()
        {

        }

        public void GetUser()
        {

        }

        public void GetTransactionList()
        {

        }

        public void GetActiveProducts()
        {

        }

        public void ReadFile()
        {
            var reader = new StreamReader(File.OpenRead(@"products.csv"));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
            }
        }




        //public System.IO.File.WriteAllText(@"log.txt", text)
    }
}

