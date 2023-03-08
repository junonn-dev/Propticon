using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.UserControls.resources;

namespace UILayoutExample
{
    partial class HipListBox
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DoubleBuffered = true;
            this.ItemHeight = 30;
            this.BorderStyle = BorderStyle.None;
            this.Margin = new Padding(0);
            this.SelectionMode = System.Windows.Forms.SelectionMode.One;
            //this.BackColor = ColorPallete.GetARGBColor(ColorAlphaValue.Alpha01, GlobalBrandColor.BrandColor1);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private int _hotTrackedIndex = -1;
        private int HotTrackedIndex
        {
            get => _hotTrackedIndex;
            set
            {
                if (value != _hotTrackedIndex)
                {
                    if (_hotTrackedIndex >= 0 && _hotTrackedIndex < Items.Count)
                    {
                        Invalidate(GetItemRectangle(_hotTrackedIndex));
                    }
                    _hotTrackedIndex = value;
                    if (_hotTrackedIndex >= 0)
                    {
                        Invalidate(GetItemRectangle(_hotTrackedIndex));
                    }
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var borderRect = e.Bounds;
            borderRect.Width--;
            borderRect.Height--;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (Focused)
                {
                    e.Graphics.FillRectangle(Brushes.Teal, e.Bounds);
                    e.Graphics.DrawRectangle(Pens.LightSkyBlue, borderRect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds);
                    e.Graphics.DrawRectangle(Pens.White, borderRect);
                }
            }
            else if (e.Index == HotTrackedIndex)
            {
                e.Graphics.FillRectangle(Brushes.DarkSlateGray, e.Bounds);
                e.Graphics.DrawRectangle(Pens.DarkCyan, borderRect);
            }
            else
            {
                e.DrawBackground();
            }
            if (this.Items.Count!=0 && e.Index >= 0 && Items[e.Index] != null)
            {
                e.Graphics.DrawString(Items[e.Index].ToString(),
                    new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129))), Brushes.Black, 6, e.Bounds.Top, StringFormat.GenericTypographic);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HotTrackedIndex = -1;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            HotTrackedIndex = IndexFromPoint(e.Location);
            base.OnMouseMove(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (SelectedIndex >= 0)
            {
                RefreshItem(SelectedIndex);
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (SelectedIndex >= 0)
            {
                RefreshItem(SelectedIndex);
            }
            base.OnLostFocus(e);
        }
    }
}
