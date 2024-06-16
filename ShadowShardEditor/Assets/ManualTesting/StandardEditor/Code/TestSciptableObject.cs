using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.StandardEditor.Code
{
    [CreateAssetMenu(fileName = "TestData", menuName = "Static data/Test/Standard editor")]
    public class ShadowShardData : ScriptableObject
    {
        public GUIStyle Styles = new GUIStyle();
        public int IndentLevel = 2;
        public bool IsDisabled = false;
        public GUIContent Label = new GUIContent("Test Label");
        public float SliderValue = 0.5f;
        public float MinValue = 0.0f;
        public float MaxValue = 1.0f;
        public int IntSliderValue = 5;
        public Vector3 Vector3Value = new Vector3(1, 2, 3);
        public Vector4 Vector4Value = new Vector4(1, 2, 3, 4);
        public FloatRange FloatRangeValue = new FloatRange(0, 1);
        public bool ToggleValue;
        public string ShaderGlobalKeyword = "SHADER_GLOBAL_KEYWORD";
        
        public SerializedObject GetSerializedObject() =>
            new(this);
    }
}