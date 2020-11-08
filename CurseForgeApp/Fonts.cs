using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace CurseForgeApp
{
    public class Fonts
    {
        static readonly PrivateFontCollection Cache;

        public static FontFamily NotoSans => Cache.Families.First();

        static Fonts()
        {
            Cache = new PrivateFontCollection();
        }

        public static void InitializeFonts()
        {
            //InstallResourceFont("Assets/Fonts/Minecraftia-Regular.ttf");
            InstallResourceFont("Assets/Fonts/NotoSans-Regular.ttf");
            InstallResourceFont("Assets/Fonts/NotoSans-Bold.ttf");
            InstallResourceFont("Assets/Fonts/NotoSans-Italic.ttf");
            InstallResourceFont("Assets/Fonts/NotoSans-BoldItalic.ttf");
        }

        static void InstallResourceFont(string resourceName)
        {
            resourceName = string.Concat(nameof(CurseForgeApp), ".", resourceName.Replace("/", "."));

            var assembly = typeof(Fonts).Assembly;
            var resourceStream = assembly.GetManifestResourceStream(resourceName);

            if (resourceStream == null)
                return;

            byte[] buffer;

            using (resourceStream)
            {
                buffer = new byte[resourceStream.Length];
                resourceStream.Read(buffer, 0, buffer.Length);
            }

            IntPtr hFont = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, hFont, buffer.Length);
            Cache.AddMemoryFont(hFont, buffer.Length);
        }
    }
}
