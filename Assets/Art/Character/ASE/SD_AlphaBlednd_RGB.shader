// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ASE/Me/AlphaBlend_RGB"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		[HDR]_MainColor("MainColor", Color) = (1,1,1,1)
		_Power("Power", Float) = 0
		[Toggle(_POWERONOFF_ON)] _PowerOnOff("Power On/Off", Float) = 0
		[Toggle(_RA_ON)] _RA("R/A", Float) = 0
		_Alpha("Alpha", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" "Queue"="Transparent" }
	LOD 0

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend SrcAlpha OneMinusSrcAlpha
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
			#pragma shader_feature _RA_ON


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
			uniform float _Alpha;

			
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
				#ifdef _RA_ON
				float staticSwitch14 = tex2DNode1.r;
				#else
				float staticSwitch14 = tex2DNode1.a;
				#endif
				#ifdef _POWERONOFF_ON
				float staticSwitch12 = pow( staticSwitch14 , _Power );
				#else
				float staticSwitch12 = staticSwitch14;
				#endif
				float4 appendResult8 = (float4(( _MainColor * tex2DNode1 * i.ase_color ).rgb , ( _MainColor.a * staticSwitch12 * i.ase_color.a * _Alpha )));
				
				
				finalColor = appendResult8;
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18800
125;373;1546;565;2121.735;23.60291;1.749459;True;False
Node;AmplifyShaderEditor.SamplerNode;1;-1322.194,87.33486;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;None;31311b10d78377945a9b1b5c1dfe3c5b;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;10;-838.7789,795.5961;Float;False;Property;_Power;Power;2;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;14;-937.3468,199.6094;Float;False;Property;_RA;R/A;4;0;Create;True;0;0;0;False;1;;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;9;-624.8611,677.9117;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;5;-814.0265,-100.7714;Half;False;Property;_MainColor;MainColor;1;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,1;0.9221513,0.9221513,0.9221513,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;6;-752.2275,405.2505;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;-228.7708,705.0965;Inherit;False;Property;_Alpha;Alpha;5;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;12;-326.1523,461.7343;Float;False;Property;_PowerOnOff;Power On/Off;3;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;-224.1215,44.88162;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-45.17364,349.3384;Inherit;False;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;8;121.9036,162.1295;Inherit;False;FLOAT4;4;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;559.8223,-39.85481;Float;False;True;-1;2;ASEMaterialInspector;0;1;ASE/Me/AlphaBlend_RGB;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;2;5;False;-1;10;False;-1;0;5;False;-1;10;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;True;0;False;-1;True;2;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;2;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;2;RenderType=Opaque=RenderType;Queue=Transparent=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;14;1;1;4
WireConnection;14;0;1;1
WireConnection;9;0;14;0
WireConnection;9;1;10;0
WireConnection;12;1;14;0
WireConnection;12;0;9;0
WireConnection;2;0;5;0
WireConnection;2;1;1;0
WireConnection;2;2;6;0
WireConnection;7;0;5;4
WireConnection;7;1;12;0
WireConnection;7;2;6;4
WireConnection;7;3;13;0
WireConnection;8;0;2;0
WireConnection;8;3;7;0
WireConnection;0;0;8;0
ASEEND*/
//CHKSM=AD444AE8B4ED95ECAB85187A16E84ED7AEADC735