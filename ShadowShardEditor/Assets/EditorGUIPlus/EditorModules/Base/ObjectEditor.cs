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
        
        internal Object DrawObjectField(GUIContent label, ref Object objectProperty, int indentLevel = 0,
            bool allowSceneObjects = true, Action<Object> onChangedCallback = null)
        {
            Object localObjectProperty = objectProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!objectProperty.Equals(localObjectProperty)) 
                objectProperty = localObjectProperty;
            
            return objectProperty;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                Object newValue = EditorGUILayout.ObjectField(label, localObjectProperty,
                    typeof(Object), allowSceneObjects: allowSceneObjects);

                if(EditorGUI.EndChangeCheck())
                {
                    localObjectProperty = newValue;
                    onChangedCallback?.Invoke(newValue);
                }
            }
        }
    }
}