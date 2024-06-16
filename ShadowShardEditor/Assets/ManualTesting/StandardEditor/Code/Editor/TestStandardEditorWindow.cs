using ShadowShard.Editor;
using ShadowShard.Editor.Enums;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.StandardEditor.Code.Editor
{
    public class ShadowShardEditorWindow : EditorWindow
    {
        private ShadowShardData _shadowShardData;
        private ShadowShardEditor _shadowShardEditor;
        private SerializedObject _serializedShadowShardData;

        [MenuItem("Window/EditorTesting/Standard Editor Tests")]
        public static void ShowWindow() =>
            GetWindow<ShadowShardEditorWindow>("Standard Editor Tests");

        private void OnGUI()
        {
            _shadowShardData = EditorGUILayout.ObjectField("Test data", _shadowShardData, typeof(ShadowShardData), false) as ShadowShardData;
            _shadowShardEditor ??= new ShadowShardEditor();
            if(_shadowShardData == null)
            {
                EditorGUILayout.HelpBox("Test data is not set!", MessageType.Error);
                return;
            }

            if(_serializedShadowShardData == null)
            {
                _serializedShadowShardData = _shadowShardData.GetSerializedObject();
                _serializedShadowShardData.ApplyModifiedProperties();
                _serializedShadowShardData.Update();
            }

            EditorGUI.BeginChangeCheck();

            _shadowShardEditor.DrawVertical(_shadowShardData.Styles, () => { });
            _shadowShardEditor.DrawIndented(_shadowShardData.IndentLevel, () => { });
            _shadowShardEditor.DrawDisabled(_shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawIndentedDisabled(_shadowShardData.IndentLevel, _shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(() => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.Label, _shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.Label, () => { });

            _shadowShardData.SliderValue = _shadowShardEditor.DrawSlider(
                new GUIContent("Slider"), _serializedShadowShardData.FindProperty("SliderValue"), new FloatRange(0, 1), _shadowShardData.IndentLevel);

            _shadowShardData.IntSliderValue = _shadowShardEditor.DrawIntSlider(
                new GUIContent("Int Slider"), _serializedShadowShardData.FindProperty("IntSliderValue"), new IntRange(0, 10), _shadowShardData.IndentLevel);

            _shadowShardEditor.DrawFromVector3ParamSlider(
                new GUIContent("Vector3 Slider"), _serializedShadowShardData.FindProperty("Vector3Value"), Vector3Param.X, new FloatRange(0, 1), _shadowShardData.IndentLevel);

            _shadowShardEditor.DrawVector3Sliders(
                new GUIContent("X"), new GUIContent("Y"), new GUIContent("Z"), _serializedShadowShardData.FindProperty("Vector3Value"), new FloatRange(0, 1),
                _shadowShardData.IndentLevel);

            _shadowShardEditor.DrawMinMaxSlider(
                new GUIContent("Min Max Slider"), _serializedShadowShardData.FindProperty("MinValue"), _serializedShadowShardData.FindProperty("MaxValue"),
                new FloatRange(0, 1), _shadowShardData.IndentLevel);

            _shadowShardEditor.DrawMinMaxVector4StartSlider(
                new GUIContent("Vector4 Start Slider"), _serializedShadowShardData.FindProperty("Vector4Value"), new FloatRange(0, 1), _shadowShardData.IndentLevel);

            _shadowShardEditor.DrawMinMaxVector4EndSlider(
                new GUIContent("Vector4 End Slider"), _serializedShadowShardData.FindProperty("Vector4Value"), new FloatRange(0, 1), _shadowShardData.IndentLevel);

            if(EditorGUI.EndChangeCheck())
            {
                _serializedShadowShardData.ApplyModifiedProperties();
                _serializedShadowShardData.Update();
            }
        }
    }
}