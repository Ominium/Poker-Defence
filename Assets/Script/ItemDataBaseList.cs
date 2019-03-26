using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBaseList : ScriptableObject
{             //The scriptableObject where the Item getting stored which you create(ItemDatabase)

    [SerializeField]
    public List<Items> itemList = new List<Items>();              //List of it

    public Items getItemByID(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].item_num == id)
                return itemList[i].getCopy();
        }
        return null;
    }

    public Items getItemByName(string name)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].item_name.ToLower().Equals(name.ToLower()))
                return itemList[i].getCopy();
        }
        return null;
    }
}
