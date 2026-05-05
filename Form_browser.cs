//  Form_browser.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;//プロジェクト→参照の追加→アセンブリ 拡張→System.Text.Encodings.Web
using System.Text.Json;//プロジェクト→参照の追加→アセンブリ 拡張→System.Text.Json
using System.Windows.Forms;
using System.Net;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace 英文逐語訳
{
    public partial class Form_browser : Form
    {
        public Form_browser(string st)
        {
            InitializeComponent();
            readDic("en-ja.json");
            wb.DocumentText = 逐語訳html(st, en);
        }
        public Form_browser(string st, Dictionary<string, string> en)
        {
            InitializeComponent();
            wb.DocumentText = 逐語訳html(st, en);
        }


        Dictionary<string, string> en;
        void readDic(string file)
        {
            string path = Assembly.GetEntryAssembly().Location;
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\") + 1);
            string json = System.IO.File.ReadAllText(path + file, Encoding.UTF8);
            var option = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
                WriteIndented = true,
            };
            en = JsonSerializer.Deserialize<Dictionary<string, string>>(json, option);//参照の追加→アセンブリ 拡張→System.Memory
        }

        string 逐語訳html(string inputText, Dictionary<string, string> en)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset=\"UTF-8\">");
            sb.AppendLine("<style>");
            sb.Append(style());
            sb.AppendLine("\r\n</style>");
            sb.AppendLine("</head><body><pre>");

            bool f; string tmp1, tmp2;
            var lines = inputText.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                foreach (var w in words)
                {
                    f = false; tmp1 = ""; tmp2 = "";
                    var word = w.Trim();
                    if (en.TryGetValue(word.ToLower(), out string meaning))
                    { sb.Append($"<span class=\"word\" title=\"{word} {meaning}\">{word}</span> "); f = true; }

                    if (f == false)
                    {
                        tmp1 = trimEn(word);
                        if (en.TryGetValue(tmp1.ToLower(), out string m))
                        { sb.Append($"<span class=\"word\" title=\"{tmp1} {m}\">{word}</span> "); f = true; }
                    }

                    if (f == false)
                    {
                        tmp2 = trimSuffix(tmp1);
                        if (en.TryGetValue(tmp2.ToLower(), out string m))
                        { sb.Append($"<span class=\"word\" title=\"{tmp2} {m}\">{word}</span> "); f = true; }
                    }

                    if (f == false) { sb.Append(word + " "); Console.WriteLine(word); }
                }
                sb.Append("\r\n");
            }
            sb.AppendLine(Google翻訳リンク(WebUtility.HtmlEncode(inputText)));
            sb.AppendLine("</pre></body></html>");
            return sb.ToString();
        }
        String trimEn(string txt)
        {
            return
            txt.Replace(".", "").Replace(",", "").Replace("?", "").Replace("!", "").Replace(";", "")
               .Replace(":", "").Replace("(", "").Replace(")", "").Replace("\"", "").Replace("“", "").Replace("'s", "");
        }
        string trimSuffix(string w)
        {
            string tmp;
            if (w.Length > 1)
            {
                if (en.ContainsKey(w.Substring(0, w.Length - 1)))
                {
                    tmp = w.Substring(w.Length - 1);
                    if (tmp == "s" || tmp == "d" || tmp == "r") { return w.Substring(0, w.Length - 1); }
                }
            }
            if (w.Length > 2)
            {
                if (en.ContainsKey(w.Substring(0, w.Length - 2)))
                {
                    tmp = w.Substring(w.Length - 2);
                    if (tmp == "ed" || tmp == "er") { return w.Substring(0, w.Length - 2); }
                }
            }
            if (w.Length > 3)
            {
                tmp = w.Substring(w.Length - 3);
                string b = w.Substring(0, w.Length - 3);
                if (en.ContainsKey(b))
                {
                    if (tmp == "ing") { return b; }
                    if (w.Substring(w.Length - 2) == "er") { return b; }
                    if (w.Substring(w.Length - 2) == "ed") { return b; }
                }
                if (en.ContainsKey(b + "e"))
                {
                    if (w.Substring(w.Length - 3) == "ing") { return b + "e"; }
                    if (w.Substring(w.Length - 2) == "ed") { return b + "e"; }
                }

                if (tmp == "ies") { if (en.ContainsKey(b + "y")) { return b + "y"; } }
                if (tmp == "ied") { if (en.ContainsKey(b + "y")) { return b + "y"; } }
            }
            return "";
        }
        string style() {
            return @"
.word { cursor: pointer; padding: 2px; border-radius: 3px; }
.word:hover { background-color: #ffff99; }

pre {
  color: #555;           /* 文字色 */
  padding: 16px;            /* 内側の余白 */
  font-family: 'Consolas', 'Monaco', 'Courier New', monospace; /* 等幅フォント */
  font-size: 25px;
  line-height: 1.5;
  overflow: auto;           /* 内容が溢れたらスクロール */
  
  /* 自動折り返し設定 */
  white-space: pre-wrap;
  word-wrap: break-word;
}
";
        }
        string Google翻訳リンク(string src)
        {
            // 英文を URL エンコード
            string encoded = Uri.EscapeDataString(src);
            // Google翻訳のURL（英語→日本語）
            string url = $"https://translate.google.com/?sl=en&tl=ja&text={encoded}&op=translate";
            // aタグのHTMLを返す
            return $"<a href=\"{url}\" target=\"_blank\">Google翻訳で見る</a>";
        }
        private void wb_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true; // IE の新規ウィンドウをキャンセル
            string url = wb.StatusText;// クリックされたリンクの URL
            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", url);
            //Process.Start("msedge.exe", WebUtility.HtmlEncode(url));
            Process.Start(new ProcessStartInfo(url) {UseShellExecute = true });
        }
    }
}
