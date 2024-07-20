using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public string skillName;
    public bool isSelected;
    private GameObject selected;

    [SerializeField] private float coolTime;

    private bool isUsed = false;

    public SkillData skillData;
    public Image skillIcon;
    public Image mask;

    public PlayerUi playerUi;

    private void Start()
    {
        if (skillData != null)
        {
            skillName = skillData.skillName;
            skillIcon.sprite = skillData.skillIcon;
            coolTime = skillData.skillCoolTime;
        }
    }

    private void Update()
    {
        if (isUsed)
        {
            mask.fillAmount -= 1f / coolTime * Time.deltaTime;
            if(mask.fillAmount <= 0f )
            {
                mask.fillAmount = 0f;
                isUsed = false;
            }
        }
    }

    public void Init()
    {
        selected = SelectedObj();

        if(selected.name == "SelectedSlot")
        {
            isSelected = true;
        }
        else if(selected.name == "UnSelectedSlot")
        {
            isSelected = false;
        }
    }

    private GameObject SelectedObj()
    {
        return this.gameObject.transform.parent.gameObject;
    }

    public void StartCoolTime()
    {
        if (!isUsed)
        {
            SkillMethod();
            mask.fillAmount = 1;
            isUsed = true; 
        }
    }

    private void SkillMethod()
    {
        switch (skillName)
        {
            case "Fuel":
                playerUi.AddGage(40);
                break;
        }
    }
}
