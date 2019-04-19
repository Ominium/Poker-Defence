
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PCctrl : MonoBehaviour
{
    public Image hpbar;
    public Text hptext;
    public GameObject tr;
    Transform start;
    public static float dodgeper = 0.0f;
    bool dodge = false;
    public static int hp = 100;
    public static int mhp;
    public int lhp;
    float dis = 2.5f;
    bool Hoting = false;
    int damaged;
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
            float rand = Random.Range(0, 1);
            if (rand>dodgeper)
            {
                damaged = lhp - hp;
                Hoting = true;
                lhp = hp;
            }
            if (rand < dodgeper)
            {
                dodge = true;
                hp = lhp;
            }
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

    // Update is called once per frame
    void Update()
    {
        hpbar.fillAmount =(float) hp / mhp;
        Hot();
        StartCoroutine(ShowDamage());
    }
}
