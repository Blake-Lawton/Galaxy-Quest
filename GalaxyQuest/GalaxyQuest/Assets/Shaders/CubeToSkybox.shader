Shader "Custom/CubemapToSphere"
{
    Properties {
        _CubeMap("Skybox Cubemap", CUBE) = "" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            samplerCUBE _CubeMap;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target {
                float theta = i.uv.x * 2 * UNITY_PI;
                float phi = i.uv.y * UNITY_PI;

                float3 dir = float3(
                    sin(phi) * sin(theta),
                    cos(phi),
                    sin(phi) * cos(theta)
                );

                return texCUBE(_CubeMap, dir);
            }
            ENDCG
        }
    }
}