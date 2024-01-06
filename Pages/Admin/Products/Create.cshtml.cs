using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using Product_Tutorial.Models;
using Product_Tutorial.Services;

namespace Product_Tutorial.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private string errormessage;
        private string successmessage;
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ProductDto.ImageFileName == null)
            {
                ModelState.AddModelError("productDto.ImageFile", "The Image File is Required");
            }
            if (!ModelState.IsValid)
            {
                errormessage = "Please provide all The Required fields";
                return;
            }


            //save Image On server 
            string newFilename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFilename += Path.GetExtension(ProductDto.ImageFileName!.FileName);
            string ImageFullPath = environment.WebRootPath + "/Images/" + newFilename;
            using (var stream = System.IO.File.Create(ImageFullPath))
            {
                ProductDto.ImageFileName.CopyTo(stream);
            }
            // save on database

            ProductTable product = new ProductTable
            { 
            Name =ProductDto.Name,
                Brand = ProductDto.Brand,
                Category = ProductDto.Category,
                Price = ProductDto.Price,
                Description = ProductDto.Description,
     
                CreatedAt = DateTime.Now,
                ImageFileName = newFilename,
            };
            context.productTables.Add(product);
            context.SaveChanges();
            Response.Redirect("/Admin/Products/Index");

            //clera the Form
            ProductDto.Name = "";
            ProductDto.Brand = "";
            ProductDto.Category = "";
            // ProductDto.Price = "";
            ProductDto.Description = "";
            ProductDto.ImageFileName = null;
            ModelState.Clear();
            successmessage = "Product Added suceessfully ";
        }

        // [BindProperty]
        //  public ProductTable ProductTable { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

    }
}
