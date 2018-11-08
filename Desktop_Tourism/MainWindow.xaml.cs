using System;
using System.Threading.Tasks;
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
        string[] imageSources = new string[2]{ @"pack://application:,,,/pictures/change_1.png", @"pack://application:,,,/pictures/change_2.png" };
        private const string errorTemplate = "Ошибка! Причина: ";

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
            ButtonImage.Source = new BitmapImage(new Uri(imageSources[login]));
        }

        private int GetIndex()
        {
            return login == 0 ? 1 : 0;
        }

        private async void OnLoginClick(object sender, RoutedEventArgs e)
        {
            bool tryLogin = await TryLogin();
            if (tryLogin)
            {
                MessageBox.Show("Молодец! Вход произошёл успешно");
            }
            else
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        public async Task<bool> TryLogin()
        {
            string login = Nickname.Text, password = Password.Password;
            return await Task.Run(() => (UserAction.Login(login, password)));
        }

        private void OnSignUp(object sender, RoutedEventArgs e)
        {
            if (GetMessage().Length == 0)
            {
                MessageBox.Show("Молодец");
            }
            else
            {
                ShowError(GetMessage());
            }
        }

        private string GetMessage()
        {
            string errorReason = $"{GetSignUpMessage()}. {EqualsPasswords()}";
            return errorReason.Length == 1 ? "" : errorTemplate + errorReason;
        }

        private async Task<string> GetSignUpMessage()
        {
            return await UserAction.SignUp(NewLogin.Text, NewPassword.Password) ? "" : "Логин уже используется";
        }

        private string EqualsPasswords()
        {
            return NewPassword.Password.Equals(TryPassword.Password) ? "" : "Пароли не совпадают";
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
