using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.AssetObject;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
public class ObjectTestSection : MaterialSection
{
    private Material _material;
    protected Property TestProfileAsset = new("_TestProfileAsset");
    protected Property TestProfileHash = new("_TestProfileHash");
    private readonly GUIContent _label = new("Test");
    public ObjectTestSection(Material material) : base(new GUIContent("Test Label"))
    {
        _material = material;
    }
    public override void FindProperties(MaterialProperty[] properties)
    {
        TestProfileAsset.Find(properties);
        TestProfileHash.Find(properties);
    }
    public override void DrawProperties(MaterialEditorGUIPlus editor)
    {
        editor.DrawMaterialAssetObject(_material, TestProfileAsset.MaterialProperty, TestProfileHash.MaterialProperty, DrawTestProfile, 1);
        return;
        MaterialAssetObject DrawTestProfile()
        {
            string guid = TestProfileAsset.MaterialProperty.vectorValue.ToGuid();
            TestProfile assetObject = editor.GetMaterialAssetObjectFromGuid<TestProfile>(guid);
            
            return EditorGUILayout.ObjectField(_label, assetObject, 
                typeof(TestProfile), allowSceneObjects: false) as TestProfile;
        }
    }
    public override void SetKeywords(Material material)
    {
    }
}
}