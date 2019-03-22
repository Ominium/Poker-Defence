using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Smith : Enemys
{
    public Text text;
    public Image hpbar;

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
