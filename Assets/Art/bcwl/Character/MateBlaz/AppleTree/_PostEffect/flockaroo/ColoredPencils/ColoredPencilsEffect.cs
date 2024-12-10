using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flockaroo
{
[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
//[AddComponentMenu("Image Effects/Artistic/ColoredPencils")]
public class ColoredPencilsEffect : MonoBehaviour {
        private Shader shader = null;
        private Texture2D RandTex = null;
       private Material mat = null;
        [Header("Main faders")]
        [Range(0.0f,1.0f)]
        public float fade=0.0f;
        [Range(0.0f,1.0f)]
        public float panFade=0.0f;
        [Header("Source")]
        [Range(0.0f,2.0f)]
        public float brightness=1.0f;
        [Range(0.0f,2.0f)]
        public float contrast=1.0f;
        [Range(0.0f,2.0f)]
        public float color=1.0f;
        [Header("Effect")]
        [Range(0.0f,2.0f)]
        public float outlines=1.0f;
        [Range(0.0f,2.0f)]
        public float hatches=1.0f;
        [Range(0.0f,2.0f)]
        public float outlineError=1.0f;
        [Range(0.0f,1.0f)]
        public float flicker=0.3f;
        [Range(0.0f,100.0f)]
        public float flickerFreq=10.0f;
        [Range(0.0f,1.0f)]
        public float fixedHatchDir=0.0f;
        [Range(0.7f,1.5f)]
        public float hatchScale=1.0f;
        [Range(0.0f,3.0f)]
        public float mipLevel=0.0f;
        private bool useMipmaps=false;
        [Range(0.0f,1.0f)]
        public float vignetting=1.0f;
        [Range(0.0f,1.0f)]
        public float contentVignetting=0.0f;
        [Header("Background")]
        public Color paperTint = new Color(1.0f,0.97f,0.85f);
        [Range(0.0f,2.0f)]
        public float paperRoughness = 1.0f;
        public Texture2D paperTex = null;
        [Header("Other")]
        public bool flipY=false;
        private RenderTexture rtmip = null;
        private Mesh mesh;
        private bool isShaderooGeom = false;
        List<Mesh> meshes;
        
        // Use this for initialization

        /*protected Material mat
        {
            get
            {
                if (m_Material == null)
                {
                    m_Material = new Material(shader);
                    m_Material.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_Material;
            }
        }*/

        void initShader()
        {
            if (shader == null)
                shader = Resources.Load<Shader>("flockaroo_ColoredPencils/imageEffShader");
            //if (shader == null)
            //    shader = Resources.Load<Shader>("Assets/pencil-effect/imageEffShader");
        }

        void initRandTex()
        {
            //if (RandTex == null)
            //    RandTex = Resources.Load<Texture2D>("rand256");
            if (RandTex == null)
            {
                //RandTex = new Texture2D(256, 256, TextureFormat.RGBAFloat, true);
                //RandTex = new Texture2D(256, 256, TextureFormat.RGBAHalf, true);
                RandTex = new Texture2D(256, 256, TextureFormat.RGBA32, true);

                for (int x = 0; x < RandTex.width; x++)
                {
                    for (int y = 0; y < RandTex.height; y++)
                    {
                        float r = Random.Range(0.0f, 1.0f);
                        float g = Random.Range(0.0f, 1.0f);
                        float b = Random.Range(0.0f, 1.0f);
                        float a = Random.Range(0.0f, 1.0f);
                        RandTex.SetPixel(x, y, new Color(r, g, b, a) );
                    }
                }

                RandTex.Apply();
            }
        }
		
		void initMipmapRenderTexture(RenderTexture src)
		{
			        if(rtmip == null)
                    {
                        rtmip = new RenderTexture(src.width, src.height,0,RenderTextureFormat.ARGB32);
                        //rtmip = new RenderTexture(src);
                        rtmip.antiAliasing=1; // must be for mipmapping to work!!
                        rtmip.useMipMap=true;
#if UNITY_5_5_OR_NEWER
                        //rtmip.autoGenerateMips=false;
#endif
                    }

		}

        void Start () {
            initShader();
            initRandTex();
            if (isShaderooGeom)
            {
              meshes = new List<Mesh>();
              int trinum = 300000;
              int maxMeshSize = 0x10000/3*3;
              int mnum = (trinum*3+maxMeshSize-1)/maxMeshSize;
              for(int j=0;j<mnum;j++)
              {
	        mesh = new Mesh();
                meshes.Add(mesh);
                mesh.Clear();
                //GetComponent<MeshFilter>().mesh = mesh;
                int vnum = maxMeshSize;
                Vector3[] verts = new Vector3 [vnum];
                //Vector2[] uvs   = new Vector2 [vnum];
                int[] tris  = new int [vnum];
                for(int i=0;i<vnum;i++)
                {
                    verts[i].x=i+j*maxMeshSize;
                    verts[i].y=1;
                    verts[i].z=2;
                    //uvs[i].x=i;
                    //uvs[i].y=0;
                    tris[i]=i;
                }
	        mesh.vertices = verts;
                //mesh.uv = uvs;
	        mesh.triangles = tris;
              }  
            }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
        private void OnRenderImage(RenderTexture src, RenderTexture dest) {

            initShader();
            initRandTex();

            if (mat == null)
            {
                mat = new Material(shader);
                mat.hideFlags = HideFlags.HideAndDontSave;
            }

            mat.SetTexture("_PaperTex", paperTex);
            mat.SetTexture("_RandTex", RandTex);
            mat.SetFloat("effectFade", fade);
            mat.SetFloat("panFade", panFade);
            mat.SetFloat("brightness", brightness);
            mat.SetFloat("contrast", contrast);
            mat.SetFloat("colorStrength", color);
            mat.SetFloat("flicker", flicker);
            mat.SetFloat("flickerFreq", flickerFreq);
            mat.SetFloat("fixedHatchDir", fixedHatchDir);
            mat.SetFloat("outlines", outlines);
            mat.SetFloat("hatches", hatches);
            mat.SetFloat("outlineRand", outlineError);
            mat.SetFloat("vignetting", vignetting);
            mat.SetFloat("contentWhiteVign", contentVignetting);
            mat.SetFloat("hatchScale", hatchScale);
            mat.SetFloat("mipLevel", mipLevel);
            mat.SetFloat("flipY", flipY?1.0f:0.0f);
            mat.SetColor("paperTint", paperTint);
            mat.SetFloat("paperRough", paperRoughness);
            mat.SetFloat("paperTexFade", (paperTex==null)?0.0f:1.0f);
            mat.SetInt("_FrameCount", Time.frameCount);
            useMipmaps=(mipLevel>0.0001f);

            if (useMipmaps)
            {
				initMipmapRenderTexture(src);
                Graphics.Blit(src, rtmip);
#if UNITY_5_5_OR_NEWER
                //rtmip.GenerateMips();
#endif
                Graphics.SetRenderTarget(dest);
                mat.SetTexture("_MainTex", rtmip);
				Graphics.Blit(rtmip, dest, mat);
            }
            else
            {
                mat.SetTexture("_MainTex", src);

                if(isShaderooGeom)
                {
					//initMipmapRenderTexture(src);
                    Graphics.Blit(src, dest);
                    //Graphics.SetRenderTarget(rtmip);
                    //rtmip.DiscardContents(true,true);
                    //Graphics.SetRenderTarget(dest);
                    mat.SetPass(0);
                    foreach(Mesh mesh in meshes)
                    {
                        Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
                    }
                    //rtmip.GenerateMips();
                    //Graphics.SetRenderTarget(dest);
                    //Graphics.Blit(rtmip, dest);
                }
                else
                {
                    Graphics.Blit(src, dest, mat);
                }
            }
        }
        /*public void OnPostRender() {
            if (mat == null)
            {
                mat = new Material(shader);
                mat.hideFlags = HideFlags.HideAndDontSave;
            }
            mat.SetPass(0);
            Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
        }*/

}
}