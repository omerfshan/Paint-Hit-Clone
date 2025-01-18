using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static float rotatinspeed = 100;
    public static float rotatinTime = 100;
    public GameObject ball;
    public GameObject dummyBall;
    public static Color color = Color.gray;
    public float speed;
    private int ballCount;
    private int circleNo;
    private int HeartNo;
    public Image[] balls;
    public GameObject[] Hearts;

    public static int currentCircleNo;
    Color[] ChangingColors;
    public SpriteRenderer spr;
    public Material splashMat;

    private void Start()
    {
        if (balls == null || balls.Length == 0)
        {
            Debug.LogError("Balls array is not set or empty. Please assign balls in the inspector.");
            return;
        }

        ballCount = LevelsManager.ballsCount; // Top sayısını al
        if (ballCount <= 0)
        {
            Debug.LogWarning("Ball count is zero or negative. Setting default value (1).");
            ballCount = 1;
        }

        Debug.Log($"Initial Ball Count: {ballCount}");
        ResetGame();
    }

    void ResetGame()
    {
        ChangingColors = ColorScript.colorArray;

        color = ChangingColors[0];
        ChangeBallsCount();

        GameObject gameObject2 = Instantiate(Resources.Load("Round" + Random.Range(1, 4))) as GameObject;

        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "circle" + circleNo;

        Debug.Log($"Ball GameReset: Initial BallCount = {ballCount}");

        HeartNo = PlayerPrefs.GetInt("Hearts", 1);
        if (HeartNo == 0)
        {
            PlayerPrefs.SetInt("Hearts", 1);
        }

        HeartNo = PlayerPrefs.GetInt("Hearts");
        for (int i = 0; i < HeartNo; i++)
        {
            Hearts[i].SetActive(true);
        }

        MakeHurldes();
    }

    public void HeartsLow()
    {
        HeartNo--;
        PlayerPrefs.SetInt("Hearts", HeartNo);
        Hearts[HeartNo].SetActive(false);
    }

    public void HitBall()
    {
        if (ballCount <= 1)
        {
            Debug.Log("Ball Count Reached zero. Creating new Circle.");
            Invoke("NewCircle", 0.4f);
        }

        ballCount--;

        if (ballCount >= 0)
        {
            balls[ballCount].enabled = false;

            // Alpha değerini şeffaf yap
            Color tempColor = balls[ballCount].color;
            tempColor.a = 0f; // Şeffaf
            balls[ballCount].color = tempColor;
        }
        else
        {
            Debug.LogWarning("No balls left to disable.");
        }

        ChangeBallsCount();
        Debug.Log($"Ball Count After Hit: {ballCount}");

        GameObject newBall = Instantiate(ball, new Vector3(0, 0, -8), Quaternion.identity);
        newBall.GetComponent<MeshRenderer>().material.color = color;
        newBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void ChangeBallsCount()
    {
        Debug.Log($"Changing Balls: Active Ball Count = {ballCount}");

        for (int i = 0; i < balls.Length; i++)
        {
            if (i < ballCount)
            {
                balls[i].enabled = true;

                // Alpha değerini opak yap
                Color tempColor =color;
                tempColor.a = 1f; // Opak

                balls[i].color = tempColor;
            }
            else
            {
                balls[i].enabled = false;

                // Alpha değerini şeffaf yap
                Color tempColor = color;
                tempColor.a = 0f; // Şeffaf
                balls[i].color = tempColor;
            }
        }
    }

    public void NewCircle()
    {
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
        currentCircleNo = circleNo;

        GameObject newCircle = Instantiate(Resources.Load("Round" + Random.Range(1, 4))) as GameObject;
        if (newCircle != null)
        {
            newCircle.transform.position = new Vector3(0, 20, 23);
            newCircle.name = "circle" + circleNo;
            ballCount = LevelsManager.ballsCount;

            if (circleNo < ChangingColors.Length)
            {
                color = ChangingColors[circleNo];
            }
            else
            {
                Debug.LogWarning("circleNo out of bounds for ChangingColors. Using default color.");
                color = ChangingColors[0];
            }

            LevelsManager.currentColor = color;
            spr.color = color;
            splashMat.color = color;
            MakeHurldes();
            ChangeBallsCount();
        }
        else
        {
            Debug.LogError("Failed to load new circle prefab.");
        }
    }

    void MakeHurldes()
    {
        if (circleNo == 1) FindAnyObjectByType<LevelsManager>().MakeHurldes1();
        if (circleNo == 2) FindAnyObjectByType<LevelsManager>().MakeHurldes2();
        if (circleNo == 3) FindAnyObjectByType<LevelsManager>().MakeHurldes3();
        if (circleNo == 4) FindAnyObjectByType<LevelsManager>().MakeHurldes4();
        if (circleNo == 5) FindAnyObjectByType<LevelsManager>().MakeHurldes5();
    }
}
