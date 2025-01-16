using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{ public static int currentLevel;
  public static int ballsCount;
  public static int totalCircles;
  public static Color currentColor;
    void Awake()
    {
     if(PlayerPrefs.GetInt("FirstTime1",0)==0)
     {
        PlayerPrefs.SetInt("firstTime1",0);
        PlayerPrefs.SetInt("C_Level",1);
        
     } 
      UpgradeLevel();
     
    }
   public void UpgradeLevel()
   {
      currentLevel = PlayerPrefs.GetInt("C_Level", 1);

        if(currentLevel==1)
        {
            ballsCount = 3;
            totalCircles = 2;
        }

        if(currentLevel ==2)
        {
            ballsCount = 3;
            totalCircles = 3;
        }

        if(currentLevel ==3)
        {
            ballsCount = 3;
            totalCircles = 4;
        }

        if(currentLevel ==4)
        {
            ballsCount = 3;
            totalCircles = 5;
        }

        if(currentLevel ==5)
        {
            ballsCount = 4;
            totalCircles = 5;
        }

        if(currentLevel ==6)
        {
            ballsCount = 4;
            totalCircles = 6;
            Ball.rotatinspeed = 120;
            Ball.rotatinTime = 2;
        }

        if(currentLevel ==7)
        {
            ballsCount = 5;
            totalCircles = 7;
            Ball.rotatinspeed = 140;
            Ball.rotatinTime = 1;
        }

    }
      public void MakeHurldes1()
      {
        GameObject gameObject =GameObject.Find("circle"+Ball.currentCircleNo);
        int index=Random.Range(1,3);
        gameObject.transform.GetChild(index).GetComponent<MeshRenderer>().enabled=true;
        gameObject.transform.GetChild(index).GetComponent<MeshRenderer>().material.color=currentColor;
        gameObject.transform.GetChild(index).gameObject.tag="red";

      }
       public void MakeHurldes2()
      {
        GameObject gameObject =GameObject.Find("circle"+Ball.currentCircleNo);
        
         int[] array= new int[]
        {
            Random.Range(1,3),
            Random.Range(15,17)
        }; 
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().enabled=true;
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().material.color=currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag="red";
         }
      }
       public void MakeHurldes3()
      {
        GameObject gameObject =GameObject.Find("circle"+Ball.currentCircleNo);
        
         int[] array= new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(18,20)
        }; 
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().enabled=true;
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().material.color=currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag="red";
         }
      }
       public void MakeHurldes4()
      {
        GameObject gameObject =GameObject.Find("circle"+Ball.currentCircleNo);
        
         int[] array= new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(15,17),
            Random.Range(22,24)
        }; 
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().enabled=true;
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().material.color=currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag="red";
         }
      }
       public void MakeHurldes5()
      {
        GameObject gameObject =GameObject.Find("circle"+Ball.currentCircleNo);
        
         int[] array= new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(11,13),
            Random.Range(8,10),
            Random.Range(15,17)
        }; 
        for (int i = 0; i < array.Length; i++)
        {
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().enabled=true;
            gameObject.transform.GetChild(array[i]).GetComponent<MeshRenderer>().material.color=currentColor;
            gameObject.transform.GetChild(array[i]).gameObject.tag="red";
         }
      }
   
   
   }
   
   
   
   
   
   
   
   
