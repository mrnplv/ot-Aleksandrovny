using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static Xamarin.Essentials.Permissions;

namespace otAleksandrovny
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public ProductsCollectionViewModel CollectionViewModel { get; set; }
        public ProductViewModel()
        {
            Product = new Product();
        }
        public string Name
        {
            get { return Product.Name; }
            set { Product.Name = value; }
        }
        public string Price1 { 
            get { return Product.Price1; }
            set { Product.Price1 = value; }
        }
        public int Price2
        {
            get { return Product.Price2; }
            set { Product.Price2 = value; }
        }
        public string Image
        {
            get { return Product.Image; }
            set { Product.Image = value; }
        }
        public int ProductCount
        {
            get { return Product.ProductCount; }
            set { Product.ProductCount = value; }
        }
    }
}  
