using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace otAleksandrovny
{
    public class ProductsCollectionViewModel
    {
        public Command AddCommand { get; set; }
        public Command RemoveCommand { get; set; }
        public ObservableCollection<ProductViewModel> ProductList { get; }
       
        public static ObservableCollection<ProductViewModel> selectedProductsList { get; set; }

        public ProductsCollectionViewModel()
        {
            selectedProductsList = new ObservableCollection<ProductViewModel>();
            ProductList = new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel { Name = "Круассан миндальный", Price1 = "150 ₽", Price2 = 150, Image = "croissant.jpeg", ProductCount = 0, CollectionViewModel=this },
                new ProductViewModel { Name = "Завиток с изюмом", Price1 = "90 ₽", Price2 = 90, Image = "zavitok.jpg", ProductCount = 0, CollectionViewModel=this },
                new ProductViewModel { Name = "Багет", Price1 = "165 ₽", Price2 = 165, Image = "baget.jpg", ProductCount = 0, CollectionViewModel = this },
                new ProductViewModel { Name = "Батон нарезной", Price1 = "60 ₽", Price2 = 60, Image = "bread.jpg", ProductCount = 0, CollectionViewModel = this },
                new ProductViewModel { Name = "Сосиска в тесте", Price1 = "195 ₽", Price2 = 195, Image = "sosiska.jpeg", ProductCount = 0, CollectionViewModel = this },
                new ProductViewModel { Name = "Хачапури с сыром", Price1 = "171 ₽", Price2 = 171, Image = "hachapuri.jpeg", ProductCount = 0, CollectionViewModel = this },
                new ProductViewModel { Name = "Банановый кекс", Price1 = "140 ₽", Price2 = 140, Image = "bananacake.jpg", ProductCount = 0, CollectionViewModel = this },
                new ProductViewModel { Name = "Шоколадный маффин", Price1 = "123 ₽", Price2 = 123, Image = "muffin.jpg", ProductCount = 0, CollectionViewModel = this },
                new ProductViewModel { Name = "Кофейный пончик", Price1 = "100 ₽", Price2 = 100, Image = "donut.jpg", ProductCount = 0, CollectionViewModel = this }
            };
            AddCommand = new Command(AddToCart);
            RemoveCommand = new Command(RemoveFromCart);
        }
        private void AddToCart(object productObj)
        {
            ProductViewModel product = productObj as ProductViewModel;
            if (selectedProductsList.Contains(product)) 
            {
                ++product.ProductCount;
            }
            else
            {
                product.ProductCount = 1;
                selectedProductsList.Add(product);
            }                        
        }
        private void RemoveFromCart(object productObj)
        {
            ProductViewModel product = productObj as ProductViewModel;
            if (product == null) return;
            else if (product.ProductCount == 1)
            {
                selectedProductsList.Remove(product);
            }
            else
            {
                --product.ProductCount;
            }
        }
    }
}
