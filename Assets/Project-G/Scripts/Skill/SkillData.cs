using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Data/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public float skillCoolTime;
    public Sprite skillIcon;
}
