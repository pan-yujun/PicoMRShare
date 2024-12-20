using UnityEngine;
using System.Collections;
 
class AnimateTiledTexture : MonoBehaviour
{
    public int columns = 2;
    public int rows = 2;
    public float framesPerSecond = 10f;
 	public Light flame = null;
	public float flameIntensity = 1.8f;
	
    //the current frame to display
    private int index = 0;
 
    void Start()
    {
        StartCoroutine(updateTiling());
 	
		// Set base intensity
        if(flame!=null)
		flame.intensity = flameIntensity;
		
        //set the tile size of the texture (in UV units), based on the rows and columns
        Vector2 size = new Vector2(1f / columns, 1f / rows);
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
    }
 
    private IEnumerator updateTiling()
    {
        while (true)
        {
            //move to the next index
            index++;
            if (index >= rows * columns)
                index = 0;
 
            //split into x and y indexes
            Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
                                          (index / columns) / (float)rows);          //y index
 
			GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
 
			if(flame && flame.enabled){				
				flame.intensity = Random.Range(flameIntensity - 0.2f, flameIntensity + 0.2f);
			}
			
            yield return new WaitForSeconds(1f / framesPerSecond);
        }
 
    }
}