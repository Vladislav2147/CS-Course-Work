using ComputerShop.model.business;
using ComputerShop.model.database;
using ComputerShop.viewmodel.login;
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
using Mouse = ComputerShop.model.database.Mouse;

namespace ComputerShop.view.login
{
	/// <summary>
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			double screenHeight = SystemParameters.FullPrimaryScreenHeight;
			double screenWidth = SystemParameters.FullPrimaryScreenWidth;
			
			InitializeComponent();

			using(ComputerShopContext context = new ComputerShopContext())
			{
				Console.WriteLine(context.GetEntity<Customer>().Cast<Customer>().FirstOrDefault().Email);
			}
			this.Top = (screenHeight - this.MaxHeight) / 2;
			this.Left = (screenWidth - this.MaxWidth) / 2;
            this.Loaded += Login_Loaded;
        }


        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка стартовой View
            SignIn view = new SignIn();

            SignInViewModel vm = new SignInViewModel();
            vm.CodeBehind = this;
            view.DataContext = vm;
            this.LoginOutputView.Content = view;

        }


    }
}
