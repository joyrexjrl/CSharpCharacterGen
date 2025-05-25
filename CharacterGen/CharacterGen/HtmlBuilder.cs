using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterGen
{
    public static class HtmlBuilder
    {
        public static string Build(string sheet)
        {
            string projectRoot = Directory.GetParent(Application.StartupPath)?.Parent?.FullName;

            string resetsPath = Path.Combine(projectRoot, "CSS", "resets.css");
            string resets = File.ReadAllText(resetsPath);

            string mainStylePath = Path.Combine(projectRoot, "CSS", "mainStyle.css");
            string mainStyle = File.ReadAllText(mainStylePath);

            string oseCssPath = Path.Combine(projectRoot, "CSS", "oseStyle.css");
            string oseCss = File.ReadAllText(oseCssPath);

            string tekoRegularUri = GetFontUri("teko-v22-latin-regular.woff2");
            string tekoSemiBoldUri = GetFontUri("teko-v22-latin-600.woff2");
            string novaSquareUri = GetFontUri("NovaSquare-Regular.ttf");

            string fontFace = $@"
                @font-face {{
                    font-family: 'Teko';
                    src: url('{tekoRegularUri}') format('woff2');
                    font-weight: 400;
                }}
                @font-face {{
                    font-family: 'Teko';
                    src: url('{tekoSemiBoldUri}') format('woff2');
                    font-weight: 600;
                }}
                @font-face {{
                    font-family: 'Nova Square';
                    src: url('{novaSquareUri}') format('truetype');
                }}";

            return $@"
            <html>
                <head>
                    <style>
                        {fontFace}
                        {mainStyle}
                        {resets}
                        {oseCss}
                    </style>
                </head>
                <body>
                    {sheet}
                </body>
            </html>";
        }

        static string GetFontUri(string fileName)
        {
            string projectRoot = Directory.GetParent(Application.StartupPath)?.Parent?.FullName;
            string fontPath = Path.Combine(projectRoot, "Fonts", fileName);
            return new Uri(fontPath).AbsoluteUri;
        }
    }
}
