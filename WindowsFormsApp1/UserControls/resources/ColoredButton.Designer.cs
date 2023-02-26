using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.UserControls.resources
{
    partial class ColoredButton
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
            this.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public override Color BackColor { get; set; }
        
        //protected Color BorderColor { get => base.FlatAppearance.BorderColor; set => base.FlatAppearance.BorderColor = BorderColor; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            this.BackColor = ColorPallete.GetARGBColor((int)GlobalBrandColor.HighAlpha, GlobalBrandColor.BrandColor2);
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = ColorPallete.GetARGBColor((int)GlobalBrandColor.HighBoldAlph, GlobalBrandColor.BrandColor2);
            this.ForeColor = Color.FromArgb((int)GlobalBrandColor.WhiteFontColor);

            //this.FlatAppearance.BorderColor = GlobalBrandColor.BrandColor1;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;


            base.OnPaint(pevent);
        }
    }
}
