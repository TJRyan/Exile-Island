using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting
{
    private static int width = 10;
    private static int height = 10;
    private static int roleNumber = 4;
    private static int item_MAXNUM = 8;
    private static float ChestProba = 0.05f;
    private static int round = 10;

    public static int[] RIP;//角色初始化位置
    public static Color[] colors;

    public Setting()
    {
        colors = new Color[4];
        RIP = new int[4];
        RIP[0] = (height/3) * width;
        RIP[1] = (2 * height / 3) * width - 1;
        RIP[2] = (height - 1) * width + width / 3;
        RIP[3] = (width / 3) * 2;

        colors[0] = Color.clear;
        colors[1] = Color.cyan;
        colors[2] = Color.green;
        colors[3] = Color.red;
    }

    public Setting(int w, int h, int rN, int i, float cp, int r)
    {
        width = w;
        height = h;
        roleNumber = rN;
        item_MAXNUM = i;
        ChestProba = cp;
        round = r;

        RIP = new int[4];
        RIP[0] = height * width / 3;
        RIP[1] = (height - 1) * width + width / 3;
        RIP[2] = (2 * height / 3) * width - 1;
        RIP[3] = (width / 3) * 2;
    }

    public static int GetWidth()
    {
        return width;
    }
    public static bool SetWidth(int width)
    {
        Setting.width = width;
        return true;
    }

    public static int GetHeight()
    {
        return height;
    }
    public static bool SetHeight(int height)
    {
        Setting.height = height;
        return true;
    }

    public static int GetRoleNumber()
    {
        return roleNumber;
    }
    public static bool SetRoleNumber(int roleNumber)
    {
        Setting.roleNumber = roleNumber;
        return true;
    }

    public static int GetItemMAXNUM()
    {
        return item_MAXNUM;
    }
    public static bool SetItemMAXNUM(int num)
    {
        item_MAXNUM = num;
        return true;
    }

    public static float GetChestPro()
    {
        return ChestProba;
    }

    public static int GetRound()
    {
        return round;
    }
}
