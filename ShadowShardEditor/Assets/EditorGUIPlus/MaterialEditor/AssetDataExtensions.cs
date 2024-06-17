using System;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor
{
    public static class AssetDataExtensions
    {
        public static string ToGuid(this Vector4 vector)
        {
            byte[] bytes = new byte[16];

            BitConverter.GetBytes(vector.x).CopyTo(bytes, 0);
            BitConverter.GetBytes(vector.y).CopyTo(bytes, 4);
            BitConverter.GetBytes(vector.z).CopyTo(bytes, 8);
            BitConverter.GetBytes(vector.w).CopyTo(bytes, 12);

            return new Guid(bytes).ToString("N"); // Specify "N" format for hyphen-less GUID string
        }
    
        public static Vector4 ToVector4(this string guid)
        {
            byte[] guidBytes = Guid.ParseExact(guid, "N").ToByteArray(); // Parse the GUID without hyphens

            float x = BitConverter.ToSingle(guidBytes, 0);
            float y = BitConverter.ToSingle(guidBytes, 4);
            float z = BitConverter.ToSingle(guidBytes, 8);
            float w = BitConverter.ToSingle(guidBytes, 12);

            return new Vector4(x, y, z, w);
        }
        
        public static float AsFloat(this uint value)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        }
    }
}