using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Criminal : Enemys
    
{
    public Transform Weapontr;
    bool Attacking = false;
    public Text text;
    public Image hpbar;
    void Awake()
    {
        hp = 85 + (EnemyCtrl.round * 7);
        mhp = hp;
        lhp = hp;
        dis = 2.85f;
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

        while (angle < 270)
        {
            if (angle >=90 && !dmged)
            {
                PCctrl.hp -= dmg;
                dmged = true;
            }
            Weapontr.transform.Rotate(new Vector3(0, 0, -1), 5);
            angle += 5;
            yield return null;
        }
        angle = 0;
        
        while (angle < 270)
        {

            Weapontr.transform.Rotate(new Vector3(0, 0, 1), 5);
            angle += 5;
            yield return null;
        }
        yield return new WaitForSeconds(dms-1.5f);
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
