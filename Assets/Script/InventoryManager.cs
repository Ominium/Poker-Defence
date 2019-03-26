using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public PlayeritemData data;
    public List<Button> invens = new List<Button>();
    public List<Button> useinvens = new List<Button>();
    public List<Items> Playeritems=new List<Items>();
   
    // Start is called before the first frame update
    public void invensClick1()
    {
        Debug.Log("000000000000");
    }
    public void invensClick(int Button)
    {
        Debug.Log("000000000000");

        if (invens[Button].image.sprite != null)
        {
            int num = 0;
           // Debug.Log(" ");
            for (int i = 0; i < useinvens.Count; i++)
            {
                if (useinvens[i].image.sprite == null)
                {
                    useinvens[i].image.sprite = invens[Button].image.sprite;
                    invens[Button].image.sprite = null;
                    break;
                }
                else num++;
            }
            if (num == useinvens.Count)
            {
                useinvens[0].image.sprite = invens[Button].image.sprite;
            }
        }
    }
    void OnEnable()
    {
        for (int i = 0; i < data.itemList.Count; i++)
        {
            Playeritems.Add(data.itemList[i]);
        }
        for (int i = 0; i <invens.Count; i++)
        {
            if (Playeritems.Count == i)
            {

                break;
            }
             invens[i].image.sprite = Playeritems[i].item_sprite;
        }
    }
    public void useinvensClick(int Button)
    {
        if (useinvens[Button].image.sprite != null)
        {
            int num = 0;
            for (int i = 0; i < invens.Count; i++)
            {
                if (invens[i].image.sprite == null)
                {
                    invens[i].image.sprite = useinvens[Button].image.sprite;
                    break;
                }
                else num++;
            }
            if (num == invens.Count)
            {
                Sprite sprite = invens[Button].image.sprite;
                invens[0].image.sprite = useinvens[Button].image.sprite;
                useinvens[Button].image.sprite = sprite;
            }
        }
    }

    
}
