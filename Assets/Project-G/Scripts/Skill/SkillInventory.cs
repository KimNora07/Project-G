using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{
    public SkillSlot[] slots;
    [SerializeField] private Transform selectedSlot;
    [SerializeField] private Transform unSelectedSlot;

    // ½½·Ô ¹Ù²Ù±â
    public void SlotChange()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isSelected)
            {
                slots[i].transform.SetParent(unSelectedSlot, false);
            }
            else
            {
                slots[i].transform.SetParent(selectedSlot, false);
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Init();
        }
    }
    public void UseSkill()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isSelected)
            {
                slots[i].StartCoolTime();
            }
        }
    }
    
}
