
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PCctrl : MonoBehaviour
{
    public Image hpbar;
    public GameObject Arrow;
    public Text hptext;
    public List<GameObject> Arrows = new List<GameObject>();
    public GameObject tr;
    Transform start;
    public static int hp = 100;
    public static int mhp;
    public int lhp;
    
    public int Tdam = 10;
    float dis = 2.5f;
    bool Hoting = false;
    int damaged;
    public static float dms = 1.5f;
    public static int Ammor = 0;
    float x = -17.02f;
    float y = -2.78f;
    bool Hiting = false;
    void Start()
    {
        mhp = hp;
        lhp = hp;
    }
    void Hot()
    {
        if (lhp != hp)
        {
            damaged = lhp - hp;
            Hoting = true;
            lhp = hp;
        }
    }
    IEnumerator ShowDamage()
    {
        if (Hoting)
        {
            hptext.gameObject.SetActive(true);
            hptext.text = "-"+damaged.ToString();
            Hoting = false;
            yield return new WaitForSeconds(0.7f);
            hptext.gameObject.SetActive(false);
        }
    }
    void ArrowShot(List<GameObject> list)
    {

        GameObject a = Arrow;
        list.Add(a);
        
        a.transform.position = new Vector3(x,y,0);
        Instantiate(a, a.transform.position, a.transform.rotation);
    }


    IEnumerator Hit()
    {
        if (!Hiting)
        {
            while (hp > 0)
            {
                ArrowShot(Arrows);
                Hiting = true;
                yield return new WaitForSeconds(dms);
                Hiting = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Hit());
        if (Arrows.Count > 14)
        {
                Arrows.Clear();
        }
        hpbar.fillAmount =(float) hp / mhp;
        Hot();
        StartCoroutine(ShowDamage());
    }
}
