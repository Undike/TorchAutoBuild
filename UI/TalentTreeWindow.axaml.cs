using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.IO;
using TorchAutoBuild.Models.Talents.Node;
using TorchAutoBuild.Models.Talents.Tree;

namespace TorchAutoBuild.UI
{
    public partial class TalentTreeWindow : Window
    {
        private TalentTree _tree; 

        public TalentTreeWindow(TalentTree tree)
        {
            InitializeComponent();
            _tree = tree;
            TreeTitle.Text = _tree.Name;
            BuildTalentGrid();
            BuildCoreTalentGrid();

            Dispatcher.UIThread.Post(() =>
            {
                DrawLinesBetweenTalents();
            }, DispatcherPriority.Render);
            TalentGrid.PropertyChanged += (s, e) =>
            {
                if (e.Property == BoundsProperty)
                {
                    DrawLinesBetweenTalents();
                }
            };
        }

        private void BuildCoreTalentGrid()
        {
            CoreTalentGrid.Children.Clear();
            CoreTalentGrid.RowDefinitions.Clear();
            CoreTalentGrid.ColumnDefinitions.Clear();

            if (_tree?.CoreTalentSlots == null)
                return;

            CoreTalentGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto)); // title
            CoreTalentGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto)); // CoreTalents

            int totalColumns = 0;

            foreach (var slot in _tree.CoreTalentSlots)
            {
                int groupColumns = slot.CoreTalents.Count;
                for (int i = 0; i < groupColumns; i++)
                    CoreTalentGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));

                int middleIndex = totalColumns + groupColumns / 2;

                // Заголовок UnlockPointsThreshold
                var header = new TextBlock
                {
                    Text = $"Unlock at {slot.UnlockPointsThreshold}",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center
                };
                Grid.SetRow(header, 0);
                Grid.SetColumn(header, middleIndex);
                CoreTalentGrid.Children.Add(header);

                // CoreTalents
                for (int i = 0; i < groupColumns; i++)
                {
                    var coreTalent = slot.CoreTalents[i];
                    var btn = new Button
                    {
                        Content = coreTalent.Name,
                        Tag = coreTalent
                    };

                    Grid.SetRow(btn, 1);
                    Grid.SetColumn(btn, totalColumns + i);
                    CoreTalentGrid.Children.Add(btn);
                }

                totalColumns += groupColumns;
            }
        }

        private void BuildTalentGrid()
        {
            var exeDir = AppContext.BaseDirectory;
            var projectRoot = Path.GetFullPath(Path.Combine(exeDir, @"..\..\..\"));
            var godsFolder = Path.Combine(projectRoot, "Assets");

            if (_tree == null)
                return;

            TalentGrid.Rows = 5;
            TalentGrid.Columns = _tree.Size;

            TalentGrid.Children.Clear();

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < _tree.Size; col++)
                {
                    var pos = new TalentNodePos(col, row);
                    var node = _tree.GetNodeByPos(pos);

                    if (node != null)
                    {
                        var btn = new Button
                        {
                            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
                            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch,
                            Content = new Image
                            {
                                Source = new Avalonia.Media.Imaging.Bitmap(Path.Combine(godsFolder, "talent.png")),
                                Stretch = Avalonia.Media.Stretch.Uniform,
                                Width = 40,
                                Height = 40
                            },
                            Tag = node.Id,
                            IsEnabled = true
                        };
                        btn.Click += Talent_Click;

                        Grid.SetRow(btn, row);
                        Grid.SetColumn(btn, col);
                        TalentGrid.Children.Add(btn);
                    }
                    else
                    {
                        var border = new Border
                        {
                            Background = Avalonia.Media.Brushes.Transparent,
                            BorderThickness = new Thickness(0)
                        };
                        Grid.SetRow(border, row);
                        Grid.SetColumn(border, col);
                        TalentGrid.Children.Add(border);
                    }
                }
            }

        }

        private void DrawLinesBetweenTalents()
        {
            if (_tree == null || LinesCanvas == null)
                return;

            LinesCanvas.Children.Clear();

            foreach (var node in _tree.Nodes)
            {
                if (node.PrerequisiteTalentPos != null)
                {
                    var fromPos = node.PrerequisiteTalentPos.Value;
                    var toPos = node.Pos;

                    var startPoint = GetButtonCenterPosition(fromPos);
                    var endPoint = GetButtonCenterPosition(toPos);
                    Debug.WriteLine($"From: {fromPos}, To: {toPos}");
                    Debug.WriteLine($"StartPoint: {startPoint}, EndPoint: {endPoint}");


                    var line = new Avalonia.Controls.Shapes.Line
                    {
                        StartPoint = startPoint,
                        EndPoint = endPoint,
                        Stroke = Avalonia.Media.Brushes.Yellow,
                        StrokeThickness = 4,
                    };

                    LinesCanvas.Children.Add(line);
                }
            }
        }

        private Point GetButtonCenterPosition(TalentNodePos pos)
        {
            foreach (var child in TalentGrid.Children)
            {
                if (child is Button btn &&
                    Grid.GetColumn(btn) == pos.X &&
                    Grid.GetRow(btn) == pos.Y)
                {
                    var centerLocal = new Point(btn.Bounds.Width / 2, btn.Bounds.Height / 2);
                    var point = btn.TranslatePoint(centerLocal, LinesCanvas);

                    if (point == null)
                        Debug.WriteLine($"TranslatePoint return null for button at position {pos}");

                    return point ?? new Point(0, 0);
                }
            }

            Debug.WriteLine($"The Button can`t find at position {pos}");
            return new Point(0, 0);
        }

        private void Talent_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string talentId)
            {
                // Add logic to handle the click event for the talent button
            }
        }

        private void CoreTalent_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string talentId)
            {
                // Add logic to handle the click event for the core talent button
            }
        }
    }
}