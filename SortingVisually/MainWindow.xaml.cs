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
        const int N = 30;
        const int pause = 400;

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
            bool flag;
            do
            {
                flag = false;
                for (int i = 1; i < N; i++)
                {
                    dList[i].MyColor = Brushes.Green;
                    dList[i - 1].MyColor = Brushes.Green;
                    await Task.Delay(pause);
                    if (dList[i - 1].Number > dList[i].Number)
                    {
                        await Task.Delay(pause);
                        Swap(i - 1, i);
                        flag = true;
                        await Task.Delay(pause);
                    }
                    await Task.Delay(pause);
                    dList[i].MyColor = Brushes.Red;
                    dList[i - 1].MyColor = Brushes.Red;
                }
            } while (flag != false);
        }

        async private void InsertSort()
        {
            for (int i = 1; i < N; i++)
            {
                dList[i].MyColor = Brushes.Green;
                await Task.Delay(pause);
                int j = i;
                while (j > 0)
                {
                    dList[j].MyColor = Brushes.Green;
                    dList[j - 1].MyColor = Brushes.Green;
                    await Task.Delay(pause);

                    if (dList[j - 1].Number > dList[j].Number)
                    {
                        Swap(j - 1, j);
                    }
                    await Task.Delay(pause);
                    dList[j].MyColor = Brushes.Red;
                    dList[j - 1].MyColor = Brushes.Red;
                    j--;
                }
            }
        }

        async private void SelectionSort()
        {
            for (int i=0; i<N; i++)
            {
                int min = i;
                for (int j = i+1; j < N; j++)
                {
                    if (dList[j].Number < dList[min].Number)
                    {
                        min = j;
                    }
                }
                dList[min].MyColor = Brushes.Green;
                dList[i].MyColor = Brushes.Green;
                await Task.Delay(pause);
                Swap(min, i);
                await Task.Delay(pause);
                dList[min].MyColor = Brushes.Red;
                dList[i].MyColor = Brushes.Red;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Bubble.IsChecked == true)
            {
                BubbleSort();
            }
            else if (Inserts.IsChecked == true)
            {
                InsertSort();
            }
            else if (Selection.IsChecked == true)
            {
                SelectionSort();
            }
        }

        private void Fill()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                dList.Add(new DataList(rnd.Next(1, 200), Brushes.Red));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Fill();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dList.Clear() ;
            Fill();
        }
    }
}
