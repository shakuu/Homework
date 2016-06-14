namespace StartUp
{
    using System.Windows;
    using System.Windows.Forms;
    using RemoveFilesModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Path { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            dialog.ShowDialog();

            this.Path = dialog.SelectedPath;
            textBlock.Text = string.Format($"Current Folder: {this.Path}");
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            var box =
                 System.Windows.Forms.MessageBox.Show("Are you sure sure?", "Confirm", MessageBoxButtons.OKCancel);

            if (box.ToString() == "OK")
            {
                if (string.IsNullOrEmpty(this.Path))
                {
                    textBlock.Text = "No folder is selected";
                }
                else
                {
                    textBlock.Text = RemoveFiles.Remove(this.Path);
                }
            }
        }
    }
}
