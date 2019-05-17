using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{

    public Color[] colors;

    public HexGrid hexGrid;
    public RangeGrid rangeGrid;

    private Color activeColor;

    static private Vector3 vector;//鼠标所指格子坐标
    static private int index; //鼠标指向地图的索引在这里

    void Awake()
    {
        SelectColor(0);
    }

    void Update()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        HandleInput();
    }

    static public Vector3 GetPointedVec()
    {
        return vector;
    }

    static public int GetPointedIndex()
    {
        return index;
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            Vector3 point = hit.point;
            index = hexGrid.GetCellIndex(point);
            vector = hexGrid.GetCellVec(index);

            hexGrid.HighlightCell(index);
            if (Input.GetMouseButtonDown(0))
            {
                //rangeGrid.ColorCell(index, activeColor);
            }
        }
    }

    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }
}