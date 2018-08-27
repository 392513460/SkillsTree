using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能属性信息
/// </summary>
[System.Serializable]
public class SkillInfo  {
    public int id;
    public string skillName;
    public Sprite icon;
    public string iconPath;
    public string description;
    public SkillType skillType;
    public EnhanceType enhanceType;
    public int castMp;
    public float animTime;
    public float skillTime;
    public float skillRound;
    public int minDamage;
    public int maxDamage;
    public int varience;
    public int circleChance;
    public GameObject skillEffects;
    public DamageType attackType;
    public ElementType elementType;
    public int DrainHp;
    public BuffType buffType;
    public float skillSpeed;
    public ApplyType applyType;
    public ReleasType releasType;
    public int[] unlockConditionID;
    public int[] unloackLevel;
    public bool learned;
    public bool locked;
    public bool isFly;
    public bool isController;
    public bool isPosion;
    public int posionDamage;
    public int controllerRound;
    public int needPoints;
}

public enum SkillType
{
    Life,
    Strengthen,
    Fight
}

public enum EnhanceType
{
    None,
    Strength,
    Magic,
    Force,
    Luck,
    Endurance,
    Aigle
}

public enum DamageType
{
    None,
    Magic,
    Physic
}
public enum ElementType
{   
    Normal,
    Fire,
    Ice,
    Dragon,
    Dark,
    Wind
}

public enum BuffType
{
    None,
    Heal,
    MagicRecover,
    MagicDamage,
    PhysicDamage,
    Dodge,
    CircleChance,
    Defense,
    Speed
}
public enum ApplyType
{
    Single,
    Mutiple
}

public enum ReleasType
{
    Self,
    Enemy
}