using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Uppgifter_P1.Entities
{
    public class Ad
    {
        public int AdID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Condition {  get; set; }

        public Ad(int categoryID,int adID, string title, string description, int price, string condition)
        {
            AdID = adID;
            CategoryID = categoryID;
            Title = title;
            Description = description;
            Price = price;
            Condition = condition;
        }

        public Ad() 
        {
        }
    }
}
