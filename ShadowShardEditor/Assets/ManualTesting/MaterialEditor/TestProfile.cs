using EditorGUIPlus.MaterialEditor.AssetObject;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    [CreateAssetMenu(fileName = "Test Profile", menuName = "Test Profile")]
    public class TestProfile : MaterialAssetObject
    {
        public float testFloatValue;
        private static readonly int TestFloatValue = Shader.PropertyToID("_TestFloatValue");

        public override void SetMaterialAssetObject(Material material)
        {
            if (material.HasProperty(TestFloatValue))
                material.SetFloat(TestFloatValue, testFloatValue);
        }

        public override void ResetToDefault()
        {
            testFloatValue = 1.0f;
            
            base.ResetToDefault();
        }
    }
}