// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Outline/Unlit Colored"
{
	Properties {
	// shader properties
		_Color ("Color", Color) = (1,1,1,1) // main color
		_Outline ("outline strength", Range(0.0,0.25)) = 0.01 // outline strength
		_OutlineColor ("Outline color", Color) = (0,0,0,0) // outline color
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 100 // small LOD Low poly art.

		Pass {
		// outline pass
			Cull Front // cull front, only need black backface.

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata { // model data struct.
				float4 vertex : POSITION;
				float4 normal : NORMAL;
			};

			struct v2f { // model render data struct.
				float4 vertex : SV_POSITION;
			};

       		//standard properties
	        fixed _Outline;
	        fixed4 _OutlineColor;
			
			v2f vert (appdata v) { 
			//vertex calculations
	        	float3 norm = normalize(v.normal);
	        	v.vertex.xyz *= (1 + _Outline); // multiply vertex positions with outline strength

				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex); // multiply view and projection matrix 
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target {
				return _OutlineColor; // return given outline color.
			}
			ENDCG
		}

		Pass {
		// model color pass
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			
			#include "UnityCG.cginc"

			struct appdata { // model data struct
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
			};

       		//standard properties
			fixed4 _Color;
			
			v2f vert (appdata v) {
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex); // multiply view and projection matrix 
				return o;
			}
			
			fixed4 frag (v2f i) : COLOR {
				return _Color;
			}
			ENDCG
		}
	}
}
