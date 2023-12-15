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
    public Image backGround;
    public LevelManager levelManager;
    public static int levelCount;

    void Start()
    {
        levelCount++;
         backGround.GetComponent<Image>().sprite = levelOne;
    }
    void Update()
    {
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
    }
}
