using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IMS.Data;

namespace IMS.Controllers;

public class ProductController : Controller
{

    ApplicationDbContext _context;
    //database added
    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    //get all product
    public IActionResult Index()
    {
        //var products = ProductRepository.GetAll();
        //return View(products);

        // return View(ProductRepository.GetAll()); //j data guli dekhabo seigula pass krbo
        var product = _context.Product.ToList();
        return View(product);
    }

    //details page
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }





    //  add product page
    public IActionResult Create()
    {
        PopulateDropdowns();
        return View();
    }
    //add product
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        PopulateDropdowns();
        return View(product);
    }

    //edit page
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Product.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        PopulateDropdowns();
        return View(product);
    }
    //edit
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        _context.Update(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    //delete page

    public async Task<IActionResult> Delete(int? id)
    {
        var product = await _context.Product.FindAsync(id);

        return View(product);
    }

    //delete
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product != null)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    private void PopulateDropdowns()
    {
        // var categories = new List<Category>
        // {
        //     new Category { Id = 1, Name = "Electronics" },
        //     new Category { Id = 2, Name = "Mechanical" }
        // };

        // var suppliers = new List<Supplier>
        // {
        //     new Supplier { Id = 1, Name = "Supplier 1", ContactInfo = "Test Contact 1", Country = "USA" },
        //     new Supplier { Id = 2, Name = "Supplier 2", ContactInfo = "Test Contact 2", Country = "UK" }
        // };

        var suppliers = _context.Supplier.ToList();
        var categories = _context.Category.ToList();

        ViewBag.Categories = categories
         .Select(c => new SelectListItem
         {
             Value = c.Id.ToString(),
             Text = c.Name
         }).ToList();

        ViewBag.Suppliers = suppliers
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Country
            }).ToList();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
