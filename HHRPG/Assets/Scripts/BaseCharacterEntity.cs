using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JyGame;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Animator))]
public abstract class BaseCharacterEntity : MonoBehaviour
{
   
#if UNITY_EDITOR
    private void OnValidate()
    {
        var cacheAnimator = GetComponent<Animator>();
        //if (animatorController == null && cacheAnimator != null)
        //    animatorController = cacheAnimator.runtimeAnimatorController;
        EditorUtility.SetDirty(gameObject);
    }
#endif

    public virtual void Dead()
    {
        //var keys = new List<string>(Buffs.Keys);
        //for (var i = keys.Count - 1; i >= 0; --i)
        //{
        //    var key = keys[i];
        //    if (!Buffs.ContainsKey(key))
        //        continue;

        //    var buff = Buffs[key];
        //    buff.BuffRemove();
        //    Buffs.Remove(key);
        //}
    }
    
    public virtual void ApplyBuff(BaseCharacterEntity caster, int level, BaseSkill skill, int buffIndex)
    {
        //if (skill == null || buffIndex < 0 || buffIndex >= skill.GetBuffs().Count || skill.GetBuffs()[buffIndex] == null || Hp <= 0)
        //    return;
        
        //var buff = NewBuff(level, skill, buffIndex, caster, this);
        //if (buff.GetRemainsDuration() > 0f)
        //{
        //    // Buff cannot stack so remove old buff
        //    //if (Buffs.ContainsKey(buff.Id))
        //    //{
        //    //    buff.BuffRemove();
        //    //    Buffs.Remove(buff.Id);
        //    //}
        //    //Buffs[buff.Id] = buff;
        //}
        //else
        //    buff.BuffRemove();
    }

    public void ChangeActionClip(AnimationClip clip)
    {
        //CacheAnimatorController[ANIM_ACTION_STATE] = clip;
    }

    //public abstract BaseCharacterSkill NewSkill(int level, BaseSkill skill);
    //public abstract BaseCharacterBuff NewBuff(int level, BaseSkill skill, int buffIndex, BaseCharacterEntity giver, BaseCharacterEntity receiver);
}
