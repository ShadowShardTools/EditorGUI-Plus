using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class ObjectEditor
    {
        private readonly GroupEditor _groupEditor;

        internal ObjectEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        internal Object DrawObjectField(GUIContent label, Object objectProperty, int indentLevel = 0,
            bool allowSceneObjects = true, Action<Object> onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return objectProperty;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                Object newValue = EditorGUILayout.ObjectField(label, objectProperty,
                    typeof(Object), allowSceneObjects: allowSceneObjects);

                if(EditorGUI.EndChangeCheck())
                {
                    objectProperty = newValue;
                    onChangedCallback?.Invoke(newValue);
                }
            }
        }
    }
}