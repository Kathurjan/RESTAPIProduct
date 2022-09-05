using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route ("[Controller]")]
public class ProductController : ControllerBase
{
    private ProductReposetiory _productReposetiory;
    private ProductValidator _productValidator;

    public ProductController(ProductReposetiory reposetiory)
    {
        _productReposetiory = reposetiory;
        _productValidator = new ProductValidator();
    }
    
    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productReposetiory.GetAllProduct();
    }


    [HttpPost]
    public ActionResult CreateNewProduct(Product product)
    {
        var validation = _productValidator.Validate(product);
        if (validation.IsValid)
        {
            return Ok(_productReposetiory.InsertProduct(product));
        }

        return BadRequest(validation.ToString());
    }

    [HttpGet]
    [Route("CreateDb")]
    public string CreateDb()
    {
        
        _productReposetiory.CreateDb();
        return "database created";
    } 


}