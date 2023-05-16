// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "StandardMask_2Layers"
{
	Properties
	{
		_MaskTexture("Mask Texture", 2D) = "white" {}
		_R_AlbedoColor("R_Albedo Color", Color) = (1,1,1,0)
		_R_Albedo("R_Albedo", 2D) = "white" {}
		_R_NormalMap("R_Normal Map", 2D) = "bump" {}
		_R_NormalIntensity("R_Normal  Intensity", Range( 0 , 10)) = 0
		_R_Occlusion("R_Occlusion", 2D) = "white" {}
		_R_OcclusionIntensity("R_Occlusion Intensity", Range( 0 , 1)) = 0
		_R_Metalic("R_Metalic", 2D) = "white" {}
		_R_MetalicIntensity("R_Metalic Intensity", Range( 0 , 1)) = 0
		_R_SmoothnessIntensity("R_Smoothness Intensity", Range( 0 , 1)) = 0
		_G_AlbedoColor("G_Albedo Color", Color) = (1,1,1,0)
		_G_Albedo("G_Albedo", 2D) = "white" {}
		_G_NormalMap("G_Normal Map", 2D) = "bump" {}
		_G_NormalIntensity("G_Normal  Intensity", Range( 0 , 10)) = 0
		_G_Occlusion("G_Occlusion", 2D) = "white" {}
		_G_OcclusionIntensity("G_Occlusion Intensity", Range( 0 , 1)) = 0
		_G_Metalic("G_Metalic", 2D) = "white" {}
		_G_MetalicIntensity("G_Metalic Intensity", Range( 0 , 1)) = 0
		_G_SmoothnessIntensity("G_Smoothness Intensity", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _MaskTexture;
		uniform float4 _MaskTexture_ST;
		uniform float _R_NormalIntensity;
		uniform sampler2D _R_NormalMap;
		uniform float4 _R_NormalMap_ST;
		uniform float _G_NormalIntensity;
		uniform sampler2D _G_NormalMap;
		uniform float4 _G_NormalMap_ST;
		uniform sampler2D _R_Albedo;
		uniform float4 _R_Albedo_ST;
		uniform float4 _R_AlbedoColor;
		uniform sampler2D _G_Albedo;
		uniform float4 _G_Albedo_ST;
		uniform float4 _G_AlbedoColor;
		uniform sampler2D _R_Metalic;
		uniform float4 _R_Metalic_ST;
		uniform float _R_MetalicIntensity;
		uniform sampler2D _G_Metalic;
		uniform float4 _G_Metalic_ST;
		uniform float _G_MetalicIntensity;
		uniform float _R_SmoothnessIntensity;
		uniform float _G_SmoothnessIntensity;
		uniform sampler2D _R_Occlusion;
		uniform float4 _R_Occlusion_ST;
		uniform float _R_OcclusionIntensity;
		uniform sampler2D _G_Occlusion;
		uniform float4 _G_Occlusion_ST;
		uniform float _G_OcclusionIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_MaskTexture = i.uv_texcoord * _MaskTexture_ST.xy + _MaskTexture_ST.zw;
			float4 tex2DNode17 = tex2D( _MaskTexture, uv_MaskTexture );
			float2 uv_R_NormalMap = i.uv_texcoord * _R_NormalMap_ST.xy + _R_NormalMap_ST.zw;
			float2 uv_G_NormalMap = i.uv_texcoord * _G_NormalMap_ST.xy + _G_NormalMap_ST.zw;
			o.Normal = ( ( tex2DNode17.r * UnpackScaleNormal( tex2D( _R_NormalMap, uv_R_NormalMap ) ,_R_NormalIntensity ) ) + ( tex2DNode17.g * UnpackScaleNormal( tex2D( _G_NormalMap, uv_G_NormalMap ) ,_G_NormalIntensity ) ) );
			float2 uv_R_Albedo = i.uv_texcoord * _R_Albedo_ST.xy + _R_Albedo_ST.zw;
			float2 uv_G_Albedo = i.uv_texcoord * _G_Albedo_ST.xy + _G_Albedo_ST.zw;
			o.Albedo = ( ( tex2DNode17.r * ( tex2D( _R_Albedo, uv_R_Albedo ) * _R_AlbedoColor ) ) + ( tex2DNode17.g * ( tex2D( _G_Albedo, uv_G_Albedo ) * _G_AlbedoColor ) ) ).rgb;
			float2 uv_R_Metalic = i.uv_texcoord * _R_Metalic_ST.xy + _R_Metalic_ST.zw;
			float4 tex2DNode11 = tex2D( _R_Metalic, uv_R_Metalic );
			float2 uv_G_Metalic = i.uv_texcoord * _G_Metalic_ST.xy + _G_Metalic_ST.zw;
			float4 tex2DNode5 = tex2D( _G_Metalic, uv_G_Metalic );
			o.Metallic = ( ( tex2DNode17.r * ( tex2DNode11 * _R_MetalicIntensity ) ) + ( tex2DNode17.g * ( tex2DNode5 * _G_MetalicIntensity ) ) ).r;
			o.Smoothness = ( ( tex2DNode17.r * ( tex2DNode11.a * _R_SmoothnessIntensity ) ) + ( tex2DNode17.g * ( tex2DNode5.a * _G_SmoothnessIntensity ) ) );
			float4 temp_cast_2 = (1.0).xxxx;
			float2 uv_R_Occlusion = i.uv_texcoord * _R_Occlusion_ST.xy + _R_Occlusion_ST.zw;
			float4 lerpResult25 = lerp( temp_cast_2 , tex2D( _R_Occlusion, uv_R_Occlusion ) , _R_OcclusionIntensity);
			float4 temp_cast_3 = (1.0).xxxx;
			float2 uv_G_Occlusion = i.uv_texcoord * _G_Occlusion_ST.xy + _G_Occlusion_ST.zw;
			float4 lerpResult22 = lerp( temp_cast_3 , tex2D( _G_Occlusion, uv_G_Occlusion ) , _G_OcclusionIntensity);
			o.Occlusion = ( ( tex2DNode17.r * lerpResult25 ) + ( tex2DNode17.g * lerpResult22 ) ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=15301
224;160;1711;1200;3259.343;1938.56;2.611049;True;True
Node;AmplifyShaderEditor.SamplerNode;3;-1347.723,-316.561;Float;True;Property;_R_Occlusion;R_Occlusion;5;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1;-1359.26,1029.253;Float;False;Property;_G_SmoothnessIntensity;G_Smoothness Intensity;18;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;5;-1375.601,728.2426;Float;True;Property;_G_Metalic;G_Metalic;16;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;14;-1369.364,1169.5;Float;True;Property;_G_Occlusion;G_Occlusion;14;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;11;-1360.626,-760.3248;Float;True;Property;_R_Metalic;R_Metalic;7;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;41;-1306.859,-1185.483;Float;False;Property;_R_AlbedoColor;R_Albedo Color;1;0;Create;True;0;0;False;0;1,1,1,0;1,1,1,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;18;-1361.74,-1372.595;Float;True;Property;_R_Albedo;R_Albedo;2;0;Create;True;0;0;False;0;None;1d10d54bcd6636049843a733cf37727a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;43;-1337.59,311.984;Float;False;Property;_G_AlbedoColor;G_Albedo Color;10;0;Create;True;0;0;False;0;1,1,1,0;1,1,1,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;16;-1385.581,126.4518;Float;True;Property;_G_Albedo;G_Albedo;11;0;Create;True;0;0;False;0;None;1d10d54bcd6636049843a733cf37727a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;-1343.399,1380.82;Float;False;Property;_G_OcclusionIntensity;G_Occlusion Intensity;15;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-1225.834,-11.24557;Float;False;Constant;_Float3;Float 3;2;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-1328.424,-107.7479;Float;False;Property;_R_OcclusionIntensity;R_Occlusion Intensity;6;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;12;-1240.808,1477.322;Float;False;Constant;_Float8;Float 8;2;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;-1722.843,507.6188;Float;False;Property;_G_NormalIntensity;G_Normal  Intensity;13;0;Create;True;0;0;False;0;0;0;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-1344.914,-540.3566;Float;False;Property;_R_MetalicIntensity;R_Metalic Intensity;8;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-1707.869,-980.9489;Float;False;Property;_R_NormalIntensity;R_Normal  Intensity;4;0;Create;True;0;0;False;0;0;0;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2;-1359.889,948.2106;Float;False;Property;_G_MetalicIntensity;G_Metalic Intensity;17;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-1342.166,-459.3149;Float;False;Property;_R_SmoothnessIntensity;R_Smoothness Intensity;9;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;17;-963.1097,48.41852;Float;True;Property;_MaskTexture;Mask Texture;0;0;Create;True;0;0;False;0;None;8a4eca7c7db28994d9284e1e429e5bd8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;44;-915.4914,289.8651;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-886.3488,-1310.829;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-878.603,-702.1953;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-893.577,786.3716;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;25;-865.1138,-246.8755;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;23;-1386.178,465.8206;Float;True;Property;_G_NormalMap;G_Normal Map;12;0;Create;True;0;0;False;0;None;3766e8be3c3c84f4cb77d8defc51e7d4;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;22;-880.0878,1241.692;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;-880.6729,-602.3003;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-895.6469,886.2667;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;20;-1371.204,-1022.747;Float;True;Property;_R_NormalMap;R_Normal Map;3;0;Create;True;0;0;False;0;None;3766e8be3c3c84f4cb77d8defc51e7d4;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;-516.4169,-519.4625;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-523.2489,714.7306;Float;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-507.4638,-918.6865;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-527.3199,832.7607;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;-531.3899,969.1047;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-517.5869,605.2967;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;-518.4509,-399.398;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-512.3459,-655.8069;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-508.2749,-773.8362;Float;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-533.4249,1089.17;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;37;-258.5127,-21.58689;Float;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;38;-263.6191,116.2866;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;40;-248.5918,363.3826;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;39;-266.1721,243.9471;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;36;-261.0657,-136.4814;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,-2.356335;Float;False;True;2;Float;;0;0;Standard;StandardMask_2Layers;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;44;0;16;0
WireConnection;44;1;43;0
WireConnection;42;0;18;0
WireConnection;42;1;41;0
WireConnection;21;0;11;0
WireConnection;21;1;10;0
WireConnection;24;0;5;0
WireConnection;24;1;2;0
WireConnection;25;0;6;0
WireConnection;25;1;3;0
WireConnection;25;2;7;0
WireConnection;23;5;4;0
WireConnection;22;0;12;0
WireConnection;22;1;14;0
WireConnection;22;2;13;0
WireConnection;15;0;11;4
WireConnection;15;1;8;0
WireConnection;19;0;5;4
WireConnection;19;1;1;0
WireConnection;20;5;9;0
WireConnection;31;0;17;1
WireConnection;31;1;15;0
WireConnection;29;0;17;2
WireConnection;29;1;23;0
WireConnection;35;0;17;1
WireConnection;35;1;42;0
WireConnection;30;0;17;2
WireConnection;30;1;24;0
WireConnection;26;0;17;2
WireConnection;26;1;19;0
WireConnection;33;0;17;2
WireConnection;33;1;44;0
WireConnection;34;0;17;1
WireConnection;34;1;25;0
WireConnection;28;0;17;1
WireConnection;28;1;21;0
WireConnection;27;0;17;1
WireConnection;27;1;20;0
WireConnection;32;0;17;2
WireConnection;32;1;22;0
WireConnection;37;0;27;0
WireConnection;37;1;29;0
WireConnection;38;0;28;0
WireConnection;38;1;30;0
WireConnection;40;0;34;0
WireConnection;40;1;32;0
WireConnection;39;0;31;0
WireConnection;39;1;26;0
WireConnection;36;0;35;0
WireConnection;36;1;33;0
WireConnection;0;0;36;0
WireConnection;0;1;37;0
WireConnection;0;3;38;0
WireConnection;0;4;39;0
WireConnection;0;5;40;0
ASEEND*/
//CHKSM=BBA0D6559DC08C00B19BCB3F118798749D93CD96