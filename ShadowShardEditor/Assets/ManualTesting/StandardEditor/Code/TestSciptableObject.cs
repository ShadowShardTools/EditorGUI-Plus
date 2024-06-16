using UnityEngine;

namespace ManualTesting.StandardEditor.Code
{
    [CreateAssetMenu(fileName = "TestData", menuName = "Static data/Test/Standard editor")]
    public class ShadowShardData : ScriptableObject
    {
        public GUIStyle Styles;
        public int IndentLevel;
        public bool IsDisabled;
        public GUIContent Label;
    }
}