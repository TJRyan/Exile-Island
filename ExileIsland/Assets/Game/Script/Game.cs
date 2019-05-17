using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Role[] roles;
    public HexGrid hexGrid;
    public GameObject playerPrefab;
    public Result result;
    int roleNumber;
    int resultTag = 0;
    int id = 0;
    int round = 50;

    void Awake()
    {
        roleNumber = Setting.GetRoleNumber();
        round = Setting.GetRound();
        roles = new Role[roleNumber];

        for(int i = 0; i < roleNumber; ++i)
        {
            GameObject role;
            role = GameObject.Instantiate(playerPrefab);
            //Debug.Log("新建角色 " + i);
            role.transform.SetParent(transform, false);
            //role.GetComponentInChildren<Renderer>().material.color = Setting.colors[i];


            roles[i] = role.GetComponent<Player>();
            roles[i].id = i;
            
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Game Start");
        for (; id < roleNumber; ++id)
        {
            hexGrid.SetRoleID(Setting.RIP[id], id);
            roles[id].transform.position = hexGrid.GetCellVec(Setting.RIP[id]);
        }
        --id;
    }

    // Update is called once per frame
    void Update()
    {
        if ((resultTag = GameOver()) == -1)
        {
            //Debug.Log(id);
            if (roles[id].GetStatus() != Info.running)
            {
                id = (id + 1) % roleNumber;
                Debug.Log("player " + id);
                Action.roleID = id;
                roles[id].Run();
                if (id == roleNumber - 1) --round;
            }
        }
        else
            result.GameOver(resultTag);
    }

    int GameOver()
    {
        if (round == 0) return 4;
        int winner = -1;
        int left = 0;
        for (int i = 0; i < roleNumber; ++i)
            if (roles[i].GetStatus() != Info.dead)
                ++left;

        if (left == 1)
            for (int i = 0; i < roleNumber; ++i)
                if (roles[i].GetStatus() != Info.dead)
                    winner = i;
        return winner;
    }

    public int GetRound()
    {
        return round;
    } 
}
