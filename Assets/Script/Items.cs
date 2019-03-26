using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Items 
{
    public enum itemclass
    {
        C=0,
        B=1,
        A=2,
        S=3,
    }
    public int item_num;
    public itemclass item_class;
    public string item_name;
    public int item_dmg;
    public string item_text;
    public Sprite item_sprite;
    [SerializeField]
    public List<ItemAttribute> item_Attributes = new List<ItemAttribute>();

    public Items() { }
    public Items(int num,string a,int b,string c,Sprite d,itemclass e,List<ItemAttribute> lists)
    {
        item_num = num;
        item_name = a;
        item_text = c;
        item_dmg = b;
        item_sprite = d;
        item_class = e;
        item_Attributes = lists;
    }
  
    public Items getCopy()
    {
        return (Items)this.MemberwiseClone();
    }
    void Awake()
    {
        
    }
}
