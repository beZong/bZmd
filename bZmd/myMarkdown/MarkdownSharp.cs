#if MarkdownSharp

using bZmd.DockUI;
using MarkdownSharp;
using System;
using System.IO;


namespace bZmd.myMarkdown
{
	class myMarkdownSharp
	{
		// https://github.com/Kiri-rin/markdownsharp/blob/master/MarkdownSharp/Markdown.cs
		static MarkdownOptions options = new MarkdownOptions
		{
			AutoHyperlink = true,
			AutoNewlines = true,
			LinkEmails = true,
			QuoteSingleLine = true,
			StrictBoldItalic = true
		};

		static Markdown _markdown = new Markdown(options);

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
			Global.myDebug("calling MarkdownSharp", 2);
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