using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public char item_class;
    public string item_name;
    public int item_dmg;
    public string item_text;
    public Sprite item_sprite;
    public Item(string a,int b,string c,Sprite d,char e)
    {
        item_name = a;
        item_name = c;
        item_dmg = b;
        item_sprite = d;
        item_class = e;
    }
    public Item[] items = new Item[30];
   

    void Awake()
    {
        items[0] = new Item("", 0, "", null, 'B');
        items[1] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[2] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[3] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[4] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[5] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[6] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[7] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[8] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[9] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[10] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[11] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[12] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[13] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[14] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[15] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[16] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[17] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[18] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[19] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[20] = new Item("번개 구슬", 30, "번개를 내리는 구슬", null, 'B');
        items[21] = new Item("번개 구슬", 50, "번개를 내리는 구슬", null, 'A');
        items[22] = new Item("번개 구슬", 50, "번개를 내리는 구슬", null, 'A');
        items[23] = new Item("번개 구슬", 50, "번개를 내리는 구슬", null, 'A');
        items[24] = new Item("번개 구슬", 50, "번개를 내리는 구슬", null, 'A');
        items[25] = new Item("번개 구슬", 50, "번개를 내리는 구슬", null, 'A');
        items[26] = new Item("번개 구슬", 50, "번개를 내리는 구슬", null, 'A');
        items[27] = new Item("번개 구슬", 80, "번개를 내리는 구슬", null, 'S');
        items[28] = new Item("번개 구슬", 80, "번개를 내리는 구슬", null, 'S');
        items[29] = new Item("번개 구슬", 80, "번개를 내리는 구슬", null, 'S');
    }
}
