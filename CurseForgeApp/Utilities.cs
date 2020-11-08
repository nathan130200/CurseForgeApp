using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CurseForgeApp
{
    public static class Utilities
    {
        public static void InvokeAction(this Control c, Action fn)
            => c.Invoke(fn);

        public static object InvokeAction(this Control c, Func<object> fn)
            => c.Invoke(fn);

        public static void ApplyFontTo(this FontFamily family, params Control[] controls)
        {
            foreach(var control in controls)
            {
                var oldFont = control.Font;
                var newFont = new Font(Fonts.NotoSans, oldFont.Size, oldFont.Style, oldFont.Unit, oldFont.GdiCharSet);
                control.Font = newFont;
            }
        }

        public static void InjectMinecraftFont(this object obj, bool scanChildren = true)
        {
            var typeInfo = obj.GetType().GetTypeInfo();

            if (typeInfo.TryGetProperty("Font", out var rawFont))
            {
                var oldFont = (Font)rawFont.GetValue(obj);
                var newFont = new Font(Fonts.NotoSans, oldFont.Size, oldFont.Style, oldFont.Unit, oldFont.GdiCharSet);
                rawFont.SetValue(obj, newFont);
            }

            if (scanChildren)
            {
                if (typeInfo.TryGetProperty("Controls", out var rawControls))
                {
                    var controls = (Control.ControlCollection)rawControls.GetValue(obj);

                    foreach (var control in controls)
                        control.InjectMinecraftFont();
                }
            }
        }

        static bool TryGetProperty(this TypeInfo ti, string name, out PropertyInfo p)
        {
            p = ti.GetProperty(name);
            return p != null;
        }
    }
}
