using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsTree : MonoBehaviour {
    public HeroType heroType;
    [HideInInspector]
    public Text points;

    public Image[] lines;

    void Start()
    {
        points = this.transform.Find("MyPoint/Text").GetComponent<Text>();
        if(PlayerPrefs.GetInt(this.gameObject.name + "SkillPoints")!=0)
        {
            points.text= PlayerPrefs.GetInt(this.gameObject.name + "SkillPoints").ToString();
        }
    }

    public bool ConsumePoints(int point)
    {
        if (point > int.Parse(points.text))
        {
            return false;
        }
        else
        {
            int tempPoint = int.Parse(points.text);
            tempPoint -= point;
            points.text = tempPoint.ToString();
            return true;
        }
    }

    public void ChangeLine(int id)
    {
        for(int i=0;i<lines.Length;i++)
        {
            if(lines[i].GetComponent<Line>().id==id)
            {
                lines[i].GetComponent<Image>().color = Color.yellow;
            }
        }
    }

    public void SavePoints()
    {
        PlayerPrefs.SetInt(this.gameObject.name + "SkillPoints", int.Parse(points.text.ToString()));
        PlayerPrefs.Save();
     
    }

	
}

