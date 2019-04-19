using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GachaManager : MonoBehaviour
{
    public Text[] texts = new Text[2];
    public PlayeritemData inventory;
    public ItemDataBaseList baseList;
    public Text goldtext;
    Items item;
    public void GachaButton(int i)
    {
        if (GameUI.gold > i * 100)
        {
            for (int m = 0; m < i; m++)
            {


                int random;
                random = Random.Range(0, 100);
                if (random < 70)
                {
                    int random2;
                    random2 = Random.Range(1, 6);
                    item = baseList.itemList[random2];
                    if (inventory.itemList.Count < 20)
                    {
                        for (int k = 0; k < inventory.itemList.Count; k++)
                        {
                            if (inventory.itemList[k].item_num == 0)
                            {
                                inventory.itemList[k] = item;
                                break;
                            }
                        }
                    }
                }
                if (random >= 70)
                {
                    int random2;
                    random2 = Random.Range(6, 10);
                    item = baseList.itemList[random2];
                    if (inventory.itemList.Count < 20)
                    {
                        for (int k = 0; k < inventory.itemList.Count; k++)
                        {
                            if (inventory.itemList[k].item_num == 0)
                            {
                                inventory.itemList[k] = item;
                                break;
                            }
                        }
                    }
                }
                GameUI.gold -= i * 100;
                PlayerPrefs.SetInt("Gold", GameUI.gold);
            }
        }
        else
        {
            StartCoroutine(TextResult(goldtext));
        }
    }
    public IEnumerator TextResult(Text text) // 텍스트를 ON OFF 하는 함수
    {
        
        text.gameObject.SetActive(true);
        text.text = "골드가 부족합니다!";
        text.color = Color.yellow;
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = GameUI.gold.ToString();
        texts[1].text = GameUI.gold2.ToString();
    }
}
