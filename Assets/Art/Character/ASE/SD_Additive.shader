// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ASE/Me/Additive"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		[HDR]_MainColor("MainColor", Color) = (1,1,1,1)
		[Toggle(_POWERONOFF_ON)] _PowerOnOff("Power On/Off", Float) = 0
		[Toggle(_TEX_RA_ON)] _Tex_RA("Tex_R/A", Float) = 0
		_Power("Power", Float) = 0
		[Toggle(_Y_MASK_ON)] _Y_Mask("Y_Mask", Float) = 0
		_Float0("Float 0", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" "Queue"="Transparent" }
	LOD 0

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend One One
		AlphaToMask Off
		Cull Off
		ColorMask RGBA
		ZWrite Off
		ZTest LEqual
		Offset 0 , 0
		
		
		
		Pass
		{
			Name "Unlit"
			Tags { "LightMode"="ForwardBase" }
			CGPROGRAM

			

			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature _POWERONOFF_ON
			#pragma shader_feature _TEX_RA_ON
			#pragma shader_feature_local _Y_MASK_ON


			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform half4 _MainColor;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float _Power;
			uniform float _Float0;

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				o.ase_texcoord1.xy = v.ase_texcoord.xy;
				o.ase_color = v.color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord1.zw = 0;
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = vertexValue;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				float2 uv_MainTex = i.ase_texcoord1.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				float4 tex2DNode1 = tex2D( _MainTex, uv_MainTex );
				#ifdef _POWERONOFF_ON
				float staticSwitch8 = pow( tex2DNode1.r , _Power );
				#else
				float staticSwitch8 = tex2DNode1.r;
				#endif
				#ifdef _TEX_RA_ON
				float staticSwitch10 = tex2DNode1.r;
				#else
				float staticSwitch10 = tex2DNode1.a;
				#endif
				float2 texCoord14 = i.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				#ifdef _Y_MASK_ON
				float staticSwitch12 = texCoord14.y;
				#else
				float staticSwitch12 = _Float0;
				#endif
				
				
				finalColor = ( _MainColor * staticSwitch8 * i.ase_color * i.ase_color.a * staticSwitch10 * staticSwitch12 );
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18800
191;22;1244;997;550.3901;76.87659;1;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;14;-767.8773,759.3695;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-1210.992,-94.58329;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;None;440a99b0024242a48b453163f1fbbda6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;-834.1474,234.3024;Float;False;Property;_Power;Power;4;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;7;-565.2673,224.7548;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;15;-404.3116,770.9387;Inherit;True;True;True;True;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;16;-202.1187,473.2742;Inherit;False;Property;_Float0;Float 0;6;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;5;-582.4314,-453.9126;Half;False;Property;_MainColor;MainColor;1;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;6;-529.8162,-226.8599;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;10;-455.7331,5.524607;Float;False;Property;_Tex_RA;Tex_R/A;3;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;8;-271.0663,152.206;Float;False;Property;_PowerOnOff;Power On/Off;2;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;12;108.1271,560.1017;Inherit;False;Property;_Y_Mask;Y_Mask;5;0;Create;True;0;0;0;False;0;False;0;0;1;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;372.4149,54.69667;Inherit;True;6;6;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;675.0293,8.974177;Float;False;True;-1;2;ASEMaterialInspector;0;1;ASE/Me/Additive;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;4;1;False;-1;1;False;-1;0;1;False;-1;1;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;True;0;False;-1;True;2;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;2;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;2;RenderType=Opaque=RenderType;Queue=Transparent=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;7;0;1;1
WireConnection;7;1;9;0
WireConnection;15;0;14;2
WireConnection;10;1;1;4
WireConnection;10;0;1;1
WireConnection;8;1;1;1
WireConnection;8;0;7;0
WireConnection;12;1;16;0
WireConnection;12;0;15;0
WireConnection;2;0;5;0
WireConnection;2;1;8;0
WireConnection;2;2;6;0
WireConnection;2;3;6;4
WireConnection;2;4;10;0
WireConnection;2;5;12;0
WireConnection;0;0;2;0
ASEEND*/
//CHKSM=308A3D8AB1B431AD0F43E1A83257B99CA8BCFDF0