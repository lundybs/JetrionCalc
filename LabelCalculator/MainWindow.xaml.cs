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

namespace LabelCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalcLibrary calc = new CalcLibrary();
        private double extraFootage = 0;
        private double percentage = 0;

        public MainWindow()
        {
            InitializeComponent();
            LabelQuanityTextBox.Focus();
        }

        private void MenuItem_Click_Help(object sender, RoutedEventArgs e) //This is the about menu
        {
            MessageBox.Show("This is a working prototype, not a final product yet.", "About", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e) //This cloes the application in the menu
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

                if (LabelsPerImageTextBox.Text != "" || LabelQuanityTextBox.Text != "" || PixelLengthTextBox.Text != "" || EyeMarksTextBox.Text != "")
                {
                    try
                    {
                        string labelsToPrint = calc.LabelTotals(percentage, extraFootage);
                        calc.LabelInfo(LabelQuanityTextBox.Text, PixelLengthTextBox.Text, LabelsPerImageTextBox.Text, EyeMarksTextBox.Text);

                        TotalLabelsTextBox.Text = labelsToPrint;
                        TailTextBox.Text = calc.TailCalculation();
                        LeaderTextBox.Text = calc.LeaderCalculation();
                        ItemBlankTextBox.Text = calc.ItemBlankCalculation();
                        FiftyFeetTextBox.Text = calc.FiftyFootCalculation();
                        OneHundredFeetTextBox.Text = calc.OneHundredFootCalculation();
                        ThreeHundredFeetTextBox.Text = calc.ThreeHundredFootCalcation();
                        OneEighthPitchTextBox.Text = calc.EighthPitchCalculation();
                        ThirtyTwoPitchTextBox.Text = calc.ThirtyTwoPitchCalculation();
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

        private void CalcuateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string labelsToPrint = calc.LabelTotals(percentage, extraFootage);
                calc.LabelInfo(LabelQuanityTextBox.Text, PixelLengthTextBox.Text, LabelsPerImageTextBox.Text, EyeMarksTextBox.Text);

                TotalLabelsTextBox.Text = labelsToPrint;
                TailTextBox.Text = calc.TailCalculation();
                LeaderTextBox.Text = calc.LeaderCalculation();
                ItemBlankTextBox.Text = calc.ItemBlankCalculation();
                FiftyFeetTextBox.Text = calc.FiftyFootCalculation();
                OneHundredFeetTextBox.Text = calc.OneHundredFootCalculation();
                ThreeHundredFeetTextBox.Text = calc.ThreeHundredFootCalcation();
                OneEighthPitchTextBox.Text = calc.EighthPitchCalculation();
                ThirtyTwoPitchTextBox.Text = calc.ThirtyTwoPitchCalculation();

            }
            catch
            {
                MessageBox.Show("You did not enter in a correct number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearListButton_Click(object sender, RoutedEventArgs e)
        {
            //will remove this method
        }

        private void FiftyFootStopButton_Click(object sender, RoutedEventArgs e)
        {
            int labelQuantity = int.Parse(TotalStopTextBox.Text);
            int printLabel = int.Parse(PrintedStopTextBox.Text);
            int difference = labelQuantity - printLabel;
            try
            {
                if (difference >= 0)
                {
                    string returnValue = calc.FiftyFootStop(PixelLengthTextBox.Text, TotalStopTextBox.Text, PrintedStopTextBox.Text);
                    NewTotalStopTextBox.Text = returnValue;
                }
                else
                {
                    MessageBox.Show("The new total is greater than the total images to print", "Negative Total", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Not all boxes were correctly filled in.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckBoxEmboss_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxEmboss.IsChecked == true)
            {
                extraFootage = 2;
            }
            else
            {
                extraFootage = 0;
            }
        }

        private void CheckBoxHotStamp_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxHotStamp.IsChecked == true)
            {
                extraFootage = 4;
            }
            else
            {
                extraFootage = 0;
            }
        }

        private void RadioButton0Percent_Checked(object sender, RoutedEventArgs e)
        {
            if (LabelQuanityTextBox.Text != "")
            {
                int orderLabelQuantity = int.Parse(LabelQuanityTextBox.Text);


                if (RadioButton0Percent.IsChecked == true)
                {
                    if (orderLabelQuantity >= 10000)
                    {
                        percentage = 1.02;
                    }
                    else if (orderLabelQuantity <= 4999)
                    {
                        percentage = 1.05;
                    }
                    else
                    {
                        percentage = 1.1;
                    }

                }
            }
        }

        private void RadioButton2Percent_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButton2Percent.IsChecked == true)
            {
                percentage = 1.02;
            }
        }

        private void RadioButton5Percent_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButton5Percent.IsChecked == true)
            {
                percentage = 1.05;
            }
        }

        private void RadioButton10Percent_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButton10Percent.IsChecked == true)
            {
                percentage = 1.1;
            }
        }

        private void ComboBoxResolution_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> resolution = new List<string>();
            resolution.Add("Select DPI");
            resolution.Add("270 DPI");
            resolution.Add("225 DPI");
            resolution.Add("180 DPI");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = resolution;
            comboBox.SelectedIndex = 0;
        }

        private void PDOffSetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (ComboBoxResolution.SelectedIndex)
                {
                    case 1:
                        double resHigh = 270;
                        NewPDOffSetResolutions(resHigh);
                        break;
                    case 2:
                        double resMed = 225;
                        NewPDOffSetResolutions(resMed);
                        break;
                    case 3:
                        double resLow = 180;
                        NewPDOffSetResolutions(resLow);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Not all values were enter in correctly.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void NewPDOffSetResolutions(double resolution)
        {
            string w1r1 = calc.White1R1PDOffSet(W1R1TextBox.Text, resolution);
            string w1r2 = calc.White1R1PDOffSet(W1R2TextBox.Text, resolution);
            string w2r1 = calc.White1R1PDOffSet(W2R1TextBox.Text, resolution);
            string w2r2 = calc.White1R1PDOffSet(W2R2TextBox.Text, resolution);
            string w3r1 = calc.White1R1PDOffSet(W3R1TextBox.Text, resolution);
            string w3r2 = calc.White1R1PDOffSet(W3R2TextBox.Text, resolution);
            string c1r1 = calc.White1R1PDOffSet(C1R1TextBox.Text, resolution);
            string c1r2 = calc.White1R1PDOffSet(C1R2TextBox.Text, resolution);
            string c2r1 = calc.White1R1PDOffSet(C2R1TextBox.Text, resolution);
            string c2r2 = calc.White1R1PDOffSet(C2R2TextBox.Text, resolution);
            string c3r1 = calc.White1R1PDOffSet(C3R1TextBox.Text, resolution);
            string c3r2 = calc.White1R1PDOffSet(C3R2TextBox.Text, resolution);
            string m1r1 = calc.White1R1PDOffSet(M1R1TextBox.Text, resolution);
            string m1r2 = calc.White1R1PDOffSet(M1R2TextBox.Text, resolution);
            string m2r1 = calc.White1R1PDOffSet(M2R1TextBox.Text, resolution);
            string m2r2 = calc.White1R1PDOffSet(M2R2TextBox.Text, resolution);
            string m3r1 = calc.White1R1PDOffSet(M3R1TextBox.Text, resolution);
            string m3r2 = calc.White1R1PDOffSet(M3R2TextBox.Text, resolution);
            string y1r1 = calc.White1R1PDOffSet(Y1R1TextBox.Text, resolution);
            string y1r2 = calc.White1R1PDOffSet(Y1R2TextBox.Text, resolution);
            string y2r1 = calc.White1R1PDOffSet(Y2R1TextBox.Text, resolution);
            string y2r2 = calc.White1R1PDOffSet(Y2R2TextBox.Text, resolution);
            string y3r1 = calc.White1R1PDOffSet(Y3R1TextBox.Text, resolution);
            string y3r2 = calc.White1R1PDOffSet(Y3R2TextBox.Text, resolution);
            string k1r1 = calc.White1R1PDOffSet(K1R1TextBox.Text, resolution);
            string k1r2 = calc.White1R1PDOffSet(K1R2TextBox.Text, resolution);
            string k2r1 = calc.White1R1PDOffSet(K2R1TextBox.Text, resolution);
            string k2r2 = calc.White1R1PDOffSet(K2R2TextBox.Text, resolution);
            string k3r1 = calc.White1R1PDOffSet(K3R1TextBox.Text, resolution);
            string k3r2 = calc.White1R1PDOffSet(K3R2TextBox.Text, resolution);

            NewResolutionW1R1TextBox.Text = w1r1;
            NewResolutionW1R2TextBox.Text = w1r2;
            NewResolutionW2R1TextBox.Text = w2r1;
            NewResolutionW2R2TextBox.Text = w2r2;
            NewResolutionW3R1TextBox.Text = w3r1;
            NewResolutionW3R2TextBox.Text = w3r2;
            NewResolutionC1R1TextBox.Text = c1r1;
            NewResolutionC1R2TextBox.Text = c1r2;
            NewResolutionC2R1TextBox.Text = c2r1;
            NewResolutionC2R2TextBox.Text = c2r2;
            NewResolutionC3R1TextBox.Text = c3r1;
            NewResolutionC3R2TextBox.Text = c3r2;
            NewResolutionM1R1TextBox.Text = m1r1;
            NewResolutionM1R2TextBox.Text = m1r2;
            NewResolutionM2R1TextBox.Text = m2r1;
            NewResolutionM2R2TextBox.Text = m2r2;
            NewResolutionM3R1TextBox.Text = m3r1;
            NewResolutionM3R2TextBox.Text = m3r2;
            NewResolutionY1R1TextBox.Text = y1r1;
            NewResolutionY1R2TextBox.Text = y1r2;
            NewResolutionY2R1TextBox.Text = y2r1;
            NewResolutionY2R2TextBox.Text = y2r2;
            NewResolutionY3R1TextBox.Text = y3r1;
            NewResolutionY3R2TextBox.Text = y3r2;
            NewResolutionK1R1TextBox.Text = k1r1;
            NewResolutionK1R2TextBox.Text = k1r2;
            NewResolutionK2R1TextBox.Text = k2r1;
            NewResolutionK2R2TextBox.Text = k2r2;
            NewResolutionK3R1TextBox.Text = k3r1;
            NewResolutionK3R2TextBox.Text = k3r2;
        }
    }
}