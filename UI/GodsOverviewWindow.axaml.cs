using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TorchAutoBuild.Factories;
using TorchAutoBuild.Models;

namespace TorchAutoBuild.UI
{
    public partial class GodsOverviewWindow : Window
    {
        public GodsOverviewWindow()
        {
            InitializeComponent();
            BuildGodsGrid();
        }

        private void BuildGodsGrid()
        {
            var gods = GodsRepository.Gods;
            GodsGrid.Children.Clear();
            GodsGrid.RowDefinitions.Clear();
            GodsGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < 5; i++)
                GodsGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

            for (int i = 0; i < 6; i++)
                GodsGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

            // All this will be changed when all the gods and their trees are ready.
            // Now it's done this way to check if it's working properly.
            var realGod = gods.FirstOrDefault();

            for (int col = 0; col < 6; col++)
            {
                string godName;
                string treeName;
                string godId;
                string treeId;
                bool isReal = col == 0 && realGod != null;

                if (isReal)
                {
                    var firstTree = realGod.TalentTrees.FirstOrDefault();
                    godName = realGod.Name;
                    treeName = firstTree?.Name ?? "Unknown Tree";
                    godId = realGod.Id;
                    treeId = firstTree?.Id ?? "unknown_tree";
                }
                else
                {
                    var placeholderGod = GodFactory.CreateTestGod($"god_placeholder_{col}", $"God {col + 1}");
                    var placeholderTree = placeholderGod.TalentTrees.First();

                    godName = placeholderGod.Name;
                    treeName = placeholderTree.Name;
                    godId = placeholderGod.Id;
                    treeId = placeholderTree.Id;
                }

                // === Row 0 — God Name ===
                var nameBlock = new TextBlock
                {
                    Text = godName,
                    FontWeight = Avalonia.Media.FontWeight.Bold,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
                };
                Grid.SetRow(nameBlock, 0);
                Grid.SetColumn(nameBlock, col);
                GodsGrid.Children.Add(nameBlock);

                // === Row 1 — Tree Button ===
                var treeButton = new Button
                {
                    Content = treeName,
                    Tag = (godId, treeId),
                    IsEnabled = isReal
                };

                if (isReal)
                    treeButton.Click += OpenTree_Click;

                Grid.SetRow(treeButton, 1);
                Grid.SetColumn(treeButton, col);
                GodsGrid.Children.Add(treeButton);
            }
        }

        private async void OpenTree_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is ValueTuple<string, string> ids)
            {
                var (godId, treeId) = ids;

                var tree = GodsRepository.GetTalentTree(godId, treeId);
                if (tree != null)
                {
                    var treeWindow = new TalentTreeWindow(tree);
                    treeWindow.Show();
                }
                else
                {
                    ShowMessage("Error", "Can`t fount Talent Tree.");
                }
            }
        }

        private async void ShowMessage(string message, string title = "Message")
        {
            var dialog = new SimpleDialog(message, title);
            await dialog.ShowDialog(this);
        }
    }
}