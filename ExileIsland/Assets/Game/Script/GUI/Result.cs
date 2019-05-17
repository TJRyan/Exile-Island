using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(int i)
    {
        gameObject.SetActive(true);
        switch(i)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                text.text = "Winner: Player" + i.ToString();
                break;
            case 4:
                text.text = "Round Over";
                break;
        }
    }
}
