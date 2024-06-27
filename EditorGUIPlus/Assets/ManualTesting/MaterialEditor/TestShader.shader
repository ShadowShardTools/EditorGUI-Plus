Shader "Unlit/TestShader"
{
    Properties
    {
        _BaseMap ("Base Map", 2D) = "white" {}
        _Color ("Main Color", Color) = (1, 1, 1, 1)
        _FloatValue ("Float Value", Range(0, 1)) = 0.5
        _FloatMinValue ("Float Value", Range(0, 1)) = 0.5
        _FloatMaxValue ("Float Value", Range(0, 1)) = 0.5
        _IntValue ("Int Value", Range(0, 10)) = 5
        _VectorValue ("Vector Value", Vector) = (0, 0, 0, 0)
        _ToggleValue ("Toggle Value", Float) = 0
        _EnumValue ("Enum Value", Float) = 0
        _ShaderKeywordToggle ("Shader Keyword Toggle", Float) = 0
        _NormalScale("NormalScale", Range(0.0, 8.0)) = 1
        
        [HideInInspector] _TestProfile("Obsolete, kept for migration purpose", Int) = 0
        [HideInInspector] _TestProfileAsset("Profile Asset", Vector) = (0, 0, 0, 0)
        [HideInInspector] _TestProfileHash("Profile Hash", Float) = 0
        
        _TestFloatValue("Profile Float Value", Float) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            //#pragma shader_feature_local_fragment _TEST_KEYWORD
            #pragma multi_compile _ _TEST_KEYWORD

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _BaseMap;
            float4 _Color;
            float _FloatValue;
            float4 _VectorValue;
            float _ToggleValue;
            float _TestFloatValue;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 col = tex2D(_BaseMap, i.uv) * _Color;
                half4 fin = col * _FloatValue + _VectorValue;
                
                if(_ToggleValue > 0.5f)
                    fin += 1;

                /*#ifdef _TEST_KEYWORD
                    return half4(1.0, 1.0, 1.0, 1.0);
                #else
                    return fin;
                #endif*/
                
                return _TestFloatValue;
            }
            ENDCG
        }
    }
        
    CustomEditor "ManualTesting.MaterialEditor.TestMaterialGUI"
}