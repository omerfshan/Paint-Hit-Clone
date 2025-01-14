using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static float rotatinspeed=100;
    public static float rotatinTime=100;
    public GameObject ball;
    public static Color color=Color.gray;
    public float speed;
    private int ballCount;
    private int circleNo;
 
    Color[] ChangingColors;
    public  SpriteRenderer spr;
    public Material splashMat;

    private void Start(){
    
    ResetGame();
   
    }
    void ResetGame()
    {   ChangingColors=ColorScript.colorArray;
         color=ChangingColors[0];
        if(ChangingColors==null||ChangingColors.Length==0)
        {
           Debug.LogError("ChangingColor Array empty or null");
           return;
        }
        color=ChangingColors[0];
        GameObject gameObject2=Instantiate(Resources.Load("Round"+Random.Range(1,4)))as GameObject;
        if(gameObject2==null)
        {
         Debug.LogError("Failed to load Round prefabs");
         return;
        }
        gameObject2.transform.position=new Vector3(0,20,23);
        gameObject2.name="circle"+circleNo;

        ballCount=LevelsManager.ballsCount;
        Debug.Log("Ball GameReset: Initial BallCount="+ballCount);

  
}
   
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
         Debug.Log("Ball Count Reached zero. Creatingg new Circle");
         base.Invoke("NewCircle",0.4f);
        }
        ballCount--;
        Debug.Log("Ball Count After Hit"+ballCount);
        GameObject gameObject=Instantiate<GameObject>(ball,new Vector3(0,0,-8),Quaternion.identity);
        if(gameObject==null)
        {
          Debug.LogError("obje oluşturulamadı");
        }
        gameObject.GetComponent<MeshRenderer>().material.color=color;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed,ForceMode.Impulse);

    }

    public void NewCircle()
    {   
        Debug.Log("NewCircle called. Current circleNo: " + circleNo);

        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject circle = GameObject.Find("circle" + circleNo);

        if (circle != null)
        {
            for (int i = 0; i < 24; i++)
            {
             if (circle.transform.childCount > i)
                {
                    circle.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            if (circle.transform.childCount > 24)
            {
                circle.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = Ball.color;
            }

            if (circle.GetComponent<iTween>())
            {
            circle.GetComponent<iTween>().enabled = false;
            }
        }
        else
        {
            Debug.LogWarning("Circle not found: circle" + circleNo);
        }

        foreach (GameObject item in array)
        {
            if (item != null)
            {
                iTween.MoveBy(item, iTween.Hash(
                    "y", -2.90f,
                    "easetype", iTween.EaseType.spring,
                    "time", 0.5
                ));
             }
        }

        circleNo++;

        GameObject gameObject2 = Instantiate(Resources.Load("Round" + Random.Range(1, 4))) as GameObject;
        if (gameObject2 != null)
        {
            gameObject2.transform.position = new Vector3(0, 20, 23);
            gameObject2.name = "circle" + circleNo;
            ballCount = LevelsManager.ballsCount;

            if (circleNo < ChangingColors.Length)
            {
                color = ChangingColors[circleNo];
            }
            else
            {
                Debug.LogWarning("circleNo out of bounds for ChangingColors. Using default color.");
                color=ChangingColors[0];
            }

            spr.color = color;
            splashMat.color = color;
    }
    else
    {
        Debug.LogError("Failed to load new circle prefab.");
    }
}



}
