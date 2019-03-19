using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    float Movespeed = 2.5f;
    public static int dmg = 10;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
             Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Enemys>().hp -= dmg;
        }

    }


    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.left * Movespeed;
        Vector3 distance = new Vector3(dir.x, dir.y, 0);
        tr.Translate(new Vector3(distance.x, distance.y, 0) * Movespeed * Time.deltaTime, Space.Self);
        tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y, 0);


    }
}
