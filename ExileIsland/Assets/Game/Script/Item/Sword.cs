using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    int ATK = 100;


    // Start is called before the first frame update
    public Sword()
    {
        itemTag = ItemTag.sword;
        consume = 1;
        range = 1;
    }

    public override bool use(int myID, int targetID)
    {
        Role me = Game.roles[myID];
        Role target = Game.roles[targetID];
        if (!me.UseEnergy(consume)) return false;

        target.ReduceHP(ATK + me.GetATK() - target.GetDEF());
        return true;
    }

    public override string toString()
    {
        return "屠龙刀";
    }
}
