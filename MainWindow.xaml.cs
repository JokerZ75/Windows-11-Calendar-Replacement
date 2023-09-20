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

namespace Windows_11_Calendar_Replacement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        // Attributes
        Calender calendar;

        public MainWindow()
        {
            InitializeComponent();

            calendar = new Calender();
            UpdateWindow();
        }

        void DateButton_Click(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            button.Background = Brushes.Red;
        }



        void UpdateWindow()
        {
            Month currentMonth = calendar.CurrentMonth;
            string currentYear = calendar.CurrentYear.ToString();

            CurrentMonthLabel.Content = currentMonth.ToString();
            CurrentYearLabel.Content = currentYear;

            // Create a grid for the dates
            Grid grid = new Grid();
            for (
                int i = 0; i < 7; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(col);
            }
            for (
                int i = 0; i < 6; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }

            int x = 0;

            foreach (Day day in currentMonth.Days)
            {

                Button dateButton = new Button();
                dateButton.Content = day.ToString();
                dateButton.Click += DateButton_Click;
                Grid.SetRow(dateButton, x / 7);
                Grid.SetColumn(dateButton, x % 7);
                grid.Children.Add(dateButton);
                x++;
            }

            x = 0;

            grid.ShowGridLines = true;

            DatesGrid.Children.Clear();
            DatesGrid.Children.Add(grid);

        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            calendar.NextMonth();
            UpdateWindow();
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            calendar.PrevMonth();
            UpdateWindow();
        }
    }
}
