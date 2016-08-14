using System.IO;

namespace bZmd.myMarkdown
{
	class IMarkdown
	{
		public string htmlTemplate = "<html><head>\n"
			// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
			+ "</head><body>\n{0}\n</body></html>";

		public string htmlTemplate_css = "<!DOCTYPE html><html><head>\n"
			// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
			+ "<style type=\"text/css\">{0}</style></head><body>\n{1}\n</body></html>";

		public virtual string StringToHtml(string sIn)
		{
			return "<!-- IMarkdown -->" + sIn;
		}

		public string FileToHtml(FileInfo info)
		{
			string text;
			using (var stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}

			return StringToHtml(text);
        }

		public void FileToHtml(FileInfo info, Stream CssFile, out string html_with_css)
		{
			string sHtml = string.Empty;
			FileToHtml(info, CssFile, out html_with_css, out sHtml);
        }

		public string FileToHtml(FileInfo info, Stream CssFile)
		{
			string html_with_css = string.Empty;
			FileToHtml(info, CssFile, out html_with_css);

			return html_with_css;
		}

		public void FileToHtml(FileInfo info, Stream CssFile, out string html_with_css, out string html)
		{

			// Convert Markdown to Html
			string raw_html = FileToHtml(info);
			html = string.Format(this.htmlTemplate, raw_html);

			if (CssFile == null)
			{
				html_with_css = html;
				return;
			}

			// http://codeblog.vurdalakov.net/2014/11/minimal-amount-of-css-to-replicate-github-markdown-style.html
			// Fetch and apply Stylesheet;
			string stylesheet;
			// using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("bZmd.myMarkdown.markdown.css"))
			using (var reader = new StreamReader(CssFile))
			{
				stylesheet = reader.ReadToEnd();
			}

			html_with_css = string.Format(this.htmlTemplate_css, stylesheet, raw_html);
		}
	}
}
