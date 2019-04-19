using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    float time1 = 0;
    float time2 = 0;
    float time3 = 0;
    float time4= 0;
    float time5 = 0;
    float time6 = 0;
    float time7 = 0;
    float time8 = 0;
    float time9 = 0;
    
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
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void useinvensClick(int Button)
    {
        if (UsePlayeritems[Button] != itemlist.itemList[0])
        {
            UsePlayeritems[Button] = itemlist.itemList[0];
           
        }
        UseUpdate();
    }
    void Update()
    {
        ItemResult();
    }
    

    void ItemResult()
    {
        
        
        if (itemuse[1])
        {
           
            time1 += Time.deltaTime;
            if (time1 > 1.5f)
            {
                GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < EnemyGame.Length; i++)
                {
                    EnemyGame[i].GetComponent<Enemys>().hp -= 5;
                }
                time1 = 0;
            }
 
        }
        if (itemuse[2])
        {
            
            GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < EnemyGame.Length; i++)
            {
                EnemyGame[i].GetComponent<Enemys>().Changemovs = (-1.0f);
            }
        }
        if (itemuse[3])
        {
            
            time2 += Time.deltaTime;
            if (time2 > 3f)
            {
                if (PCctrl.hp <= PCctrl.mhp)
                {
                    PCctrl.hp += 5;
                }
                time2 = 0;
            }
        }
        if (itemuse[4])
        {
            float time = 0;
            time += Time.deltaTime;
            if (time > 3f)
            {
                FokerManager.CardCount3--;
                time = 0;
            }
        }
        if (itemuse[5])
        {
            
            time3 += Time.deltaTime;
            if (time3 > 3f)
            {
                int rand;
                rand = Random.Range(0, 15);
                GameUI.gold += rand;
                time3 = 0;
            }

        }
        if (itemuse[6])
        {
            GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i=0; i < EnemyGame.Length; i++)
            {
                if (EnemyGame[i].GetComponent<Enemys>().Hiting == true)
                {
                    EnemyGame[i].GetComponent<Enemys>().hp -= 5;
                }
            }
        }
        if (itemuse[7])
        {
            PCctrl.dodgeper = 0.25f;
        }
        if (itemuse[8])
        {
            
            time4 += Time.deltaTime;
            if (time4 > 3.5f)
            {
                GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < EnemyGame.Length; i++)
                {
                    EnemyGame[i].GetComponent<Enemys>().hp -= 30;
                }
                time4 = 0;
            }
        }
        if (itemuse[9])
        {
            FokerManager.Drewspeed = 1.2f;
        }
        if (itemuse[10])
        {
            
            time5 += Time.deltaTime;
            if (time5 > 3f)
            {
                if (PCctrl.hp <= PCctrl.mhp)
                {
                    PCctrl.hp += 8;
                }
                time5 = 0;
            }
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
            if (FokerManager.Pokering)
            {
                GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < EnemyGame.Length; i++)
                {
                    if (EnemyGame[i].GetComponent<Enemys>().Hoting)
                    {
                        PCctrl.hp += (int)FokerManager.PokerDmg;
                    }
                }

            }
        }
        if (itemuse[15])
        {
           
            time6 += Time.deltaTime;
            if (time6 > 2.0f)
            {
                GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < EnemyGame.Length; i++)
                {
                    EnemyGame[i].GetComponent<Enemys>().hp -= 50;
                }
                time6 = 0;
            }
        }
        if (itemuse[16])
        {
           
            float Orimovs = 0;
            time7 += Time.deltaTime;
            time8 += Time.deltaTime;
            GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
            if (time8 > 1f) {
                for (int i = 0; i < EnemyGame.Length; i++)
                {
                    Orimovs = EnemyGame[i].GetComponent<Enemys>().movs;
                    EnemyGame[i].GetComponent<Enemys>().movs = 0;
                }
                time8 = 0;
            }
            if (time7 > 2.0f)
            {
                for (int i = 0; i < EnemyGame.Length; i++)
                {
                    EnemyGame[i].GetComponent<Enemys>().movs = Orimovs;
                }
                time7 = 0;
            }
        }
        if (itemuse[17])
        {
            GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < EnemyGame.Length; i++)
            {
                if (EnemyGame[i].GetComponent<Enemys>().Hiting)
                {
                    EnemyGame[i].GetComponent<Enemys>().hp -= EnemyGame[i].GetComponent<Enemys>().dmg;
                }
            }
        }
        if (itemuse[18])
        {
            PCctrl.dodgeper = 0.5f;
        }
        if (itemuse[19])
        {
            PCctrl.Ammor = 10;
        }
        if (itemuse[20])
        {
            
            int rand = 0;
            rand = Random.Range(0, 10);
            time9 += Time.deltaTime;
            if (time9 > 2.0f)
            {
                GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
                if (EnemyGame.Length > 0)
                {
                    if (rand > 5)
                    {
                        EnemyGame[0].GetComponent<Enemys>().hp = 0;
                    }
                }
                time9 = 0;
            }
        }
        if (!itemuse[2])
        {
            GameObject[] EnemyGame = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < EnemyGame.Length; i++)
            {
                EnemyGame[i].GetComponent<Enemys>().Changemovs = 0f;
            }
        }
        if (!itemuse[7] && !itemuse[18])
        {
            PCctrl.dodgeper = 0;
        }
        if (!itemuse[19] && !itemuse[11] && !itemuse[13])
        {
            PCctrl.Ammor = 0;
        }
    } 
}
