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
