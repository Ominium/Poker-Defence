using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Enemys
{
    public Text text;
    public Image hpbar;

    PCctrl a;
    void Awake()
    {
        hp = 300 + (EnemyCtrl.round * 10);
        mhp = hp;
        lhp = hp;
        dis = 2f;
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