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

using System;
using JCMG.xNode;
using UnityEditor;
using UnityEngine;
using JCMG.xNode.Editor;

namespace JCMG.COC.Editor
{
	[CustomNodeGraphEditor(typeof(COCNodeGraph))]
	internal sealed class COCNodeGraphEditor : NodeGraphEditor
	{
		public override void OnOpen()
		{
			// Create and add an AssetRootNode if not present.
			if (target.nodes.TrueForAll(x => x.GetType() != typeof(AssetRootNode)))
			{
				var node = target.AddNode(typeof(AssetRootNode));
				node.position = Vector2.zero;
				node.name = NodeEditorUtilities.NodeDefaultName(typeof(AssetRootNode));

				AssetDatabase.SaveAssets();
				AssetDatabase.AddObjectToAsset(node, target);
				AssetDatabase.SaveAssets();
				NodeEditorWindow.RepaintAll();
			}
		}

		public override void RemoveNode(Node node)
		{
			// Prevent deletion of the AssetRootNode as there should always be one per graph.
			// otherwise delete as normal.
			if (node is AssetRootNode)
			{
				return;
			}

			base.RemoveNode(node);
		}

		public override string GetNodeMenuName(Type type)
		{
			// Ensure only COC nodes other than the AssetRootNode can be created.
			if (type == typeof(AssetRootNode) || type.Namespace != COCEditorConstants.NAMESPACE)
			{
				return null;
			}

			return base.GetNodeMenuName(type);
		}
	}
}
