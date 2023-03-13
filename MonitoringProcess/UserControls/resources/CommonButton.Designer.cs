using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MonitorigProcess.UserControls.resources
{
    abstract partial class CommonButton
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
            //base 값을 지정하면 이 값으로 초기 컨트롤이 생성됨. 
            //여기의 base 값을 변경해도 이미 폼에 그려진 컨트롤들에 영향을 주지 않음 
            //버튼의 크기를 일괄로 변경하면 안되는 상황이 발생할 수 있기 때문에,
            //버튼 사용자가 크기를 커스터마이징할 수 있도록 허용
            base.Size = new System.Drawing.Size(80, 30);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            
        }

        #endregion
        public override Font Font { get; set; }
        public abstract override Color BackColor { get; set; }
    }
}
