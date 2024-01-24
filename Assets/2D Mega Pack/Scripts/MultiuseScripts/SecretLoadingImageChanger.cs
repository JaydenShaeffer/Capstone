using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretLoadingImageChanger : MonoBehaviour
{
    public Sprite levelOne;
    public Sprite bossOne;
    /*public Sprite levelTwo;
    public Sprite bossTwo;
    public Sprite levelThree;
    public Sprite bossThree;  */
    public Image backGround;
    public SecretLevelManager secretlevelManager;
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
       /* if (levelCount == 3)
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
            
        }*/
    }
}
