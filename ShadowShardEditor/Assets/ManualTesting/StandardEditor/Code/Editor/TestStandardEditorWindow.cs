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
        private Vector2 _scrollPosition;

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
            using EditorGUILayout.ScrollViewScope scroll = new(_scrollPosition);
            _scrollPosition = scroll.scrollPosition;
            
            DrawGroups();
            DrawSliders();
            DrawToggles();
            DrawVectorEditors();

            if(EditorGUI.EndChangeCheck())
            {
                _serializedShadowShardData.ApplyModifiedProperties();
                _serializedShadowShardData.Update();
            }
        }

        private void DrawGroups()
        {
            _shadowShardEditor.DrawVertical(_shadowShardData.Styles, () => { });
            _shadowShardEditor.DrawIndented(_shadowShardData.IndentLevel, () => { });
            _shadowShardEditor.DrawDisabled(_shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawIndentedDisabled(_shadowShardData.IndentLevel, _shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(() => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.Label, _shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.Label, () => { });
        }

        private void DrawSliders()
        {
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
        }

        private void DrawToggles()
        {
            _shadowShardData.ToggleValue = _shadowShardEditor.DrawToggle(
                new GUIContent("Toggle"), _serializedShadowShardData.FindProperty("ToggleValue"), _shadowShardData.IndentLevel);

            _shadowShardData.ToggleValue = _shadowShardEditor.DrawShaderGlobalKeywordToggle(
                new GUIContent("Shader Global Keyword Toggle"), _serializedShadowShardData.FindProperty("ToggleValue"), _shadowShardData.ShaderGlobalKeyword,
                _shadowShardData.IndentLevel);
        }
        
        private void DrawVectorEditors()
        {
            _shadowShardData.FloatValue = _shadowShardEditor.DrawFloat(new GUIContent("Float"), _serializedShadowShardData.FindProperty("FloatValue"), FloatRange.Normalized, _shadowShardData.IndentLevel);
            _shadowShardData.Vector2Value = _shadowShardEditor.DrawVector2(new GUIContent("Vector2"), _serializedShadowShardData.FindProperty("Vector2Value"), Vector2Range.Normalized, _shadowShardData.IndentLevel);
            _shadowShardData.Vector3Value = _shadowShardEditor.DrawVector3(new GUIContent("Vector3"), _serializedShadowShardData.FindProperty("Vector3Value"), Vector3Range.Normalized, _shadowShardData.IndentLevel);
            _shadowShardData.Vector4Value = _shadowShardEditor.DrawVector4(new GUIContent("Vector4"), _serializedShadowShardData.FindProperty("Vector4Value"), Vector4Range.Normalized, _shadowShardData.IndentLevel);
            _shadowShardData.ColorValue = _shadowShardEditor.DrawColor(new GUIContent("Color"), _serializedShadowShardData.FindProperty("ColorValue"), true, false, _shadowShardData.IndentLevel);
            _shadowShardData.Vector2IntValue = _shadowShardEditor.DrawNormalizedIntFromVector2Int(new GUIContent("Vector2Int"), _serializedShadowShardData.FindProperty("Vector2IntValue"), Vector2Param.X, _shadowShardData.IndentLevel);
            _shadowShardData.Vector3IntValue = _shadowShardEditor.DrawNormalizedIntFromVector3Int(new GUIContent("Vector3Int"), _serializedShadowShardData.FindProperty("Vector3IntValue"), Vector3Param.X, _shadowShardData.IndentLevel);
            _shadowShardData.TextureValue = _shadowShardEditor.DrawTexture(new GUIContent("Texture"), _serializedShadowShardData.FindProperty("TextureValue"), _shadowShardData.IndentLevel);
            _shadowShardData.TextFieldValue = _shadowShardEditor.DrawTextField(new GUIContent("Text Field"), _serializedShadowShardData.FindProperty("TextFieldValue"), _shadowShardData.IndentLevel);
            _shadowShardData.FolderPathValue = _shadowShardEditor.DrawFolderPathField(new GUIContent("Folder Path"), _serializedShadowShardData.FindProperty("FolderPathValue"), "");
        }
    }
}