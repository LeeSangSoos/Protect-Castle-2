using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_status : MonoBehaviour
{
  public float maxlife,maxmana,maxStr, maxDex,maxInt, maxexp,
    maxaspeed,maxmspeed,maxattack,maxdefense, maxevade, maxcrit, maxskillb;

  public float life, mana, Str, Dex, Int, exp;
  public int level;
  public float attack_speed, movement_speed, attack, defense, evade, crit, skill_bonus;

  private void Awake()
  {
    level = 1;
    exp = 0;
  }

  private void Update()
  {
    #region stats
    life += Str * 10;
    attack += Str * 1;
    defense += Str * 0.5f;
    attack_speed += Dex * 0.05f;
    crit += Dex * 0.5f;
    evade += Dex * 0.1f;
    mana += Int * 5f;
    skill_bonus += Int * 0.05f;
    #endregion

    if (maxexp == exp)
      level += 1;

    maxexp = level * 1000f;
  }
}