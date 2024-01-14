
using Asp.net_GraphQL.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Asp.net_GraphQL.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private FUFlowerBouquetManagementContext _context = null;
       
        private DbSet<T> table = null;

      
        public Repository(FUFlowerBouquetManagementContext context)
        {
            this._context = context;
            this.table = _context.Set<T>();
        }

    

        public async void DeleteAsync(int id)
        {
            T existing = table.Find(id);
          
            table.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> all =  table.ToList();
            return all;
        }
     
        public async Task<T> GetByIdAsync(int? id)
        {
            return await table.FindAsync(id);
        }

        public async void InsertAsync(T obj)
        {
           table.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(T obj)
        {
           table.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
