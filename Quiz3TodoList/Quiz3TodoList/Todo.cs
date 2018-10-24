using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz3TodoList
{
    public class Todo
    {
        int id;
        string task;
        DateTime dueDate;

        public Todo(string task, DateTime dueDate, TaskStatus status)
        {
            Task = task;
            DueDate = dueDate;
            taskStatus = status;
        }

        public int Id { get => id; set => id = value; }
        public string Task { get => task; set => task = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public TaskStatus taskStatus { get; set; }

        public enum TaskStatus { Pending, Done };

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}",Id,Task,DueDate.ToString("MMM dd, yyyy"), taskStatus);
        }
    }
}
