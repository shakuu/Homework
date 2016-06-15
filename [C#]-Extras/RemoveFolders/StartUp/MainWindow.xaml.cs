namespace StartUp
{
    using RemoveFilesModels;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Forms;
    using WinForms = System.Windows.Forms;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DefaultPath = "D:\\GitHub";

        private string pathToDeleteFrom;

        #region Properties

        public string LastSelectedPath { get; private set; }
        public List<string> listOfDirsToDelete { get; private set; }

        public string PathToDeleteFrom
        {
            get
            {
                return this.pathToDeleteFrom;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Input is Empty");
                }
                else if (!Directory.Exists(value))
                {
                    throw new Exception("Folder does not exist");
                }
                else if (value.Where(chr => chr == '\\').Count() == 1
                         && value.Last() == '\\')
                {
                    throw new Exception("Drive root is not a valid selection");
                }
                else
                {
                    this.pathToDeleteFrom = value;
                }
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DeleteBtn.Visibility = Visibility.Collapsed;
            DirNameTextBox.Text = DefaultPath;
        }

        private void FolderBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            dialog.SelectedPath = DefaultPath; // Read from file

            var userInput = dialog.ShowDialog();

            if (userInput != WinForms.DialogResult.Cancel)
            {
                DirNameTextBox.Text = dialog.SelectedPath;
            }
            else
            {
                return;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var userInput = WinForms.MessageBox
                .Show(string.Format("Are you sure sure you want to delete all /obj and /bin folders in {0}?",
                this.PathToDeleteFrom),
                "Confirm", MessageBoxButtons.OKCancel);

            if (userInput == WinForms.DialogResult.OK)
            {
                var result = RemoveFiles.RemoveFolder(this.listOfDirsToDelete);

                if (result.Count == 0)
                {
                    DirNameTextBox.Text = "Operation Complete";
                }
                else
                {
                    result.Insert(0, "Folders not found: ");
                    DisplayDeletedFolders.Text =
                        string.Join(Environment.NewLine, result);
                }

                DeleteBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                DirNameTextBox.Text = "Operation canceled";
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.PathToDeleteFrom = DirNameTextBox.Text;
            }
            catch (Exception caught)
            {
                DisplayDeletedFolders.Text = caught.Message;
                DeleteBtn.Visibility = Visibility.Collapsed;
                return;
            }

            RemoveFiles.ClearList();
            this.listOfDirsToDelete =
                    RemoveFiles.FindObjBinDirectories(this.PathToDeleteFrom);

            if (this.listOfDirsToDelete.Count > 0)
            {
                DisplayDeletedFolders.Text =
                    string.Join(Environment.NewLine, listOfDirsToDelete);

                DeleteBtn.Visibility = Visibility.Visible;
            }
            else
            {
                DeleteBtn.Visibility = Visibility.Collapsed;
                DisplayDeletedFolders.Text = "No Obj or Bin folders found";
            }
        }
    }
}
