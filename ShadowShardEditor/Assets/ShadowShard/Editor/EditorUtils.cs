using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class EditorUtils
    {
        public Rect GetRect(MaterialProperty prop) => 
            EditorGUILayout.GetControlRect(true, MaterialEditor.GetDefaultPropertyHeight(prop), EditorStyles.layerMaskField);
    }
}