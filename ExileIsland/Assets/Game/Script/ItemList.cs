using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList
{
    private Item[] itemList;
    private int length = 0;

    public ItemList()
    {
        itemList = new Item[Setting.GetItemMAXNUM()];
        for(int i = 0; i < Setting.GetItemMAXNUM(); ++i)
        {
            itemList[i] = null;
        }
    }

    public bool AddItem(ItemTag tag)
    {
        Debug.Log("length" + length);
        if(length >= Setting.GetItemMAXNUM())
        {
            return false;
        }


        switch (tag)
        {
            case ItemTag.sword:
                //Debug.Log("Add"+tag);
                itemList[length] = new Sword();
                break;
            case ItemTag.bow:
                //Debug.Log("Add"+tag);
                itemList[length] = new Bow();

                break;
        }
        ++length;
        return true;
    }

    public Item GetItem(int index)
    {
        /*if (index >= length||index<0)
        {
            return null;
        }*/
        //Debug.Log("Index" + index);
        return itemList[index];
    }

    public bool DeleteItem(int index)
    {
        //Debug.Log("DropItem " + index);

        for(int i=index; i < length - 1; ++i)
        {
            itemList[i] = itemList[i + 1];
        }
        --length;
        //Debug.Log("DropItem succeed");

        return true;
    }

    public bool UseItem(int myID, int targetID, int index)
    {
        return itemList[index].use(myID, targetID);
    }
}
