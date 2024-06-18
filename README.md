![EditorGUIPlus Header Image](Documentation/Images/EditorGUIPlusMainHeader.png)

![GitHub](https://img.shields.io/github/v/release/ShadowShardTools/EditorGUI-Plus)
![GitHub](https://img.shields.io/github/license/ShadowShardTools/EditorGUI-Plus?style=plastic&label=License&link=https%3A%2F%2Fgithub.com%2FShadowShardTools%2FEditorGUI-Plus%2Fblob%2Fmain%2FLICENSE)
![GitHub](https://img.shields.io/github/last-commit/ShadowShardTools/EditorGUI-Plus)

# EditorGUI+: simple editor wrapper

## EditorGUI+ Features

* Group Editing - Easily manage and organize GUI elements in groups.
* Sliders - Create float and integer sliders with custom ranges.
* Toggles - Add boolean toggles and shader global keyword toggles.
* Vectors - Draw vector fields for Vector2, Vector2Int, Vector3, Vector3Int, and Vector4 with custom ranges.
* Textures - Draw texture fields.
* Popups - Create dropdown menus for enum values and boolean choices.
* Objects - Manage object fields.
* Text - Handle text fields.
* Curves - Draw and edit animation curves.

## MaterialEditorGUI+ Features

* Group Editing - Easily manage and organize GUI elements in groups.
* Sliders - Create float and integer sliders with custom ranges.
* Toggles - Add boolean toggles and shader global keyword toggles.
* Vectors - Draw vector fields for Vector2, Vector2Int, Vector3, Vector3Int, and Vector4 with custom ranges.
* Textures - Draw texture fields.
* Popups - Create dropdown menus for enum values and boolean choices.
* Objects - Manage scriptable object fields.

## Using EditorGUI+
### Initializing EditorGUI+
To use EditorGUI+ in your custom editor scripts, you need to create an instance of the EditorGUIPlus class:

```csharp
using EditorGUIPlus;

public class CustomEditorScript : Editor
{
    private EditorGUIPlus _editorGUIPlus;

    private void OnEnable()
    {
        _editorGUIPlus = new EditorGUIPlus();
    }

    public override void OnInspectorGUI()
    {
        // Use _editorGUIPlus to draw your custom GUI elements
    }
}
```
### Group Editor
Group editors help you organize your GUI elements in a structured manner.
You can use two way of drawing groups: **Scopes** or **Methods with actions**.

#### Scopes method
Using statement will put the rest of method into the group defined by the scope.
```csharp
private void DrawVerticalScope()
{
    using var scope = _shadowShardEditor.VerticalScope();
    GUILayout.Label("This is a vertical scope");
    GUILayout.Label("All of this content is vertical");
}
```

#### Methods With actions
You may invoke method and pass your content throug a lambda.

```csharp
Vector2 scrollPosition = Vector2.zero;

_editorGUIPlus.ScrollView(() =>
{
    _editorGUIPlus.DrawGroup(() =>
    {
        // Draw your GUI elements here
    });
}, ref scrollPosition);
```

Another way is to create a named method and pass a reference.

```csharp
Vector2 scrollPosition = Vector2.zero;

_editorGUIPlus.ScrollView(YourMethodName, ref scrollPosition);
```

### Sliders
Draw sliders for float and integer properties with custom ranges.

```csharp
SerializedProperty floatProperty = serializedObject.FindProperty("floatField");
SerializedProperty intProperty = serializedObject.FindProperty("intField");

_editorGUIPlus.DrawSlider(new GUIContent("Float Slider"), floatProperty, new FloatRange(0f, 1f));
_editorGUIPlus.DrawIntSlider(new GUIContent("Int Slider"), intProperty, new IntRange(0, 10));
```

### Toggles
Add boolean toggles to your editor interface.

```csharp
SerializedProperty toggleProperty = serializedObject.FindProperty("toggleField");

_editorGUIPlus.DrawToggle(new GUIContent("Toggle"), toggleProperty);
```

### Vectors
Draw vector fields for Vector2, Vector3, and Vector4 properties.

```csharp
SerializedProperty vector3Property = serializedObject.FindProperty("vector3Field");

_editorGUIPlus.DrawVector3(new GUIContent("Vector3 Field"), vector3Property, new Vector3Range(Vector3.zero, Vector3.one));
```

### Textures
Handle texture fields in your custom editor.

```csharp
SerializedProperty textureProperty = serializedObject.FindProperty("textureField");

_editorGUIPlus.DrawTexture(new GUIContent("Texture Field"), textureProperty);
```

### Popups
Create dropdown menus for enum values and boolean choices.

```csharp
SerializedProperty enumProperty = serializedObject.FindProperty("enumField");

_editorGUIPlus.DrawEnumPopup<YourEnumType>(new GUIContent("Enum Popup"), enumProperty);
```

### Objects
Manage object fields in your custom editor.

```csharp
SerializedProperty objectProperty = serializedObject.FindProperty("objectField");

_editorGUIPlus.DrawObjectField(new GUIContent("Object Field"), objectProperty, typeof(Object));
```

### Text
Handle text fields in your custom editor.

```csharp
SerializedProperty textProperty = serializedObject.FindProperty("textField");

_editorGUIPlus.DrawTextField(new GUIContent("Text Field"), textProperty);
```

### Curves
Draw and edit animation curves in your custom editor.

```csharp
SerializedProperty curveProperty = serializedObject.FindProperty("curveField");

_editorGUIPlus.DrawCurveField(new GUIContent("Curve Field"), curveProperty);
```

## Using MaterialEditorGUI+
### Initializing MaterialEditorGUI+
To use MaterialEditorGUI+ in your own material editor scripts, you need to create an instance of the MaterialEditorGUIPlus class or use BaseShaderGUI from EditorGUI+.
To do this in your own material editor scripts, initialize it in the base class:

```csharp
public class BaseShaderGUI : UnityEditor.ShaderGUI
{
    private readonly MaterialEditorGUIPlus _materialEditorGUIPlus = new();
    .....
    public override void OnGUI(UnityEditor.MaterialEditor materialEditorIn, MaterialProperty[] properties)
    {
        if (materialEditorIn == null)
            throw new ArgumentNullException(nameof(materialEditorIn));
            
        _materialEditor = materialEditorIn;
        _materialEditorGUIPlus.InitializeMaterialEditor(_materialEditor);
        Material material = _materialEditor != null ? _materialEditor.target as Material : null;
            
        if (material == null)
            return;
    }
}
```

### MaterialEditorGUI+ BaseShaderGUI

```csharp
using EditorGUIPlus.MaterialEditor.ShaderGUI;

public class ExampleMaterialGUI : BaseShaderGUI
{
    public override void OnOpenGUI(Material material)
    {
        Sections = new List<MaterialSection>(SetSections(material));
    }

    public override IEnumerable<MaterialSection> SetSections(Material material)
    {
        return new List<MaterialSection>
        {
            new Example1Section(),
            new Example2Section(material)
            new Example3Section(material)
        };
    }
}
```

### MaterialSection in MaterialEditorGUI+

```csharp
public class Example2Section : MaterialSection
{
    private Material _material;
    protected Property TestProperty = new("_TestProfileAsset");
    private readonly GUIContent _label = new("Test");

    public Example2Section(Material material) : base(new GUIContent("Test Label"))
    {
        _material = material;
    }

    public override void FindProperties(MaterialProperty[] properties)
    {
        TestProperty.Find(properties);
    }

    public override void DrawProperties(MaterialEditorGUIPlus editor)
    {
        ...Draw TestProperty
    }
    public override void SetKeywords(Material material)
    {
        ...Keywords logic
    }
}
```

### Sliders
Draw sliders for float and integer properties with custom ranges.

```csharp
MaterialProperty floatProperty = FindProperty("_FloatField", properties);
MaterialProperty intProperty = FindProperty("_IntField", properties);

_materialEditorGUIPlus.DrawSlider(new GUIContent("Float Slider"), floatProperty, new FloatRange(0f, 1f));
_materialEditorGUIPlus.DrawIntSlider(new GUIContent("Int Slider"), intProperty, new IntRange(0, 10));
```

### Toggles
Add boolean toggles to your editor interface.

```csharp
MaterialProperty toggleProperty = FindProperty("_ToggleField", properties);

_materialEditorGUIPlus.DrawToggle(new GUIContent("Toggle"), toggleProperty);
```

### Vectors
Draw vector fields for Vector2, Vector3, and Vector4 properties.

```csharp
MaterialProperty vector3Property = FindProperty("_Vector3Field", properties);

_materialEditorGUIPlus.DrawVector3(new GUIContent("Vector3 Field"), vector3Property, new Vector3Range(Vector3.zero, Vector3.one));
```

### Textures
Handle texture fields in your custom editor.

```csharp
MaterialProperty textureProperty = FindProperty("_TextureField", properties);

_materialEditorGUIPlus.DrawSingleLineTexture(new GUIContent("Texture Field"), textureProperty);
```

### Popups
Create dropdown menus for selecting from predefined options.

```csharp
MaterialProperty popupProperty = FindProperty("_PopupField", properties);
string[] options = new string[] { "Option1", "Option2", "Option3" };

_materialEditorGUIPlus.DrawPopup(new GUIContent("Popup Field"), popupProperty, options);
```

### Objects
Manage scriptable object fields in your custom editor.

```csharp
MaterialProperty ExampleProfileAsset = FindProperty("_ExampleProfileAsset", properties);
MaterialProperty ExampleProfileHash = FindProperty("_ExampleProfileHash", properties);

_materialEditorGUIPlus.DrawMaterialAssetObject(_material, ExampleProfileAsset.MaterialProperty, ExampleProfileHash.MaterialProperty, DrawExampleProfile, 1);
return;

MaterialAssetObject DrawExampleProfile()
{
    string guid = ExampleProfileAsset.MaterialProperty.vectorValue.ToGuid();
    ExampleProfile assetObject = editor.GetMaterialAssetObjectFromGuid<ExampleProfile>(guid);
            
    return EditorGUILayout.ObjectField(_label, assetObject, 
        typeof(ExampleProfile), allowSceneObjects: false) as ExampleProfile;
}
```

## EditorGUI+ API Reference
### Group Editor

```csharp
ScrollView(Action drawCall, ref Vector2 scrollPosition, params GUILayoutOption[] options)

DrawVertical(GUIStyle styles, Action drawCall)

DrawIndented(int indentLevel, Action drawCall)

DrawDisabled(bool isDisabled, Action drawCall)

DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall)

DrawGroup(bool isDisabled, Action drawCall)

DrawGroup(Action drawCall)

DrawGroup(GUIContent label, bool isDisabled, Action drawCall)

DrawGroup(GUIContent label, Action drawCall)
```

### Slider Editor

```csharp
DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

### Slider Int Editor

```csharp
DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

### Toggle Editor

```csharp
DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)

DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)
```

### Vector Editor

```csharp
DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3(GUIContent label, SerializedProperty property, Vector3Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4(GUIContent label, SerializedProperty property, Vector4Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4Start(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4End(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4End(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector4(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector2(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector3(GUIContent label, SerializedProperty property, Vector3 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector4(GUIContent label, SerializedProperty property, Vector4 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector4Start(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0, Action onChangedCallback = null)
```

### Vector Int Editor

```csharp
DrawInt(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2Int(GUIContent label, SerializedProperty property, Vector2IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Int(GUIContent label, SerializedProperty property, Vector3IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawInt(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedInt(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null)

DrawMinInt(GUIContent label, SerializedProperty property, int min = 0, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector2Int(GUIContent label, SerializedProperty property, Vector2Int min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector3Int(GUIContent label, SerializedProperty property, Vector3Int min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, int min = 0, int indentLevel = 0, Action onChangedCallback = null)

DrawMinIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, int min = 0, int indentLevel = 0, Action onChangedCallback = null)
```

### Texture Editor

```csharp
DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

### Popup Editor

```csharp
DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum

DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum

DrawBooleanPopup<TEnum>(SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum

DrawBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum

DrawShaderGlobalKeywordBooleanPopup<TEnum>(SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum

DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum

DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0, Action onChangedCallback = null)

DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0, Action onChangedCallback = null)

DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)
```

### Object Editor

```csharp
DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0, bool allowSceneObjects = true, Action<TObject> onChangedCallback = null) where TObject : Object
```

### Text Editor

```csharp
DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, int indentLevel = 0, Action onChangedCallback = null)
```

### Curve Editor

```csharp
DrawAnimationCurve(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

## MaterialEditorGUI+ API Reference
### Group Editor

```csharp
DrawVertical(GUIStyle styles, Action drawCall)

DrawIndented(int indentLevel, Action drawCall)

DrawDisabled(bool isDisabled, Action drawCall)

DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall)

DrawGroup(bool isDisabled, Action drawCall)

DrawGroup(Action drawCall)

DrawGroup(GUIContent label, bool isDisabled, Action drawCall)

DrawGroup(GUIContent label, Action drawCall)
```

### Slider Editor

```csharp
DrawSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3ParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3ParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

### Slider Int Editor

```csharp
DrawIntSlider(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawIntSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3IntParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFromVector3IntParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

### Toggle Editor

```csharp
DrawToggle(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawShaderLocalKeywordToggle(GUIContent label, Material material, MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)

DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)
```

### Vector Editor

```csharp
DrawFloat(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3(GUIContent label, MaterialProperty property, Vector3Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4(GUIContent label, MaterialProperty property, Vector4Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawFloat(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4Start(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4End(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, FloatRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloat(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector2(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector3(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector4(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloat(GUIContent label, MaterialProperty property, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector2(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector3(GUIContent label, MaterialProperty property, Vector3 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector4(GUIContent label, MaterialProperty property, Vector4 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector4Start(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawColor(GUIContent label, MaterialProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0, Action onChangedCallback = null)
```

### Vector Int Editor

```csharp
DrawInt(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2Int(GUIContent label, MaterialProperty property, Vector2IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Int(GUIContent label, MaterialProperty property, Vector3IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawInt(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, IntRange range, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedInt(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null)

DrawNormalizedIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null)

DrawMinInt(GUIContent label, MaterialProperty property, int min = 0, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector2Int(GUIContent label, MaterialProperty property, Vector2Int min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinVector3Int(GUIContent label, MaterialProperty property, Vector3Int min, int indentLevel = 0, Action onChangedCallback = null)

DrawMinIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, int min = 0, int indentLevel = 0, Action onChangedCallback = null)

DrawMinIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, int min = 0, int indentLevel = 0, Action onChangedCallback = null)
```

### Texture Editor

```csharp
DrawSingleLineTexture(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawSingleLineTextureWithScaleAndOffset(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)

DrawTextureScaleAndOffset(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null)
```

### Popup Editor

```csharp
DrawPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, int indentLevel = 0, Action onChangedCallback = null)

DrawShaderPropertyPopup(GUIContent label, MaterialProperty property, ShaderPropertyType shaderPropertyType, int indentLevel = 0, Action onChangedCallback = null)
```

### Object Editor

```csharp
DrawObjectField<T>(GUIContent label, MaterialProperty property, bool allowSceneObjects = true, int indentLevel = 0, Action onChangedCallback = null) where T : UnityEngine.Object
```
