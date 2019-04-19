using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Smith : Enemys
{
    public Text text;
    public Image hpbar;
    public Transform Weapontr;

    bool Attacking = false;
    void Awake()
    {
        hp = 95 + (EnemyCtrl.round * 8);
        mhp = hp;
        lhp = hp;
        dis = 2.75f;
    }

    void Start()
    {
        base.Start();

    }
    void Update()
    {
        base.Update();
        StartCoroutine(ShowDamage());
        if (Hiting && !Attacking)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        bool dmged = false;
        int angle = 0;
        Attacking = true;

       
        while (angle < 68)
        {
            if (angle >= 30 && !dmged)
            {
                PCctrl.hp -= dmg;
                dmged = true;
            }
            Weapontr.transform.Rotate(new Vector3(0, 0, 1), 5);
            angle += 5;
            yield return null;
        }
        angle = 0;
        while (angle < 68)
        {
           
            Weapontr.transform.Rotate(new Vector3(0, 0, -1), 5);
            angle += 5;
            yield return null;
        }
       

        yield return new WaitForSeconds(dms - 1.0f);
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
