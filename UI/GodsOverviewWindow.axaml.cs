using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using TorchAutoBuild.Factories;
using TorchAutoBuild.Models;
using TorchAutoBuild.Models.Talents.Tree;


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
            var exeDir = AppContext.BaseDirectory;
            var projectRoot = Path.GetFullPath(Path.Combine(exeDir, @"..\..\..\"));
            var godsFolder = Path.Combine(projectRoot, "Assets/Gods");
            

            var gods = GodsRepository.Gods;
            GodsGrid.Children.Clear();
            GodsGrid.RowDefinitions.Clear();
            GodsGrid.ColumnDefinitions.Clear();

            // 5 rows — 0: God Name, 1: Base Tree, 2-4: Advanced Trees
            for (int i = 0; i < 5; i++)
                GodsGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));

            // 6 columns for 6 gods
            for (int i = 0; i < 6; i++)
                GodsGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

            var realGod = gods.FirstOrDefault();

            for (int col = 0; col < 6; col++)
            {
                string godName;
                string godId;
                List<TalentTree> trees;
                bool isReal = col == 0 && realGod != null;

                if (isReal)
                {
                    godName = realGod.Name;
                    godId = realGod.Id;
                    trees = realGod.TalentTrees.ToList();
                }
                else
                {
                    var placeholderGod = GodFactory.CreateTestGod($"god_placeholder_{col}", $"God {col + 1}");
                    godName = placeholderGod.Name;
                    godId = placeholderGod.Id;
                    trees = new List<TalentTree> { placeholderGod.TalentTrees.First() };
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

                // === Rows 1–4 — Talent Trees: Base + Advanced1–3 ===
                for (int row = 1; row <= 4; row++)
                {
                    string label;
                    TalentTree? tree = null;

                    if (row - 1 < trees.Count)
                    {
                        tree = trees[row - 1];
                        label = tree.Name;
                    }
                    else
                    {
                        label = "Coming soon";
                    }

                    var stackPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                    };
                    if (tree != null)
                    {
                        int iconSize = 48;
                        // Adding icon (image) to the stack panel( talent tree icon)
                        var icon = new Image
                        {
                            Width = iconSize,  
                            Height = iconSize,
                            Stretch = Stretch.Uniform,
                            // set icon if tree is for testing(not real) put placeholder
                            Source = tree.TreeType != TalentTreeType.ForTesting ? GetTreeIcon(tree.Id, godsFolder) : GetPlaceholderIcon(godsFolder)
                        };
                        stackPanel.Children.Add(icon);

                        // Adding label (text) to the stack panel
                        var textBlock = new TextBlock
                        {
                            Text = label,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(0, 5, 0, 0) 
                        };
                        stackPanel.Children.Add(textBlock);

                        var treeButton = new Button
                        {
                            //set background and border to transparent
                            Background = Avalonia.Media.Brushes.Transparent,
                            BorderBrush = Avalonia.Media.Brushes.Transparent,
                            BorderThickness = new Thickness(0),
                            Padding = new Thickness(0),
                            Content = stackPanel,
                            Tag = tree != null ? (godId, tree.Id) : null,
                            IsEnabled = isReal && tree != null,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch,
                        };


                        if (tree != null && isReal)
                            treeButton.Click += OpenTree_Click;

                        Grid.SetRow(treeButton, row);
                        Grid.SetColumn(treeButton, col);
                        GodsGrid.Children.Add(treeButton);
                    }
                }
            }
        }
        private Bitmap GetTreeIcon(string treeId, string godsFolder)
        {
            //found image by treeId
            var treeImages = Path.Combine(godsFolder, "images");
            var path = Path.Combine(treeImages, $"{treeId}.png");

            if (!File.Exists(path)) GetPlaceholderIcon(godsFolder);

            return new Bitmap(path);
        }

        private Bitmap GetPlaceholderIcon(string godsFolder)
        {
            // return placeholder image
            var path = Path.Combine(godsFolder, "talent.png");
            return new Bitmap(path);
        }



        private async void OpenTree_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is ValueTuple<string, string> ids)
            {
                var (godId, treeId) = ids;

                var tree = GodsRepository.GetTalentTree(godId, treeId);
                string godName = GodsRepository.GetGodById(godId)?.Name ?? "Unknown God";
                if (tree != null)
                {
                    var treeWindow = new TalentTreeWindow(tree, godName);
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