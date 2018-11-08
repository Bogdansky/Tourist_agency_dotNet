using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Desktop_Tourism.Users;

namespace Desktop_Tourism
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int login = 0;
        string[] imageSources = new string[2]{ "pack://application:,,,Pictures/change_1.png", "pack://application:,,,Pictures/change_2.png" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnChangeButtonClick(object sender, RoutedEventArgs e)
        {
            ChangeButtonImage();
            if (Registration.Visibility == Visibility.Collapsed)
            {
                Login.Visibility = Visibility.Collapsed;
                Registration.Visibility = Visibility.Visible;
            }
            else
            {
                Registration.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Visible;
            }
        }

        private void ChangeButtonImage()
        {
            login = GetIndex();
            ButtonImage.Source = BitmapFrame.Create(new Uri(imageSources[login]));
        }

        private int GetIndex()
        {
            return login == 0 ? 1 : 0;
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            UserAction.Login(Nickname.Text, Password.Password);
        }

        private void OnSignUp(object sender, RoutedEventArgs e)
        {
            if (UserAction.SignUp(NewLogin.Text, NewPassword.Password))
            {
                MessageBox.Show("Молодец");
            }
            else
            {
                ShowError("Логин уже используется");
            }
        }

        private void ShowError(string message)
        {
            ToolTip toolTip = new ToolTip
            {
                Content = message
            };
            NewLogin.BorderBrush = new SolidColorBrush(Colors.IndianRed);
            NewLogin.ToolTip = toolTip;
        }
    }
}
