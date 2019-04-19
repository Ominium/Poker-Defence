
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemys : MonoBehaviour
{
    public int hp;
    public int mhp;
    public int lhp;
    public int damaged;
    public Transform tr;
    public float movs;
    public float Changemovs = 0;
    public float Realmovs;
    public int dmg;
    public bool Hiting = false;
    public bool Hoting = false;
    public float dis;
    public float dms;
    public Vector2 vec;
    public bool isDie = false;

    public PCctrl a;
    public void Start(){
        tr = GetComponent<Transform>();
        a = GameObject.FindObjectOfType<PCctrl>();
    }
    public void Update()    
    {
        Realmovs = movs + Changemovs;
        if (Mathf.Abs(gameObject.transform.position.x - a.transform.position.x) < dis)
        {
            StartCoroutine(Hit(dms));
        }
        else
        {
            Moving();
        }
        Hot();
        StartCoroutine(Die());
        
    }
   public IEnumerator Die()
    {
        if (hp <= 0)
        {
            isDie = true;
        }
        if (isDie)
        {
            yield return new WaitForSeconds(0.05f);
            GameUI.gold += (EnemyCtrl.round+1) * 1;
            Destroy(gameObject);
        }
       
    }
   public void Hot()
    {
        if (lhp != hp)
        {
            damaged =lhp - hp;
            Hoting = true;
            lhp = hp;
        }
    }
 
   public IEnumerator Hit( float dms)
    {
        


        if (!Hiting)
        {
            while (PCctrl.hp > 0)
            {
                
                Hiting = true;
                
                yield return new WaitForSeconds(dms);
                Hiting = false;
               
            }
        }
    }
    protected virtual void Life(List<GameObject> list)
    {
        int num;
        num = list.Count;
        list.Insert(num, gameObject);
    }
    protected virtual void Die(List<GameObject> list)
    {
        int num;
        num = list.Count;
        gameObject.SetActive(false);
        list.Insert(num, gameObject);
    }
    protected virtual void Moving()
    {
            Vector3 distance = new Vector3(vec.x, vec.y, 0);
            tr.Translate(new Vector3(distance.x, distance.y, 0) * Realmovs * Time.deltaTime, Space.Self);
            tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y, 0);    
    } 
}



