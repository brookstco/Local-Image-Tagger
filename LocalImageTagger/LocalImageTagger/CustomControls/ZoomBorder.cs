using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LocalImageTagger.UserControls
{
    //TODO: Replace with Nuget Package. It looks like the hotkeys are rebindable, so that should be easier.
    //I don't like the controsl and there aren't good restrictions. Need to fix that all, buyt not critical yet.

    /// <summary>
    /// A custom border for zooming and panning content created by Wiesław Šoltés.
    /// A full version is on NuGet/Github under the MIT license. This is a simplified version so that my own needs can be customized into it more easily.
    /// </summary>
    public class ZoomBorder : Border
    {
        private UIElement child = null;
        private Point origin;
        private Point start;

        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is TranslateTransform);
        }

        private ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }

        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (value != null && value != this.Child)
                    this.Initialize(value);
                base.Child = value;
            }
        }

        public void Initialize(UIElement element)
        {
            this.child = element;
            if (child != null)
            {
                TransformGroup group = new TransformGroup();
                ScaleTransform st = new ScaleTransform();
                group.Children.Add(st);
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                child.RenderTransform = group;
                //This decides where the origin of the transformations are. If it doesn't zoom according to the mouse, this should be set properly to the transform point
                child.RenderTransformOrigin = new Point(0.0, 0.0);

                //These are the current hardcoded command controls.
                //TODO:Change controls for zoomborder
                this.MouseWheel += child_Zoom;
                this.MouseLeftButtonDown += child_CaptureMouse;
                this.MouseLeftButtonUp += child_ReleaseMouseCapture;
                this.MouseMove += child_MouseMove;
                this.PreviewMouseRightButtonDown += new MouseButtonEventHandler(
                  child_ResetButton);
            }
        }

        public void Reset()
        {
            if (child != null)
            {
                // reset zoom
                var st = GetScaleTransform(child);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                // reset pan
                var tt = GetTranslateTransform(child);
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }

        #region Child Events

        /// <summary>
        /// Zooms in or out of the image relative to the mouse
        /// </summary>
        private void child_Zoom(object sender, MouseWheelEventArgs e)
        {
            if (child != null)
            {
                var st = GetScaleTransform(child);
                var tt = GetTranslateTransform(child);

                double zoom = e.Delta > 0 ? .2 : -.2;
                if (!(e.Delta > 0) && (st.ScaleX < .4 || st.ScaleY < .4))
                    return;

                Point relative = e.GetPosition(child);
                double absoluteX;
                double absoluteY;

                absoluteX = relative.X * st.ScaleX + tt.X;
                absoluteY = relative.Y * st.ScaleY + tt.Y;

                st.ScaleX += zoom;
                st.ScaleY += zoom;

                tt.X = absoluteX - relative.X * st.ScaleX;
                tt.Y = absoluteY - relative.Y * st.ScaleY;
            }
        }

        /// <summary>
        /// Captures the mouses movement
        /// </summary>
        private void child_CaptureMouse(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                var tt = GetTranslateTransform(child);
                start = e.GetPosition(this);
                origin = new Point(tt.X, tt.Y);
                this.Cursor = Cursors.Hand;
                child.CaptureMouse();
            }
        }

        /// <summary>
        /// Releases the mouse that was captured
        /// </summary>
        private void child_ReleaseMouseCapture(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                child.ReleaseMouseCapture();
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// Allows a button to reset the image zoom and pan
        /// </summary>
        void child_ResetButton(object sender, MouseButtonEventArgs e)
        {
            this.Reset();
        }

        /// <summary>
        /// Pans the image when the mouse is captured
        /// </summary>
        private void child_MouseMove(object sender, MouseEventArgs e)
        {
            if (child != null)
            {
                if (child.IsMouseCaptured)
                {
                    var tt = GetTranslateTransform(child);
                    Vector v = start - e.GetPosition(this);
                    tt.X = origin.X - v.X;
                    tt.Y = origin.Y - v.Y;
                }
            }
        }

        #endregion
    }
}
