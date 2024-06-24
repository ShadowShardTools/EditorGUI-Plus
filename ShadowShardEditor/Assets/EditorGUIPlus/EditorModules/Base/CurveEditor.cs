using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    public class CurveEditor
    {
        private readonly GroupEditor _groupEditor;

        internal CurveEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal AnimationCurve DrawAnimationCurve(GUIContent label, AnimationCurve curve, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return curve;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                AnimationCurve newValue = EditorGUILayout.CurveField(label, curve);

                if (EditorGUI.EndChangeCheck())
                {
                    curve = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}