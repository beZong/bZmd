using bZmd.DockUI;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace bZmd.myMarkdown
{
	class myStrikeIE
	{
		static Strike.IE.Markdownify _markdown = new Strike.IE.Markdownify();

		static public string FileToHtml(FileInfo info)
		{
			string text;
			using (var stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}

			return StringToHtml(text);
        }

		// http://codeblog.vurdalakov.net/2014/11/cs-how-to-render-github-flavored-markdown-with-github-api.html
		static public string StringToHtml(string sIn)
		{
			string parsed_html = _markdown.Transform(sIn);
			Global.myDebug("calling StrikeIE ...", 2);
			return parsed_html;
		}

		static public void FileToHtml(FileInfo info, Stream CssFile, out string sOut)
		{
			sOut = FileToHtml(info, CssFile);
        }

		static public string FileToHtml(FileInfo info, Stream CssFile)
		{
			// Convert Markdown to Html
			string parsed_html = FileToHtml(info);

			if (CssFile == null)
				return parsed_html;

			// http://codeblog.vurdalakov.net/2014/11/minimal-amount-of-css-to-replicate-github-markdown-style.html
			// Fetch and apply Stylesheet;
			const string htmlTemplate = "<html><head>"
				// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
				+ "<style type=\"text/css\">{0}</style></head><body class=\"markdown-body wiki\">{1}</body></html>";
			string stylesheet;
			// using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("bZmd.myMarkdown.markdown.css"))
			using (var reader = new StreamReader(CssFile))
			{
				stylesheet = reader.ReadToEnd();
			}

			string html_with_css = string.Format(htmlTemplate, stylesheet, parsed_html);

			return html_with_css;
		}
	}
}
