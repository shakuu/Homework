namespace StartUp
{
    using System.Windows;
    using WinForms = System.Windows.Forms;
    using RemoveFilesModels;
    using System.Windows.Forms;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DefaultPath = "D:\\GitHub";

        public string PathToDeleteFrom { get; set; }
        public string LastSelectedPath { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DeleteBtn.Visibility = Visibility.Collapsed;
            DirNameTextBox.Text = string.Format("Default directory: {0}", DefaultPath);
        }

        private void FolderBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            dialog.SelectedPath = DefaultPath; // Read from file

            var userInput = dialog.ShowDialog();
            this.PathToDeleteFrom = dialog.SelectedPath;

            if (userInput != WinForms.DialogResult.Cancel)
            {
                DeleteBtn.Visibility = Visibility.Visible;
                this.PathToDeleteFrom = dialog.SelectedPath;
                DirNameTextBox.Text = string
                    .Format("{0}", this.PathToDeleteFrom);
            }
            else
            {
                return;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var userInput = WinForms.MessageBox
                .Show(string.Format( "Are you sure sure you want to delete all /obj and /bin folders in {0}?", 
                this.PathToDeleteFrom), 
                "Confirm", MessageBoxButtons.OKCancel);

            if (userInput == WinForms.DialogResult.OK)
            {
                DisplayDeletedFolders.Text =
                    RemoveFiles.Remove(this.PathToDeleteFrom);
            }
            else
            {
                DisplayDeletedFolders.Text = "Aborting...";
            }
        }
    }
}
