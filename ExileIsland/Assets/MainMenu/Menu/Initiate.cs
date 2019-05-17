using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Initiate : MonoBehaviour
{
    // Start is called before the first frame update
    public void print()
    {
        InputField LE = GameObject.Find("Length").GetComponent<InputField>();
        InputField WE = GameObject.Find("Width").GetComponent<InputField>();
        InputField PE = GameObject.Find("PlayerEnter").GetComponent<InputField>();
        InputField BE = GameObject.Find("BoxEnter").GetComponent<InputField>();
        InputField IE = GameObject.Find("ItemEnter").GetComponent<InputField>();
        InputField RE = GameObject.Find("RoundEnter").GetComponent<InputField>();
        new Setting(int.Parse(WE.text), int.Parse(LE.text), int.Parse(PE.text), int.Parse(IE.text), float.Parse(BE.text)/100, int.Parse(RE.text));
        SceneManager.LoadScene("InGame");
    }
}
