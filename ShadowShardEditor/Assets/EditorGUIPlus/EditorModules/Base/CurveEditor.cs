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
        
        internal AnimationCurve DrawAnimationCurve(GUIContent label, ref AnimationCurve curve, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            AnimationCurve tempCurve = curve;
            _groupEditor.DrawIndented(indentLevel, Draw);
            curve = tempCurve;
            
            return curve;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                AnimationCurve newValue = EditorGUILayout.CurveField(label, tempCurve);

                if (EditorGUI.EndChangeCheck())
                {
                    tempCurve = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}