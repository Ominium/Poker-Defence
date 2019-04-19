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
    public static bool Pokering = false;
    public GameObject Throwzone;//Thorw 시 나오는 패널
    public GameObject Lightning;
    public GameObject[] Enemys = new GameObject[50];// Enemy GameObject 배열을 담아둘 GameObject 배열
    public Button[] buttons = new Button[9]; // 드로우 카드 Button 배열
    public Image[] images = new Image[5];// 쓰로우 카드 Image 배열
    public Sprite[] sprites = new Sprite[53]; //포커 Sprite 
    public Text Sc; // 포커 족보 text
    public Text decktext; // 덱 리스트 숫자
    Card[] card = new Card[52]; // 기본 카드 배열
    Card[] Usercard=new Card[9]; // 유저 드로우 카드 배열
    Card[] Throwcard = new Card[5]; // 유저 쓰로우 카드 배열
    string[] Patton = new string[4]; // 카드 문양
    string[] sc = new string[10]; // 포커 족보 string 값
    string k; // 전달받을 string 값
    public string result; // text 에 전달할 string 값
    float time = 0;
    int CardCount = 0; // 처음 구매 카운트
    public static int CardCount2 =32; // 추가 구매 카운트
    public static int CardCount3 = 0; // 실제 카운트
    public static float PokerDmg = 5; // 포커 데미지 배수 값
    bool drewing = false; // 드로우 코루틴 함수 bool 값
    public static float Drewspeed = 1.5f;
    void Awake()
    {

    }
    void Start() 
    {
        for (int i = 0; i < Usercard.Length; i++) // 시작시 유저 카드 초기화
        {
            Usercard[i] = new Card(1, "NULL", sprites[52]);
        }
        for (int i = 0; i < Throwcard.Length; i++) // 시작시 쓰로우 카드 초기화
        {
            Throwcard[i] = new Card(1, "NULL", sprites[52]);
        }
        // 문양과 족보 설정
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
                    yield return new WaitForSeconds(Drewspeed);

                }
            }
            else if (CardCount3 == card.Length)
            {
                break;
            }
        }       
        drewing = false;
    }
    public void ThrowB()// 결과 창 보는 버튼 함수 , 카드 족보 판별
    {
        int counts = 0;
        int straight = 0;
        for (int i = 0; i < 5; i++) // for 문 을 이용해  카드 정렬
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
        if (Throwcard[0].Num != 1) // Top 일때 높은 수를 불러줌
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
        for (int i = 0; i < images.Length; i++) // 족보 전달 후 초기화
        {
            images[i].sprite = sprites[52];
            Throwcard[i] = new Card(1, "NULL", sprites[52]);
        }
        StartCoroutine(TextResult(Sc));
        Throwzone.SetActive(false);
    }
    void CardPower() // 포커 정렬 전달 함수
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
    void PokerAttack(int poker) // 포커 공격 함수
    {
        Pokering = true;
        Transform tr;
        GameObject[] enemys;
        GameObject game;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");           
        int num = 0;
        float distance;
        float distance2;
        tr = GetComponent<Transform>();
        tr.position = new Vector3(-17.35f, -3.23f, 0);
        for (int i = -1; i < poker; i++)
        {
            distance = 10.5f + (poker*3);
          
            if (enemys.Length > 0)
            {
                float d = 0;
                for (int j = 0; j < enemys.Length; j++)
                {
                    d = Vector3.Distance(enemys[j].transform.position, tr.position);
                    if (d < distance)
                    {                      
                        Enemys[num] = enemys[j];
                        num++;
                    }
                }
                for (int j = 0; j < num; j++)
                {
                    distance2 = Vector3.Distance(Enemys[0].transform.position, tr.position);
                    float dis = Vector3.Distance(Enemys[j].transform.position, tr.position);
                    if (dis < distance2)
                    {
                        game = Enemys[0];
                        Enemys[0] = Enemys[j];
                        Enemys[j] = game;
                    }
                }
                for (int j = 0; j < num; j++)
                {
                    if (Enemys[j].GetComponent<Enemys>().hp > 0)
                    {

                        LightAttack(Enemys[j].transform);
                        Enemys[j].GetComponent<Enemys>().hp -= (int)(Throwcard[0].Num * PokerDmg * (poker + 1));
                        break;
                    }
                }
            }
        }
        Pokering = false;
    }
    void LightAttack(Transform enemy)
    {
        GameObject a = Lightning;
        a.transform.position = enemy.position;
        Instantiate(a,a.transform.position,a.transform.rotation);
       
    }
    public void DeckSuffle() // 덱 추가 구매 섞기
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
    public IEnumerator TextResult(Text text) // 텍스트를 ON OFF 하는 함수
    {
        text.gameObject.SetActive(true);
        text.text = result;
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);        
    }
    void CardSuffle()// 카드 섞기
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
    void CardCreate()//카드 만들기
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
        if (!drewing)// 카드 드로우 
        {            
                StartCoroutine(Carddrew());
        }
    }
}
