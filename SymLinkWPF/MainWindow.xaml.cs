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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymLinkWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			LoadDefaults();
		}

		private void BtnSubmit_Click(object sender, RoutedEventArgs e)
		{
			SymLinkObj symLink = new SymLinkObj()
			{
				Link = txtLinkLocation.Text,
				Target = txtTargetLocation.Text,
				IsDirJunction = chkIsDirJunction.IsChecked ?? false
			};
			SymLinkObj obj = new SymLinkObj();
			obj = SymLinkProcessor.Process_DEBUG(symLink);

			string disp = "";
			foreach (var item in obj.Messages)
			{
				disp += item + "\n";
			}

			MessageBox.Show(disp);
		}

		private void LoadDefaults()
		{
			//TODO: Link these to a config file location
			chkIsDirJunction.IsChecked = true;
			txtLinkLocation.Text = @"C:\SymCache";
		}

		private void btnQuit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnLinkBrowse_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnTargetBrowse_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
