﻿/*
MIT License

Copyright (c) 2020 Jeff Campbell

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using UnityEditor;
using UnityEngine;

namespace JCMG.COC.Editor
{
	/// <summary>
	/// Menu items for this library.
	/// </summary>
	internal static class COCMenuItems
	{
		[MenuItem("Tools/JCMG/COC/Evaluate all COC Node Graphs", priority = 100)]
		internal static void RunAllCOCNodeGraphs()
		{
			COCInitializer.EvaluateAllCOCNodeGraphs();
		}

		[MenuItem("Tools/JCMG/COC/Evaluate all COC Node Graphs", true)]
		internal static bool ValidateRunAllCOCNodeGraphs()
		{
			return AssetDatabase.FindAssets(COCEditorConstants.FIND_ALL_GRAPHS_FILTER).Length > 0;
		}

		[MenuItem("Tools/JCMG/COC/Submit bug or feature request")]
		internal static void OpenURLToGitHubIssuesSection()
		{
			const string GITHUB_ISSUES_URL = "https://github.com/jeffcampbellmakesgames/unity-coc";

			Application.OpenURL(GITHUB_ISSUES_URL);
		}

		[MenuItem("Tools/JCMG/COC/Donate to support development")]
		internal static void OpenURLToKoFi()
		{
			const string KOFI_URL = "https://ko-fi.com/stampyturtle";

			Application.OpenURL(KOFI_URL);
		}

		[MenuItem("Tools/JCMG/COC/About")]
		internal static void OpenAboutModalDialog()
		{
			COCAboutWindow.View();
		}
	}
}
