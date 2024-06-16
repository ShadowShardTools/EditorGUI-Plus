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

        [MenuItem("Window/EditorTesting/Standard Editor Tests")]
        public static void ShowWindow() =>
            GetWindow<ShadowShardEditorWindow>("Standard Editor Tests");

        private void OnGUI()
        {
            _shadowShardData = EditorGUILayout.ObjectField("Test data", _shadowShardData, typeof(ShadowShardData), false) as ShadowShardData;
            _shadowShardEditor ??= new ShadowShardEditor();
            if (_shadowShardData == null)
            {
                EditorGUILayout.HelpBox("Test data is not set!", MessageType.Error);
                return;
            }

            _shadowShardEditor.DrawVertical(_shadowShardData.Styles, () => { });
            _shadowShardEditor.DrawIndented(_shadowShardData.IndentLevel, () => { });
            _shadowShardEditor.DrawDisabled(_shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawIndentedDisabled(_shadowShardData.IndentLevel, _shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(() => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.Label, _shadowShardData.IsDisabled, () => { });
            _shadowShardEditor.DrawGroup(_shadowShardData.Label, () => { });
            _shadowShardData.SliderValue = _shadowShardEditor.DrawSlider(new GUIContent("Slider"), null, new FloatRange(0, 1), _shadowShardData.IndentLevel);
            _shadowShardData.IntSliderValue = _shadowShardEditor.DrawIntSlider(new GUIContent("Int Slider"), null, new IntRange(0, 10), _shadowShardData.IndentLevel);
            _shadowShardEditor.DrawFromVector3ParamSlider(new GUIContent("Vector3 Slider"), null, Vector3Param.X, new FloatRange(0, 1), _shadowShardData.IndentLevel);
            _shadowShardEditor.DrawVector3Sliders(new GUIContent("X"), new GUIContent("Y"), new GUIContent("Z"), null, new FloatRange(0, 1), _shadowShardData.IndentLevel);
            _shadowShardData.FloatRangeValue = _shadowShardEditor.DrawMinMaxSlider(new GUIContent("Min Max Slider"), null, null, new FloatRange(0, 1), _shadowShardData.IndentLevel);
            _shadowShardData.FloatRangeValue = _shadowShardEditor.DrawMinMaxVector4StartSlider(new GUIContent("Vector4 Start Slider"), null, new FloatRange(0, 1), _shadowShardData.IndentLevel);
            _shadowShardData.FloatRangeValue = _shadowShardEditor.DrawMinMaxVector4EndSlider(new GUIContent("Vector4 End Slider"), null, new FloatRange(0, 1), _shadowShardData.IndentLevel);
        }
    }
}