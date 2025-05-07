using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillFactory
{
    static readonly BaseSkill[] skills =
    {
        new SkillAutoClick(GameManager.Instance),
        new SkillGrowUp(),
        new SkillBeautyUp(),
        new SkillEncountUp()
    };

    public enum SkillKind
    {
        AutoClick,
        GrowUp,
        BeautyUp,
        EncountUp
    }

    public BaseSkill Create(SkillKind skillKind)
    {
        return skills.SingleOrDefault(skill => skill.skillKind == skillKind);
    }
}
