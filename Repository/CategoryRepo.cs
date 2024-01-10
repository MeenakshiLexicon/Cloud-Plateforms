using Microsoft.Data.SqlClient;
using Sql_Uppgifter_P1.Entities;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Uppgifter_P1.Repository
{
    public class CategoryRepo
    {
        private static string _connstring = "Data Source=LAPTOP-ABIF7V0V;Initial Catalog=MarketplaceDB;Integrated Security=true;trustservercertificate=true";

        public List<Category> CateroriesAll()
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_connstring))
                {
                    return dbConnection.Query<Category>("GetAllCategories", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Category>(); 
            }
        }
    }

}
