using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//控制界面上方横栏显示的信息
public class Status : MonoBehaviour
{
    Text text;
    //public Role role;
    public HexGrid hexGrid;
    public Game game;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = "游戏开始";
        //Debug.Log("Get it!");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hexGrid.PointedTag());
        switch (hexGrid.GetRoleID(HexMapEditor.GetPointedIndex()))
        {
            case 0:
                ShowRoleInfo(0);
                break;
            case 1:
                ShowRoleInfo(1);
                break;
            case 2:
                ShowRoleInfo(2);
                break;
            case 3:
                ShowRoleInfo(3);
                break;
            default:break;
        }
    }

    void ShowRoleInfo(int id)
    {
        string round = "Round:" + game.GetRound();
        string ID = " ID:" + id.ToString();
        string Lv = " Lv:" + Game.roles[id].GetLv().ToString();
        string Exp = " Exp:" + Game.roles[id].GetEXP().ToString() + "/" + Game.roles[id].GetRemainExp().ToString();
        string HP = " HP:" + Game.roles[id].GetRemainHP().ToString() + "/" + Game.roles[id].GetHP().ToString();
        string ATK = " ATK:" + Game.roles[id].GetATK().ToString();
        string DEF = " DEF:" + Game.roles[id].GetDEF().ToString();
        string energy = " 行动力:" + Game.roles[id].GetRemainEnergy().ToString();
        text.text = round +  ID + Lv + Exp + HP + ATK + DEF + energy;
    }
}
