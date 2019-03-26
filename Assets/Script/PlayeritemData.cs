using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(menuName = "Example/Create PlayeritemData Instance")]

public class PlayeritemData : ScriptableObject
{
    [SerializeField]
    public List<Items> itemList = new List<Items>();              //List of it

    public PlayeritemData() {}


    public Items GetItemByID(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].item_num == id)
                return itemList[i].getCopy();
        }
        return null;
    }
    public Items GetItemByName(string name)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].item_name.ToLower().Equals(name.ToLower()))
                return itemList[i].getCopy();
        }
        return null;
    }

    
}
