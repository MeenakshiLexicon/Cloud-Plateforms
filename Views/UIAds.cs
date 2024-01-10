using Sql_Uppgifter_P1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Uppgifter_P1.Views
{
  public static  class UIAds
  {
        public static Ad SetInsertAd()
        {
            Ad ad = new Ad();
            Console.WriteLine("Enter Id");
            ad.AdID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Category Id:");
            ad.CategoryID = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter title");
            ad.Title = Console.ReadLine();

            Console.WriteLine("Enter description:");
            ad.Description = Console.ReadLine();

            Console.WriteLine("Enter Price:");
            ad.Price = decimal.Parse(Console.ReadLine());
            return ad;
        }

        public static int SetDeleteAd()
        {
            Console.WriteLine("Choose which ad you want to delete");

            return int.Parse(Console.ReadLine());
        }

        public static Ad SetUpdateAd()
        {
            Ad updatedAd = new Ad();
            Console.WriteLine("Enter Id no Where you want to Update:");
            updatedAd.AdID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Category Id");
            updatedAd.CategoryID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter title");
            updatedAd.Title = Console.ReadLine();

            Console.WriteLine("Enter description:");
            updatedAd.Description = Console.ReadLine();

            Console.WriteLine("Enter Price:");
            updatedAd.Price = decimal.Parse(Console.ReadLine());

            return updatedAd;
        }

        public static Ad SetSearchAd()
        {
            Ad searchAd = new Ad();
            Console.Write("Enter a search text: ");
            searchAd.Condition = Console.ReadLine(); ;  
            return searchAd;
        }
  }
}

