using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemUI : MonoBehaviour
{
    public InventoryManager inventory;
    public Button[] buttons =new Button[18];
    public Image image;
    public Text name;
    public Text text;
    int Save = 0;
    public void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.sprite = inventory.Playeritems[i].item_sprite;
        }
    }
    public void Sellitem()
    {
        for (int i = 0; i < inventory.Playeritems.Count; i++)
        {
            if (image.sprite == inventory.Playeritems[i].item_sprite&&image.sprite!=inventory.itemlist.itemList[0].item_sprite)
            {
                inventory.Playeritems.RemoveAt(i);
                buttons[Save].image.sprite = null;
                inventory.invens[Save].image.sprite = null;
                image.sprite = null;
                GameUI.gold += 50;
                break;
            }
        }
        inventory.UseUpdate();
    }
    public void infoClick(int Button)
    {
        Save = Button;
        image.sprite = inventory.Playeritems[Button].item_sprite;
        text.text = inventory.Playeritems[Button].item_text;
        name.text = inventory.Playeritems[Button].item_name;
    }
}
