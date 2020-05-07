using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace CrmApp
{
    class productCharacteristics
    {
        private static ProductOption prodChangingName;

        static void Main2()
        {
            ProductOption prod = new ProductOption
            {
                Name = "mobile",
                Price = 300,
                Quantity = 5,

            };

            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);


            // product tries
            Product prodFind = prodMangr.FindProduct(2);
            Console.WriteLine(
                $"Id= {prodFind.Id} Name= {prodFind.Name} Price= {prodFind.Price}" +
                $" Quantity= {prodFind.Quantity}");       
            
            
            //testing reading a customer
            Product pd3 = prod.FindProductById(2);
            Console.WriteLine(
                $"Id= {pd3.Id} Name= {pd3.Name} Price= {pd3.Price} Quantity={pd3.Quantity}");


            //testing updating
            ProductOption prodUpdateName = new ProductOption
            {
               Name = "laptop"
            };
            Product product = prodMangr.Update(prodChangingName, 2);
            pd3 = product;
            Console.WriteLine(
                $"Id= {pd3.Id} Name= {pd3.Name} Price= {pd3.Price} Quantity= {pd3.Quantity}");


            //testing deletion

            bool result = prodMangr.DeleteProductById(3);
            Console.WriteLine($"Result = {result}");
            pd3  = prodMangr.FindProductById(3);
            if (pd3 != null)
            {
                Console.WriteLine(
                $"Id= {pd3.Id} Name= {pd3.Name} Price= {pd3.Price} Quantity= {pd3.Quantity}");

            }
            else
            {
                Console.WriteLine("The product does not exist");
            }


        }
    }
}
