using Asp.net_GraphQL.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Asp.net_GraphQL.Service
{
    public class QueryType
    {


        public IEnumerable<FlowerBouquet> AllCakesAsync([Service] FUFlowerBouquetManagementContext context)
        {
            try
            {
                return context.FlowerBouquets.ToList();
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Error in AllCakesAsync: {ex.Message}");
                throw; 
            }
        }


    }
}