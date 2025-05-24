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

            return $@"
            <html>
                <head>
                    <style>
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
    }
}
