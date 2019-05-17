using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Role
{
    public HexGrid hexGrid;
    public Camera mainCamera;
    public ItemListPlane listPlane;
    public GetItem getItem;


    // Start is called before the first frame update
    void Start()
    {
        itemList = new ItemList();
        remainEnergy = GetEnergy();
    }

    // Update is called once per frame
    void Update()
    {
        if(status == Info.running)
            switch (Action.Action_tag)
            {
                case 0:
                    //Debug.Log("Mouse");
                    Mouse();
                    break;
                case 1:
                    //Debug.Log("Move");
                    Move();
                    break;
                case 2:
                    UseItem();
                    //Debug.Log("Item");
                    break;
                case 3:
                    //Debug.Log("End");
                    status = Info.waiting;
                    return;
                case 4:
                    //Debug.Log("DropItem!");
                    DropItem();
                    break;
            }
    }

    public override void Run()
    {
        if (status != Info.waiting) return;
        status = Info.running;
        Action.Action_tag = 0;
        remainEnergy = GetEnergy();
        listPlane.UpdateList(id);
    }

    void Mouse()
    {

    }

    void Move()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&Input.GetMouseButtonUp(0))
        {
            int index = hexGrid.GetCellIndex(transform.position);//当前人物位置
            int pointed = HexMapEditor.GetPointedIndex();//当前光标位置

            //检测是否在移动范围,是否有其他人，是否有充足能量
            if (hexGrid.CheckInRange(index, pointed, 10) && hexGrid.GetRoleID(pointed)==-1 && UseEnergy(1))
            {
                hexGrid.SetRoleID(index, -1);
                hexGrid.SetRoleID(pointed, id);
                AddEXP(1);
                transform.position = HexMapEditor.GetPointedVec();
            }
        }
    }

    void UseItem()
    {
        if (Action.itemIndex == -1 || itemList.GetItem(Action.itemIndex) == null) return;

        //Debug.Log("使用 " + Action.itemIndex);
        int targetIndex;

        if (Input.GetMouseButtonUp(0))
        {
            targetIndex = HexMapEditor.GetPointedIndex();

            //Debug.Log("1" + targetIndex);
            int range = itemList.GetItem(Action.itemIndex).range;
            //Debug.Log("2");
            if (hexGrid.GetRoleID(targetIndex) == -1)
            {
                if(range != 0)
                {
                    //Debug.Log("3" + hexGrid.GetRoleID(targetIndex));
                    return;
                }
            }

            //Debug.Log("4");

            Action.targetIndex = targetIndex;
            //Debug.Log("5");
            int myIndex = hexGrid.GetCellIndex(transform.position);
            //Debug.Log("6");

            if (!hexGrid.CheckInRange(myIndex, targetIndex, range))
            {
                if (range != 0)
                {
                    //Debug.Log("7");
                    return;
                }
            }
            //Debug.Log("8");

            itemList.UseItem(id, hexGrid.GetRoleID(targetIndex), Action.itemIndex);
            //Debug.Log("9");
        }
    }

    void DropItem()
    {
        //Debug.Log("丢弃 " + Action.itemIndex);
        if (Action.itemIndex == -1) return;
        //Debug.Log("开始丢弃");
        itemList.DeleteItem(Action.itemIndex);
        itemList.AddItem(getItem.itemTag);
        hexGrid.SetItemTag(getItem.index, ItemTag.noItem);
        Action.itemIndex = -1;
        listPlane.UpdateList(id);
        //Debug.Log("丢弃成功");
        Action.Action_tag = 0;
    }
}
