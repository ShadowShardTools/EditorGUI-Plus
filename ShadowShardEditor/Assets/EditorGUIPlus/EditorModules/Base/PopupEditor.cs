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
        
        internal TEnum DrawEnumPopup<TEnum>(ref TEnum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));
            
            return DrawEnumPopup(label, ref enumProperty, indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawEnumPopup<TEnum>(GUIContent label, ref TEnum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            int enumOption = DrawPopup(label, ref enumProperty, Enum.GetNames(enumType), indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawEnumFlagsField<TEnum>(GUIContent label, ref TEnum enumProperty, bool includeObsolete = false,
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            TEnum tempEnum = enumProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            enumProperty = tempEnum;
            
            return enumProperty;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                TEnum newValue = (TEnum)EditorGUILayout.EnumFlagsField(label, tempEnum, includeObsolete);

                if (EditorGUI.EndChangeCheck())
                {
                    tempEnum = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal TEnum DrawBooleanPopup<TEnum>(ref Enum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawBooleanPopup<TEnum>(label, ref enumProperty, indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawBooleanPopup<TEnum>(GUIContent label, ref Enum enumProperty, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            int enumOption = DrawBooleanPopup(label, ref enumProperty, Enum.GetNames(enumType), 
                indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(Material material, ref Enum enumProperty,
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawShaderLocalKeywordBooleanPopup<TEnum>(label, material, ref enumProperty, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(GUIContent label, Material material, 
            ref Enum enumProperty, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawShaderLocalKeywordBooleanPopup(label, material, ref enumProperty, 
                Enum.GetNames(enumType), shaderGlobalKeyword, indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(ref Enum enumProperty, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawShaderGlobalKeywordBooleanPopup<TEnum>(label, ref enumProperty, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        }
        
        internal TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, ref Enum enumProperty, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawShaderGlobalKeywordBooleanPopup(label, ref enumProperty, 
                Enum.GetNames(enumType), shaderGlobalKeyword, indentLevel, onChangedCallback);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal int DrawPopup<TEnum>(GUIContent label, ref TEnum enumProperty, string[] displayedOptions, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum
        {
            TEnum tempEnum = enumProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            enumProperty = tempEnum;
            
            return Convert.ToInt32(enumProperty);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                int propertyValue = Convert.ToInt32(tempEnum);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    tempEnum = (TEnum)Enum.ToObject(tempEnum.GetType(), newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawBooleanPopup<TEnum>(GUIContent label, ref TEnum enumProperty, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;
            
            TEnum tempEnum = enumProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            enumProperty = tempEnum;
            
            return Convert.ToInt32(enumProperty);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                int propertyValue = Convert.ToInt32(tempEnum);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    tempEnum = (TEnum)Enum.ToObject(tempEnum.GetType(), newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawShaderLocalKeywordBooleanPopup<TEnum>(GUIContent label, Material material, ref TEnum enumProperty, 
            string[] displayedOptions, string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;
            
            TEnum tempEnum = enumProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            enumProperty = tempEnum;
            
            return Convert.ToInt32(enumProperty);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                int propertyValue = Convert.ToInt32(tempEnum);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
            
                if (EditorGUI.EndChangeCheck())
                {
                    tempEnum = (TEnum)Enum.ToObject(tempEnum.GetType(), newValue);
                    KeywordsService.SetKeyword(material, shaderLocalKeyword, newValue > 0);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, ref TEnum enumProperty, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;

            TEnum tempEnum = enumProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            enumProperty = tempEnum;
            
            return Convert.ToInt32(enumProperty);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                int propertyValue = Convert.ToInt32(tempEnum);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
            
                if (EditorGUI.EndChangeCheck())
                {
                    tempEnum = (TEnum)Enum.ToObject(tempEnum.GetType(), newValue);
                    KeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue > 0);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawTagField(GUIContent label, ref string tag, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            string tempTag = tag;
            _groupEditor.DrawIndented(indentLevel, Draw);
            tag = tempTag;
            
            return tag;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string newValue = EditorGUILayout.TagField(label, tempTag);

                if (EditorGUI.EndChangeCheck())
                {
                    tempTag = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawLayerField(GUIContent label, ref int layer, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            int tempLayer = layer;
            _groupEditor.DrawIndented(indentLevel, Draw);
            layer = tempLayer;
            
            return layer;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = EditorGUILayout.LayerField(label, tempLayer);

                if (EditorGUI.EndChangeCheck())
                {
                    tempLayer = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal int DrawMaskField(GUIContent label, ref int mask, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            int tempMask = mask;
            _groupEditor.DrawIndented(indentLevel, Draw);
            mask = tempMask;
            
            return mask;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = EditorGUILayout.MaskField(label, tempMask, displayedOptions);

                if (EditorGUI.EndChangeCheck())
                {
                    tempMask = newValue;
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