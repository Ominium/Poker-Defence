using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dealer : Enemys
{
    bool fired = false;
    public Text text;
    public Image hpbar;
    public GameObject Gold;
    void Awake()
    {
        hp = 70 + (EnemyCtrl.round * 7);
        mhp = hp;
        lhp = hp;
        dis = 3.08f;
    }
    IEnumerator Goldshot()
    {
        fired = true;
        Gold.transform.position =new Vector2(a.transform.position.x,a.transform.position.y+5);
        Instantiate(Gold, Gold.transform.position, Gold.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        PCctrl.hp -= dmg;
        yield return new WaitForSeconds(dms-0.5f);
        fired = false;
    }
    void Start()
    {
        base.Start();

    }
    void Update()
    {
        base.Update();
        if (base.isDie)
        {
            GameUI.gold += EnemyCtrl.round * 10;
        }
        StartCoroutine(ShowDamage());
        if (Hiting && !fired)
        {
            StartCoroutine(Goldshot());
        }
    }
    IEnumerator ShowDamage()
    {
        if (base.Hoting)
        {
            hpbar.fillAmount = (float)hp / (float)mhp;
            text.gameObject.SetActive(true);
            text.text = base.damaged.ToString();
            Hoting = false;
            yield return new WaitForSeconds(0.6f);
            text.gameObject.SetActive(false);
        }
    }
}
