# ASP.NET-Core-8-Razor-Pages-CRUD---.NET-8-Razor-Pages-CRUD-Using-Entity-Framework-Core-and-SQL-Server
ASP.NET Core 8 Razor Pages CRUD - .NET 8 Razor Pages CRUD Using Entity Framework Core and SQL Server


[![Watch the video](https://img.youtube.com/vi/WHFTzo0psng/0.jpg)](https://youtu.be/WHFTzo0psng)

## Introduction
## Create Project 
## Create Database MS SQL Server
## Asp.NET Core Connection Db MS SQL Server
## Install Nugets ASP.NET Core ( Entity Framework )
## Create Application Db Context Class
## Register Database Connections
## Create Product Model  ASP.NET Core
## Add-Migrations ASP.NET Core
## Update-Database (Create Tables) Asp.Net Core
## Create Administration
## List Products
## Create ProductDto Model
## Create the Form Asp.Net Core
## Form Validation Asp.Net Core
                <div class="row mb-3">
                <label  class="col-sm-4 col-form-label">Name</label>
                <div class="col-sm-8">
                 <input asp-for="ProductDto.Name" class="form-control" />
                    <span asp-validation-for="ProductDto.Name" class="text-danger"></span>
                </div>

             </div>
## Upload Image on Server
             string newFilename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
             newFilename += Path.GetExtension(ProductDto.ImageFileName!.FileName);
             string ImageFullPath = environment.WebRootPath + "/Images/" + newFilename;
             using (var stream = System.IO.File.Create(ImageFullPath))
                {
                ProductDto.ImageFileName.CopyTo(stream);
               }
## Delete Image on Server

                //Delete Old Image on the server 
                string OldimageFullPath = environment.WebRootPath + "/images/" + product.ImageFileName;
                System.IO.File.Delete(OldimageFullPath);
## Save On Database
                product.Name = ProductDto.Name;
                product.Brand = ProductDto.Brand;
                product.Category = ProductDto.Category;
                product.Price = ProductDto.Price;
                product.Description = ProductDto.Description ?? "";
                product.ImageFileName = newFileName;

                context.SaveChanges();
                Product = product;
                successMessage = "Product Updated";
                
## Pagination(Page Size)  ASP.NET Core
## Search  ASP.NET Core
## Sporting  ASP.NET Core

In this video, we are going to create an ASP.NET Razor Pages CRUD app using Entity Framework Core and SQL Server. We will use the .NET 8 Razor Pages template in Visual Studio 2022 to create this CRUD app.

we are going to create an ASP.NET Razor Pages Full CRUD Operations application using Entity Framework Core Code First approach and SQL Server. 

We will be using the Core .NET 8 Razor Pages template in Visual Studio 2022 to create this application.

Bootstrap in this ASP.NET Razor Pages website to style our pages.


