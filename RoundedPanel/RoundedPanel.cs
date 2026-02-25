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

        // Header
        private bool _showHeader = true;
        private int _headerHeight = 36;
        private Color _headerColor = Color.SteelBlue;

        private const string FallbackIconFont = "Segoe MDL2 Assets";

        private Color _headerGradientStartColor = Color.FromArgb(64, 86, 110);
        private Color _headerGradientEndColor = Color.FromArgb(45, 62, 80);

        [Category("Header - Appearance")]
        public Color HeaderGradientStartColor
        {
            get => _headerGradientStartColor;
            set { _headerGradientStartColor = value; Invalidate(); }
        }

        [Category("Header - Appearance")]
        public Color HeaderGradientEndColor
        {
            get => _headerGradientEndColor;
            set { _headerGradientEndColor = value; Invalidate(); }
        }

        public enum InnerIconType
        {
            None,

            // Communication
            Email, Phone, Chat, Send, Inbox, Calendar,

            // User / Security
            User, UserAdd, UserRemove, Lock, Unlock, Key,
            Shield, ShieldCheck, ShieldError,

            // Navigation
            Search, Filter, Settings, Menu, More, Home, Back, Forward, Refresh,

            // Files / Data
            File, FileAdd, FileRemove, Folder, FolderOpen, Save, Upload, Download, Database,

            // Status
            Check, Close, Warning, Info, Error,

            // Commerce
            Cart, CreditCard, Money, Wallet, Tag, Chart, ChartBar, ChartLine,

            // Media
            Play, Pause, Stop, Camera, Image,

            // Misc
            Star, Heart, Location, Link, Globe, Clipboard, Edit, Trash
        }
        public enum InnerIconPosition
        {
            Left,
            Right
        }

        [Category("Header")]
        [DefaultValue(true)]
        public bool ShowHeader
        {
            get => _showHeader;
            set
            {
                if (_showHeader == value) return;
                _showHeader = value;
                Redraw();
            }
        }

        [Category("Header")]
        [DefaultValue(36)]
        public int HeaderHeight
        {
            get => _headerHeight;
            set
            {
                int v = Math.Max(20, value);
                if (_headerHeight == v) return;
                _headerHeight = v;
                Redraw();
                PerformLayout();
            }
        }

        [Category("Header")]
        public Color HeaderColor
        {
            get => _headerColor;
            set
            {
                if (_headerColor == value) return;
                _headerColor = value;
                Redraw();
            }
        }


        // Texto
        private string _textHeader = "Título";
        private ContentAlignment _textHeaderAlign = ContentAlignment.MiddleLeft;
        private Font _textHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold);
        private Color _textHeaderColor = Color.White;

        [Category("Header - Text")]
        [DefaultValue("Título")]
        public string TextHeader
        {
            get => _textHeader;
            set
            {
                if (_textHeader == value) return;
                _textHeader = value;
                Redraw();
            }
        }

        [Category("Header - Text")]
        [DefaultValue(ContentAlignment.MiddleLeft)]
        public ContentAlignment TextHeaderAlign
        {
            get => _textHeaderAlign;
            set
            {
                if (_textHeaderAlign == value) return;
                _textHeaderAlign = value;
                Redraw();
            }
        }

        [Category("Header - Text")]
        public Font TextHeaderFont
        {
            get => _textHeaderFont;
            set
            {
                if (_textHeaderFont == value) return;
                _textHeaderFont = value ?? this.Font;
                Redraw();
            }
        }

        [Category("Header - Text")]
        public Color TextHeaderColor
        {
            get => _textHeaderColor;
            set
            {
                if (_textHeaderColor == value) return;
                _textHeaderColor = value;
                Redraw();
            }
        }


        // Ícone
        private bool _showIcon = true;
        private Image _headerIcon = null;
        private ContentAlignment _iconAlign = ContentAlignment.MiddleRight;

        // Inner Icon (Header)
        private InnerIconType _innerIcon = InnerIconType.None;
        private ContentAlignment _innerIconAlign = ContentAlignment.MiddleRight;
        private Color _innerIconColor = Color.White;
        private int _innerIconSize = 16;
        private string _iconFontFamily = "Segoe Fluent Icons";

        [Category("Header - Icon")]
        [DefaultValue(InnerIconType.None)]
        public InnerIconType InnerIcon
        {
            get => _innerIcon;
            set
            {
                if (_innerIcon == value) return;
                _innerIcon = value;
                Redraw();
            }
        }

        [Category("Header - Icon")]
        [DefaultValue(ContentAlignment.MiddleRight)]
        public ContentAlignment InnerIconAlign
        {
            get => _innerIconAlign;
            set
            {
                if (_innerIconAlign == value) return;
                _innerIconAlign = value;
                Redraw();
            }
        }

        [Category("Header - Icon")]
        [DefaultValue(typeof(Color), "White")]
        public Color InnerIconColor
        {
            get => _innerIconColor;
            set
            {
                if (_innerIconColor == value) return;
                _innerIconColor = value;
                Redraw();
            }
        }

        [Category("Header - Icon")]
        [DefaultValue(16)]
        public int InnerIconSize
        {
            get => _innerIconSize;
            set
            {
                int v = Math.Max(10, value);
                if (_innerIconSize == v) return;
                _innerIconSize = v;
                Redraw();
            }
        }

        [Category("Header - Icon")]
        [DefaultValue("Segoe Fluent Icons")]
        public string IconFontFamily
        {
            get => _iconFontFamily;
            set
            {
                if (_iconFontFamily == value) return;
                _iconFontFamily = value;
                Redraw();
            }
        }


        [Category("Header - Icon")]
        [DefaultValue(true)]
        public bool ShowIcon
        {
            get => _showIcon;
            set
            {
                if (_showIcon == value) return;
                _showIcon = value;
                Redraw();
            }
        }


        [Category("Header - Icon")]
        public Image HeaderIcon
        {
            get => _headerIcon;
            set
            {
                if (_headerIcon == value) return;
                _headerIcon = value;
                Redraw();
            }
        }

        [Category("Header - Icon")]
        [DefaultValue(ContentAlignment.MiddleRight)]
        public ContentAlignment IconAlign
        {
            get => _iconAlign;
            set
            {
                if (_iconAlign == value) return;
                _iconAlign = value;
                Redraw();
            }
        }

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

        private bool _headerBottomSeparator = true;

        [Category("Header - Appearance")]
        public bool HeaderBottomSeparator
        {
            get => _headerBottomSeparator;
            set { _headerBottomSeparator = value; Invalidate(); }
        }

        private bool _isCollapsed = false;
        private int _expandedHeight;
        private bool _collapseOnHeaderClick = true;

        [Category("Behavior")]
        public bool IsCollapsed
        {
            get => _isCollapsed;
            set
            {
                _isCollapsed = value;
                ApplyCollapseState();
            }
        }

        [Category("Behavior")]
        public bool CollapseOnHeaderClick
        {
            get => _collapseOnHeaderClick;
            set => _collapseOnHeaderClick = value;
        }

        private bool _showCollapseIcon = true;

        [Category("Header - Behavior")]
        [DefaultValue(true)]
        public bool ShowCollapseIcon
        {
            get => _showCollapseIcon;
            set
            {
                _showCollapseIcon = value;
                Invalidate();
            }
        }
        #endregion

        #region Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color parentBack = Parent?.BackColor ?? SystemColors.Control;
            g.Clear(parentBack);

            Rectangle rect = new Rectangle(
                _borderThickness,
                _borderThickness,
                Width - (_borderThickness * 2) - 1,
                Height - (_borderThickness * 2) - 1
            );

            using (GraphicsPath path = GetRoundedPath(rect))
            {

                // Fundo do painel
                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Header


                Rectangle headerRect = Rectangle.Empty;
                if (ShowHeader && HeaderHeight > 0)
                {
                    headerRect = new Rectangle(rect.X, rect.Y, rect.Width, HeaderHeight);

                    using (GraphicsPath headerPath = GetRoundedHeaderPath(headerRect))
                    using (SolidBrush headerBrush = new SolidBrush(HeaderColor))
                    {
                        g.FillPath(headerBrush, headerPath);
                    }

                    using (GraphicsPath headerPath = GetRoundedHeaderPath(headerRect))
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        headerRect,
                        _headerGradientStartColor,
                        _headerGradientEndColor,
                        LinearGradientMode.Vertical))
                    {
                        g.FillPath(brush, headerPath);
                    }

                    if (_headerBottomSeparator)
                    {
                        using (Pen p = new Pen(Color.FromArgb(40, 0, 0, 0), 1))
                        {
                            g.DrawLine(p, 0, _headerHeight - 1, Width, _headerHeight - 1);
                        }
                    }

                    if (ShowCollapseIcon && CollapseOnHeaderClick)
                        DrawCollapseIcon(g);

                    // Texto do header
                    if (!string.IsNullOrEmpty(TextHeader))
                    {
                        using (Brush textBrush = new SolidBrush(TextHeaderColor))
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.LineAlignment = StringAlignment.Center;

                            switch (TextHeaderAlign)
                            {
                                case ContentAlignment.MiddleCenter:
                                    sf.Alignment = StringAlignment.Center;
                                    break;
                                case ContentAlignment.MiddleRight:
                                    sf.Alignment = StringAlignment.Far;
                                    break;
                                default:
                                    sf.Alignment = StringAlignment.Near;
                                    break;
                            }

                            Rectangle textRect = headerRect;
                            textRect.Inflate(-12, 0);

                            g.DrawString(TextHeader, TextHeaderFont, textBrush, textRect, sf);
                        }
                    }

                    // InnerIcon
                    // InnerIcon
                    if (InnerIcon != InnerIconType.None)
                    {
                        string glyph = GetGlyph(InnerIcon);

                        if (!string.IsNullOrEmpty(glyph))
                        {
                            using (Font iconFont = new Font("Segoe MDL2 Assets", InnerIconSize, FontStyle.Regular, GraphicsUnit.Pixel))
                            using (Brush iconBrush = new SolidBrush(InnerIconColor))
                            {
                                SizeF sz = g.MeasureString(glyph, iconFont);

                                int collapseWidth = GetCollapseIconWidth(g);

                                int x;

                                if (InnerIconAlign == ContentAlignment.MiddleRight)
                                {
                                    // 🔥 aqui está a correção
                                    x = headerRect.Right - collapseWidth - (int)sz.Width - 10;
                                }
                                else
                                {
                                    x = headerRect.X + 10;
                                }

                                int y = headerRect.Y + (HeaderHeight - (int)sz.Height) / 2;

                                g.DrawString(glyph, iconFont, iconBrush, x, y);
                            }
                        }
                    }
                }

                // Borda
                if (_borderThickness > 0)
                {
                    using (Pen pen = new Pen(BorderColor, _borderThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        g.DrawPath(pen, path);
                    }
                }
            }
            g.ResetClip();
        }

        private void Redraw()
        {
            Invalidate();
            Update();
            if (Parent != null)
            {
                Parent.Invalidate();
                Parent.Update();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_collapseOnHeaderClick)
            {
                if (e.Y <= _headerHeight)
                {
                    IsCollapsed = !IsCollapsed;
                }
            }
        }

        private const string IconFont = "Segoe MDL2 Assets";

        private InnerIconPosition _headerIconPosition;

        private InnerIconType _headerInnerIcon = InnerIconType.None;

        private int GetRightHeaderReservedSpace(Graphics g)
        {
            int reserved = 10; // margem base

            if (_headerInnerIcon != InnerIconType.None &&
                _headerIconPosition == InnerIconPosition.Right)
            {
                using (Font f = new Font(IconFont, 12))
                {
                    SizeF size = g.MeasureString(GetGlyph(_headerInnerIcon), f);
                    reserved += (int)size.Width + 8;
                }
            }

            return reserved;
        }
        private int GetCollapseIconWidth(Graphics g)
        {
            if (!CollapseOnHeaderClick)
                return 0;

            string glyph = _isCollapsed ? "\uE76C" : "\uE70D";

            using (Font f = new Font(IconFont, 10))
            {
                SizeF size = g.MeasureString(glyph, f);
                return (int)size.Width + 10; // margem
            }
        }
        private void DrawCollapseIcon(Graphics g)
        {
            string glyph = _isCollapsed ? "\uE76C" : "\uE70D";

            using (Font f = new Font(IconFont, 10))
            using (Brush b = new SolidBrush(ForeColor))
            {
                SizeF size = g.MeasureString(glyph, f);

                int reservedRight = GetRightHeaderReservedSpace(g);

                float x = Width - size.Width - reservedRight;
                float y = (_headerHeight - size.Height) / 2;

                g.DrawString(glyph, f, b, x, y);
            }
        }

        private GraphicsPath GetRoundedHeaderPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, RadiusTopLeft, RadiusTopLeft, 180, 90);
            path.AddArc(rect.Right - RadiusTopRight, rect.Y, RadiusTopRight, RadiusTopRight, 270, 90);
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
            path.CloseFigure();

            return path;
        }

        private void DrawHeaderText(Graphics g, Rectangle headerRect)
        {
            if (string.IsNullOrEmpty(TextHeader)) return;

            StringFormat sf = new StringFormat();

            sf.Alignment = TextHeaderAlign == ContentAlignment.MiddleCenter ? StringAlignment.Center :
                           TextHeaderAlign == ContentAlignment.MiddleRight ? StringAlignment.Far :
                           StringAlignment.Near;

            sf.LineAlignment = StringAlignment.Center;

            Rectangle textRect = headerRect;
            textRect.Inflate(-10, 0);

            using (Brush textBrush = new SolidBrush(TextHeaderColor))
                g.DrawString(TextHeader, TextHeaderFont, textBrush, textRect, sf);
        }

        private void DrawHeaderIcon(Graphics g, Rectangle headerRect)
        {
            if (!ShowIcon || HeaderIcon == null) return;

            int size = HeaderHeight - 10;
            int y = headerRect.Y + (HeaderHeight - size) / 2;
            int x = IconAlign == ContentAlignment.MiddleRight
                ? headerRect.Right - size - 10
                : headerRect.X + 10;

            g.DrawImage(HeaderIcon, new Rectangle(x, y, size, size));
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
        private string GetGlyph(InnerIconType icon)
        {
            switch (icon)
            {
                // Communication
                case InnerIconType.Email: return "\uE715";
                case InnerIconType.Phone: return "\uE717";
                case InnerIconType.Chat: return "\uE8BD";
                case InnerIconType.Send: return "\uE724";
                case InnerIconType.Inbox: return "\uE719";
                case InnerIconType.Calendar: return "\uE787";

                // User / Security
                case InnerIconType.User: return "\uE77B";
                case InnerIconType.UserAdd: return "\uE8FA";
                case InnerIconType.UserRemove: return "\uE8FB";
                case InnerIconType.Lock: return "\uE72E";
                case InnerIconType.Unlock: return "\uE785";
                case InnerIconType.Key: return "\uE192";
                case InnerIconType.Shield: return "\uE83D";
                case InnerIconType.ShieldCheck: return "\uE73E";
                case InnerIconType.ShieldError: return "\uEA39";

                // Navigation
                case InnerIconType.Search: return "\uE721";
                case InnerIconType.Filter: return "\uE71C";
                case InnerIconType.Settings: return "\uE713";
                case InnerIconType.Menu: return "\uE700";
                case InnerIconType.More: return "\uE712";
                case InnerIconType.Home: return "\uE80F";
                case InnerIconType.Back: return "\uE72B";
                case InnerIconType.Forward: return "\uE72A";
                case InnerIconType.Refresh: return "\uE72C";

                // Files / Data
                case InnerIconType.File: return "\uE7C3";
                case InnerIconType.FileAdd: return "\uE8B7";
                case InnerIconType.FileRemove: return "\uE8B6";
                case InnerIconType.Folder: return "\uE8B7";
                case InnerIconType.FolderOpen: return "\uE838";
                case InnerIconType.Save: return "\uE74E";
                case InnerIconType.Upload: return "\uE898";
                case InnerIconType.Download: return "\uE896";
                case InnerIconType.Database: return "\uE9F1";

                // Status
                case InnerIconType.Check: return "\uE73E";
                case InnerIconType.Close: return "\uE711";
                case InnerIconType.Warning: return "\uE7BA";
                case InnerIconType.Info: return "\uE946";
                case InnerIconType.Error: return "\uEA39";

                // Commerce
                case InnerIconType.Cart: return "\uE7BF";
                case InnerIconType.CreditCard: return "\uE8C7";
                case InnerIconType.Money: return "\uEAFD";
                case InnerIconType.Wallet: return "\uE8C9";
                case InnerIconType.Tag: return "\uE8EC";
                case InnerIconType.Chart: return "\uE9D2";
                case InnerIconType.ChartBar: return "\uE9D2";
                case InnerIconType.ChartLine: return "\uE9E9";

                // Media
                case InnerIconType.Play: return "\uE768";
                case InnerIconType.Pause: return "\uE769";
                case InnerIconType.Stop: return "\uE71A";
                case InnerIconType.Camera: return "\uE722";
                case InnerIconType.Image: return "\uEB9F";

                // Misc
                case InnerIconType.Star: return "\uE734";
                case InnerIconType.Heart: return "\uEB52";
                case InnerIconType.Location: return "\uE707";
                case InnerIconType.Link: return "\uE71B";
                case InnerIconType.Globe: return "\uE774";
                case InnerIconType.Clipboard: return "\uE8C8";
                case InnerIconType.Edit: return "\uE70F";
                case InnerIconType.Trash: return "\uE74D";

                default: return "";
            }
        }

        private void ApplyCollapseState()
        {
            if (_isCollapsed)
            {
                _expandedHeight = Height;
                Height = _headerHeight + 2;
            }
            else
            {
                Height = _expandedHeight;
            }

            Invalidate();
        }
        #endregion
    }
}