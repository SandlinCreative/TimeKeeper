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

        public MainWindow()
        {
            InitializeComponent();


            //Entry testEntry = new Entry("Business Office", "Some notes.", 8, 11.25f, 28.75f);

            ObservableCollection<Entry> entryData = new ObservableCollection<Entry>();

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

            dg_list.DataContext = entryData;
        }

        private void dg_list_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void dg_list_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("I am heard.");
        }


        private void Window_Initialized(object sender, EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
