using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RoundedPanel
{
    public partial class RoundedPanel : Panel
    {
        #region "Members"

        /// <summary>
        /// Border radius of the panel
        /// </summary>
        private int _borderRadius = 30;

        private int _radiusTopLeft = 30;
        private int _radiusTopRight = 30;
        private int _radiusButtonLeft = 30;
        private int _radiusButtonRight = 30;

        #endregion

        #region "Properties"

        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        public int RadiusTopLeft
        {
            get { return _radiusTopLeft; }
            set { _radiusTopLeft = value; this.Invalidate(); }
        }

        public int RadiusTopRight
        {
            get { return _radiusTopRight; }
            set { _radiusTopRight = value; this.Invalidate(); }
        }

        public int RadiusButtonLeft
        {
            get { return _radiusButtonLeft; }
            set { _radiusButtonLeft = value; this.Invalidate(); }
        }

        public int RadiusButtonRight
        {
            get { return _radiusButtonRight; }
            set { _radiusButtonRight = value; this.Invalidate(); }
        }

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor
        /// </summary>
        public RoundedPanel() : base()
        {
            Resize += new EventHandler(RoundedPanel_Resize);
            BackColor = System.Drawing.Color.LightBlue;
        }

        /// <summary>
        /// Constructor with container
        /// </summary>
        /// <param name="container">The container</param>
        public RoundedPanel(IContainer container)
            : this()
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region "Events"

        /// <summary>
        /// Event handler for resize
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private void RoundedPanel_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Event handler for paint
        /// </summary>
        /// <param name="e">The paint event arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            System.Drawing.Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(this.Parent.BackColor);

            System.Drawing.Rectangle rect = this.ClientRectangle;

            if (RadiusTopLeft == 0)
                RadiusTopLeft = 1;

            if (RadiusTopRight == 0)
                RadiusTopRight = 1;

            if (RadiusButtonLeft == 0)
                RadiusButtonLeft = 1;

            if (RadiusButtonRight == 0)
                RadiusButtonRight = 1;

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, RadiusTopLeft, RadiusTopLeft, 180, 90);
                path.AddArc(rect.X + rect.Width - RadiusTopRight, rect.Y, RadiusTopRight, RadiusTopRight, 270, 90);
                path.AddArc(rect.X + rect.Width - RadiusButtonRight, rect.Y + rect.Height - RadiusButtonRight, RadiusButtonRight, RadiusButtonRight, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - RadiusButtonLeft, RadiusButtonLeft, RadiusButtonLeft, 90, 90);
                path.CloseFigure();

                g.FillPath(new System.Drawing.SolidBrush(this.BackColor), path);
            }
        }

        #endregion
    }
}
