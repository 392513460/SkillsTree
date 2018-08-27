using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFight : MonoBehaviour {

    public HeroType heroType;

    [HideInInspector]
    public int id;

    public void UseSkill(int id)
    {
        this.id = id;
        SkillInfo info = SkillsInfo.Instance.GetSkillById(this.id);
        switch(info.attackType)
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
                    case ElementType.Normal:
                        break;
                }
                break;
            case DamageType.Physic:
                break;
            case DamageType.None:
                
                break;
        }

        switch(info.buffType)
        {
            case BuffType.None:
                break;
            case BuffType.Heal:
                break;
            case BuffType.CircleChance:
                break;
            case BuffType.Defense:
                break;
            case BuffType.Dodge:
                break;           
            case BuffType.MagicDamage:
                break;
            case BuffType.MagicRecover:
                break;
            case BuffType.PhysicDamage:
                break;
            case BuffType.Speed:
                break;
        }
        switch(info.isFly)
        {
            case true:
                break;
            case false:
                break;
        }
        switch(info.isController)
        {
            case true:
                break;
            case false:
                break;
        }
        switch(info.isPosion)
        {
            case true:
                break;
            case false:
                break;
        }
        switch(info.applyType)
        {
            case ApplyType.Mutiple:
                break;
            case ApplyType.Single:
                break;
        }
    }

}
