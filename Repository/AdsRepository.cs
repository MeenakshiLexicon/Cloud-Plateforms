using Dapper;
using Microsoft.Data.SqlClient;
using Sql_Uppgifter_P1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Sql_Uppgifter_P1.Repository
{
    public class AdsRepository
    {
        private static string _connstring = "Data Source=LAPTOP-ABIF7V0V;Initial Catalog=MarketplaceDB;Integrated Security=true;trustservercertificate=true";

        public List<Ad> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_connstring))
                {
                    return dbConnection.Query<Ad>("GetAllAds", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred in GetAll: {ex.Message}");
                return new List<Ad>(); 
            }
        }

        public static void InsertAd(Ad ad)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connstring))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AdID", ad.AdID);
                    parameters.Add("@CategoryID", ad.CategoryID);
                    parameters.Add("@Title", ad.Title);
                    parameters.Add("@Description", ad.Description);
                    parameters.Add("@Price", ad.Price);
                    db.Execute("AddAd", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in InsertAd: {ex.Message}");

            }
        }

        public static void Delete(int adID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connstring))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AdID", adID);
                    db.Execute("DeleteAd", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in Delete: {ex.Message}");

            }
        }

        public static List<Ad> SearchAd(string searchText)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connstring))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@SearchCondition", searchText);

                    var model = db.Query<Ad>("SearchAds", parameters, commandType: CommandType.StoredProcedure).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in SearchAd: {ex.Message}");
                return new List<Ad>();
            }
        }

        public static void UpdateAd(Ad updatedAd)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connstring))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AdID", updatedAd.AdID);
                    parameters.Add("@CategoryID", updatedAd.CategoryID);
                    parameters.Add("@Title", updatedAd.Title);
                    parameters.Add("@Description", updatedAd.Description);
                    parameters.Add("@Price", updatedAd.Price);
                    db.Execute("UpdateAds", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in UpdateAd: {ex.Message}");

            }
        }

    }
}
