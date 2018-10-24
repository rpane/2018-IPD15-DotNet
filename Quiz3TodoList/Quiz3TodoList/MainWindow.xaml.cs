using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace Quiz3TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Globals.db = new Database();
                RefreshList();
                lblStatus.Text = "....";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "Error connecting to database:\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void lvTask_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Todo currTodo = lvTask.SelectedItem as Todo;
            if (currTodo == null) return;
            Globals.option = "Update";
            AddEditTodo dlg = new AddEditTodo(this, currTodo);
            if (dlg.ShowDialog() == true)
            {
                RefreshList();               
                
            }
            lblStatus.Text = Globals.statusBar;
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Todo currTodo = lvTask.SelectedItem as Todo;
            if (currTodo == null) return;
            //
            MessageBoxResult result = MessageBox.Show(this, "Are you sure you want to delete:\n" +
                currTodo, "Confirm delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            //
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    Globals.db.DeleteTodo(currTodo.Id);
                    RefreshList();
                    lblStatus.Text = "Deleted Item";

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void miExport_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (.csv) | *.csv";
            sfd.Title = "Save a Csv File";
            sfd.DefaultExt = ".csv";
            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (var item in lvTask.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
            }
            lblStatus.Text = "File Exported";
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit without saving", "Exit confirmation",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (result == MessageBoxResult.No)
            {
                miExport_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Globals.option = "Add";
            AddEditTodo dlg = new AddEditTodo(this);
            if (dlg.ShowDialog() == true)
            {
                RefreshList();                
            }
            
        }

        void RefreshList()
        {
            try
            {
                List<Todo> list = Globals.db.GetAllTasks();
                lvTask.ItemsSource = list;
                // no need to do Refresh if we assign to ItemsSource
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void rbSortTask_Checked(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            List<Todo> list = db.GetAllTasks();
            List<Todo> sorted = list.OrderBy(Todo => Todo.Task).ToList();
            lvTask.ItemsSource = sorted;
            lblStatus.Text = "Sorted by Task";

        }

        private void rbSortDD_Checked(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            List<Todo> list = db.GetAllTasks();
            List<Todo> sorted = list.OrderBy(Todo => Todo.DueDate).ToList();
            lvTask.ItemsSource = sorted;
            lblStatus.Text = "Sorted by DueDate";
        }

       
    }
}

/*CREATE TABLE [dbo].[Todo] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Task]       VARCHAR (50) NOT NULL,
    [DueDate]    DATE         NOT NULL,
    [TaskStatus] VARCHAR (50) DEFAULT ('Pending') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Table_Column] CHECK ([TaskStatus]='Done' OR [TaskStatus]='Pending')
);*/
