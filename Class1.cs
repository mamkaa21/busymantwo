using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busymantwo
{
    internal class Class1
    {
        public static ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
    }

    public class Task
    {
        public string Info { get; set; } = " ";
        public DateTime DataStart { get; set; } = DateTime.Now;
        public string Speed { get; set; } = " ";
        public string Status { get; set; } = " ";
        public DateTime? DataEnd { get; set; }

    }
}
