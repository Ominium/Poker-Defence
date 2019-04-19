using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : Mage
{

    

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        movs = 2.5f;
        vec = Vector2.left;
        dmg = base.dmg;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
        
            PCctrl.hp -= ( dmg- PCctrl.Ammor);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 distance = new Vector3(vec.x, vec.y, 0);
        tr.Translate(new Vector3(distance.x, distance.y, 0) * movs * Time.deltaTime, Space.Self);
        tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y, 0);
    }
}

