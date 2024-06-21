using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes
{
    public class BuildTargetSelectionScope : GUI.Scope
    {
        public readonly BuildTargetGroup SelectedBuildTargetGroup;
        
        public BuildTargetSelectionScope()
        {
            SelectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
        }
        
        protected override void CloseScope()
        {
            EditorGUILayout.EndBuildTargetSelectionGrouping();
        }
    }
}