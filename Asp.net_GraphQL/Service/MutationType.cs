using Asp.net_GraphQL.DataAccess;

namespace Asp.net_GraphQL.Service
{
    public class MutationType
    {

        //Create Operation:
        public async Task<FlowerBouquet> SaveCakeAsync([Service] FUFlowerBouquetManagementContext context,
   FlowerBouquet newCake)
        {
            context.FlowerBouquets.Add(newCake);
            await context.SaveChangesAsync();
            return newCake;
        }

        //Update Operation:

        public async Task<FlowerBouquet> UpdateCakeAsync([Service] FUFlowerBouquetManagementContext context, FlowerBouquet updateCake)
        {
            context.FlowerBouquets.Update(updateCake);
            await context.SaveChangesAsync();
            return updateCake;
        }

        // Delete Operation:
        public async Task<string> DeleteCakeAsync([Service] FUFlowerBouquetManagementContext context, int id)
        {
            var cakeToDelete = await context.FlowerBouquets.FindAsync(id);
            if (cakeToDelete == null)
            {
                return "Invalid Operation";
            }
            context.FlowerBouquets.Remove(cakeToDelete);
            await context.SaveChangesAsync();
            return "Record Deleted!";
        }

    }
}
