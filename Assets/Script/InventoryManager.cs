using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class InventoryManager : MonoBehaviour
{
    public Text Failtext;
    public PlayeritemData data;
    public ItemDataBaseList itemlist;
    public List<Button> invens = new List<Button>();
    public List<Button> useinvens = new List<Button>();
    public List<Items> Playeritems=new List<Items>();
    public List<Items> UsePlayeritems = new List<Items>();
    bool getgold = false;
    int[] Uitemint = new int[3];
    bool[] itemuse = new bool[21];
    // Start is called before the first frame update
    public  void UseUpdate()
    {
        for (int i = 0; i < invens.Count; i++)
        {
            if (Playeritems.Count == i)
            {

                break;
            }
            invens[i].image.sprite = Playeritems[i].item_sprite;
        }
        for (int i = 0; i < useinvens.Count; i++)
        {
            useinvens[i].image.sprite = UsePlayeritems[i].item_sprite;
        }
        ItemSet();
        for(int i = 0; i < itemuse.Length; i++)
        {
            Debug.Log(itemuse[i] + i.ToString());
        }  
    }
    void ItemSet()
    {
        for(int i=0; i < itemuse.Length; i++)
        {
            itemuse[i] = false;
        }
        for (int i = 0; i < UsePlayeritems.Count; i++)
        {
            for (int j = 1; j < itemuse.Length; j++)
            {               
                if (UsePlayeritems[i] == itemlist.itemList[j])
                {
                    itemuse[j] = true;
                }                
            }
        }
    }
   
    public void invensClick(int Button)
    {
        bool NoChange = false;

        if (Playeritems[Button] != itemlist.itemList[0])
        {

            for (int Useritems = 0; Useritems < UsePlayeritems.Count; Useritems++)
            {
                if (UsePlayeritems[Useritems] == Playeritems[Button])
                {
                    NoChange = true;
                }

            }
            if (!NoChange)
            {
              
                for (int i = 0; i < UsePlayeritems.Count; i++)
                {

                    if (UsePlayeritems[i].item_sprite == Playeritems[Button].item_sprite)
                    {
                        StartCoroutine(TextResult(Failtext));
                        break;
                    }                                       
                    if (UsePlayeritems[i] == itemlist.itemList[0])
                    {
                        UsePlayeritems[i] = Playeritems[Button];
                        Uitemint[i] = Playeritems[Button].item_num;
                            break;                       
                    }
                }
            }
            PlayerPrefs.SetInt("Uitem1", Uitemint[0]);
            PlayerPrefs.SetInt("Uitem2", Uitemint[1]);
            PlayerPrefs.SetInt("Uitem3", Uitemint[2]);
            UseUpdate();
        }
    }
    public IEnumerator TextResult(Text text) // 텍스트를 ON OFF 하는 함수
    {
        text.gameObject.SetActive(true);
        text.text = "아이템은 중복으로 착용 할 수 없습니다";
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);
    }
    void Awake()
    {
        Uitemint[0] = PlayerPrefs.GetInt("Uitem1");
        Uitemint[1] = PlayerPrefs.GetInt("Uitem2");
        Uitemint[2] = PlayerPrefs.GetInt("Uitem3");
        for (int i = 0; i < UsePlayeritems.Count; i++)
        {
            UsePlayeritems[i] =itemlist.itemList[Uitemint[i]];
        }
        for (int i = 0; i < data.itemList.Count; i++)
        {
            Playeritems[i]=data.itemList[i];
        }
      
        UseUpdate();
        gameObject.SetActive(false);
    }
    public void useinvensClick(int Button)
    {
        if (UsePlayeritems[Button] != itemlist.itemList[0])
        {
            UsePlayeritems[Button] = itemlist.itemList[0];
            UseUpdate();
        }
    }
    void Update()
    {
       
    }
    

    void ItemResult()
    {
        
        if (itemuse[1])
        {

 
        }
        if (itemuse[2])
        {

        }
        if (itemuse[3])
        {

        }
        if (itemuse[4])
        {

        }
        if (itemuse[5])
        {

        }
        if (itemuse[6])
        {

        }
        if (itemuse[7])
        {

        }
        if (itemuse[8])
        {

        }
        if (itemuse[9])
        {

        }
        if (itemuse[10])
        {

        }
        if (itemuse[11])
        {
            PCctrl.Ammor = 5;
        }
        if (itemuse[12]&&!getgold)
        {
            GameUI.gold += 300;
            getgold = true;
        }
        if (itemuse[13])
        {
            PCctrl.Ammor = 7;
        }
        if (itemuse[14])
        {

        }
        if (itemuse[15])
        {
            
        }
        if (itemuse[16])
        {

        }
        if (itemuse[17])
        {

        }
        if (itemuse[18])
        {

        }
        if (itemuse[19])
        {
            PCctrl.Ammor = 10;
        }
        if (itemuse[20])
        {

        }
        if (!itemuse[19] && !itemuse[11] && !itemuse[13])
        {
            PCctrl.Ammor = 0;
        }
    } 
}
