using RefrigeratorApp.Modals;
using System;
using System.Collections.Generic;

namespace RefrigeratorApp
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products; // Initialize as an empty list

        public ProductRepository()
        {
            _products = new List<Product>(); // Initialize the list in the constructor
        }

        // Stage 1
        public void addProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine("Product Added Successfully");
            //checkStatus();

        }
        public void checkStatus()
        {
            Console.WriteLine($"******************* Items in Refrigerator : ************************ Total Count : {_products.Count} ");
            if (_products.Count > 0)
            {
                foreach (var item in _products)
                {
                    Console.WriteLine($" Product : {item.Name}  Quantity :  {item.Quantity}  Expire On : {item.ExpirationDate.ToString("yyyy-MM-dd")} ");
                }
            }
            else
            {
                Console.WriteLine("No items in the Refrigerator, Please enter product details from above commands");
            }
        }
        public void consumeProduct(string productName, int consumedQuantity)
        {
            if (!string.IsNullOrEmpty(productName) && consumedQuantity > 0) // Ensure valid input
            {
                var selectedProduct = _products.Find(p => p.Name.ToLower() == productName.ToLower());
                if (selectedProduct != null)
                {

                    selectedProduct.Quantity -= consumedQuantity;
                    Console.WriteLine($"Product consumed : {productName} , quantity consumed : {consumedQuantity} ");
                    if (selectedProduct.Quantity <= 0)
                    {
                        _products.Remove(selectedProduct);
                    }
                }
                else
                {
                    Console.WriteLine($"Product with name : {productName} not found in the fridge");
                }
            }
            else
            {
                Console.WriteLine($"Please enter a valid Product Name and Quantity");
            }
        }


        // Stage 2
        public void checkforExpiryAndAlert(int days)
        {
            foreach (var item in _products)
            {
                if (item.ExpirationDate.Date <= DateTime.Now.Date.AddDays(days)) // Check if expiration date is within 3 days
                {
                    Console.WriteLine($"===========================  ALERT: {item.Name} is about to expire on {item.ExpirationDate.ToShortDateString()} ================= ");
                }
            }
        }
        public void removeExpiredProducts()
        {
            var expiredProducts = _products.Where(p => p.ExpirationDate.Date < DateTime.Now.Date).ToList();

            foreach (var expiredProduct in expiredProducts)
            {
                _products.Remove(expiredProduct);
                Console.WriteLine($"Product {expiredProduct.Name} has expired and removed from the refrigerator.");
            }
        }
        public void removeExpiredProducts(string productName)
        {
            var expiredProduct = _products.FirstOrDefault(p => p.Name.ToLower() == productName.ToLower());
            if (expiredProduct != null)
            {
                _products.Remove(expiredProduct);
                Console.WriteLine($"Product {expiredProduct.Name} is removed from the refrigerator items.");
            }
            else
            {
                Console.WriteLine($"No product found with the name {productName}.");
            }
        }
    }
}
