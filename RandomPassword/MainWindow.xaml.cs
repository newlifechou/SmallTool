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

namespace RandomPassword
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            List<CharType> types = new List<CharType>();
            if (CboNumber.IsChecked == true)
            {
                types.Add(CharType.Number);
            }
            if (CboUpper.IsChecked == true)
            {
                types.Add(CharType.Upper);
            }
            if (CboLower.IsChecked == true)
            {
                types.Add(CharType.Lower);
            }
            if (CboSpecial.IsChecked == true)
            {
                types.Add(CharType.Special);
            }

            int.TryParse(TxtLength.Text, out int length);

            string password = new RandomPasswordGenerator().GetPassword(length, types.ToArray());

            TxtPassword.Text = password;

        }
    }
}
