using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static float rotatinspeed=100;
    public GameObject ball;
    public static Color color=Color.gray;
    public float speed;
    public int ballCount;
  
private void Start() {
    ballCount=3;
}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
        {
            HitBall();
        }
    }

public void HitBall()
{
    if(ballCount<=1)
    {
      base.Invoke("NewCircle",0.4f);
    }
    ballCount--;
    GameObject gameObject=Instantiate<GameObject>(ball,new Vector3(0,0,-8),Quaternion.identity);
    gameObject.GetComponent<MeshRenderer>().material.color=color;
    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed,ForceMode.Impulse);

}

public void NewCircle()
{
    GameObject[] array=GameObject.FindGameObjectsWithTag("circle");
    GameObject circle=GameObject.Find("circle"+ci);
GameObject gameObject2=Instantiate(Resources.Load("Round"+Random.Range(1,4)))as GameObject;
gameObject2.transform.position=new Vector3(0,20,23);
gameObject2.name="circle";
}


}
