using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public ItemTag itemTag;
    public GameObject Chest_top;
    public Vector3 rotate;
    public float angle = 0;
    public bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpening == true)
        {
            box_open();
        }
    }

    public void open()
    {
        isOpening = true;
    }

    public void box_open()
    {
        rotate = new Vector3(-2.5f, 0, 0);
        if (angle <= 45)
        {
            Chest_top.transform.Rotate(rotate);
            angle += 2.5f;
        }
        else
            GameObject.Destroy(gameObject);
    }
}
