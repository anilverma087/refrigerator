using RefrigeratorApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorApp
{
    public interface IProductRepository
    {
        // Stage 1
        void addProduct(Product product);
        void consumeProduct(string productName, int consumedQuantity);
        void checkStatus();

        // Stage 2
        void checkforExpiryAndAlert(int days);
        void removeExpiredProducts();
        void removeExpiredProducts(string productName);
    }
}
