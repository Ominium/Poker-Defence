using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int item_num;
    public char item_class;
    public string item_name;
    public int item_dmg;
    public string item_text;
    public Sprite item_sprite;
    public Item(int num,string a,int b,string c,Sprite d,char e)
    {
        item_num = num;
        item_name = a;
        item_text = c;
        item_dmg = b;
        item_sprite = d;
        item_class = e;
    }
    
    void Awake()
    {
        
    }
}
