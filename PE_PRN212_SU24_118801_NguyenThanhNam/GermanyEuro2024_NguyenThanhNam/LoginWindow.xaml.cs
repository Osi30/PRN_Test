using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GermanyEuro2024_NguyenThanhNam
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UefaAccountService service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            Uefaaccount uefaaccount = service.Login(email, password);
            if (uefaaccount != null)
            {
                if (uefaaccount.Role == 3 || uefaaccount.Role == 2)
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Uefaaccount = uefaaccount;
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("You have no permission to access this function!", "Authentication", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
