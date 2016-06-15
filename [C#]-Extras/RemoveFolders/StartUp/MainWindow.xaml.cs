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
        private const string InitialDefaultPath = "D:\\GitHub";

        private string pathToDeleteFrom;

        #region Properties

        public string LastSelectedPath { get; private set; }
        public List<string> listOfDirsToDelete { get; private set; }
        public string DefaultPath { get; private set; }

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
            this.DefaultPath = InitialDefaultPath;
            DirNameTextBox.Text = this.DefaultPath;
        }

        private void FolderBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            dialog.SelectedPath = DefaultPath; // Read from file

            var userInput = dialog.ShowDialog();

            if (userInput != WinForms.DialogResult.Cancel)
            {
                DeleteBtn.Visibility = Visibility.Collapsed;
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
                var result = new List<string>();

                try
                {
                    result = RemoveFiles.RemoveFolder(this.listOfDirsToDelete);
                }
                catch (Exception)
                {
                    DisplayDeletedFolders.Text = "Una";
                }


                if (result.Count == 0)
                {
                    DisplayDeletedFolders.Text = "Operation Complete";
                }
                else
                {
                    result.Insert(0, "Unable to delete: ");
                    DisplayDeletedFolders.Text =
                        string.Join(Environment.NewLine, result);
                }

                DeleteBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                DirNameTextBox.Text = "Operation canceled";
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.PathToDeleteFrom = DirNameTextBox.Text;
                this.DefaultPath = this.pathToDeleteFrom;
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

        private void ArchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.PathToDeleteFrom = DirNameTextBox.Text;
            }
            catch (Exception caught)
            {
                DisplayDeletedFolders.Text = caught.Message;
                return;
            }

            var success = CompressingFiles.Compressing.CompressFolder(this.PathToDeleteFrom);

            if (success)
            {
                DisplayDeletedFolders.Text = string.Format("Successfully archived{1}Output file: {0}",
                    DirNameTextBox.Text + ".zip",
                    Environment.NewLine);
            }

        }

        private void DirNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            DeleteBtn.Visibility = Visibility.Collapsed;
        }
    }
}
