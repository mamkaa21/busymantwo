using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace busymantwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Task selectedTask;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Task> Tasks { get; set; }
        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                PropertyChanged?.Invoke(this,                    new PropertyChangedEventArgs(nameof(SelectedTask)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            if (!File.Exists("task.json"))
                Tasks = new ObservableCollection<Task>();
            else
                using (FileStream fs = new FileStream("task.json", FileMode.OpenOrCreate))
                {
                    Tasks = JsonSerializer.Deserialize<ObservableCollection<Task>>(fs);
                }
            ViewTasks();
        }

        private void ViewTasks()
        {
            Tasks = new ObservableCollection<Task>(Class1.Tasks.Where(s => s.Status == "Ожидает" || s.Status == "В работе"));
        }

        private void NewTask_Add(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.ShowDialog();
            ViewTasks();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tasks)));
        }

        private void HistoryBut(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.Show();
        }

        public void Vipilnenie(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
                MessageBox.Show("Обьект выполнен");
            SelectedTask.Status = "Выполнена";
            ViewTasks();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tasks)));
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.Show();

        }

        private void Otmenabut(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
                MessageBox.Show("Обьект отменен");
            SelectedTask.Status = "Отменен";
            ViewTasks();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tasks)));
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.Show();

        }

        void Save()
        {
            using (FileStream fs = new FileStream("task.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fs, Tasks);
            }
        }
    }
}
