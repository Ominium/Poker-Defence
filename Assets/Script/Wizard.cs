using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wizard : Enemys
{
    public Text text;
    public Image hpbar;
    public GameObject Fire;
    bool fired = false;
    void Awake()
    {
        hp = 40 + (EnemyCtrl.round * 6);
        mhp = hp;
        lhp = hp;
        dis = 3.5f;
    }

    void Start()
    {
        base.Start();

    }
    void Update()
    {
        base.Update();
        StartCoroutine(ShowDamage());
        if (Hiting && !fired)
        {
            StartCoroutine(Fireshot());
        }
    }
    IEnumerator Fireshot()
    {
        fired = true;
        Fire.transform.position = gameObject.transform.position;
        Instantiate(Fire, Fire.transform.position, Fire.transform.rotation);
        yield return new WaitForSeconds(dms);
        fired = false;
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
