using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankPercCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbAllAmount.IsReadOnly = true;
        }


        private void MaskingValidationNum(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            int intValue = 0;
            double doubleValue = 0;
            if (!int.TryParse(textBox.Text, out intValue) || (!double.TryParse(textBox.Text, out doubleValue)))
            {
                MessageBox.Show("Введенное значение не является ни целым, ни числом с плавающей точкой.");
                textBox.Text = "";
            }
        }

        private void btCalc_Click(object sender, RoutedEventArgs e)
        {

            double startcount = Convert.ToDouble(tbAmount.Text);
            double rate = Convert.ToDouble(tbPercentage.Text);
            int years = Convert.ToInt32(tbAmountYears.Text);
            rate = rate / 100;
            int periods = 0;

            switch ((cbVariableofAccural.SelectedIndex)
)
            {
                case 0:
                    double dayRate = rate / 365;
                    periods = years * 365;
                    startcount = startcount * Math.Pow((1 + dayRate), periods);
                    tbAllAmount.Text = Convert.ToString(Math.Round(startcount, 2));
                    break;
                case 1:
                    double monthRate = rate / 12;
                    periods = years * 12;
                    startcount = startcount * Math.Pow((1 + monthRate), periods);
                    tbAllAmount.Text = Convert.ToString(Math.Round(startcount, 2));
                    break;
                case 2:
                    double quarterRate = rate / 4;
                    periods = years * 4;
                    startcount = startcount * Math.Pow((1 + quarterRate), periods);
                    tbAllAmount.Text = Convert.ToString(Math.Round(startcount, 2));
                    break;
                case 3:
                    double halfyearRate = rate / 2;
                    periods = years * 2;
                    startcount = startcount * Math.Pow((1 + halfyearRate), periods);
                    tbAllAmount.Text = Convert.ToString(Math.Round(startcount, 2));
                    break;
                case 4:
                    double yearRate = rate;
                    periods = years;
                    startcount = startcount * Math.Pow((1 + yearRate), periods);
                    tbAllAmount.Text = Convert.ToString(Math.Round(startcount, 2));
                    break;
                default:
                    cbVariableofAccural.Text = "Процесс не выбран";
                    break;
            }

        }

    }
}