using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntitiyLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            //program.cs
            /*CategoryManager cm = new CategoryManager();
            Category ct = new Category();
            ct.CategoryID = 4;
            ct.CategoryName = "Klavye ve Monitor";
            cm.BLUpdate(ct);

            foreach (var item in cm.GetAll())
            {
                Console.WriteLine("ID:" + item.CategoryID +
                    " - Kategori Adı" + item.CategoryName);
            }*/
            //ct.CategoryName = "Monitor";
            //cm.BLAdd(ct);
            //cm.BLDell(3);

            //Program.cs
            /*ProductManager cm = new ProductManager();
            foreach (var item in cm.GetByName("Monster"))
            {
                Console.WriteLine(item.Stock);
            }

            foreach (var item in cm.GetAll())
            {
                Console.WriteLine("ID:" + item.ProductID +
                    " - Kategori Adı" + item.ProductName);
            }*/
            CategoryManager cm = new CategoryManager();
            Category c = new Category();
            c.CategoryName = "Aksesuar";
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if (results.IsValid)
            {
                cm.BLAdd(c);
                Console.WriteLine("Kategori eklendi");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }

            Console.Read();
        }
        

    }
}
