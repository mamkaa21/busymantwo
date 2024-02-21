using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static busymantwo.MainWindow;
using static busymantwo.TaskWindow;

namespace busymantwo
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public HistoryWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>(Class1.Tasks.Where(s => s.Status == "Выполнена"));
            DataContext = this;
        }
       
    }
}
