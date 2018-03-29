using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SortingVisually
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] quantity;
        const int N = 10;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Swap(int a, int b)
        {
            int tmp = quantity[a];
            quantity[a] = quantity[b];
            quantity[b] = tmp;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //int j;
            

            for (int i = 0; i < N-1; i++)
            {
                
                for (int j = 1; j < N-i; j++)
                {
                    {
                        Binding binding = new Binding();
                        //binding.ElementName = "j";
                        //binding.Path = new PropertyPath("j");
                        binding.Source = j;
                        //lblText.SetBinding(Label.ContentProperty, binding);
                        BindingOperations.SetBinding(lblText, Label.ContentProperty, binding);
                        lblText.Content = j + "<" + (j - 1);

                    }
                    
                    Thread.Sleep(100);
                    if (quantity[j] < quantity[j - 1])
                    {
                        Swap(j, j - 1);
                    }
                }
            }
            MessageBox.Show("The end");
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            quantity = new int[N];
            for (int i = 0; i < N; i++)
            {
                quantity[i] = rnd.Next(1, 200);
            }

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.VerticalAlignment = VerticalAlignment.Bottom;
            Basic_sp.Children.Add(grid);


            for (int i = 0; i < N; i++)
            {
                StackPanel spnl = new StackPanel();
                spnl.VerticalAlignment = VerticalAlignment.Bottom;

                TextBlock lbl_T = new TextBlock();
                lbl_T.Text = String.Format("{0}", quantity[i]);
                lbl_T.Foreground = new SolidColorBrush(Colors.Red);
                lbl_T.HorizontalAlignment = HorizontalAlignment.Center;
                spnl.Children.Add(lbl_T);

                Label lbl_L = new Label();
                lbl_L.Background = new SolidColorBrush(Colors.Black);
                lbl_L.Height = quantity[i];
                lbl_L.HorizontalAlignment = HorizontalAlignment.Center;
                spnl.Children.Add(lbl_L);

                TextBlock lbl_B = new TextBlock();
                lbl_B.Text = String.Format("{0}", i);
                lbl_B.Foreground = new SolidColorBrush(Colors.Green);
                lbl_B.HorizontalAlignment = HorizontalAlignment.Center;
                spnl.Children.Add(lbl_B);

                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetRow(spnl, 0);
                Grid.SetColumn(spnl, i);
                grid.Children.Add(spnl);
            }
        }
    }
}
