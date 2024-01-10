using Microsoft.Data.SqlClient;
using Sql_Uppgifter_P1.Entities;
using Sql_Uppgifter_P1.Repository;
using Sql_Uppgifter_P1.Views;
using System.Data;

namespace Sql_Uppgifter_P1
{
    public class Program
    {
        private static int Menu()
        {
            Console.Clear();
            Console.WriteLine("These are the Categories!");
            Console.WriteLine("\n1.Electronics\n2.Vehicle\n3.Home Furnishings\n4.Leisure\n5.Housing\n6.Clothes & Accessories\n7.Miscellaneous");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("\nChoose an options!");
            Console.WriteLine("1.Add New Advertisment Details :");
            Console.WriteLine("2.Delete Advertisment Details:");
            Console.WriteLine("3.Update Existing Advertisment details");
            Console.WriteLine("4.Search with title and Category");
            Console.WriteLine("5.Show all Advertisement data");
            Console.WriteLine("6.Show all Categories data");
            Console.WriteLine("7.Exit");

            return int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = Menu();
                if (choice == 1)
                {
                   var ad = UIAds.SetInsertAd();
                    AdsRepository.InsertAd(ad);
                }
                else if (choice == 2)
                {
                    var adToDelete = UIAds.SetDeleteAd();
                    AdsRepository.Delete(adToDelete);
                }
                else if (choice == 3)
                {
                    var updatedAd = UIAds.SetUpdateAd();
                    AdsRepository.UpdateAd(updatedAd);
                }
                else if (choice == 4)
                {
                    var searchAd = UIAds.SetSearchAd();
                    List<Ad> searchResults = AdsRepository.SearchAd(searchAd.Condition);
                    Console.Clear();
                    foreach (var results in searchResults)
                    {

                        Console.WriteLine($"Title: {results.Title}");
                        Console.WriteLine($"Price: {results.Price}");
                        Console.WriteLine("----------------------------------");
                    }

                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine("No matching ads found.");

                    }
                    else
                    {
                        Console.WriteLine("Please enter Title If tou want to see description:");
                        string adTitle = Console.ReadLine();
                        List<Ad> searchResult = AdsRepository.SearchAd(adTitle);
                        Console.Clear();
                        foreach (var ad in searchResult)
                        {
                            Console.WriteLine("\n\nFound match\n");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine($"Title: {ad.Title}");
                            Console.WriteLine($"Description: {ad.Description}");
                            Console.WriteLine($"Price: {ad.Price}");
                            Console.WriteLine("----------------------------------");
                        }
                        if (searchResult.Count == 0)
                        {
                            Console.WriteLine("No matching ads found.");

                        }
                    }
                    Console.ReadLine();
                }
                else if (choice == 5)
                {
                    List<Ad> allAds = new AdsRepository().GetAll();

                    if (allAds.Count > 0)
                    {
                        Console.WriteLine("All Ads:");
                        foreach (var ad in allAds)
                        {
                            Console.WriteLine($"AdID: {ad.AdID}, Title: {ad.Title}, Description: {ad.Description}, Price: {ad.Price}, CategoryID: {ad.CategoryID}");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No ads found.");
                    }
                }
                else if (choice == 6)
                {
                    List<Category> allCategory = new CategoryRepo().CateroriesAll();

                    if (allCategory.Count > 0)
                    {
                        Console.WriteLine("Show all Category:");
                        foreach (var category in allCategory)
                        {
                            Console.WriteLine($"CategoryID: {category.CategoryID}, CategoryName: {category.CategoryName}");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No Category found.");
                    }
                }
                else if (choice == 7)
                {
                    break;
                }
               
            }
        }
    }
}
