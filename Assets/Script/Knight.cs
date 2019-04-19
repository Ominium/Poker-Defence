using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Enemys
{
    public Text text;
    public Image hpbar;
    bool Attacking = false;
    public Transform Weapontr;
    void Awake()
    {
        hp = 300 + (EnemyCtrl.round * 10);
        mhp = hp;
        lhp = hp;
        dis = 3f;
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

        while (Weapontr.localPosition.x > -0.6)
        {
            Weapontr.transform.Translate(-0.04f, 0, 0);
            yield return null;

        }
        PCctrl.hp -= dmg;
        while (Weapontr.localPosition.x < 0)
        {
            Weapontr.transform.Translate(0.04f, 0, 0);
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