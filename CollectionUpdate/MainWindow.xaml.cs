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

namespace CollectionUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Vm _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new Vm();
            this.DataContext = _vm;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.Ints.Clear();
            await Task.Delay(100);
            for (int i = 0; i < 20; i++)
            {
                _vm.Ints.Add(i);
                await Task.Delay(100);
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var itemCollection = List.Items;
            itemCollection.Filter = x => ((int) x)%2 == 0;
        }
    }
}
