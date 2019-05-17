using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListPlane : MonoBehaviour
{
    public Button itemPrefab;
    public Action action;
    public GameObject dropItem;
    private int maxItem = 8;
    private static Button[] items;
    private const float gapRatio = 0.15f;
    private const float widRatio = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        maxItem = Setting.GetItemMAXNUM();
        items = new Button[maxItem];//最大按钮数
        float planeRatio = gapRatio * (maxItem + 1) + widRatio * maxItem;
        float realGap = gapRatio / planeRatio;
        float realWid = widRatio / planeRatio;

        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchorMax = new Vector2(planeRatio, 1.2f);

        float ratio = 0;
        for (int i = 0; i < maxItem; ++i)
        {
            ratio += realGap;

            //Debug.Log("Creat Button!");
            items[i] = GameObject.Instantiate(itemPrefab);
            rectTransform = items[i].GetComponent<RectTransform>();
            items[i].transform.SetParent(transform, false);
            items[i].GetComponentInChildren<Text>().text = "空";
            int index = i;
            items[i].onClick.AddListener(delegate { setItemIndex(index); });
            items[i].onClick.AddListener(delegate { dropItem.SetActive(false);});
            //Debug.Log("设置按钮" + i);

            rectTransform.anchorMin = new Vector2(ratio, 0.167f);
            ratio += realWid;
            rectTransform.anchorMax = new Vector2(ratio, 0.833f);
        }
        gameObject.SetActive(false);
    }

    void setItemIndex(int i)
    {
        action.setItemIndex(i);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateList(int id)
    {
        //Debug.Log("maxItem = " + maxItem);
        for(int i = 0; i < maxItem; ++i)
        {
            //Debug.Log("更新" + id + "的" + i + "物品");
            Item item = Game.roles[id].GetItem(i);
            //Debug.Log("成功访问");
            if (item == null)
            {
                //Debug.Log("item为空");
                items[i].GetComponentInChildren<Text>().text = "空";
            }
            else
                items[i].GetComponentInChildren<Text>().text = item.toString();
            //Debug.Log("成功设置");
        }
    }
}
