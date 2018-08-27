using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelFight : MonoBehaviour {

    public int[] mainHeroList;

    //用来获取当前回合得角色
    private TestFight testFight;

    //技能的预制体
    public GameObject shortCut;

    public Transform grid;

    public HeroType heroType;

    private static SkillPanelFight instance;
    public static SkillPanelFight Instance
    {
        get
        {
            if(instance==null)
            {
                instance = GameObject.Find("SkillPanel").GetComponent<SkillPanelFight>();

            }
            return instance;
        }
    }

    void Start()
    {  
        //Test
        CurrentPlayer(GameObject.Find("PlayerFight").GetComponent<TestFight>());
     

    }

    public void CurrentPlayer(TestFight testFight)
    {
        heroType = testFight.heroType;
        this.testFight = testFight;
        int[] idList = null;
        switch(this.testFight.heroType)
        {
            case HeroType.MainHero:
                idList = mainHeroList;
                break;
            case HeroType.Test:
                //其他队友
                break;
        }

        foreach (int id in idList)
        {
            GameObject tempGo = Instantiate(shortCut, grid);
            SkillInfo tempInfo = null;
            tempInfo = SkillsInfo.Instance.GetSkillById(id);
            if (tempInfo.skillType == SkillType.Fight&&tempInfo.learned==true)
            {
                tempGo.GetComponent<ShortCut>().Setting(id);
            }
            else
            {
                Destroy(tempGo);
            }
          
        }
    }



}
