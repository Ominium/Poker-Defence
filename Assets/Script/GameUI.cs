using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
  
    public int[] UpgradeState = new int[4];
    public Text[] texts = new Text[5];
    public Text failtext;
    public static float time = 40.0f;
    public static int gold = 0;
    public static int gold2 = 0;
    public static string name = "";
    public FokerManager foker;
    Item[] items = new Item[30];
    Item[] useritems = new Item[18];
    Item[] use_useritems = new Item[3];
    int[] use_useritemnum = new int[18];
    string[] use_useritemstr = new string[3];
    int[] useritemnum = new int[18];
    string[] useritemstr = new string[18];
    // Start is called before the first frame update
    void Awake()
    {
       for(int i =0; i < items.Length; i++)
        {
            items[i] = new Item(i, "번개", 30, "번개 내려오는 구슬", null, 'B');
            if (i > 20)
            {
                items[i].item_class = 'A';
            }
            if (i > 27)
            {
                items[i].item_class = 'S';
            }
        }
        items[0].item_sprite= Resources.Load("item_01", typeof(Sprite)) as Sprite;
        for (int i = 0; i < useritemstr.Length; i++)
        {
            useritemstr[i] = "User" + i.ToString();
        }
        for (int i = 0; i < useritemnum.Length; i++)
        {
            useritemnum[i] = PlayerPrefs.GetInt(useritemstr[i]);
        }
        for (int i = 0; i < useritems.Length; i++)
        {
            useritems[i] = items[useritemnum[i]];
        }
        for(int i=0; i < use_useritemstr.Length; i++)
        {
            use_useritemstr[i] = "Use_User" + i.ToString();
        }
        for (int i = 0; i < useritemnum.Length; i++)
        {
            use_useritemnum[i] = PlayerPrefs.GetInt(use_useritemstr[i]);
        }
        for (int i = 0; i < useritems.Length; i++)
        {
           use_useritems[i] = items[useritemnum[i]];
        }
        gold = PlayerPrefs.GetInt("Gold");
        UpgradeState[0] = PlayerPrefs.GetInt("UP0");
        UpgradeState[1] = PlayerPrefs.GetInt("UP1");
        UpgradeState[2] = PlayerPrefs.GetInt("UP2");
        UpgradeState[3] = PlayerPrefs.GetInt("UP3");
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
        PlayerPrefs.SetInt("UP0",UpgradeState[0]);
        PlayerPrefs.SetInt("UP1", UpgradeState[1]);
        PlayerPrefs.SetInt("UP2", UpgradeState[2]);
        PlayerPrefs.SetInt("UP3",UpgradeState[3]);

    }
    public void UpGradeFunction(int i)
    {
        bool Failed = false;
        if (gold >= UpgradeState[i] * 10 + 5)
        {          
            if (i == 0)
            {
                if (PCctrl.mhp < 200)
                {
                    PCctrl.mhp += 5;
                    PCctrl.hp = PCctrl.mhp;
                    GoldUse(i);
                }
                else Failed = true;
            }
            if (i == 1)
            {
                if (PCctrl.Ammor < 20)
                {
                    PCctrl.Ammor += 1;
                    GoldUse(i);
                }
            }
            if (i == 2)
            {
                if (FokerManager.PokerDmg < 15f)
                {
                    FokerManager.PokerDmg += 0.5f;
                    GoldUse(i);
                }
                else Failed = true;
            }
            if (i == 3)
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
        texts[1].text =  time.ToString("F1");
        texts[2].text = "Cards : " + (52 - FokerManager.CardCount3).ToString();
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
            for (int i = 0; i < useritems.Length; i++)
            {
                PlayerPrefs.SetInt(useritemstr[i], useritems[i].item_num);
            }
            for(int i = 0; i < use_useritems.Length; i++)
            {
                PlayerPrefs.SetInt(use_useritemstr[i], use_useritems[i].item_num);
            }
            Time.timeScale = 0.0f;
        }
    }
}
