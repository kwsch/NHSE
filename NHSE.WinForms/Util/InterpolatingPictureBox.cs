using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NHSE.WinForms
{
    public class InterpolatingPictureBox : PictureBox
    {
        private readonly InterpolationMode InterpolationMode = InterpolationMode.HighQualityBicubic;

        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            eventArgs.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(eventArgs);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaintBackground(pevent);
        }
    }
}
