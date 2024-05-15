using RefrigeratorApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RefrigeratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            while (true)
            {
                Console.WriteLine("RefrigeratorApp : Commands:");
                Console.WriteLine("1. Type 1 to insert a new product");
                Console.WriteLine("2. Type 2 to consume a a product");
                Console.WriteLine("3. Type 3 to check status of the refrigerator");
                Console.WriteLine("4. Type 4 to remove items from refrigerator");
                Console.Write("Enter the command number eg:- (1,2,3,4) : ");
                string command = Console.ReadLine();
                ExecuteCommand(command, productRepository);
                productRepository.checkforExpiryAndAlert(3); // check for items that is going to expire in X days
                productRepository.removeExpiredProducts(); // automatically remove the expiry product if any

            }
        }

        static void ExecuteCommand(string command , IProductRepository productRepository)
        {

            switch (command)
            {

                case "1":
                    Console.Write("Product name: ");
                    var name = Console.ReadLine();
                    Console.Write("Product quantity: ");
                    var quantity = int.Parse(Console.ReadLine());
                    Console.Write("Expiration date (YYYY-MM-DD): ");
                    var expirationDate = DateTime.Parse(Console.ReadLine());
                    Product obj = new Product();
                    obj.Name = name;
                    obj.ExpirationDate = expirationDate;    
                    obj.Quantity = quantity;
                    productRepository.addProduct(obj);
                    break;
                case "2":
                    Console.Write("Product name: ");
                    var cName = Console.ReadLine();
                    Console.Write("Product quantity: ");
                    var cQuantity = int.Parse(Console.ReadLine());
                    productRepository.consumeProduct(cName, cQuantity);
                    break;
                case "3":
                    productRepository.checkStatus();
                    break;
                case "4":
                    Console.Write("Product name: ");
                    var pName = Console.ReadLine();
                    productRepository.removeExpiredProducts(pName); // remove product manually
                    break;
                default:
                    break;
            }
            Console.WriteLine("*************************************************************************************");
            Console.WriteLine(); // for empty line
        }
    }
}
