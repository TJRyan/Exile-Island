using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTag {sword, bow, maxTag, noItem};

public abstract class Item
{
    public ItemTag itemTag;
    public int consume;
    public int range;

    protected Item()
    {

    }
    public abstract bool use(int myID, int targetID);
    public abstract string toString();
}
