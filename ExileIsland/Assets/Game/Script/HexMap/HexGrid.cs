using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HexGrid : MonoBehaviour
{
    private int width;
    private int height;

    public HexCell cellPrefab;
    HexCell[] cells;

    public Text cellLabelPrefab;

    public GameObject chestPrefab;

    public GetItem getItem;

    Canvas gridCanvas;
    HexMesh hexMesh;
    HexLine lineRenderer;

    //public Color defaultColor = Color.white;

    void Awake()
    {
        new Setting();

        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();
        lineRenderer = GetComponentInChildren<HexLine>();

        width = Setting.GetWidth();
        height = Setting.GetHeight();
        cells = new HexCell[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;//中心坐标
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        //cell.color = defaultColor;

        for(int id = 0; id < Setting.GetRoleNumber(); ++id)
        {
            if (i == Setting.RIP[id]) cell.roleID = id;
        }

        if (x > 0)
        {
            cell.SetNeighbor(HexDirection.W, cells[i - 1]);
        }
        if (z > 0)
        {
            if ((z & 1) == 0)
            {
                cell.SetNeighbor(HexDirection.SE, cells[i - width]);
                if (x > 0)
                {
                    cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
                }
            }
            else
            {
                cell.SetNeighbor(HexDirection.SW, cells[i - width]);
                if (x < width - 1)
                {
                    cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
                }
            }
        }

        //生成宝箱
        if (Random.value < Setting.GetChestPro() && cell.roleID == -1)
        {
            cell.item = GameObject.Instantiate(chestPrefab);
            cell.item.transform.SetParent(transform, false);
            cell.item.transform.localPosition = position + Vector3.down * 3;
            cell.item.transform.Rotate(new Vector3(0, Random.value * 360, 0));


            ItemTag maxTag = ItemTag.maxTag;
            ItemTag itemTag = (ItemTag)(Random.value * (float)maxTag);
            cell.item.GetComponent<Chest>().itemTag = (itemTag != maxTag) ? itemTag : ItemTag.bow;
        }
        else
        {
            cell.item = null;
            cell.itemTag = ItemTag.noItem;
        }

        /*显示格子坐标
        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector3(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();*/
    }
    // Start is called before the first frame update
    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public int GetCellIndex(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        return index;
    }
    public Vector3 GetCellVec(int index)
    {
        //Debug.Log(index);
        return cells[index].transform.position;
    }
    public HexCoordinates GetHexCoordinates(int index)
    {
        return cells[index].coordinates;
    }
    public HexCoordinates GetHexCoordinates(Vector3 position)
    {
        return GetHexCoordinates(GetCellIndex(position));
    }


    public ItemTag GetItemTag(int index)
    {
        return cells[index].itemTag;
;
    }
    public void SetItemTag(int index, ItemTag itemTag)
    {
        Debug.Log("拾取宝箱");
        if(itemTag==ItemTag.noItem && cells[index].item != null)
        {
            cells[index].item.GetComponent<Chest>().isOpening = true;
            Debug.Log("拾取完毕");
        }
        cells[index].itemTag = itemTag;
    }

    public int GetRoleID(int index)
    {
        //Debug.Log(index);
        return cells[index].roleID;
    }
    public void SetRoleID(int index, int id)
    {
        cells[index].roleID = id;

        //判断是否遇见物体
        if(id != -1 && cells[index].itemTag != ItemTag.noItem)
        {
            getItem.index = index;
            getItem.roleID = id;
            getItem.itemTag = cells[index].item.GetComponent<Chest>().itemTag;
            getItem.setText();
            //Debug.Log(getItem.itemTag);
            getItem.show();
        }
    }



    public void ColorCell(int index, Color color)
    {
        HexCell cell = cells[index];
        cell.color = color;
        hexMesh.Triangulate(cells);
    }

    public void HighlightCell(int index)
    {
        HexCell cell = cells[index];
        lineRenderer.Outline(cell);
    }

    public bool IsNeigh(int a, int b)
    {
        for (HexDirection i = HexDirection.NE; i <= HexDirection.NW; ++i)
        {
            if (cells[a].GetNeighbor(i) == cells[b]) return true;
            
        }
        return false;
    }



    public bool CheckInRange(int index, int targetIndex, int range)
    {
        range *= 2;
        Debug.Log(index);
        HexCoordinates role = cells[index].coordinates;
        Debug.Log(targetIndex);
        HexCoordinates target = cells[targetIndex].coordinates;

        int r = Mathf.Abs(role.X - target.X) + Mathf.Abs(role.Y - target.Y) + Mathf.Abs(role.Z - target.Z);

        if (r > range)
            return false;
        return true;
    }

}
