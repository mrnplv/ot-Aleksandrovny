using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace otAleksandrovny
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();
            this.BindingContext = new ProductsCollectionViewModel();
        }
        private async void CartButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

    }
}