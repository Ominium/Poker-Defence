using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cook : Enemys
{
    public Transform Weapontr;
    public Text text;
    float time = 0;
    public Image hpbar;
    bool Attacking = false;
    void Awake()
    {
        hp = 150 + (EnemyCtrl.round * 10);
        mhp = hp;
        lhp = hp;
        dis = 2.65f;
    }

    void Start()
    {
        base.Start();

    }
    void Update()
    {
        base.Update();
        StartCoroutine(ShowDamage());
        if (Hiting)
        {
            
            time += Time.deltaTime;
            if (time > dms)
            {
                time = 0;
                PCctrl.hp -= dmg;
            }
        }
        if (Hiting && !Attacking)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        int angle = 0;
       Attacking = true;

        while (angle < 55)
        {

            Weapontr.transform.Rotate(new Vector3(0, 0, -1), 5);
            angle += 5;
            yield return null;
        }
        angle = 0;
        while (angle < 55)
        {

            Weapontr.transform.Rotate(new Vector3(0, 0, 1), 5);
            angle += 5;
            yield return null;
        }
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
