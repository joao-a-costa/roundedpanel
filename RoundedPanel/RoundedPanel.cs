using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RoundedPanel
{
    public partial class RoundedPanel : Panel
    {
        private int _radiusTopLeft = 20;
        private int _radiusTopRight = 20;
        private int _radiusBottomLeft = 20;
        private int _radiusBottomRight = 20;

        private int _borderThickness = 1;
        private Color _borderColor = Color.DimGray;

        #region Construtores

        public RoundedPanel()
        {
            this.BackColor = Color.LightYellow;
            this.BorderStyle = BorderStyle.None; // IMPORTANTE: não usar o BorderStyle nativo

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);
        }

        public RoundedPanel(IContainer container) : this()
        {
            container?.Add(this);
        }

        #endregion

        #region Propriedades

        [Category("Appearance")]
        public int RadiusTopLeft
        {
            get => _radiusTopLeft;
            set { _radiusTopLeft = Math.Max(1, value); Invalidate(); }
        }

        [Category("Appearance")]
        public int RadiusTopRight
        {
            get => _radiusTopRight;
            set { _radiusTopRight = Math.Max(1, value); Invalidate(); }
        }

        [Category("Appearance")]
        public int RadiusBottomLeft
        {
            get => _radiusBottomLeft;
            set { _radiusBottomLeft = Math.Max(1, value); Invalidate(); }
        }

        [Category("Appearance")]
        public int RadiusBottomRight
        {
            get => _radiusBottomRight;
            set { _radiusBottomRight = Math.Max(1, value); Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        // Compatibilidade com BorderRadius antigo
        [Browsable(true)]
        [Category("Appearance")]
        public int BorderRadius
        {
            get => RadiusTopLeft;
            set
            {
                int v = Math.Max(1, value);
                RadiusTopLeft = v;
                RadiusTopRight = v;
                RadiusBottomLeft = v;
                RadiusBottomRight = v;
            }
        }

        #endregion

        #region Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color parentBack = this.Parent?.BackColor ?? SystemColors.Control;
            g.Clear(parentBack);

            Rectangle rect = new Rectangle(
                _borderThickness,
                _borderThickness,
                this.Width - (_borderThickness * 2) - 1,
                this.Height - (_borderThickness * 2) - 1
            );

            using (GraphicsPath path = GetRoundedPath(rect))
            {
                // Fundo
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Borda arredondada
                if (_borderThickness > 0)
                {
                    using (Pen pen = new Pen(_borderColor, _borderThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, RadiusTopLeft, RadiusTopLeft, 180, 90);
            path.AddArc(rect.Right - RadiusTopRight, rect.Y, RadiusTopRight, RadiusTopRight, 270, 90);
            path.AddArc(rect.Right - RadiusBottomRight, rect.Bottom - RadiusBottomRight, RadiusBottomRight, RadiusBottomRight, 0, 90);
            path.AddArc(rect.X, rect.Bottom - RadiusBottomLeft, RadiusBottomLeft, RadiusBottomLeft, 90, 90);
            path.CloseFigure();

            return path;
        }

        #endregion
    }
}