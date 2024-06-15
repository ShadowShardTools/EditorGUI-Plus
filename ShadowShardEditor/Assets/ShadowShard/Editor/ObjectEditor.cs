using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShadowShard.Editor
{
    public class ObjectEditor
    {
        private readonly GroupEditor _groupEditor;

        public ObjectEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        public void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<TObject> onChangedCallback = null)
            where TObject : Object
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                TObject newValue = EditorGUILayout.ObjectField(label, (TObject)property.objectReferenceValue,
                    typeof(TObject), allowSceneObjects: allowSceneObjects) as TObject;
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    property.objectReferenceValue = newValue;
                    property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke(newValue);
                }
            }
        }
    }
}