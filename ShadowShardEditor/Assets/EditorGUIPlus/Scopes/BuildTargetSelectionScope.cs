using System;
using UnityEditor;

namespace EditorGUIPlus.Scopes
{
    public class BuildTargetSelectionScope : IDisposable
    {
        public readonly BuildTargetGroup SelectedBuildTargetGroup;
        
        public BuildTargetSelectionScope()
        {
            SelectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
        }

        public void Dispose() =>
            EditorGUILayout.EndBuildTargetSelectionGrouping();
    }
}