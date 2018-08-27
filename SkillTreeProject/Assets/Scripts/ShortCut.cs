using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCut : MonoBehaviour {

    private int id;
    private int totalDamage;
    SkillInfo info = null;
    public Image icon;

    public void Setting(int id)
    {
        this.id = id;
        info = SkillsInfo.Instance.GetSkillById(id);
        Debug.Log("info.icon::"+info.icon == null);
        icon.sprite = info.icon;

    }

    public void UseSkillClick()
    {
        //TODO 使用技能     
     TestFight[] tempTestFights=   GameObject.FindObjectsOfType<TestFight>();
        foreach(TestFight temp in tempTestFights)
        {
            if(temp.heroType== SkillPanelFight.Instance.heroType)
            {
                temp.UseSkill(this.id);
            }
        }
    }
}
