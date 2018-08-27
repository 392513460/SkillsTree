using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour {

    private HeroType heroType;

    public GameObject[] skillsTree;

    void Start()
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        switch(heroType)
        {
            case HeroType.MainHero:
                 foreach(GameObject tempGame in skillsTree)
                {
                   if( tempGame.GetComponent<SkillsTree>().heroType == HeroType.MainHero)
                    {
                        tempGame.SetActive(true);
                    }
                    else
                    {
                        tempGame.SetActive(false);
                    }
                }
                break;
            case HeroType.Test:
                foreach (GameObject tempGame in skillsTree)
                {
                    if (tempGame.GetComponent<SkillsTree>().heroType == HeroType.Test)
                    {
                        tempGame.SetActive(true);
                    }
                    else
                    {
                        tempGame.SetActive(false);
                    }
                }
                break;

        }
    }

    public void HeadClick(string Head)
    {
        heroType = (HeroType)System.Enum.Parse(typeof(HeroType), Head);
        UpdateShow();
    }
}
