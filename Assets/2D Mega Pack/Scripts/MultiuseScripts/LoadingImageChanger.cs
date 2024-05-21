using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingImageChanger : MonoBehaviour
{
    public Sprite levelOne;
    public Sprite bossOne;
    public Sprite levelTwo;
    public Sprite bossTwo;
    public Sprite levelThree;
    public Sprite bossThree;
    public Sprite levelFour;
    public Sprite bossFour;
    public Sprite levelFive;
    public Sprite bossFive;
    public Sprite levelSix;
    public Sprite bossSix;
    public Sprite levelSeven;
    public Sprite bossSeven;
    public Sprite levelEight;
    public Sprite bossEight;
    public Sprite levelNine;
    public Sprite bossNine;
    public Image backGround;
    public LevelManager levelManager;
    public static int levelCount;
    public int level;

    void Start()
    {
        levelCount++;
         backGround.GetComponent<Image>().sprite = levelOne;
    }
    void Update()
    {
        level = levelCount;
        if (levelCount == 1)
        {
            backGround.GetComponent<Image>().sprite = levelOne;
            
        }
        if (levelCount == 2)
        {
            backGround.GetComponent<Image>().sprite = bossOne;
            
        }
        if (levelCount == 3)
        {
            backGround.GetComponent<Image>().sprite = levelTwo;
            
        }
        if (levelCount == 4)
        {
            backGround.GetComponent<Image>().sprite = bossTwo;
            
        }
         if (levelCount == 5)
        {
            backGround.GetComponent<Image>().sprite = levelThree;
            
        }
         if (levelCount == 6)
        {
            backGround.GetComponent<Image>().sprite = bossThree;
            
        }
         if (levelCount == 7)
        {
            backGround.GetComponent<Image>().sprite = levelFour;
            
        }
         if (levelCount == 8)
        {
            backGround.GetComponent<Image>().sprite = bossFour;
            
        }
         if (levelCount == 9)
        {
            backGround.GetComponent<Image>().sprite = levelFive;
            
        }
         if (levelCount == 10)
        {
            backGround.GetComponent<Image>().sprite = bossFive;
            
        }
        if (levelCount == 11)
        {
            backGround.GetComponent<Image>().sprite = levelSix;
            
        }
          if (levelCount == 12)
        {
            backGround.GetComponent<Image>().sprite = bossSix;
            
        }
        if (levelCount == 13)
        {
            backGround.GetComponent<Image>().sprite = levelSeven;
            
        }
        if (levelCount == 14)
        {
            backGround.GetComponent<Image>().sprite = bossSeven;
            
        }
        if (levelCount == 15)
        {
            backGround.GetComponent<Image>().sprite = levelEight;
            
        }
        if (levelCount == 16)
        {
            backGround.GetComponent<Image>().sprite = bossEight;
            
        }
        if (levelCount == 17)
        {
            backGround.GetComponent<Image>().sprite = levelNine;
            
        }
         if (levelCount == 18)
        {
            backGround.GetComponent<Image>().sprite = bossNine;
            
        }
    }
}
