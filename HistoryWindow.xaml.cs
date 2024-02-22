using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

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

        private void OK_Click (object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
