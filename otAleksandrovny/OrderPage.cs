using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace otAleksandrovny
{
    public class OrderPage : ContentPage
    {
        Picker timepicker;
        Entry cardnumber;
        Entry expirymonth;
        Entry expiryyear;
        Entry cvv;
        Entry ownername;
        Button confirmOrderButton;
        public OrderPage(int cartsum)
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout order = new StackLayout
            {
                Spacing = 15,
                Orientation = StackOrientation.Vertical
            };
            order.Children.Add(new Label
            {
                Text = "Заказ",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                TextColor = Color.DarkOrchid,
                FontFamily = "MontserratSB"
            });

            order.Children.Add(timepicker = new Picker
            {
                Title = "Время получения заказа",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Orchid,
                FontFamily = "MontserratSB"
            });
            timepicker.Items.Add("10:00 - 10:30");
            timepicker.Items.Add("11:00 - 11:30");
            timepicker.Items.Add("12:00 - 12:30");
            timepicker.Items.Add("13:00 - 13:30");
            timepicker.Items.Add("14:00 - 14:30");
            timepicker.Items.Add("15:00 - 15:30");
            timepicker.Items.Add("16:00 - 16:30");
            timepicker.Items.Add("17:00 - 17:30");
            timepicker.Items.Add("18:00 - 18:30");
            timepicker.Items.Add("19:00 - 19:30");
            timepicker.Items.Add("20:00 - 20:30");

            Frame frame1 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = new Entry { Placeholder = "Комментарий к заказу", FontFamily = "MontserratSB" }
            };
            order.Children.Add(frame1);

            Grid cardinfo = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };
            order.Children.Add(new Label
            {
                Text = "Данные карты:",
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 20,
                TextColor = Color.Orchid,
                FontFamily = "MontserratSB"
            });
            cardnumber = new Entry
            {
                Placeholder = "Номер карты",
                Text = "",
                Keyboard = Keyboard.Numeric,
                MaxLength = 16
            };
            expirymonth = new Entry
            {
                Placeholder = "ММ",
                Text = "",
                Keyboard = Keyboard.Numeric,
                MaxLength = 2
            };
            expiryyear = new Entry
            {
                Placeholder = "ГГ",
                Text = "",
                Keyboard = Keyboard.Numeric,
                MaxLength = 2
            };
            cvv = new Entry
            {
                Placeholder = "CVV",
                Text = "",
                Keyboard = Keyboard.Numeric,
                MaxLength = 3
            };
            ownername = new Entry
            {
                Placeholder = "Имя владельца",
                Text = ""
            };
            Grid.SetColumnSpan(cardnumber, 3);
            cardinfo.Children.Add(cardnumber);
            cardinfo.Children.Add(expirymonth, 0, 1);
            cardinfo.Children.Add(expiryyear, 1, 1);
            cardinfo.Children.Add(cvv, 2, 1);
            Grid.SetColumnSpan(ownername, 3);
            Grid.SetRow(ownername, 2);
            cardinfo.Children.Add(ownername);
            Frame frame2 = new Frame()
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = cardinfo
            };
            order.Children.Add(frame2);

            order.Children.Add(new Label
            {
                Text = string.Format("Сумма заказа: {0} ₽", cartsum),
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 20,
                TextColor = Color.Orchid,
                FontFamily = "MontserratSB"
            });

            order.Children.Add(confirmOrderButton = new Button
            {
                Text = "Оформить заказ",
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
            confirmOrderButton.Clicked += ConfirmButton_Click;
            this.Content = order;
        }
        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(cardnumber.Text)) || (string.IsNullOrWhiteSpace(expirymonth.Text)) || (string.IsNullOrWhiteSpace(expiryyear.Text)) || (string.IsNullOrWhiteSpace(cvv.Text)) || (string.IsNullOrWhiteSpace(ownername.Text)))
            {
                await DisplayAlert("Ошибка", "Заполните данные карты", "OK");
            }
            else
            {
                ProductsCollectionViewModel.selectedProductsList.Clear();
                await DisplayAlert("Заказ", "Заказ успешно оформлен", "OK");
                await Navigation.PopAsync();
            }
               
        }
    }   
}
