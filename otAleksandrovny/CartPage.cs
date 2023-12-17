using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace otAleksandrovny
{
    public class CartPage : ContentPage
    {
        public CollectionView cart;
        Image image;
        public static int cartSum { get; set; }
        Button orderButton;
        public CartPage()
        {
            this.Padding = new Thickness(20, 20, 20, 20);
            StackLayout cartlayout = new StackLayout
            {
                Spacing = 15,
                Orientation = StackOrientation.Vertical
            };
            cartlayout.Children.Add(new Label
            {
                Text = "Корзина",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                TextColor = Color.DarkOrchid,
                FontFamily = "MontserratSB"
            });
            cartlayout.Children.Add(cart = new CollectionView
            {
                ItemsSource = ProductsCollectionViewModel.selectedProductsList,
                ItemTemplate = new DataTemplate(() =>
                {
                    Grid cartgrid = new Grid
                    {
                        Padding = 10,
                        RowDefinitions =
                        {
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto }
                        },
                        ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = GridLength.Auto },
                            new ColumnDefinition { Width = 180 },
                            new ColumnDefinition { Width = 20 }
                        }
                    };
                    Frame frame = new Frame
                    {
                        BorderColor = Color.DimGray,
                        CornerRadius = 10,
                        Padding = 0,
                        HasShadow = true,
                        Content = image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 90, VerticalOptions = LayoutOptions.FillAndExpand }
                    };
                    image.SetBinding(Image.SourceProperty, "Image");

                    Label nameLabel = new Label 
                    { 
                        FontAttributes = FontAttributes.Bold, 
                        FontSize = 15, 
                        TextColor = Color.MediumOrchid,
                        VerticalOptions = LayoutOptions.End
                    };
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label priceLabel = new Label 
                    {
                        TextColor = Color.DimGray,
                        VerticalOptions = LayoutOptions.Start                                   
                    };
                    priceLabel.SetBinding(Label.TextProperty, "Price1");

                    Label countlabel = new Label
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.End
                    };
                    countlabel.SetBinding(Label.TextProperty, "ProductCount");

                    Label cartlabel = new Label
                    {
                        Text = "шт.",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Start
                    };

                    Grid.SetRowSpan(frame, 2);
                    cartgrid.Children.Add(frame);
                    cartgrid.Children.Add(nameLabel, 1, 0);
                    cartgrid.Children.Add(priceLabel, 1, 1);
                    cartgrid.Children.Add(countlabel, 2, 0);
                    cartgrid.Children.Add(cartlabel, 2, 1);
                    return cartgrid;
                })
            });
            cartlayout.Children.Add(orderButton = new Button
            {
                Text = "Оформление заказа",
                TextTransform = TextTransform.None,
                TextColor = Color.White,
                BorderColor = Color.Gray,
                BorderWidth = 1,
                CornerRadius = 10,
                HeightRequest = 60,
                WidthRequest = 300,
                FontSize = 18,
                FontFamily = "MontserratSB",
                BackgroundColor = Color.Orchid,
                HorizontalOptions = LayoutOptions.Center
            });
            orderButton.Clicked += OrderButton_Click;
            this.Content = cartlayout;
        }
        private async void OrderButton_Click(object sender, EventArgs e)
        {
            cartSum = 0;
            foreach(ProductViewModel cartprod in ProductsCollectionViewModel.selectedProductsList)
            {
                cartSum += (cartprod.Price2 * cartprod.ProductCount);
            }
            await Navigation.PushAsync(new OrderPage(cartSum));
        }
    }
}
