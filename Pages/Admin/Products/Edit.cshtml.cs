using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Tutorial.Models;
using Product_Tutorial.Services;

namespace Product_Tutorial.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public string errorMessage = "";
        public string successMessage = "";
        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public ProductTable Product { get; set; } = new ProductTable();
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            var product = context.productTables.Find(id);
            if (id == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }
            ProductDto.Name = product.Name;
            ProductDto.Brand = product.Brand;
            ProductDto.Category = product.Category;
            ProductDto.Price = product.Price;
            ProductDto.Description = product.Description;

            Product = product;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provid all the required fields";
                return;
            }
            var product = context.productTables.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            //Update The Image on server
            string newFileName = product.ImageFileName;
            if (ProductDto.ImageFileName != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProductDto.ImageFileName.FileName);

                string imageFullPath = environment.WebRootPath + "/images/" + newFileName;

                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProductDto.ImageFileName.CopyTo(stream);
                }


                //Delete Old Image on the server 
                string OldimageFullPath = environment.WebRootPath + "/images/" + product.ImageFileName;
                System.IO.File.Delete(OldimageFullPath);

                // Update all change in Database
                product.Name = ProductDto.Name;
                product.Brand = ProductDto.Brand;
                product.Category = ProductDto.Category;
                product.Price = ProductDto.Price;
                product.Description = ProductDto.Description ?? "";
                product.ImageFileName = newFileName;

                context.SaveChanges();
                Product = product;
                successMessage = "Product Updated";

                Response.Redirect("/Admin/Products/Index");
            }
        }
    }
}
