using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    public class CurvePropertyEditor
    {
        private readonly GroupEditor _groupEditor;

        internal CurvePropertyEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal AnimationCurve DrawAnimationCurve(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.animationCurveValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                AnimationCurve newValue = EditorGUILayout.CurveField(label, property.animationCurveValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.animationCurveValue = newValue;
                    if (applyModifiedProperties)
                        property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}