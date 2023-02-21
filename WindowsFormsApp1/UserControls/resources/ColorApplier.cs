using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UserControls.resources
{
    public class ColorApplier
    {
        public class TabControlDesigner
        {
            public TabControlDesigner(Guna.UI2.WinForms.Guna2TabControl tabControl)
            {
                tabControl.ItemSize = new System.Drawing.Size(120, 40);
                tabControl.Name = "tabControl";
                tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
                tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.White;
                tabControl.TabButtonHoverState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
                tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.Transparent;
                tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
                tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.White;
                tabControl.TabButtonIdleState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
                tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
                tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
                tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
                tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
                tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
                tabControl.TabButtonSize = new System.Drawing.Size(120, 40);
                tabControl.TabMenuBackColor = System.Drawing.Color.White;
                tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;

            }
        }
    }
}
