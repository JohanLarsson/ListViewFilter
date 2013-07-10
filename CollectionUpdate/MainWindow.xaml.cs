using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                _vm.Ints.Add(new Dummy{Value = i});
                await Task.Delay(100);
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var itemCollection = List.Items;
            itemCollection.Filter = x => ((Dummy) x).Value%2 == 0;
        }

        private void Button100_Click(object sender, RoutedEventArgs e)
        {
            Add(100);
        }

        private void Button1000_Click(object sender, RoutedEventArgs e)
        {
            Add(1000);
        }

        private void Button10000_Click(object sender, RoutedEventArgs e)
        {
            Add(10000);
        }

        private void Add(int n)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            _vm.Ints.Clear();
            for (int i = 0; i < n; i++)
            {
                _vm.Ints.Add(new Dummy { Value = i });
            }
            Time.Text = string.Format("Adding {0} took {1} ms",n, stopwatch.ElapsedMilliseconds);
        }
    }
}
