using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle3 : MonoBehaviour {

	void Start () {
        iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
       {
            "y",
            0,
            "easetype",
            iTween.EaseType.easeInOutQuad,
            "time",
            0.6,
            "OnComplete",
            "RotateCirlce"
       }));
    }
	
	void RotateCirlce()
    {
        iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
        {
            "y",
            0.75f,
            "time",
            Ball.rotatinTime,
            "easeType",
            iTween.EaseType.easeInOutQuad,
            "loopType",
            iTween.LoopType.pingPong,
            "delay",
            0.5
        }));
    }
}
