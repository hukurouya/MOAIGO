using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static List<BaseSkill> skills = new List<BaseSkill>();
    
    private static SkillFactory _skillFactory;

    public static void Create()
    {
        SkillFactory factroy = new SkillFactory();
        skills.Add(factroy.Create(SkillFactory.SkillKind.AutoClick));
        skills.Add(factroy.Create(SkillFactory.SkillKind.GrowUp));
        skills.Add(factroy.Create(SkillFactory.SkillKind.BeautyUp));
        skills.Add(factroy.Create(SkillFactory.SkillKind.EncountUp));
    }

    public static List<BaseSkill> GetSkills()
    {
        if(skills.Count <= 0)
        {
            SkillManager.Create();
            return skills;
        }

        return skills;
    }
}
