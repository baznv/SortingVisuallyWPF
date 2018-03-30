using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;

namespace SortingVisually
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<DataList> dList;
        const int N = 5;

        public MainWindow()
        {
            InitializeComponent();
            dList = new ObservableCollection<DataList>();
            lbox.ItemsSource = dList;
        }

        private void Swap(int a, int b)
        {
            var tmp = dList[a];
            dList[a] = dList[b];
            dList[b] = tmp;

        }

        async private void BubbleSort()
        {
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    dList[j].MyColor = Brushes.Green;
                    dList[j - 1].MyColor = Brushes.Green;
                    await Task.Delay(400);
                    if (dList[j].Number < dList[j - 1].Number)
                    {
                        await Task.Delay(400);

                        Swap(j, j - 1);
                        await Task.Delay(400);

                    }
                    await Task.Delay(400);

                    dList[j].MyColor = Brushes.Red;
                    dList[j - 1].MyColor = Brushes.Red;
                }
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            BubbleSort();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            
            for (int i = 0; i < N; i++)
            {
                dList.Add(new DataList(rnd.Next(1,200), Brushes.Red));
            }

        }
    }
}
