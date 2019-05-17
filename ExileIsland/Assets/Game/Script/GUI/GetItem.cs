using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetItem : MonoBehaviour
{
    public int index;
    public int roleID;
    public ItemTag itemTag;
    public HexGrid hexGrid;
    public ItemListPlane listPlane;
    public GameObject ItemButtonList;
    public DropItem dropItem;

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
        gameObject.SetActive(true);
    }

    public void setText()
    {
        Text text = GetComponentInChildren<Text>();
        string text1 = "你找到了";
        string text3 = "，是否拾获？";
        string text2;

        switch (itemTag)
        {
            case ItemTag.bow:
                text2 =  "弓";
                break;
            case ItemTag.sword:
                text2 =  "屠龙刀";
                break;
            default:
                text2 = "???";
                break;
        }
        //Debug.Log("print" + text2);
        text.text = text1 + text2 + text3;
    }

    public void getItem()
    {
        Debug.Log("itemTag" + itemTag);
        if (!Game.roles[roleID].AddItem(itemTag))
        {
            Debug.Log("Add False");
            ItemButtonList.SetActive(true);
            dropItem.show();
            
        }
        else
        {
            Debug.Log("Add Success");
            hexGrid.SetItemTag(index, ItemTag.noItem);
            listPlane.UpdateList(roleID);
        }
    }
    
}
