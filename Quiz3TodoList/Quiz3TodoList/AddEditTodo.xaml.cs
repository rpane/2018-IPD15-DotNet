using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Quiz3TodoList
{
    /// <summary>
    /// Interaction logic for AddEditTodo.xaml
    /// </summary>
    public partial class AddEditTodo : Window
    {
        
        private Todo currTodo;
        public AddEditTodo(Window parent, Todo __currTodo = null)
        {
            InitializeComponent();
            Owner = parent;
            currTodo = __currTodo;
            btnSaveUpdate.Content = Globals.option;
            if(currTodo != null)
            {
                lblID.Content = currTodo.Id + "";
                tbTask.Text = currTodo.Task;
                dpDueDate.Text = currTodo.DueDate.ToString();
                if(currTodo.taskStatus.ToString() == "Done")
                {
                    cbDone.IsChecked = true;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            string task = tbTask.Text;
            if(task.Length < 1 || task.Length >50)
            {
                MessageBox.Show(this, "Task length needs to be between 1-50 characters", "Input error");
                return;
            }
            
            if(dpDueDate.Text == "")
            {
                MessageBox.Show(this, "Due Date needs to be given", "Input error");
                return;
            }
            DateTime dueDate = DateTime.Parse(dpDueDate.Text);
           
            string isDone;           
            if(cbDone.IsChecked == true)
            {
                isDone = "Done";
            }
            else
            {
                isDone = "Pending";
            }
            Todo.TaskStatus taskStat;
           
                
                if (!Enum.TryParse<Todo.TaskStatus>(isDone, out taskStat))
                {
                    throw new InvalidCastException("Enum value invalid: " + isDone);
                }
            
            
            try
            {
                if(currTodo == null)
                {
                    Todo t = new Todo(task, dueDate, taskStat);
                    Globals.db.AddTodo(t);
                    Globals.statusBar = "Todo Added";
                }
                else
                {
                    currTodo.Task = task;
                    currTodo.DueDate = dueDate;
                    currTodo.taskStatus = taskStat;
                    Globals.db.UpdateTodo(currTodo);
                    Globals.statusBar = "Todo Updated";
                }
                this.DialogResult = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
