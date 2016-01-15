# bZmd -- beZong Markdown

Preview markdown files, when editing with (virtually) any editors.

## Motivation

Inspired by [**Grip -- GitHub Readme Instant Preview**](https://github.com/joeyespo/grip), I realized that, in order to manipulate several markdown files, **a handy viewer might be even useful than editors**. Also, a viewer will be ealier to implement, and to add some features (not in Grip) such as,

* single executive instance for multiple wikis
* release the need of default `readme.md`
* no need to specify `xxxx.md` file name
* adopt for poor-linked wiki

## Planned Features

* Render GitHub/GitLab Flavored Markdown 
	* customize CSS
* Fetch active markdown files from other editors, including:
	* (50%) Notepad++
	* PSPad
	* Visual Studio
	* SharpDevelop
	* ... allow user to add other programs
	* clipboard (for browsing)
	* file explorer (for browsing)
* Monitor changes for files and directory tree
	* remember cursor/scrolling position while refreshing
* (10%) Tabbed document interface (DockUI) for multiple markdown files
* Handle broken link
* Full text search acorss files
* Window location
	* Side By side, auto docking
	* auto hide
* As a member of **beZong -- organize your digital belongings**
* support html and other format
 
## Coding Reference
### Markdown
* [GitHub Flavored Markdown](https://help.github.com/articles/github-flavored-markdown/)
	* Redcarpet - https://github.com/blog/832-rolling-out-the-redcarpet
* [GitLab Flavored Markdown](https://gitlab.com/gitlab-org/gitlab-ce/blob/master/doc/markdown/markdown.md)
* [Markdown Cheatsheet · adam-p/markdown-here](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
* [**Grip -- GitHub Readme Instant Preview**](https://github.com/joeyespo/grip)  (MIT License ?)
* (10%) https://github.com/Knagis/CommonMark.NET
* CommonMark markdowndeep sundown
* https://github.com/PKRoma/MarkdownSharp 1506
	* others https://github.com/search?utf8=%E2%9C%93&q=MarkdownSharp
* https://github.com/jpoehls/MarkdownWin -- "live preview" Markdown viewer for Windows.
* https://github.com/KyleGobel/MarkdownSharp-GithubCodeBlocks

### Windows API
* [AArnott/pinvoke](https://github.com/AArnott/pinvoke) (MIT License)

### User Interface
* [**DockPanelSuite**](https://github.com/dockpanelsuite/dockpanelsuite) (MIT License)


