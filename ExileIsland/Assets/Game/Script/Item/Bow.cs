using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Item
{
    int ATK = 1;

    public Bow()
    {
        itemTag = ItemTag.sword;
        consume = 1;
        range = 2;
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
        return "弓";
    }
}
