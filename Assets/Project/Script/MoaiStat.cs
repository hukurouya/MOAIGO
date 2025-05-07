using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoaiStat
{
    public class SkillInfo
    {
        public BaseSkill skill;
        public bool isActive;

        public SkillInfo(BaseSkill skill, bool isActive)
        {
            this.skill = skill;
            this.isActive = isActive;
        }
    }

    private List<SkillInfo> _skills = new List<SkillInfo>();

    public List<SkillInfo> skills
    { 
        get { return _skills; }
    }

    public MoaiStat()
    {
        CreateSkillList();
    }

    public void UpdateSkill()
    {
        foreach(SkillInfo s in _skills)
        {
            if (s.skill == null) continue;

            if(s.skill.skillLevel > 0)
                s.skill.Update();
        }
    }

    private void CreateSkillList()
    {
        SkillManager.Create();
        
        List<BaseSkill> skillList = SkillManager.skills;
        foreach(BaseSkill skill in skillList)
        {
            SkillInfo info = new SkillInfo(skill, false);
            _skills.Add(info);
        }
    }
}
