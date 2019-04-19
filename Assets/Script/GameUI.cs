using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{

    
    public Text[] texts = new Text[5];
    public Text failtext;
    public static float time = 40.0f;
    public static int gold = 0;
    public static int gold2 = 0;
    public static string name = "";
    public FokerManager foker;

    // Start is called before the first frame update
    void Awake()
    {
        gold = PlayerPrefs.GetInt("Gold");

    }
    public void InputScene(int i)
    {

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }
    public void OPen(GameObject game)
    {
       game.SetActive(true);    
    }
    public void ExitB(GameObject game)
    {
        game.SetActive(false);
    }

    public void ExitB2()
    {
        Application.Quit();
    }
    public void SaveB()
    {
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Round", EnemyCtrl.round);
 
    }


    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 40.0f;
            EnemyCtrl.RoundStarting = false;
        }
        texts[0].text = "Round " + EnemyCtrl.round ;
        texts[1].text =  time.ToString("F1");
        texts[2].text = "Cards : " + (52 - FokerManager.CardCount3).ToString();
        texts[3].text = gold.ToString();
        texts[4].text = PCctrl.hp.ToString();
        if (PCctrl.hp <= 0)
        {
            PlayerPrefs.SetInt("Round", 0);
            PlayerPrefs.SetInt("Gold", 0);
          
            Time.timeScale = 0.0f;
        }
    }
}
