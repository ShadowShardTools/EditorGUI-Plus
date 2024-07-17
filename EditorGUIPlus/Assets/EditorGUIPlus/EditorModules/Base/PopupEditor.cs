using System;
using EditorGUIPlus.MaterialEditor;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class PopupEditor
    {
        private const string BooleanDisplayedOptionsError = "The displayedOptions array should contain exactly two options.";

        private readonly GroupEditor _groupEditor;

        internal PopupEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal TEnum DrawEnumPopup<TEnum>(TEnum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new GUIContent(ObjectNames.NicifyVariableName(enumType.Name));
            
            return DrawEnumPopup(label, enumProperty, indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawEnumPopup<TEnum>(GUIContent label, TEnum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            int enumOption = DrawPopup(label, enumProperty, Enum.GetNames(enumType), indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }

        internal TEnum DrawEnumFlagsField<TEnum>(GUIContent label, TEnum enumProperty, bool includeObsolete = false,
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return enumProperty;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                TEnum newValue = (TEnum)EditorGUILayout.EnumFlagsField(label, enumProperty, includeObsolete);

                if (EditorGUI.EndChangeCheck())
                {
                    enumProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal TEnum DrawBooleanPopup<TEnum>(TEnum enumProperty, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new GUIContent(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawBooleanPopup(label, enumProperty, indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawBooleanPopup<TEnum>(GUIContent label, TEnum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            int enumOption = DrawBooleanPopup(label, enumProperty, Enum.GetNames(enumType), 
                indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(Material material, Enum enumProperty,
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new GUIContent(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawShaderLocalKeywordBooleanPopup<TEnum>(label, material, enumProperty, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(GUIContent label, Material material, 
            Enum enumProperty, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawShaderLocalKeywordBooleanPopup(label, material, enumProperty, 
                Enum.GetNames(enumType), shaderGlobalKeyword, indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(TEnum enumProperty, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new GUIContent(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawShaderGlobalKeywordBooleanPopup(label, enumProperty, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, TEnum enumProperty, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawShaderGlobalKeywordBooleanPopup(label, enumProperty, 
                Enum.GetNames(enumType), shaderGlobalKeyword, indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal int DrawPopup<TEnum>(GUIContent label, TEnum enumProperty, string[] displayedOptions, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return Convert.ToInt32(enumProperty);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                int propertyValue = Convert.ToInt32(enumProperty);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    enumProperty = (TEnum)Enum.ToObject(enumProperty.GetType(), newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }

        private int DrawPopup(GUIContent label, SerializedProperty enumProperty, string[] displayedOptions, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return enumProperty.enumValueIndex;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                int newValue = EditorGUILayout.Popup(label, enumProperty.enumValueIndex, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    enumProperty.enumValueIndex = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawBooleanPopup<TEnum>(GUIContent label, TEnum enumProperty, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return Convert.ToInt32(enumProperty);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                int propertyValue = Convert.ToInt32(enumProperty);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    enumProperty = (TEnum)Enum.ToObject(enumProperty.GetType(), newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawShaderLocalKeywordBooleanPopup<TEnum>(GUIContent label, Material material, TEnum enumProperty, 
            string[] displayedOptions, string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return Convert.ToInt32(enumProperty);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                int propertyValue = Convert.ToInt32(enumProperty);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
            
                if (EditorGUI.EndChangeCheck())
                {
                    enumProperty = (TEnum)Enum.ToObject(enumProperty.GetType(), newValue);
                    KeywordsService.SetKeyword(material, shaderLocalKeyword, newValue > 0);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, TEnum enumProperty, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;

            _groupEditor.DrawIndented(indentLevel, Draw);
            return Convert.ToInt32(enumProperty);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                int propertyValue = Convert.ToInt32(enumProperty);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
            
                if (EditorGUI.EndChangeCheck())
                {
                    enumProperty = (TEnum)Enum.ToObject(enumProperty.GetType(), newValue);
                    KeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue > 0);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawTagField(GUIContent label, string tag, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return tag;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string newValue = EditorGUILayout.TagField(label, tag);

                if (EditorGUI.EndChangeCheck())
                {
                    tag = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawLayerField(GUIContent label, int layer, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return layer;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = EditorGUILayout.LayerField(label, layer);

                if (EditorGUI.EndChangeCheck())
                {
                    layer = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawMaskField(GUIContent label, int mask, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return mask;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = EditorGUILayout.MaskField(label, mask, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    mask = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal bool IsDisplayedBooleanErrorMessage(string[] displayedOptions)
        {
            if (displayedOptions.Length == 2) 
                return true;
            
            EditorGUILayout.HelpBox(BooleanDisplayedOptionsError, MessageType.Error);
            return false;
        }
    }
}