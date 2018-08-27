using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SkillsInfo : MonoBehaviour {
    public List<SkillInfo> skillsData;
    [HideInInspector]
    public Dictionary<int, SkillInfo> skillInfoDict=new Dictionary<int, SkillInfo>();

    private static SkillsInfo instance;
    public static SkillsInfo Instance
    {
        get {
            if(instance==null)
            {
                instance = GameObject.Find("SkillsInfo").GetComponent<SkillsInfo>();
            }

            return instance;
            }
       
    }
	// Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();
        //加载场景的时候不能将这个销毁
        DontDestroyOnLoad(this.gameObject);
        InitSkillInfo();
        
        //Test Log
        for(int i=0;i<skillInfoDict.Count;i++)
        {
            SkillInfo info = GetSkillById(i + 1);

            Debug.Log("id::" + info.id + ":icon::" + info.icon.name);
        }
           
	}
	
    void InitSkillInfo()
    {
        for (int i = 0; i < skillsData.Count; i++)
        {
            skillInfoDict.Add(skillsData[i].id, skillsData[i]);
        }
        LoadSkillMessage();
    }

    /// <summary>
    /// 对外开放的接口
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SkillInfo GetSkillById(int id)
    {
        SkillInfo info = null;
        skillInfoDict.TryGetValue(id, out info);
        return info;
    }

    /// <summary>
    /// 加载技能的存储信息
    /// </summary>
    private void LoadSkillMessage()
    {
        //TODO
        if (PlayerPrefs.HasKey(this.gameObject.name) == false) return;
        string str = PlayerPrefs.GetString(this.gameObject.name);
        string[] itemArray = str.Split('-');
        for (int i = 0; i < itemArray.Length - 1; i++)
        {
            string itemStr = itemArray[i];
            if (itemStr != "0")
            {
                string[] temp = itemStr.Split(',');
                int id = int.Parse(temp[0]);
                bool learned = bool.Parse(temp[1]);
                SkillInfo info = GetSkillById(id);
                info.learned = learned;

            }
        }
    }

    public void SaveSkillMessage()
    {
        StringBuilder sb = new StringBuilder();
       for(int i=0;i<skillsData.Count;i++)
        {
            SkillInfo tempInfo = null;
            tempInfo = skillsData[i];
            
            sb.Append(tempInfo.id + "," + tempInfo.learned+ "-");
        }
        sb.Append("0-");
        PlayerPrefs.SetString(this.gameObject.name, sb.ToString());

        SkillsTree[] tempSkillsTrees = GameObject.FindObjectsOfType<SkillsTree>();
        foreach (SkillsTree tempSkillsTree in tempSkillsTrees)
        {
            tempSkillsTree.SavePoints();
        }
        PlayerPrefs.Save();

        Debug.Log("技能保存完毕");
    }

	
}
public enum HeroType
{
    MainHero,
    Test
}

