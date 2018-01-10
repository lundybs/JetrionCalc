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

namespace LabelCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtLabelQuanity.Focus();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //This is the about menu
        {
            MessageBox.Show("This is a working prototype, not a final product yet.", "About", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //This cloes the application in the menu
        {
            this.Close();
        }

        public void EnterToTab(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        public void ClearTextBoxWithGotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();

            if (e.OriginalSource is TextBox textbox)
            {
                textbox.SelectAll();
            }
        }

        public void EnterToCalculate(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                if (null) { }
                else
                {
                    try
                    {
                        
                    }
                    catch
                    {
                        MessageBox.Show("You did not enter in correct numeric values", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
                }
            }

            else if (e.Key == Key.Up)
            {
                e.Handled = true;
                uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
            }

            else if (e.Key == Key.Down)
            {
                e.Handled = true;
                uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
