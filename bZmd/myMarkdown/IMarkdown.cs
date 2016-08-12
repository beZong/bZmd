using System.IO;

namespace bZmd.myMarkdown
{
	interface IMarkdown
	{
		string FileToHtml(FileInfo info);

		string StringToHtml(string sIn);

		void FileToHtml(FileInfo info, Stream CssFile, out string sOut);

		string FileToHtml(FileInfo info, Stream CssFile);
	}
}
