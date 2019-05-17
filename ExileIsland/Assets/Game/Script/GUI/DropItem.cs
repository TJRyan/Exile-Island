using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        Action.itemIndex = -1;
        Action.Action_tag = 4;
        gameObject.SetActive(true);
    }
}
