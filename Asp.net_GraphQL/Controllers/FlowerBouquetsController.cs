using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.net_GraphQL.DataAccess;
using Asp.net_GraphQL.Service;


namespace Asp.net_GraphQL.Controllers
{
    public class FlowerBouquetsController : Controller
    {
        private FUFlowerBouquetManagementContext _context;
        private IRepository<FlowerBouquet> Generic;
        private QueryType QueryType;

        public FlowerBouquetsController(FUFlowerBouquetManagementContext context, QueryType queryType)
        {
            this._context = context;
            this.Generic = new Repository<FlowerBouquet>(context);
            this.QueryType = queryType;
        }

        public async Task<IActionResult> Index()
        {
            var fUFlowerBouquetManagementContext = QueryType.AllCakesAsync(_context);
            return View( fUFlowerBouquetManagementContext);
        }

        // GET: FlowerBouquets/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var flowerBouquet = await Generic.GetByIdAsync(id);
            if (flowerBouquet == null)
            {
                return NotFound();
            }

            return View(flowerBouquet);
        }

        // GET: FlowerBouquets/Create
        public async Task<IActionResult> Create()
        {
            IEnumerable<FlowerBouquet> fu =  Generic.GetAll();
            var uniqueCategories = fu.Select(f => f.Category).Distinct();
            var uniqueSuppliers = fu.Select(f => f.Supplier).Distinct();
            ViewData["CategoryId"] = new SelectList(uniqueCategories, "CategoryId", "CategoryId");
            ViewData["SupplierId"] = new SelectList(uniqueSuppliers, "SupplierId", "SupplierId");
            return View();
        }





        // POST: FlowerBouquets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlowerBouquetId,CategoryId,FlowerBouquetName,Description,UnitPrice,UnitsInStock,FlowerBouquetStatus,SupplierId")] FlowerBouquet flowerBouquet)
        {
            if (ModelState.IsValid)
            {
               Generic.InsertAsync(flowerBouquet);
           
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<FlowerBouquet> fu =  Generic.GetAll();
            var uniqueCategories = fu.Select(f => f.Category).Distinct();
            var uniqueSuppliers = fu.Select(f => f.Supplier).Distinct();
            ViewData["CategoryId"] = new SelectList(uniqueCategories, "CategoryId", "CategoryId");
            ViewData["SupplierId"] = new SelectList(uniqueSuppliers, "SupplierId", "SupplierId");
            return View(flowerBouquet);
        }

        // GET: FlowerBouquets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || Generic.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            var flowerBouquet = await Generic.GetByIdAsync(id);
            if (flowerBouquet == null)
            {
                return NotFound();
            }
            IEnumerable<FlowerBouquet> fu =  Generic.GetAll();
            var uniqueCategories = fu.Select(f => f.Category).Distinct();
            var uniqueSuppliers = fu.Select(f => f.Supplier).Distinct();
            ViewData["CategoryId"] = new SelectList(uniqueCategories, "CategoryId", "CategoryId");
            ViewData["SupplierId"] = new SelectList(uniqueSuppliers, "SupplierId", "SupplierId");
            return View(flowerBouquet);
        }

        // POST: FlowerBouquets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlowerBouquetId,CategoryId,FlowerBouquetName,Description,UnitPrice,UnitsInStock,FlowerBouquetStatus,SupplierId")] FlowerBouquet flowerBouquet)
        {
            if (id != flowerBouquet.FlowerBouquetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Generic.UpdateAsync(flowerBouquet);
                 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (Generic.GetByIdAsync(id) ==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<FlowerBouquet> fu =  Generic.GetAll();
            var uniqueCategories = fu.Select(f => f.Category).Distinct();
            var uniqueSuppliers = fu.Select(f => f.Supplier).Distinct();
            ViewData["CategoryId"] = new SelectList(uniqueCategories, "CategoryId", "CategoryId");
            ViewData["SupplierId"] = new SelectList(uniqueSuppliers, "SupplierId", "SupplierId");
            return View(flowerBouquet);
        }

        // GET: FlowerBouquets/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

           var search = Generic.GetByIdAsync(id);

            return View(search);
        }

        // POST: FlowerBouquets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Generic.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    
    }
}
