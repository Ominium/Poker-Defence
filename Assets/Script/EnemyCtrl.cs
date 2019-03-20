using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class EnemyCtrl :MonoBehaviour
{
    
    public GameObject[] Enemy=new GameObject[10];
    int[] roundunit = new int[50];
    public Transform Respontr;
    int countunit = 0;
    public Text UnitCount;
    public Text RoundCount;
    public static int round;
    public static float Restime = 40.0f;
   
    public static bool RoundStarting = false;
    void Awake()
    {
        for (int i = 0; i < roundunit.Length; i++)
        {
            roundunit[i] = (i * 3 + 5) / 2;
        }
        round = PlayerPrefs.GetInt("Round");
        
        Respontr = GetComponent<Transform>();
    }
   
    void Start()
    {
        
    }
    IEnumerator RoundStart(int i)
    {
        Restime = 40.0f;
        RoundStarting = true;
        float z = Restime;

        countunit = roundunit[i];

        while (Restime>=0)
        {
           
            float x = 19.1f;
            float y = -2.5f;
            
            int rand = Random.Range(0, 9);
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
         
           
            StartCoroutine(RoundStart(round));
            round++;
        }
        if (round == 50)
        {
            StopCoroutine(RoundStart(round));
            RoundCount.gameObject.SetActive(true);
            RoundCount.text = "Game Clear !!";

        }
    }
   




}
