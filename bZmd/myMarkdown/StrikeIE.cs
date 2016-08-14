using bZmd.DockUI;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace bZmd.myMarkdown
{
	class myStrikeIE : IMarkdown
	{
		static Strike.IE.Markdownify _markdown = new Strike.IE.Markdownify();

		public myStrikeIE()
		{
			htmlTemplate = "<html><head>\n"
				// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
				+ "</head><body class=\"markdown-body wiki\">\n{0}\n</body></html>";

			htmlTemplate_css = "<!DOCTYPE html><html><head>\n"
				// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
				+ "<style type=\"text/css\">{0}</style></head><body class=\"markdown-body wiki\">\n{1}\n</body></html>";
		}

	// http://codeblog.vurdalakov.net/2014/11/cs-how-to-render-github-flavored-markdown-with-github-api.html
	override public string StringToHtml(string sIn)
		{
			string parsed_html = _markdown.Transform(sIn);
			Global.myDebug("calling StrikeIE ...", 2);
			return "<!-- Stiike.IE -->\n" + parsed_html;
		}
	}
}
