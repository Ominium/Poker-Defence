using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shif : Enemys
{
   
    bool Attacking = false;
    public Text text;
    public Image hpbar;
    public Transform Weapontr;
    void Awake()
    {
        hp = 55+ (EnemyCtrl.round * 5);
        mhp = hp;
        lhp = hp;
        dis = 2.45f;

    }
 

    void Start()
    {
        
        base.Start();

    }
    void Update()
    {
        base.Update();
        StartCoroutine(ShowDamage());
       
                
     
        if (Hiting & !Attacking)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        Attacking = true;
       
        while (Weapontr.localPosition.x > -0.4)
        {
            Weapontr.transform.Translate(-0.01f,0,0);
            yield return null;
           
        }
        PCctrl.hp -= dmg;
        while (Weapontr.localPosition.x < 0)
        {
            Weapontr.transform.Translate(0.01f, 0, 0);
            yield return null;
        }
        
        yield return new WaitForSeconds(dms - 0.8f);
        Attacking = false;
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