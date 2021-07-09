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

using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

using System.Runtime.InteropServices;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Entry> entryData = new ObservableCollection<Entry>();

        public MainWindow()
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();

            AllocConsole();
            string consoleTitle = "     ______                            __         ____          __                 __ " + System.Environment.NewLine + "    / ____/____   ____   _____ ____   / /___     / __ \\ __  __ / /_ ____   __  __ / /_" + System.Environment.NewLine + "   / /    / __ \\ / __ \\ / ___// __ \\ / // _ \\   / / / // / / // __// __ \\ / / / // __/" + System.Environment.NewLine + "  / /___ / /_/ // / / /(__  )/ /_/ // //  __/  / /_/ // /_/ // /_ / /_/ // /_/ // /_  " + System.Environment.NewLine + "  \\____/ \\____//_/ /_//____/ \\____//_/ \\___/   \\____/ \\__,_/ \\__// .___/ \\__,_/ \\__/  " + System.Environment.NewLine + "                                                                /_/                   " + System.Environment.NewLine;
            System.Console.WriteLine(consoleTitle);
            InitializeComponent();


            //Entry testEntry = new Entry("Business Office", "Some notes.", 8, 11.25f, 28.75f);

            

            for (int i = 0; i <= 2; i++)
            {
                entryData.Add(new Entry(
                    "Location " + i,
                    DateTime.Now,
                    DateTime.Now.AddHours(i),
                    28.75,
                    "sample notes"
                    ));
            }

            
        }

        private void dg_list_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            Console.WriteLine("Auto Generating Column " + e.Column.Header);

        }

        private void dg_list_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Console.WriteLine("Loading Row...\n" + e.Row.Item);
        }

        private void dg_list_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            Console.WriteLine("Row Details Loading...");
        }

        private void dg_list_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DataGrid Loaded.");
            dg_list.DataContext = entryData;
        }
    }
}
