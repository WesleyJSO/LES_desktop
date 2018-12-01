using les_desktop.API;
using les_desktop.Controller;
using les_desktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace les_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static FormUrlEncodedContent GetUserCredentials()
        {
            // recuperar os dados de arquivo salvo no computador futuramente
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "email", "wesley@wesley.com" },
                { "password", "1234" }
            });
        }
        public MainWindow()
        {
            // User user = PostApiAsync();
            InitializeComponent();
            this.Title = "DAORA";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // var desktopWorkingArea = SystemParameters.WorkArea;
            // this.Left = desktopWorkingArea.Right - this.Width;
            // this.Top = desktopWorkingArea.Bottom - this.Height;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            var fileHandler = new FileHandler();
            var user = new User
            {
                Email = this.Email.Text,
                Password = this.Password.Text
            };
            DomainEntity eEntity = SystemAPI.Run(user, "login", "POST");
            fileHandler.CreateFileWithEncryptedDate(eEntity);
        }
    }
}
