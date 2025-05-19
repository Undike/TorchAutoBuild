using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TorchAutoBuild.UI
{
    public partial class SimpleDialog : Window
    {
        public SimpleDialog()
        {
            InitializeComponent();
        }

        public SimpleDialog(string message, string title = "Message") : this()
        {
            this.Title = title;
            MessageTextBlock.Text = message;
        }

        private void OkButton_Click(object? sender, RoutedEventArgs e)
        {
            Close(true);
        }
    }
}
