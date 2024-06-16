using ShadowShard.Editor;
using UnityEditor;

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
        }
    }
}