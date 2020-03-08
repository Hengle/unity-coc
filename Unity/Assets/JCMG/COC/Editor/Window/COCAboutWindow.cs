﻿using UnityEditor;
using UnityEngine;

namespace JCMG.COC.Editor
{
	/// <summary>
	/// A window that shows information about the library and its contributors (only myself at the moment).
	/// </summary>
	internal sealed class COCAboutWindow : EditorWindow
	{
		#pragma warning disable 0649

		[SerializeField]
		private Texture2D _socialShareImage;

		[SerializeField]
		private Texture2D _portraitImage;

		#pragma warning restore 0649

		private const string WINDOW_TITLE = "JCMG COC";
		private const string VERSION_LABEL = "Version:";
		private const string GITHUB_LABEL = "GitHub:";
		private const string KOFI_LABEL = "KOFI:";
		private const string TWITTER_LABEL = "Twitter:";

		private const string GITHUB_URL = "https://github.com/jeffcampbellmakesgames";
		private const string KOFI_URL = "https://ko-fi.com/stampyturtle";
		private const string TWITTER_URL = "https://twitter.com/StampyTurtle";

		private const string SHARE_MESSAGE = "Hi there! My name is Jeff Campbell and I make open source tools for game " +
		                                     "developers.\n\nIf you enjoy using this tool and want to support its development " +
		                                     "and other high-quality, free open-source tools, follow me on Twitter, " +
		                                     "GitHub, and consider buying me a coffee on Ko-Fi.";

		public static void View()
		{
			var window = CreateInstance<COCAboutWindow>();
			window.minSize = new Vector2(512f, 490f);
			window.maxSize = window.minSize;
			window.titleContent = new GUIContent(WINDOW_TITLE);
			window.position = new Rect(
				Screen.currentResolution.width / 2f,
				Screen.currentResolution.height / 2f,
				0f,
				0f);
			window.ShowUtility();
		}

		private void OnGUI()
		{
			// JCMG Share Image
			if (_socialShareImage != null)
			{
				GUILayout.Label(_socialShareImage);

				DrawSeparator();
			}

			// COC Version
			using (new EditorGUILayout.HorizontalScope())
			{
				EditorGUILayout.LabelField(VERSION_LABEL, EditorStyles.boldLabel, GUILayout.Width(75f));
				EditorGUILayout.LabelField(COCVersionConstants.VERSION);
			}

			DrawSeparator();

			// Share message and portrait
			using (new EditorGUILayout.HorizontalScope())
			{
				if (_portraitImage != null)
				{
					GUILayout.Label(_portraitImage, GUILayout.Width(96f), GUILayout.Height(96f));
				}
				EditorGUILayout.SelectableLabel(SHARE_MESSAGE, EditorStyles.textArea, GUILayout.Height(96f));
			}

			// Links for Github, KoFi, and Twitter
			var originalColor = GUI.contentColor;

			// Twitter
			using (new EditorGUILayout.HorizontalScope())
			{
				EditorGUILayout.LabelField(TWITTER_LABEL, EditorStyles.boldLabel, GUILayout.Width(75f));
				GUI.contentColor = Color.cyan;
				if (GUILayout.Button(TWITTER_URL, GUI.skin.label))
				{
					Application.OpenURL(TWITTER_URL);
				}

				GUI.contentColor = originalColor;
			}

			// Github
			using (new EditorGUILayout.HorizontalScope())
			{
				EditorGUILayout.LabelField(GITHUB_LABEL, EditorStyles.boldLabel, GUILayout.Width(75f));
				GUI.contentColor = Color.cyan;
				if (GUILayout.Button(GITHUB_URL, GUI.skin.label))
				{
					Application.OpenURL(GITHUB_URL);
				}
				GUI.contentColor = originalColor;
			}

			// KOFI
			using (new EditorGUILayout.HorizontalScope())
			{
				EditorGUILayout.LabelField(KOFI_LABEL, EditorStyles.boldLabel, GUILayout.Width(75f));
				GUI.contentColor = Color.cyan;
				if (GUILayout.Button(KOFI_URL, GUI.skin.label))
				{
					Application.OpenURL(KOFI_URL);
				}

				GUI.contentColor = originalColor;
			}
		}

		private void DrawSeparator()
		{
			GUILayout.Box(string.Empty, GUILayout.ExpandWidth(true), GUILayout.Height(1));
		}
	}
}
