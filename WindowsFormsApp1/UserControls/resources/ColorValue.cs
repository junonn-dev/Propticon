using System.Drawing;

namespace WindowsFormsApp1.UserControls.resources
{
    public enum ColorAlphaValue
    {
        //RGBA 색상에서 A는 Alpha값을 뜻함
        //Alpha 값은 0.0 ~ 1.0 사이값이며, 색의 투명도를 의미함.
        //.net에서는 A값을 8bit 수 (byte타입)으로 지정하고 있어서,
        //0~255값과 0.0 ~ 1.0을 매핑하기 위해 enum 으로 관리
        //.net 제공하는 Color.fromArgb(alpha, Color.색상명)메서드에 enum값을 부여하여 색상 만들기 위함.
        Alpha01 = 25,    //Alpha값 0.1을 25로 등차로 가정함
        Alpha02 = 50,
        Alpha03 = 75,
        Alpha04 = 100,
        Alpha05 = 125,
        Alpha06 = 150,
        Alpha07 = 175,
        Alpha08 = 200,
        Alpha09 = 225,
        Alpha10 = 255,
    }

    //Application 전체에서 사용할 대표 원색 (BrandColor)
    //원색에 적용할 alpha값 정의
    public enum GlobalBrandColor
    {
        /// <summary>
        /// 0xff808080, Color.Gray
        /// </summary>
        BrandColor1 = -8355712, 
        /// <summary>
        /// 0x4169E1, Color.RoyalBlue;
        /// </summary>
        BrandColor2 = -12490271,

        /// <summary>
        /// 0x696969, SystemColor.ControlDarkDark
        /// </summary>
        BasicFontColor = -9868951, 

        /// <summary>
        /// Color.White
        /// </summary>
        WhiteFontColor = -1,        

        LowAlpha = ColorAlphaValue.Alpha01,
        LowBoldAlpha = ColorAlphaValue.Alpha03,

        HighAlpha = ColorAlphaValue.Alpha07,
        HighBoldAlph = ColorAlphaValue.Alpha09,

        
    }

    public static class ColorPallete
    {
        //TODO : aValue도 GlobalBrandColor가져와서 사용하도록 수정 
        public static Color GetARGBColor(int aValue, GlobalBrandColor brandColor)
        {
            return Color.FromArgb(aValue, Color.FromArgb((int)brandColor));
        }

        public static Color GetARGBColor(ColorAlphaValue aValue, GlobalBrandColor brandColor)
        {
            return Color.FromArgb((int)aValue, Color.FromArgb((int)brandColor));
        }
    }
}
