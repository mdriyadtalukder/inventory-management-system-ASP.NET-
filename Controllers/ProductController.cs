using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IMS.Models;

namespace IMS.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        //var products = ProductRepository.GetAll();
        //return View(products);

        return View(ProductRepository.GetAll()); //j data guli dekhabo seigula pass krbo
    }

    //created
    public IActionResult Details(int id)
    {
        var product = ProductRepository.GetById(id);
        return View(product);
    }

    //created
    [HttpPost]
    public IActionResult Create(Product product)
    {
        ProductRepository.Add(product);
        return RedirectToAction("Index"); //Index() e hit krbe..1st ta.create korar por abr home e giye sob product dekhabe
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
