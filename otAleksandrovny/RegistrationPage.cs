using otAleksandrovny;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace otAleksandrovny
{
    public class RegistrationPage : ContentPage
    {
        Entry Name;
        Entry PhoneNumber;
        Entry RegistrationEmail;
        Entry RegistrationPassword;
        Button registrationButton;
        Customer customer = new Customer();
        public RegistrationPage()
        {
            
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout registration = new StackLayout
            {
                Spacing = 15,
                Orientation = StackOrientation.Vertical
            };
            //registration.Children.Add(new Image
            //{
            //    Source = "logo.png",
            //    HorizontalOptions = LayoutOptions.Center
            //});
            registration.Children.Add(new Label
            {
                Text = "Регистрация",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                TextColor = Color.DarkOrchid,
                FontFamily = "MontserratSB"
            });
            Frame frame1 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = Name = new Entry { Placeholder = "Имя", Text = "", FontFamily = "MontserratSB" }
            };
            registration.Children.Add(frame1);
            Frame frame2 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = PhoneNumber = new Entry { Placeholder = "Номер телефона", Text = "", FontFamily = "MontserratSB" }
            };
            registration.Children.Add(frame2);
            Frame frame3 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = RegistrationEmail = new Entry { Placeholder = "Email", Text = "", FontFamily = "MontserratSB" }
            };
            registration.Children.Add(frame3);
            Frame frame4 = new Frame
            {
                BorderColor = Color.MediumOrchid,
                CornerRadius = 10,
                HasShadow = true,
                Content = RegistrationPassword = new Entry { Placeholder = "Пароль", Text = "", FontFamily = "MontserratSB" }
            };
            registration.Children.Add(frame4);
            registration.Children.Add(registrationButton = new Button
            {
                Text = "Подтвердить",
                TextTransform = TextTransform.None,
                TextColor = Color.White,
                WidthRequest = 200,
                HeightRequest = 60,
                CornerRadius = 10,
                BorderColor = Color.Gray,
                BorderWidth = 1,
                FontSize = 18,
                FontFamily = "MontserratSB",
                BackgroundColor = Color.Orchid,
                HorizontalOptions = LayoutOptions.Center,
            });
            registrationButton.Clicked += RegistrationButton_Click;
            this.Content = registration;
        }
        private async void RegistrationButton_Click(object sender, EventArgs e)
        {
            
            if ((string.IsNullOrWhiteSpace(Name.Text)) || (string.IsNullOrWhiteSpace(PhoneNumber.Text)) ||
                (string.IsNullOrWhiteSpace(RegistrationEmail.Text)) || (string.IsNullOrWhiteSpace(RegistrationPassword.Text)))
            {
                await DisplayAlert("Ошибка регистрации", "Заполните все поля", "OK");
            }
            else
            {
                customer.Name = Name.Text;
                customer.Email = RegistrationEmail.Text;
                customer.Password = RegistrationPassword.Text;
                customer.PhoneNumber = PhoneNumber.Text;
                
                var retrunvalue = App.Database.AddUser(customer); 
                if (retrunvalue)
                {
                    await Navigation.PushAsync(new CatalogPage());

                }
                else
                {
                    await DisplayAlert("Ошибка регистрации", "Email уже используется, введите другой", "OK");
                }
               
            }
          
        }

            
    }
}

