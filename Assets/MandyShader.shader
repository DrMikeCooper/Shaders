Shader "Unlit/MandyShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_OriginX("OriginX", float) = 0.5
		_OriginY("OriginY", float) = 0.5
		_Scale("Scale", float) = 3
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
			// make fog work
			#pragma multi_compile_fog
			
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

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _OriginX;
			float _OriginY;
			float _Scale;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				int count = 0;
				float x0 = 0;
				float y0 = 0;
				float2 UV0 = float2((i.uv.x - _OriginX)*_Scale, (i.uv.y -_OriginY) * _Scale);
				while (count <20 && (x0*x0 + y0*y0 < 4))
				{
					float xtemp = x0*x0 - y0*y0 + UV0.x;
					y0 = 2 * x0*y0 + UV0.y;
					x0 = xtemp;
					count++;
				}
				count = 20 - count;

				//vec3 MaterialDiffuseColor = vec3(0.33f * (count&3), 0.08f*(count&12), count*0.05); 
				fixed4 col = fixed4(0.02 * count, 0.025*(20+count), 0.015*(20+count), 1);
				// sample the texture
				//fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);				
				return col;
			}
			ENDCG
		}
	}
}
