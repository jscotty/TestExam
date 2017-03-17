// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Outline/Unlit Textured outlined"
{
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	_Outline("outline strength", Range(0.0,0.25)) = 0.01
		_OutlineColor("Outline color", Color) = (0,0,0,0)
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		Pass{
		Cull Front

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata {
		float4 vertex : POSITION;
		float4 normal : NORMAL;
	};

	struct v2f {
		float4 vertex : SV_POSITION;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;
	fixed _Outline;
	fixed4 _OutlineColor;

	v2f vert(appdata v) {
		float3 norm = normalize(v.normal);
		v.vertex.xyz += norm * _Outline;

		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target{
		return _OutlineColor;
	}
		ENDCG
	}

		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata {
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f {
		float2 uv : TEXCOORD0;
		float4 vertex : SV_POSITION;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;

	v2f vert(appdata v) {

		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target{
		fixed4 col = tex2D(_MainTex, i.uv);
	return col;
	}
		ENDCG
	}
		Pass{
		Blend One One
		Tags{ "LightMode" = "ForwardAdd" }
		CGPROGRAM
#pragma vertex vert 
#pragma fragment frag 
#include "UnityCG.cginc" 
#pragma multi_compile_fwdadd_fullshadows 
#include "AutoLight.cginc" 
		sampler2D _MainTex;
	float4 _MainTex_ST;

	struct v2f {
		float4 pos : SV_POSITION;
		LIGHTING_COORDS(0,1)
			float2 uv : TEXCOORD2;
	};

	v2f vert(appdata_base v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
		TRANSFER_VERTEX_TO_FRAGMENT(o);
		return o;
	}

	fixed4 frag(v2f i) : COLOR
	{
		float attenuation = LIGHT_ATTENUATION(i);
	return tex2D(_MainTex, i.uv) * attenuation;
	}
		ENDCG
	}
	}
		Fallback "VertexLit"
}