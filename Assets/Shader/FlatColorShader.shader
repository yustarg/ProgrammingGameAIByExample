Shader "Custom/FlatColorShader" {
	Properties {
		_MainColor ("Main Color", Color) = (1, 0, 0, 1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass {

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform fixed4 _MainColor;

			struct v2f {
				float4 pos : SV_POSITION;
				fixed4 color : COLOR0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = _MainColor;
				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				return i.color;
			}
		
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
