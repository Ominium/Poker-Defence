using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class InventoryManager : MonoBehaviour
{
    public PlayeritemData data;
    public ItemDataBaseList itemlist;
    public List<Button> invens = new List<Button>();
    public List<Button> useinvens = new List<Button>();
    public List<Items> Playeritems=new List<Items>();
    public List<Items> UsePlayeritems = new List<Items>();

    // Start is called before the first frame update
    public  void UseUpdate()
    {
        for (int i = 0; i < useinvens.Count; i++)
        {
            if (UsePlayeritems.Count == i)
            {

                break;
            }
            useinvens[i].image.sprite = UsePlayeritems[i].item_sprite;
        }     
    }
    
   
    public void invensClick(int Button)
    {
        bool NoChange = false;

        if (invens[Button].image.sprite != null)
        {
            int num = 0;
            int m = 0;
            for (int Useritems = 0; Useritems < UsePlayeritems.Count; Useritems++)
            {
                if (UsePlayeritems[Useritems].item_sprite == invens[Button].image.sprite)
                {
                    NoChange = true;
                }

            }
            if (!NoChange)
            {
                for (int i = 0; i < itemlist.itemList.Count; i++)
                {
                    if (invens[Button].image.sprite == itemlist.itemList[i].item_sprite)
                    {
                        m = i;
                        for (int j = 0; j < UsePlayeritems.Count; j++)
                        {
                            if (UsePlayeritems[j].item_num == 0)
                            {
                                UsePlayeritems[j] = itemlist.itemList[i];
                                break;
                            }
                            else num++;
                        }

                    }
                }
                if (num == UsePlayeritems.Count)
                {
                    UsePlayeritems[0] = itemlist.itemList[m];
                }
            }
            UseUpdate();
        }
    }
    void Awake()
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
        UseUpdate();
        gameObject.SetActive(false);
    }
    public void useinvensClick(int Button)
    {
        if (UsePlayeritems[Button] != null)
        {
            UsePlayeritems[Button] = null;
        }
    }

    
}
