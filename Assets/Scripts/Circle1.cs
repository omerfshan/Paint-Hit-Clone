using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Circle1 : MonoBehaviour
{
   
    void Start()
    {
          iTween.MoveTo(base.gameObject,iTween.Hash(new object[]{
            "y",
            0,
            "easetype",
            iTween.EaseType.easeInCirc,
            "time",
            0.2,
            "OnComplete",
            "rotatecirlce"
          }));      
    }
 void rotatecirlce()
 {
    print("the itween anim is done");
 }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*Time.deltaTime*Ball.rotatinspeed);
    }
}
