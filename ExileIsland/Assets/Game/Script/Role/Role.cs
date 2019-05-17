using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Info { waiting, running, dead};

public abstract class Role : MonoBehaviour
{
    protected int ATK = 1;
    protected int DEF = 1;
    protected int exp = 0;
    protected int HP = 10;
    protected int energy = 200;
    protected ItemList itemList;
    protected int Lv = 1;
    protected int remainEnergy;
    protected int remainExp = 2;//升级所需exp
    protected int remainHP = 10;
    public Info status = Info.waiting;
    public int id;


    
    public Info GetStatus() { return status; }

    public int GetATK()
    {
        return ATK;
    }
    public int GetDEF()
    {
        return DEF;
    }


    public int GetEXP()
    {
        return exp;
    }
    public int GetRemainExp()
    {
        return remainExp;
    }
    public void AddEXP(int e)
    {
        exp += e;
        while (exp >= remainExp)
        {
            exp -= remainExp;
            Reward();
        }
    }
    public void Reward()
    {
        ++Lv;
        remainExp *= 2;
        energy += 2;
        ATK += 1;
        DEF += 1;
        HP += 10;
        remainHP += 10;
    }

    public int GetEnergy()
    {
        return energy;
    }
    public bool UseEnergy(int value)
    {
        if (remainEnergy < value) return false;

        remainEnergy -= value;
        return true;
    }
    public int GetRemainEnergy()
    {
        return remainEnergy;
    }

    public int GetHP()
    {
        return HP;
    }
    public int GetRemainHP()
    {
        return remainHP;
    }
    public void ReduceHP(int i)
    {
        i = (i <= 0) ? 1 : i;
        //Debug.Log("扣" + i + "血");
        remainHP -= i;
        if (remainHP > 0) return;

        status = Info.dead;
        gameObject.SetActive(false);
    }

    public int GetLv()
    {
        return Lv;
    }

    public bool AddItem(ItemTag itemTag)
    {
        return itemList.AddItem(itemTag);
    }
    public Item GetItem(int index)
    {
        return itemList.GetItem(index);
    }

    abstract public void Run();
}
