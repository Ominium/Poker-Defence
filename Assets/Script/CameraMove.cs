using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraMove : MonoBehaviour
{
    float x_;

    public Camera camera= new Camera();

   
    // Start is called before the first frame update
    void Update()
    {
        camera.gameObject.transform.position = new Vector3(x_, 0,-10);
        

        if (camera.gameObject.transform.position.x > 12f)
        {
            x_ = 12.0f;
        }
        if (camera.gameObject.transform.position.x < -12f)
        {
            x_ = -12.0f;
        }
    }
    
    public void LeftB()
    {
        x_ -= 0.13f;
        
        
    }
    public void RightB()
    {
        x_ += 0.13f;
    }
    // Update is called once per frame

}
