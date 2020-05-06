using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ItemGrid : UserControl
    {
        public ItemGrid()
        {
            InitializeComponent();
        }

        public readonly List<PictureBox> Entries = new List<PictureBox>();
        public int Slots { get; private set; }

        private int sizeW = 32;
        private int sizeH = 32;

        public void InitializeGrid(int width, int height, IGridItem info)
        {
            sizeW = info.Width;
            sizeH = info.Height;
            Generate(width, height);
            Slots = width * height;
        }

        private const int padEdge = 0; // edges
        private const int border = 1; // between

        private void Generate(int width, int height)
        {
            SuspendLayout();
            Controls.Clear();
            Entries.Clear();

            int colWidth = sizeW;
            int rowHeight = sizeH;

            for (int row = 0; row < height; row++)
            {
                var y = padEdge + (row * (rowHeight + border));
                for (int column = 0; column < width; column++)
                {
                    var x = padEdge + (column * (colWidth + border));
                    var pb = GetControl(sizeW, sizeH);
                    pb.SuspendLayout();
                    Controls.Add(pb);
                    pb.Location = new Point(x, y);
                    Entries.Add(pb);
                }
            }

            Width = (2 * padEdge) + border + (width * (colWidth + border)) + 2;
            Height = (2 * padEdge) + border + (height * (rowHeight + border)) + 2;
            Debug.WriteLine($"{Name} -- Width: {Width}, Height: {Height}");
            ResumeLayout();
        }

        public static PictureBox GetControl(int width, int height)
        {
            return new PictureBox
            {
                AutoSize = false,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackColor = Color.Transparent,
                Width = width + (2 * 1),
                Height = height + (2 * 1),
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                BorderStyle = BorderStyle.FixedSingle,
            };
        }
    }
}
