using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    public int[] UpgradeState = new int[6];
    public Text[] texts = new Text[5];
    public Text[] statustext = new Text[5];
    public Text failtext;
    public GameObject upgrademenu;
    public GameObject gamemenu;
    public GameObject statusmenu;
    public static float time = 40.0f;
    public static int gold = 0;
    public static string name = "";
    public FokerManager foker;  
    // Start is called before the first frame update
    void Awake()
    {
        gold = PlayerPrefs.GetInt("Gold");
        UpgradeState[0] = PlayerPrefs.GetInt("UP0");
        UpgradeState[1] = PlayerPrefs.GetInt("UP1");
        UpgradeState[2] = PlayerPrefs.GetInt("UP2");
        UpgradeState[3] = PlayerPrefs.GetInt("UP3");
        UpgradeState[4] = PlayerPrefs.GetInt("UP4");
        UpgradeState[5] = PlayerPrefs.GetInt("UP5");
    }
    void StatusOpen()
    {
        statustext[0].text = "User name : " + name;
        statustext[1].text = "HP : " + PCctrl.hp.ToString()+"  Ammor : "+PCctrl.Ammor.ToString();
        statustext[2].text = "Arrow Dmg : "+ArrowMove.dmg.ToString()+"  Arrow Dms : " + PCctrl.dms.ToString();
        statustext[3].text = "Poker Dmg : X" + FokerManager.PokerDmg.ToString() + "  Poker Reload : " + (52-FokerManager.CardCount2).ToString();
        statustext[4].text = "Next Round : " + (EnemyCtrl.round + 1).ToString() + "  Gold : " + gold.ToString();

    }
    public void MenuManager(int i)
    {
        if (i == 0)
        {
            upgrademenu.SetActive(true);
        }
        if (i == 1)
        {
            statusmenu.SetActive(true);
            upgrademenu.SetActive(false);
            StatusOpen();
        }
    }
    public void ExitB(GameObject game)
    {
        game.SetActive(false);
    }
    public void GameManager()
    {
        gamemenu.SetActive(true);
    }
    public void Continue()
    {
        gamemenu.SetActive(false);
    }
    public void ExitB2()
    {
        Application.Quit();
    }
    public void SaveB()
    {
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Round", EnemyCtrl.round);
        PlayerPrefs.SetInt("UP0",UpgradeState[0]);
        PlayerPrefs.SetInt("UP1", UpgradeState[1]);
        PlayerPrefs.SetInt("UP2", UpgradeState[2]);
        PlayerPrefs.SetInt("UP3",UpgradeState[3]);
        PlayerPrefs.SetInt("UP4", UpgradeState[4]);
        PlayerPrefs.SetInt("UP5", UpgradeState[5]);
    }
    public void UpGradeFunction(int i)
    {
        bool Failed = false;
        if (gold >= UpgradeState[i] * 10 + 5)
        {
            if (i == 0)
            {
                if (ArrowMove.dmg < 110)
                {
                    ArrowMove.dmg += 5;
                    GoldUse(i);
                }
                else Failed = true;
            }
            if (i == 1)
            {
                if (PCctrl.dms > 0.5f)
                {
                    PCctrl.dms -= 0.05f;
                    GoldUse(i);
                }
                else Failed = true;
            }
            if (i == 2)
            {
                if (PCctrl.mhp < 200)
                {
                    PCctrl.mhp += 5;
                    PCctrl.hp = PCctrl.mhp;
                    GoldUse(i);
                }
                else Failed = true;
            }
            if (i == 3)
            {
                if (PCctrl.Ammor < 20)
                {
                    PCctrl.Ammor += 1;
                    GoldUse(i);
                }
            }
            if (i == 4)
            {
                if (FokerManager.PokerDmg < 15f)
                {
                    FokerManager.PokerDmg += 0.5f;
                    GoldUse(i);
                }
                else Failed = true;
            }
            if (i == 5)
            {
                if (FokerManager.CardCount2 < 50)
                {
                    FokerManager.CardCount2 += 5;
                    GoldUse(i);
                }
                else Failed = true;
            }
        }
        else
        {
            foker.result = "골드가 부족합니다";
            failtext.color = Color.yellow;
            StartCoroutine( foker.TextResult(failtext));     
        }
        if (Failed)
        {
            foker.result = "업그레이드가 최대 강화 수치입니다";
            failtext.color = Color.green;
            StartCoroutine( foker.TextResult(failtext)); 
        }
    }

    void GoldUse(int i)
    {
      
        gold -= (UpgradeState[i] * 10 + 5);
        UpgradeState[i]++;
        foker.result = "업그레이드가 완료되었습니다";
        failtext.color = Color.white;
        StartCoroutine(foker.TextResult(failtext));

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
        texts[1].text = "Time : " + time.ToString("F1");
        texts[2].text = "Card Deck : " + (52 - FokerManager.CardCount3).ToString();
        texts[3].text = gold.ToString();
        texts[4].text = PCctrl.hp.ToString();
        if (PCctrl.hp <= 0)
        {
            PlayerPrefs.SetInt("Round", 0);
            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("UP0", UpgradeState[0]);
            PlayerPrefs.SetInt("UP1", UpgradeState[1]);
            PlayerPrefs.SetInt("UP2", UpgradeState[2]);
            PlayerPrefs.SetInt("UP3", UpgradeState[3]);
            PlayerPrefs.SetInt("UP4", UpgradeState[4]);
            PlayerPrefs.SetInt("UP5", UpgradeState[5]);
            Time.timeScale = 0.0f;
        }
    }
}
