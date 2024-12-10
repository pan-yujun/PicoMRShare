// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:False,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33300,y:32681,varname:node_2865,prsc:2|diff-6343-OUT,spec-358-OUT,gloss-1813-OUT,emission-1371-OUT,alpha-7686-OUT,voffset-7910-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32555,y:32390,varname:node_6343,prsc:2|A-6665-RGB,B-7736-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:32079,y:32253,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:32079,y:32426,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7186-UVOUT;n:type:ShaderForge.SFN_Slider,id:358,x:32389,y:32713,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4027741,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32389,y:32825,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9307736,max:5;n:type:ShaderForge.SFN_TexCoord,id:9950,x:31585,y:32363,varname:node_9950,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7186,x:31841,y:32394,varname:node_7186,prsc:2,spu:0.01,spv:0.03|UVIN-9950-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1371,x:32546,y:32541,varname:node_1371,prsc:2|A-7465-R,B-3883-R,C-6665-RGB;n:type:ShaderForge.SFN_Tex2d,id:7465,x:31841,y:32581,ptovrint:False,ptlb:Emission01,ptin:_Emission01,varname:_Emission01,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9298-OUT;n:type:ShaderForge.SFN_Tex2d,id:3883,x:31841,y:32800,ptovrint:False,ptlb:Emission02,ptin:_Emission02,varname:_Emission02,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7576-UVOUT;n:type:ShaderForge.SFN_Add,id:9298,x:31587,y:32555,varname:node_9298,prsc:2|A-9968-UVOUT,B-689-OUT;n:type:ShaderForge.SFN_TexCoord,id:9968,x:31318,y:32462,varname:node_9968,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:689,x:31318,y:32695,varname:node_689,prsc:2|A-520-R,B-2673-R,C-8876-OUT;n:type:ShaderForge.SFN_Tex2d,id:520,x:31090,y:32538,ptovrint:False,ptlb:Tex_01,ptin:_Tex_01,varname:_Tex_01,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4643-OUT;n:type:ShaderForge.SFN_Tex2d,id:2673,x:31090,y:32742,ptovrint:False,ptlb:Tex_02,ptin:_Tex_02,varname:_Tex_02,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-359-OUT;n:type:ShaderForge.SFN_Panner,id:7576,x:31608,y:32814,varname:node_7576,prsc:2,spu:0,spv:0.02|UVIN-7820-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7820,x:31326,y:32923,varname:node_7820,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:3823,x:30821,y:32135,varname:node_3823,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:7686,x:32719,y:32932,ptovrint:False,ptlb:opacity,ptin:_opacity,varname:_opacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:7910,x:32719,y:33077,varname:node_7910,prsc:2|A-449-RGB,B-2226-OUT,C-4135-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2226,x:32444,y:33196,ptovrint:False,ptlb:noisepower,ptin:_noisepower,varname:_power,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_NormalVector,id:4135,x:32429,y:33270,prsc:2,pt:False;n:type:ShaderForge.SFN_Tex2d,id:449,x:32231,y:33196,ptovrint:False,ptlb:noise,ptin:_noise,varname:_noise,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2430-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8876,x:31090,y:32967,ptovrint:False,ptlb:niuqv_power,ptin:_niuqv_power,varname:_niuqv_power,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:3913,x:30452,y:32502,ptovrint:False,ptlb:Tex_01V,ptin:_Tex_01V,varname:_node_3913,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:640,x:30452,y:32420,ptovrint:False,ptlb:Tex_01U,ptin:_Tex_01U,varname:_node_640,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:5497,x:30621,y:32439,varname:node_5497,prsc:2|A-640-OUT,B-3913-OUT;n:type:ShaderForge.SFN_Time,id:9163,x:30621,y:32227,varname:node_9163,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5831,x:30806,y:32335,varname:node_5831,prsc:2|A-9163-T,B-5497-OUT;n:type:ShaderForge.SFN_Add,id:4643,x:30996,y:32238,varname:node_4643,prsc:2|A-3823-UVOUT,B-5831-OUT;n:type:ShaderForge.SFN_TexCoord,id:6415,x:30706,y:32637,varname:node_6415,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:5398,x:30060,y:32842,ptovrint:False,ptlb:Tex_02V,ptin:_Tex_02V,varname:_Tex_01V_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:9954,x:30060,y:32760,ptovrint:False,ptlb:Tex_02U,ptin:_Tex_02U,varname:_Tex_01U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:2535,x:30225,y:32783,varname:node_2535,prsc:2|A-9954-OUT,B-5398-OUT;n:type:ShaderForge.SFN_Time,id:4956,x:30373,y:32663,varname:node_4956,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3809,x:30544,y:32763,varname:node_3809,prsc:2|A-4956-T,B-2535-OUT;n:type:ShaderForge.SFN_Add,id:359,x:30896,y:32742,varname:node_359,prsc:2|A-6415-UVOUT,B-3809-OUT;n:type:ShaderForge.SFN_TexCoord,id:8726,x:31744,y:33106,varname:node_8726,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:4684,x:31098,y:33311,ptovrint:False,ptlb:noiseV,ptin:_noiseV,varname:_Tex_02V_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:7101,x:31098,y:33229,ptovrint:False,ptlb:noiseU,ptin:_noiseU,varname:_Tex_02U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:1818,x:31263,y:33252,varname:node_1818,prsc:2|A-7101-OUT,B-4684-OUT;n:type:ShaderForge.SFN_Time,id:1122,x:31411,y:33132,varname:node_1122,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2567,x:31582,y:33232,varname:node_2567,prsc:2|A-1122-T,B-1818-OUT;n:type:ShaderForge.SFN_Add,id:2430,x:31934,y:33211,varname:node_2430,prsc:2|A-8726-UVOUT,B-2567-OUT;proporder:6665-7736-358-1813-7465-3883-520-2673-7686-449-8876-640-3913-9954-5398-7101-4684-2226;pass:END;sub:END;*/

Shader "LI/Water" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0.4027741
        _Gloss ("Gloss", Range(0, 5)) = 0.9307736
        _Emission01 ("Emission01", 2D) = "white" {}
        _Emission02 ("Emission02", 2D) = "white" {}
        _Tex_01 ("Tex_01", 2D) = "white" {}
        _Tex_02 ("Tex_02", 2D) = "white" {}
        _opacity ("opacity", Float ) = 0
        _noise ("noise", 2D) = "white" {}
        _niuqv_power ("niuqv_power", Float ) = 0.5
        _Tex_01U ("Tex_01U", Float ) = 0
        _Tex_01V ("Tex_01V", Float ) = 0
        _Tex_02U ("Tex_02U", Float ) = 0
        _Tex_02V ("Tex_02V", Float ) = 0
        _noiseU ("noiseU", Float ) = 0
        _noiseV ("noiseV", Float ) = 0
        _noisepower ("noisepower", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu ps5 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Emission01; uniform float4 _Emission01_ST;
            uniform sampler2D _Emission02; uniform float4 _Emission02_ST;
            uniform sampler2D _Tex_01; uniform float4 _Tex_01_ST;
            uniform sampler2D _Tex_02; uniform float4 _Tex_02_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float, _opacity)
                UNITY_DEFINE_INSTANCED_PROP( float, _noisepower)
                UNITY_DEFINE_INSTANCED_PROP( float, _niuqv_power)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_01V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_01U)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_02V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_02U)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseV)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseU)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                UNITY_FOG_COORDS(7)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_1122 = _Time;
                float _noiseU_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseU );
                float _noiseV_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseV );
                float2 node_2430 = (o.uv0+(node_1122.g*float2(_noiseU_var,_noiseV_var)));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_2430, _noise),0.0,0));
                float _noisepower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noisepower );
                v.vertex.xyz += (_noise_var.rgb*_noisepower_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float gloss = _Gloss_var;
                float perceptualRoughness = 1.0 - _Gloss_var;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                float3 specularColor = _Metallic_var;
                float specularMonochrome;
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float4 node_7094 = _Time;
                float2 node_7186 = (i.uv0+node_7094.g*float2(0.01,0.03));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_7186, _MainTex));
                float3 diffuseColor = (_Color_var.rgb*_MainTex_var.rgb); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_9163 = _Time;
                float _Tex_01U_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_01U );
                float _Tex_01V_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_01V );
                float2 node_4643 = (i.uv0+(node_9163.g*float2(_Tex_01U_var,_Tex_01V_var)));
                float4 _Tex_01_var = tex2D(_Tex_01,TRANSFORM_TEX(node_4643, _Tex_01));
                float4 node_4956 = _Time;
                float _Tex_02U_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_02U );
                float _Tex_02V_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_02V );
                float2 node_359 = (i.uv0+(node_4956.g*float2(_Tex_02U_var,_Tex_02V_var)));
                float4 _Tex_02_var = tex2D(_Tex_02,TRANSFORM_TEX(node_359, _Tex_02));
                float _niuqv_power_var = UNITY_ACCESS_INSTANCED_PROP( Props, _niuqv_power );
                float2 node_9298 = (i.uv0+(_Tex_01_var.r*_Tex_02_var.r*_niuqv_power_var));
                float4 _Emission01_var = tex2D(_Emission01,TRANSFORM_TEX(node_9298, _Emission01));
                float2 node_7576 = (i.uv0+node_7094.g*float2(0,0.02));
                float4 _Emission02_var = tex2D(_Emission02,TRANSFORM_TEX(node_7576, _Emission02));
                float3 emissive = (_Emission01_var.r*_Emission02_var.r*_Color_var.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float _opacity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _opacity );
                fixed4 finalRGBA = fixed4(finalColor,_opacity_var);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu ps5 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Emission01; uniform float4 _Emission01_ST;
            uniform sampler2D _Emission02; uniform float4 _Emission02_ST;
            uniform sampler2D _Tex_01; uniform float4 _Tex_01_ST;
            uniform sampler2D _Tex_02; uniform float4 _Tex_02_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float, _opacity)
                UNITY_DEFINE_INSTANCED_PROP( float, _noisepower)
                UNITY_DEFINE_INSTANCED_PROP( float, _niuqv_power)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_01V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_01U)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_02V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_02U)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseV)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseU)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_1122 = _Time;
                float _noiseU_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseU );
                float _noiseV_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseV );
                float2 node_2430 = (o.uv0+(node_1122.g*float2(_noiseU_var,_noiseV_var)));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_2430, _noise),0.0,0));
                float _noisepower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noisepower );
                v.vertex.xyz += (_noise_var.rgb*_noisepower_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float gloss = _Gloss_var;
                float perceptualRoughness = 1.0 - _Gloss_var;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                float3 specularColor = _Metallic_var;
                float specularMonochrome;
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float4 node_5403 = _Time;
                float2 node_7186 = (i.uv0+node_5403.g*float2(0.01,0.03));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_7186, _MainTex));
                float3 diffuseColor = (_Color_var.rgb*_MainTex_var.rgb); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float _opacity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _opacity );
                fixed4 finalRGBA = fixed4(finalColor * _opacity_var,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu ps5 
            #pragma target 3.0
            uniform sampler2D _noise; uniform float4 _noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _noisepower)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseV)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseU)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float3 normalDir : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1122 = _Time;
                float _noiseU_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseU );
                float _noiseV_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseV );
                float2 node_2430 = (o.uv0+(node_1122.g*float2(_noiseU_var,_noiseV_var)));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_2430, _noise),0.0,0));
                float _noisepower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noisepower );
                v.vertex.xyz += (_noise_var.rgb*_noisepower_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu ps5 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Emission01; uniform float4 _Emission01_ST;
            uniform sampler2D _Emission02; uniform float4 _Emission02_ST;
            uniform sampler2D _Tex_01; uniform float4 _Tex_01_ST;
            uniform sampler2D _Tex_02; uniform float4 _Tex_02_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float, _noisepower)
                UNITY_DEFINE_INSTANCED_PROP( float, _niuqv_power)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_01V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_01U)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_02V)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tex_02U)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseV)
                UNITY_DEFINE_INSTANCED_PROP( float, _noiseU)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1122 = _Time;
                float _noiseU_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseU );
                float _noiseV_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noiseV );
                float2 node_2430 = (o.uv0+(node_1122.g*float2(_noiseU_var,_noiseV_var)));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_2430, _noise),0.0,0));
                float _noisepower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _noisepower );
                v.vertex.xyz += (_noise_var.rgb*_noisepower_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_9163 = _Time;
                float _Tex_01U_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_01U );
                float _Tex_01V_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_01V );
                float2 node_4643 = (i.uv0+(node_9163.g*float2(_Tex_01U_var,_Tex_01V_var)));
                float4 _Tex_01_var = tex2D(_Tex_01,TRANSFORM_TEX(node_4643, _Tex_01));
                float4 node_4956 = _Time;
                float _Tex_02U_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_02U );
                float _Tex_02V_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tex_02V );
                float2 node_359 = (i.uv0+(node_4956.g*float2(_Tex_02U_var,_Tex_02V_var)));
                float4 _Tex_02_var = tex2D(_Tex_02,TRANSFORM_TEX(node_359, _Tex_02));
                float _niuqv_power_var = UNITY_ACCESS_INSTANCED_PROP( Props, _niuqv_power );
                float2 node_9298 = (i.uv0+(_Tex_01_var.r*_Tex_02_var.r*_niuqv_power_var));
                float4 _Emission01_var = tex2D(_Emission01,TRANSFORM_TEX(node_9298, _Emission01));
                float4 node_9486 = _Time;
                float2 node_7576 = (i.uv0+node_9486.g*float2(0,0.02));
                float4 _Emission02_var = tex2D(_Emission02,TRANSFORM_TEX(node_7576, _Emission02));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                o.Emission = (_Emission01_var.r*_Emission02_var.r*_Color_var.rgb);
                
                float2 node_7186 = (i.uv0+node_9486.g*float2(0.01,0.03));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_7186, _MainTex));
                float3 diffColor = (_Color_var.rgb*_MainTex_var.rgb);
                float specularMonochrome;
                float3 specColor;
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic_var, specColor, specularMonochrome );
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float roughness = 1.0 - _Gloss_var;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
