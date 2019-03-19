using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shif : Enemys
{
    public Text text;
    public Image hpbar;

    PCctrl a;
    void Awake()
    {
        hp = 55+ (EnemyCtrl.round * 5);
        mhp = hp;
        lhp = hp;
        dis = 1.45f;
    }

    void Start()
    {
        base.Start();

    }
    void Update()
    {
        base.Update();
        StartCoroutine(ShowDamage());

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