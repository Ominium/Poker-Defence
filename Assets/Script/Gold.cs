using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    float rand1 = 0;
    float rand2 = 0;
    bool dontmove = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
     
            rand1 = Random.Range(-21f, -13f);
            rand2 = Random.Range(1.8f, 2.5f);
          StartCoroutine(  RandomMove());
            Debug.Log(rand1);

        }
    }
    IEnumerator RandomMove()
    {
        
 
        while (transform.position.y <= rand2)
        {
            gameObject.transform.Translate(Vector2.up *0.25f, Space.Self);
            yield return null;
        }
      if (rand1 > -17f)
        {
            while (transform.position.x <= rand1)
            {
                gameObject.transform.Translate(Vector2.left*0.25f, Space.Self);
                yield return null;
            }
       }
        if (rand1 < -17f)
        {
            while (transform.position.x >= rand1)
            {
                gameObject.transform.Translate(Vector2.right * 0.25f , Space.Self);
                yield return null;
            }
        }
        Destroy(gameObject);
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Moving()
    {
        Vector3 distance =Vector3.down;
        transform.Translate(new Vector3(distance.x, distance.y, 0) * 5.5f* Time.deltaTime, Space.Self);
        transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!dontmove)
        {
            Moving();
        }
    }
}
