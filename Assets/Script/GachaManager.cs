﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GachaManager : MonoBehaviour
{
    public Text[] texts = new Text[2];
    public PlayeritemData inventory;
    public ItemDataBaseList baseList;
    Items item;
    public void GachaButton(int i)
    {
        for (int m = 0; m < i; m++)
        {


            int random;
            random = Random.Range(0, 100);
            if (random < 70)
            {
                int random2;
                random2 = Random.Range(0, 5);
                item = baseList.itemList[random2];
                if (inventory.itemList.Count < 20)
                {
                    inventory.itemList.Add(item);
                }
            }

            GameUI.gold -= i * 100;
        }
    }
    public void BackMain()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        texts[0].text = GameUI.gold.ToString();
        texts[1].text = GameUI.gold2.ToString();
    }
}
