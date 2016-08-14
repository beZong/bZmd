using bZmd.DockUI;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace bZmd.myMarkdown
{ 
	class myGithubAPI : IMarkdown
	{
		public myGithubAPI()
		{
			htmlTemplate = "<html><head>\n"
			// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
			+ "</head><body class=\"markdown-body\">\n{0}\n</body></html>";

			htmlTemplate_css = "<!DOCTYPE html><html><head>\n"
				// + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />"
				+ "<style type=\"text/css\">{0}</style></head><body class=\"markdown-body\">{1}</body></html>";
		}

		// http://codeblog.vurdalakov.net/2014/11/cs-how-to-render-github-flavored-markdown-with-github-api.html
		override public string StringToHtml(string markdown)
		{
			var webClient = new WebClient();
			webClient.Headers.Add("User-Agent", "ghmd-renderer");
			webClient.Headers.Add("Content-Type", "text/x-markdown");
			webClient.Encoding = Encoding.UTF8;     // todo, detect encoding
			Global.myDebug("calling api.github.com/markdown/raw ...", 2);
			return "<!-- Github API -->\n" + webClient.UploadString("https://api.github.com/markdown/raw", "POST", markdown);
		}
	}
}
