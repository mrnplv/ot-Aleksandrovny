using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace otAleksandrovny
{
    public class MainPage : ContentPage
    {
        Entry Email;
        Entry Password;
        Button loginButton;
        Button registerButton;
       
        public MainPage()
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout login = new StackLayout
            {
                Spacing = 15,
                Orientation = StackOrientation.Vertical,
            };
            login.Children.Add(new Image
            {
                Source = "logo.png",
                HorizontalOptions = LayoutOptions.Center
            });
            login.Children.Add(new Label
            {
                Text = "Вход",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 50,
                TextColor = Color.DarkOrchid,
                FontFamily = "MontserratSB",
            });
            Frame frame1 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = Email = new Entry { Placeholder = "Email", Text = "", FontFamily = "MontserratSB" }
            };
            login.Children.Add(frame1);
            Frame frame2 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = Password = new Entry { Placeholder = "Пароль", Text = "", FontFamily = "MontserratSB" }
            };
            login.Children.Add(frame2);
            login.Children.Add(loginButton = new Button
            {
                Text = "Войти",
                TextTransform = TextTransform.None,
                TextColor = Color.White,
                BorderColor = Color.Gray,
                BorderWidth = 1,
                CornerRadius = 10,
                HeightRequest = 60,
                WidthRequest = 200,
                FontSize = 18,
                FontFamily = "MontserratSB",
                BackgroundColor = Color.Orchid,
                HorizontalOptions = LayoutOptions.Center,
            });
            Grid register = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = 50}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = 120},
                    new ColumnDefinition {Width = 130}
                }
            };
            register.Children.Add(new Label { Text = "Нет аккаунта?", TextColor = Color.Black, FontSize = 17, FontFamily = "MontserratSB", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End }, 0, 0);
            register.Children.Add(registerButton = new Button { Text = "Регистрация", FontSize = 17, TextTransform = TextTransform.None, TextColor = Color.Orchid, FontFamily = "MontserratSB", WidthRequest = 25, HeightRequest = 30, BackgroundColor = Color.Transparent }, 1, 0);
            login.Children.Add(register);
            registerButton.Clicked += RegisterButton_Click;
            loginButton.Clicked += LoginButton_Click;
            this.Content = login;
        }
        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(Email.Text)) || (string.IsNullOrWhiteSpace(Password.Text)))
            {
                await DisplayAlert("Ошибка входа", "Заполните все поля", "OK");
            }
            else
            {
                var retrunvalue = App.Database.LoginValidate(Email.Text, Password.Text);
                if (retrunvalue)
                {
                    await Navigation.PushAsync(new CatalogPage());
                }
                else
                {
                    await DisplayAlert("Ошибка входа", "Такого пользователя не существует, пройдите регистрацию", "OK");
                }
            }
        }

    }
}
