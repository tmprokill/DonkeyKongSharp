using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGUI.UIHelpers
{
    internal class FontInitializer
    {
        public static PrivateFontCollection Initialize() 
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            int fontLength = Properties.Resources.SonicFont.Length;

            byte[] fontdata = Properties.Resources.SonicFont;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            return pfc;
        }
        public static void UpdateFont(Control.ControlCollection controls, PrivateFontCollection _fontCollection)
        {
            foreach (Control item in controls)
            {
                item.Font = new Font(_fontCollection.Families[0], item.Font.Size, FontStyle.Bold);
            }
        }

        public static Font GetFont(PrivateFontCollection _fontCollection, Control item)
        {
            return new Font(_fontCollection.Families[0], item.Font.Size, FontStyle.Bold);
        }

        public static Font GetFont(PrivateFontCollection _fontCollection, int size)
        {
            return new Font(_fontCollection.Families[0], size, FontStyle.Bold);
        }
    }
}
