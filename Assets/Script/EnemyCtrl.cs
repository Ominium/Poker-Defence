using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class EnemyCtrl :MonoBehaviour
{
    
    public GameObject[] Enemy=new GameObject[10];
    int[] roundunit = new int[51];
    public Transform Respontr;
    int countunit = 0;
    public Text UnitCount;
    public Text RoundCount;
    public static int round;
    public static float Restime = 40f;
    int rand2;
    int rand3;
    int num2;
    int num3;
   
    public static bool RoundStarting = false;
    void Awake()
    {
        for (int i = 0; i < roundunit.Length; i++)
        {
            roundunit[i] = (i * 2 + 5) / 2;
        }
        round = PlayerPrefs.GetInt("Round");
        
        Respontr = GetComponent<Transform>();
    }
   
    void Start()
    {
        
    }
    IEnumerator RoundStart(int i)
    {
        Restime = 40f;
        RoundStarting = true;
        float z = Restime;

        countunit = roundunit[i];

        while (Restime>=0)
        {
           
            float x = 19.1f;
            float y = -2.5f;
            
            int rand = Random.Range(rand2, rand3);
            GameObject a = Instantiate(Enemy[rand]);
           
            
            a.transform.position = new Vector3(x, y, 0);
            countunit--;
            UnitCount.text = "X " + countunit.ToString();
            if (countunit == 0)
            {
                break;
            }
            yield return new WaitForSeconds(z / roundunit[i]);
           
            Restime -= z / roundunit[i];
          
        }
       
        
    }
    void Update()
    {
        
        if (!RoundStarting)
        {

            RoundGo();
            StartCoroutine(RoundStart(round));
            round++; 
           
        }
        


    }
   void RoundGo()
    {      
        switch (round-1 / 5)
        {
            case 10:
                if (round - 1 % 5 == 0)
                {
                    roundunit[round] = 1;
                    rand2 = 9;
                    rand3 = 10;
                }

                break;
            case 9:
                num2 = 5;
                num3 = 9;
                Substitution(ref rand2, ref rand3);
                break;
            case 8:
                if (round - 1 % 5 == 0)
                {
                    roundunit[round] = 1;
                    rand2 = 9;
                    rand3 = 10;
                }
                if (round - 1 % 5 != 0)
                {
                    Substitution(ref rand2, ref rand3);
                }
                break;
            case 7:
                num2 = 4;
                num3 = 8;
                Substitution(ref rand2, ref rand3);
                break;
            case 6:
                if (round - 1 % 5 == 0)
                {
                    roundunit[round] = 1;
                    rand2 = 9;
                    rand3 = 10;
                }
                if (round - 1 % 5 != 0)
                {

                    Substitution(ref rand2, ref rand3);
                }
                break;
            case 5:
                num2 = 3;
                num3 = 6;
                Substitution(ref rand2, ref rand3);
                break;
            case 4:
                if (round - 1 % 5 == 0)
                {
                    roundunit[round] = 1;
                    rand2 = 9;
                    rand3 = 10;
                }
                if (round - 1 % 5 != 0)
                {
                    Substitution(ref rand2, ref rand3);
                }
                break;
            case 3:
                num2 = 2;
                num3 = 4;
                Substitution(ref rand2, ref rand3);
                break;
            case 2:
                if (round - 1 % 5 == 0)
                {
                    roundunit[round] = 1;
                    rand2 = 9;
                    rand3 = 10;
                }
                if (round - 1 % 5 != 0)
                {

                    Substitution(ref rand2, ref rand3);

                }
                break;
            case 1:
                num2 = 1;
                num3 = 3;
                Substitution(ref rand2,ref rand3);
                break;
            default:
                num2 = 0;
                num3 = 2;
                Substitution(ref rand2,ref rand3);
                Debug.Log(rand3);
                break;

        }

        if (round == 51)
        {
            StopCoroutine(RoundStart(round));
            RoundCount.gameObject.SetActive(true);
            RoundCount.text = "Game Clear !!";

        }
    }
    void Substitution(ref int rand2,ref int rand3)
    {
        rand2 = num2;
        rand3 = num3;
    }
    // 매개변수가 바뀌어서 이상해보였
    // 보통은 num2 = rand2 이렇게 쓰니깐


}
