using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerSkills 
{

    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;
    public class OnSkillUnlockedEventArgs : EventArgs {
        public SkillType skillType;
    }

    public enum SkillType
    {
        None,
        //MeleeDamage
        SolidGrip,
        SharpenedBlades,
        HardenedBlades,
        AgressiveDefence,
        StrongForged,
        PiercingBlades,
        InnerFire,
        ForTheKing,
        KnightOfTheKing,

        //Archery
        HardenedArrows,
        ShootingCape,
        NaturallyCalm,
        LongForgedArrows,
        StrongerDrag,
        EnchantedArrows,
        FullFocus,
        Vitality, 
            
         //Magic
         HeatUp, 
         HighVoltage,
         FireBolt,
         NaturalBalance,
         Devestation,
         LongerShock,
         HardenedLeafs,
         StrongWinds,
         CombatDissolve,
         RoyalMagician,

         //General
         GoodFood,
         DesertersJail,
         HighEducation,
         BetterHealth,
         StrangePotion,
        
    }


    public static List<SkillType> unlockedSkillTypeList;

    public List<SkillType> returnUnlockedSkills() {
        return unlockedSkillTypeList;
    }

    public static void SetUnlockedSkills(List<SkillType> unlockedList) {
        unlockedSkillTypeList = unlockedList;
    }

    public PlayerSkills() {
        unlockedSkillTypeList = new List<SkillType>();
    }

    private void UnlockSkill(SkillType skillType) {
        if(!IsSkillUnlocked(skillType))
        unlockedSkillTypeList.Add(skillType);
        OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
        
    }

    public bool IsSkillUnlocked(SkillType skilltype) {
        if(unlockedSkillTypeList.Contains(skilltype)) {
            return true;
        } else {
            return false;
        }
    }


    public bool CanUnlock(SkillType skillType) {
        SkillType skillRequirement = GetSkillRequirement(skillType);
        SkillType secondskillRequirement = GetSecondSkillRequirement(skillType);
        if (skillRequirement != SkillType.None) {
            if (IsSkillUnlocked(skillRequirement) || IsSkillUnlocked(secondskillRequirement)) {
                
                return true;
            } 
            else {
                return false;
            }
        }

        else {
            
            return true;
        }

    }


    public SkillType GetSkillRequirement(SkillType skillType) {
        switch (skillType) {
            //Melee
            case SkillType.SolidGrip: return SkillType.SharpenedBlades;
            case SkillType.ForTheKing: return SkillType.PiercingBlades;
            case SkillType.StrongForged: return SkillType.SolidGrip;
            case SkillType.PiercingBlades: return SkillType.StrongForged;
            case SkillType.AgressiveDefence: return SkillType.SolidGrip;
            case SkillType.InnerFire: return SkillType.AgressiveDefence;
            case SkillType.KnightOfTheKing: return SkillType.ForTheKing;

            //Archery 
            case SkillType.NaturallyCalm: return SkillType.ShootingCape;
            case SkillType.LongForgedArrows: return SkillType.NaturallyCalm;
            case SkillType.StrongerDrag: return SkillType.LongForgedArrows;
            case SkillType.EnchantedArrows: return SkillType.LongForgedArrows;
            case SkillType.FullFocus: return SkillType.EnchantedArrows;
            case SkillType.Vitality: return SkillType.FullFocus;

            //Melee
            case SkillType.Devestation: return SkillType.HeatUp;
            case SkillType.LongerShock: return SkillType.HighVoltage;
            case SkillType.HardenedLeafs: return SkillType.NaturalBalance;
            case SkillType.FireBolt: return SkillType.Devestation;
            case SkillType.StrongWinds: return SkillType.LongerShock;
            case SkillType.CombatDissolve: return SkillType.StrongWinds;
            case SkillType.RoyalMagician: return SkillType.CombatDissolve;

            //General 

            case SkillType.DesertersJail: return SkillType.GoodFood;
            case SkillType.HighEducation: return SkillType.DesertersJail;
            case SkillType.BetterHealth: return SkillType.HighEducation;
            case SkillType.StrangePotion: return SkillType.BetterHealth;

        } 
        return SkillType.None;
    }

    public SkillType GetSecondSkillRequirement(SkillType skillType) {
        switch (skillType) {
            //Melee
            case SkillType.SolidGrip: return SkillType.HardenedBlades;
            case SkillType.ForTheKing: return SkillType.InnerFire;

            //Archery
            case SkillType.NaturallyCalm: return SkillType.HardenedArrows;
            case SkillType.FullFocus: return SkillType.StrongerDrag;

            //Magic
            case SkillType.FireBolt: return SkillType.LongerShock;
            case SkillType.StrongWinds: return SkillType.HardenedLeafs;
            case SkillType.CombatDissolve: return SkillType.FireBolt;

        }
        return SkillType.None;
    }

    public bool TryUnlockSkill(SkillType skillType) {
       if (CanUnlock(skillType)) {
            UnlockSkill(skillType);
            
            return true;
            
        } else {
            return false;
        }
       

    }

    public void ClearUnlocks() {
        unlockedSkillTypeList.Clear();
        
    }


}
