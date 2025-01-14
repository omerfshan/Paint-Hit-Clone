using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{ public static int currentLevel;
  public static int ballsCount;
  public static int totalCircles;
   
    void Awake()
    {
     if(PlayerPrefs.GetInt("FirstTime1",0)==0)
     {
        PlayerPrefs.SetInt("firstTime1",0);
        PlayerPrefs.SetInt("C_Level",1);
        
     } 
      UpgradeLevel();
     
    }
   void UpgradeLevel()
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
      
   }
   
   
