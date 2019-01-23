using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            int pil;
            var result = 0;
            Supplier supplier = new Supplier();
            MyContext _context = new MyContext();
            Console.WriteLine("==========Supplier Data==========");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrieve");
            Console.WriteLine("=================================");
            Console.WriteLine("Pilihan Ikam: ");
            pil = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=================================");
            switch (pil)
            {
                case 1:
                    Console.WriteLine("Insert Data");
                    //insert nama, join date dan create date supplier
                    Console.WriteLine("Insert Insert Name of Supplier");
                    supplier.Name = Console.ReadLine();
                    supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
                    supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;

                    _context.Suppliers.Add(supplier);
                    result = _context.SaveChanges();
                    if (result > 0)
                    {
                        Console.WriteLine("Insert Success");
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine("Insert Failed");
                        Console.Read();
                    }

                    Console.Read();
                    break;
                case 2: /////update data
                    // input id untuk dicari
                    Console.WriteLine("Insert Id to update data");
                    int id = Convert.ToInt16(Console.ReadLine());

                    // mencari data sesuai dengan id di database
                    var get = _context.Suppliers.Find(id);

                    //pengecekan data di db
                    if(get == null)
                    {
                        Console.WriteLine("Sorry, your data isnt found");
                        Console.Read();
                    }
                    else
                    {
                        // jika ada, maka akan meminta inputan nama dan akan disimpan di db
                        Console.WriteLine("Insert Name of Supplier: ");
                        get.Name = Console.ReadLine();
                        Console.WriteLine("Insert date of update: ");
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.WriteLine("Update Success");
                            Console.Read();
                        }
                        else
                        {
                            Console.WriteLine("Update failed");
                            Console.Read();
                        }
                    }
                    Console.Read();
                    break;
                case 3: //delete
                    // input id untuk dicari
                    Console.WriteLine("Insert Id to delete data");

                    // mencari data sesuai dengan id di database
                    var getData = _context.Suppliers.Find(Convert.ToInt16(Console.ReadLine()));

                    if (getData == null)
                    {
                        Console.WriteLine("Sorry, your data isnt found");
                        Console.Read();
                    }
                    else
                    {
                        // jika ada, maka akan mengubah status isDelete dan akan disimpan di db
                        getData.IsDelete = true;
                        getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.WriteLine("Delete Success");
                            Console.Read();
                        }
                        else
                        {
                            Console.WriteLine("Delete failed");
                            Console.Read();
                        }
                    }
                    Console.Read();
                    break;
                case 4: // retrieve
                    var getDataToDisplay = _context.Suppliers.Where(x => x.IsDelete == false).ToList(); //tolist wajib untuk mengetahui bahwa semua data diambil dalam bentuk list
                    if(getDataToDisplay.Count == 0)
                    {
                        Console.Write("No data in your db");
                    }
                    else
                    {
                        foreach(var tampilin in getDataToDisplay)
                        {
                            Console.WriteLine("Name      : " + tampilin.Name);
                            Console.WriteLine("Join Date : " + tampilin.JoinDate);
                        }
                        Console.Write("Total Supplier : " + getDataToDisplay.Count);
                        Console.Read();
                    }
                    Console.Read();
                    break;
                default :
                    Console.WriteLine("Choice unavailable");
                    Console.Read();
                    break;
            }
            Console.Read();
        }
    }
}
