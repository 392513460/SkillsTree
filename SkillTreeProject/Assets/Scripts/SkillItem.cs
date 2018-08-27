using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text;

public class SkillItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int id;
    private SkillInfo info = null;
    public GameObject icon_mask;
    public Button button;
    public Image icon;

    void Start()
    {
        info = SkillsInfo.Instance.GetSkillById(id);
        icon_mask.SetActive(false);
        icon.sprite = info.icon;   
        UpdateShow();

    }

    public void UpdateShow()
    {
        if(info.locked==false)
        {
            if(info.learned==false)
            {
                icon_mask.SetActive(true);    
                         
            }
            else
            {
                SkillsTree tempParent = this.transform.parent.parent.parent.GetComponent<SkillsTree>();
                icon_mask.SetActive(false);
                tempParent.ChangeLine(id);


                if (info.skillType == SkillType.Strengthen)
                {
                    switch (info.enhanceType)
                    {
                        case EnhanceType.Strength:
                            Debug.Log("体力+5");
                            break;
                        case EnhanceType.Magic:
                            Debug.Log("魔力+5");
                            break;
                        case EnhanceType.Luck:
                            Debug.Log("幸运+5");
                            break;
                        case EnhanceType.Force:
                            Debug.Log("力量+5");
                            break;
                        case EnhanceType.Endurance:
                            Debug.Log("耐力+5");
                            break;
                        case EnhanceType.Aigle:
                            Debug.Log("敏捷+5");
                            break;

                    }

                    //TODO 加属性
                }
                else if (info.skillType == SkillType.Life)
                {
                    //TODO 生活技能
                    //2段跳
                    //三段跳
                    //潜水
                }
            }
        }
        else
        {
            icon_mask.SetActive(true);          
        }
    }

   public void LearnSkill()
    {
        if(info.unlockConditionID.Length>0)
        {
            int all = 0;
        
            for(int i=0;i<info.unlockConditionID.Length;i++)
            {
                SkillInfo tempInfo = null;
                tempInfo = SkillsInfo.Instance.GetSkillById(info.unlockConditionID[i]);
                if(tempInfo.learned==true)
                {
                    all++;
                }
            }
            if(all==info.unlockConditionID.Length)
            {
                SuccessStudy();
            }
        }
        else
        {
            SuccessStudy();
        }
    }

    void SuccessStudy()
    {
        SkillsTree tempParent = this.transform.parent.parent.parent.GetComponent<SkillsTree>();
        bool isSuccess = tempParent.ConsumePoints(info.needPoints);
        if (isSuccess)
        {
            info.learned = true;
            info.locked = false;

            UpdateShow();

        }
    }

    /// <summary>
    /// 显示技能信息冒泡框
    /// </summary>
    /// <returns></returns>
    public virtual string GetToolTipText()
    {      
        string text = "";
        text+= string.Format("<color=white><size=20>{0}</size></color>\n<color=yellow><size=25>{1}</size></color>", info.skillName, info.description);
        switch (info.skillType)
        {
            case SkillType.Life:              
                break;
            case SkillType.Fight:
                text += string.Format("\n<color=blue><size=25>消耗魔法：{0}</size></color>", info.castMp);
                switch (info.attackType)
                {
                    case DamageType.Magic:                 
                        switch(info.elementType)
                        {
                            case ElementType.Dark:
                                break;
                            case ElementType.Dragon:
                                break;
                            case ElementType.Fire:
                                break;
                            case ElementType.Ice:
                                break;
                            case ElementType.Wind:
                                break;
                        }
                        break;
                    case DamageType.Physic:
                        break;
                }               
                break;
            case SkillType.Strengthen:
                break;

        }
        return text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string toolTipText =this.GetToolTipText();
        SkillToolTip.Instance.Show(toolTipText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillToolTip.Instance.Hide();
    }

}
