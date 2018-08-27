using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillToolTip : MonoBehaviour {
    private static SkillToolTip instance;

    public static SkillToolTip Instance
    {
        get
        {
            if(instance==null)
            {
                instance = GameObject.Find("UICanvas").transform.Find("SkillTreesPanel/ToolTip").GetComponent<SkillToolTip>();
                
            }
            return instance;
        }
    }

    public bool isToolTipShow = false;

    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;

    private float targetAlpha = 0;

    public float smoothing = 1;

    private Canvas canvas;

    [Header("偏移")]
    public Vector2 toolTipPosionOffset = new Vector2(10, -10);
    void Start()
    {
        toolTipText = GetComponent<Text>();
        contentText = transform.Find("Content").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();

    }

    void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }

        if(isToolTipShow)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
            this.SetLocalPotion(position + toolTipPosionOffset);
        }
    }

    public void Show(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
        isToolTipShow = true;
    }
    public void Hide()
    {
        targetAlpha = 0;
        isToolTipShow = false;
    }
    public void SetLocalPotion(Vector3 position)
    {
        transform.localPosition = position;
    }
}
