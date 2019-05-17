using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action : MonoBehaviour
{
    public static HexGrid hexGrid;
    public static int Action_tag;
    public static string segment;
    public static int roleID;
    public static int itemIndex = -1;//按键控制，脚本ItemListPlane中
    public static int targetIndex;

    public void setAction_tag(int value) { Action_tag = value; }
    public void setItemIndex(int i) { itemIndex = i; Debug.Log("itemIndex" + i); }
    // Starts called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SendSegment(int tag)
    {
        switch (tag)
        {

        }
    }
}
