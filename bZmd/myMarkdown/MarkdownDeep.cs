#if MarkdownDeep

using bZmd.DockUI;
using System;
using System.IO;


namespace bZmd.myMarkdown
{
	class myMarkdownDeep
	{

		static Markdown _markdown = new Markdown();

#if MarkdownDeep
			md = new MarkdownDeep.Markdown();
			md.ExtraMode = true;
			md.SafeMode = false;
			md.AutoHeadingIDs = true;
			md.MarkdownInHtml = true;
            md.NewWindowForExternalLinks = true;
#endif

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

		static public string StringToHtml(string sIn)
		{
			string parsed_html = _markdown.Transform(sIn);
			Global.myDebug("calling MarkdownDeep ... not implemented", 0);
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

			// Fetch and apply Stylesheet;
			const string htmlTemplate = "<html><head><style type=\"text/css\">{0}</style></head><body class=\"markdown-body\">{1}</body></html>";
			string stylesheet;
			// using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType(), "markdown.css"))
			using (var reader = new StreamReader(CssFile))
			{
				stylesheet = reader.ReadToEnd();
			}

			string html_with_css = string.Format(htmlTemplate, stylesheet, parsed_html);

			return html_with_css;
		}
	}
}

#endif