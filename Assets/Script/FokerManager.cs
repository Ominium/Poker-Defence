using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card
{
    public Sprite sprites;
    public int Num;
    public string Patton;
    public Card(int a, string b, Sprite sprite)
    {
        Num = a;
        Patton = b;
        sprites = sprite;
    }
}
public class FokerManager : MonoBehaviour
{
    public GameObject Throwzone;
    public GameObject[] Enemys = new GameObject[50];
    public Button[] buttons = new Button[9];
    public Image[] images = new Image[5];
    public Sprite[] sprites = new Sprite[53];
    public Text Sc;
    public Text decktext;
    Card[] card = new Card[52];
    Card[] Usercard = new Card[9];
    Card[] Throwcard = new Card[5];
    string[] Patton = new string[4];
    string[] sc = new string[10];
    string k;
    public string result;
    float time = 0;
    int CardCount = 0;
    public static int CardCount2 =32;
    public static int CardCount3 = 0;
    public static float PokerDmg = 5;
    bool drewing = false;
    //bool Resulting = false;
    void Start()
    {
        for (int i = 0; i < Usercard.Length; i++)
        {
            Usercard[i] = new Card(1, "NULL", sprites[52]);
        }
        for (int i = 0; i < Throwcard.Length; i++)
        {
            Throwcard[i] = new Card(1, "NULL", sprites[52]);
        }
        Patton[0] = "Clover";
        Patton[1] = "Dieamond";
        Patton[2] = "Spade";
        Patton[3] = "Heart";
        sc[0] = "Top!";
        sc[1] = "One Pair!";
        sc[2] = "Two Pair!";
        sc[3] = "Triple!";
        sc[4] = "Straight!";
        sc[5] = "Flush!";
        sc[6] = "Full House!!";
        sc[7] = "Four Card!!";
        sc[8] = "Straight Flush!!!";
        sc[9] = "Royal Straight Flush!!!!";
        CardCount3 = CardCount;
        CardCreate();
    }
    public void CardThrow(int count)//카드 내는 함수
    {

        Throwzone.SetActive(true);
        for (int i = 0; i < images.Length; i++)
        {

            if (images[i].sprite != sprites[52])
            {
                continue;
            }
            else
            {
                images[i].sprite = buttons[count].GetComponent<Button>().image.sprite;
                Throwcard[i] = Usercard[count];
                buttons[count].GetComponent<Button>().image.sprite = sprites[52];
                return;

            }

        }

    }
    IEnumerator Carddrew()//카드 드로우 함수
    {
        drewing = true;
        for (int i = 0; i < Usercard.Length; i++)
        {
            if (!(CardCount3 == card.Length))
            {
                if (buttons[i].GetComponent<Button>().image.sprite == sprites[52])
                {

                    Usercard[i] = card[card.Length - CardCount3 - 1];
                    buttons[i].image.sprite = Usercard[i].sprites;
                    CardCount3++;
                    yield return new WaitForSeconds(1.5f);

                }
            }
            else if (CardCount3 == card.Length)
            {
                break;
            }
        }       
        drewing = false;
    }
    public void ThrowB()// 결과 창 보는 버튼 함수
    {
        int counts = 0;
        int straight = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Throwcard[i].Num > Throwcard[j].Num)
                {
                    Card card;
                    card = Throwcard[i];
                    Throwcard[i] = Throwcard[j];
                    Throwcard[j] = card;
                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i != j)
                {
                    if (Throwcard[i].Num != 1 && Throwcard[j].Num != 1)
                    {
                        if (Throwcard[i].Num == Throwcard[j].Num)
                        {
                            counts++;
                        }
                    }
                }
            }
        }
        if (Throwcard[0].Num != 1)
        {
            result = Throwcard[0].Num.ToString() + " " + sc[0];
            if (Throwcard[0].Num == 11) { result = "J " + sc[0]; }
            if (Throwcard[0].Num == 12) { result = "Q " + sc[0]; }
            if (Throwcard[0].Num == 13) { result = "K " + sc[0]; }
            if (Throwcard[0].Num == 14) { result = "A " + sc[0]; }
            if (Throwcard[0].Num == Throwcard[1].Num + 1 && Throwcard[1].Num + 1 == Throwcard[2].Num + 2
                && Throwcard[1].Num + 1 == Throwcard[3].Num + 3 &&
                Throwcard[1].Num + 1 == Throwcard[4].Num + 4)
            {
                straight++;
                result = sc[4];
            }
            if (Throwcard[0].Num == 14 && Throwcard[1].Num == 5
                && Throwcard[2].Num == 4 &&
                Throwcard[3].Num == 3 && Throwcard[4].Num == 2)
            {
                straight++;
                result = sc[4];
            }
            if (counts == 2)
            {
                result = sc[1];
            }
            if (counts == 4)
            {
                result = sc[2];
            }
            if (counts == 6)
            {
                result = sc[3];
            }
            if (counts == 8)
            {
                result = sc[6];
            }
            if (counts == 12)
            {
                result = sc[7];
            }
            if (Throwcard[0].Patton != "NULL")
            {
                if (Throwcard[0].Patton == Throwcard[1].Patton && Throwcard[0].Patton == Throwcard[2].Patton &&
                Throwcard[0].Patton == Throwcard[3].Patton
                    && Throwcard[0].Patton == Throwcard[4].Patton)
                {
                    result = sc[5];
                    straight++;
                }
            }
            if (straight == 2)
            {
                result = sc[8];

                if (Throwcard[0].Num == 14)
                {
                    result = sc[9];
                }
            }
        }
        if (Throwcard[0].Num == 1)
        {
            result = "카드를 넣어주세요!";
        }
        straight = 0;
        counts = 0;
        
        CardPower();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = sprites[52];
            Throwcard[i] = new Card(1, "NULL", sprites[52]);
        }
        StartCoroutine(TextResult(Sc));
        Throwzone.SetActive(false);
    }
    void CardPower()
    {
        int num = 0;         
       for(int i=0; i < sc.Length; i++)
        {
            if (result == sc[i])
            {
                num = i;
            }
        }
       if(result== "카드를 넣어주세요!")
        {
            num = -1;
        }
       PokerAttack(num);
    }
    void PokerAttack(int poker)
    {
        Transform tr;
        GameObject[] enemys;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");           
        int num = 0;
        tr = GetComponent<Transform>();
        tr.position = new Vector3(-17.35f, -3.23f, 0);
        for (int i = -1; i < poker; i++)
        {
            float distance = 4.5f + poker;
          
            if (enemys.Length > 0)
            {
                float d = 0;
                for (int j = 0; j < enemys.Length; j++)
                {
                    d = Vector3.Distance(enemys[j].transform.position, tr.position);
                    if (d < distance)
                    {
                        num++;
                        Enemys[num] = enemys[j];
                        distance = d;                    
                    }
                }
                for (int j = num; j > 0; j--)
                {
                    if (Enemys[j].GetComponent<Enemys>().hp > 0)
                    {
                        Enemys[j].GetComponent<Enemys>().hp -= (int)(Throwcard[0].Num * PokerDmg * (poker + 1));
                        Debug.Log(Enemys[j].GetComponent<Enemys>().hp);
                        break;
                    }
                }
            }
        }
    }
    public void DeckSuffle()
    {
        if (GameUI.gold >= 5)
        {
            GameUI.gold -= 5;
            CardCount3 = CardCount2;
            CardSuffle();
            result = "덱 교환 완료";
            decktext.color = Color.red;
            StartCoroutine(TextResult(decktext));
        }
        else
        {
            result = "골드가 부족합니다";
            decktext.color = Color.yellow;
            StartCoroutine(TextResult(decktext));
        }
    }
    public IEnumerator TextResult(Text text)
    {
        text.gameObject.SetActive(true);
        text.text = result;
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);        
    }
    void CardSuffle()
    {
        int rand;       
        for (int i = 0; i < card.Length; i++)
        {
            rand = Random.Range(0, 52);
            Card sfcard;
            sfcard = card[i];
            card[i] = card[rand];
            card[rand] = sfcard;
        }
    }
    void CardCreate()
    {
        int count = 0;
        for (int i = 1; i < 5; i++)
        {
            for (int j = 0; j < 13; j++)
            {          
                k = Patton[i-1];       
                card[count] = new Card(j + 2, k, sprites[count]);
                count++;
            }
        }
        CardSuffle();
    }  
    void Update()
    {      
        if (!drewing)
        {            
                StartCoroutine(Carddrew());
        }
    }
}
