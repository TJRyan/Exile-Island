using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Island : MonoBehaviour
{
    public Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
        //***一次伟大的尝试
        //terrain.SampleHeight(new Vector3(10000, 1, 0));
        //terrain.SampleHeight();
        terrain.terrainData.size = new Vector3(Setting.GetWidth()*250.0f, 600, Setting.GetHeight() * 250.0f);
        terrain.transform.position = new Vector3(Setting.GetWidth() * -117f, -8, Setting.GetHeight() * -118.0f);
        //terrain.terrainData.heightmapScale;
        //terrain.terrainData.detailWidth;
        //terrain.terrainData.alphamapWidth;
        //terrain.terrainData.alphamapHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
