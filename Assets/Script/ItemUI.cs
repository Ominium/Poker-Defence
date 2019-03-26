using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemUI : MonoBehaviour
{
    
    public ItemDataBaseList ItemDataBaseList;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
       if(image.sprite ==ItemDataBaseList.itemList[0].item_sprite)
        {
            Items items = ItemDataBaseList.itemList[0];
            GameObject enemys = GameObject.FindGameObjectWithTag("Enemy");
            enemys.GetComponent<Enemys>().hp -= items.item_dmg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
