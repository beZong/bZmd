# bZmd -- beZong Markdown

Preview markdown files, when editing with (virtually) any editors.

## Motivation

Inspired by [**Grip**](https://github.com/joeyespo/grip) (GitHub Readme Instant Preview)

In order to manipulate several markdown files, **a handy viewer might be even useful than editors**. 
Also, a viewer will be ealier to implement, and to add features, such as,

* auto fetch active markdown files
	* single executive instance for multiple wikis
	* no necessary the default `readme.md` file name
	* no need to specify `xxxx.md` file name
* adopt for poor-linked wiki

## Planned Features

* (50%) Render GitHub/GitLab Flavored Markdown
	* **(70%)** [GitHub markdown API](http://developer.github.com/v3/markdown) -- require network connection
		* need check Table styles
	* offline markdown parser -- as fallback when no network connection
	* **(70%)** [Strike.IE](https://github.com/SimonCropp/Strike) -- to render GitHub-flavored markdown offline
	* ~~(50%, pending) MarkdownSharp, **no table support**~~
	* customize CSS, (10%~70%) GitHub style CSS
	* GitLab style CSS
* Flexible Markdown converter
	* [Pandoc](http://pandoc.org) -- universal document converter
	* Allow user to select differnt render backend
* Fetch active markdown files from other editors, including:
	* **(80%)** Notepad++
	* PSPad ...
	* (50%) Visual Studio -- not hooked file saving ??
	* (?) SharpDevelop
	* ... allow user to add other programs
	* clipboard (for browsing)
	* **(70%)** file explorer (for browsing) ...
* Monitor changes for (60%) files and directory tree
	* **(80%)** remember scroll position while refreshing preview
		* todo, first, stat = 14
	* sync scrolling
* Tabbed document interface (DockUI) 
	* (40%) for multiple markdown files
	* optional always-on-top
	* markdown syntax help in a separate tab
	* rename ambiguous tabs
	* lock tab, max tab count
* Link / Browsing
	* (60%) Web link in browser -- **not working in debug mode ??**
	* **(80%)** File link in another tab, or
	* System default application
	* **(80%)** Show link URL in status bar
	* Handle broken link while navigating
	* Fix broken link in markdown file
* Copy
	* selected html
	* selected markdown
* Export HTML
	* @ to clipboard
	* @ save as file
	* @ with style CSS
	* @ without styles
* Full text search acorss files
* Window location
	* Side By side, auto docking
	* auto hide
* As a member of **[beZong](https://github.com/beZong/beZong) -- organize your digital belongings**
* support html and other format
 
## Coding Reference
### Markdown
* [GitHub Flavored Markdown](https://help.github.com/articles/github-flavored-markdown/)
	* Redcarpet - https://github.com/blog/832-rolling-out-the-redcarpet
* [GitHub markdown API](http://developer.github.com/v3/markdown)
	* [Grip -- GitHub Readme Instant Preview](https://github.com/joeyespo/grip) (MIT License ?)
	* [Rate Limit](https://developer.github.com/v3/rate_limit/) | GitHub Developer Guide
	* [How to render GitHub-flavored markdown with GitHub API](http://codeblog.vurdalakov.net/2014/11/cs-how-to-render-github-flavored-markdown-with-github-api.html)
	* [The minimal amount of CSS to replicate the GitHub Markdown style](http://codeblog.vurdalakov.net/2014/11/minimal-amount-of-css-to-replicate-github-markdown-style.html)
* [GitLab Flavored Markdown](https://gitlab.com/gitlab-org/gitlab-ce/blob/master/doc/markdown/markdown.md)
* [Markdown Cheatsheet · adam-p/markdown-here](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
* https://github.com/sindresorhus/github-markdown-css (MIT License)
* GitLab style CSS
	* GitHub [source code](https://github.com/gitlabhq/gitlabhq/search?l=scss&amp;q=wiki&amp;type=Code&amp;utf8=%E2%9C%93)

### Strike.IE
* [Strike.IE](https://github.com/SimonCropp/Strike) (NuGet), 
	* **need re-compile to support .NET 4.5**
* [How to render GitHub-flavored markdown offline](http://codeblog.vurdalakov.net/2014/11/cs-how-to-render-github-flavored-markdown-offline.html)

### MarkdownSharp
* https://github.com/jpoehls/MarkdownWin (C#, MarkdownSharp) -- "live preview" Markdown viewer for Windows.
* https://github.com/Kiri-rin/markdownsharp 1.14.4 (NuGet) (.NET 4.5)

### Windows API
* http://www.pinvoke.net/
* [AArnott/pinvoke](https://github.com/AArnott/pinvoke) (MIT License)
* [AutomationElement](http://tinyurl.com/jk22gz8) (msdn)
* [Compiling C# Code at Runtime](http://www.codeproject.com/Tips/715891/Compiling-Csharp-Code-at-Runtime) - CodeProject

### User Interface
* [**DockPanelSuite**](https://github.com/dockpanelsuite/dockpanelsuite) (MIT License)
* http://www.codeproject.com/Articles/1102/Using-the-WebBrowser-control-in-NET


