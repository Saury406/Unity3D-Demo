Shader "linxinfa/BoxWorld"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        // 屏幕高与宽的比值，默认是720/1280，即0.5625
        _ScreenHW ("ScreenHW", Float) = 0.5625
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float _ScreenHW;


            v2f vert (appdata v)
            {
                v2f o;
                // 把顶点坐标从局部坐标转化到齐次裁剪空间
                o.vertex = UnityObjectToClipPos(v.vertex);
                // 计算屏幕坐标，注意这时的坐标是齐次空间下的屏幕坐标
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 去齐次
                float2 screenPos = i.screenPos.xy / i.screenPos.w;
                // 根据屏幕坐标来算uv
                float2 uv = screenPos.xy * float2(1, _ScreenHW);
                // 采样
                float4 col = tex2D(_MainTex, uv);
                return col;
            }
            ENDCG
        }
    }
}
