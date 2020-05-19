using ComputerShop.viewmodel.login;
using System.Windows;

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

			this.Top = (screenHeight - this.MaxHeight) / 2;
			this.Left = (screenWidth - this.MaxWidth) / 2;
			this.Loaded += Login_Loaded;
		}


		private void Login_Loaded(object sender, RoutedEventArgs e)
		{
			SignIn view = new SignIn();

			SignInViewModel vm = new SignInViewModel();
			vm.CodeBehind = this;
			view.DataContext = vm;
			this.LoginOutputView.Content = view;

		}


	}
}
