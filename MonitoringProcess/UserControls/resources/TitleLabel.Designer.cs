using System;
using System.Drawing;

namespace MonitorigProcess.UserControls.resources
{
    partial class TitleLabel
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
            // 
            // label1
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(101, 30);
            this.Text = "Title";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //Custom Control의 일괄 적용을 위한 필드
        //필드 override하면 control 생성 시 designer에 auto generated되지 않아서 
        //이 필드값 변경해주면 프로젝트 내 전체에 일괄 적용됨
        public override Color BackColor { get; set; }
        public override Font Font { get; set; }
        public override Color ForeColor { get; set; }

        protected override void OnMouseEnter(EventArgs e)
        {
            //base.OnMouseEnter(e);
            this.BackColor = ColorPallete.GetARGBColor(((int)GlobalBrandColor.LowAlpha), GlobalBrandColor.BrandColor1);
            this.Refresh();

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //base.OnMouseLeave(e);
            this.BackColor = Color.Transparent;
            this.Refresh();
        }
        #endregion
    }
}
