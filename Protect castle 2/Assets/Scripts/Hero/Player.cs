using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  //stats
  Slider HP, MP;
  public Dictionary<string, float> stats =
    new Dictionary<string, float>() { { "maxhp", 0 }, {"maxmp",0},{ "maxexp",0},{ "hp", 0 },{ "mp", 0 },{ "hpplus", 0 },{ "mpplus", 0 },
    {"Str",0 },{"Dex",0 },{"Int",0 },{"exp",0 },{"attackspeed",0 },{"attack",0 },{"defence",0 },{"evade",0 },{"crit",0 },{"skillbonus",0 },
      {"level",0 }, {"resistence",0 } };
  int skillpoint;
  bool isattack;
  float atimer;

  //passive skill level
  public int pa1_1L, pa1_2L;

  //components
  Animator anim;
  TextMeshProUGUI TStr, TDex, TInt, Tlevel, Tattack_speed, Tattack, Tdefence, Tevade, Tcrit, Tskill_bonus, Tmagicresistence, Tskillpoint;
  GameObject Tabinven;
  public skillpanel skillpanel;

  //explain text
  public string sk1ex, sk2ex, sk3ex, sk4ex;
  public string ep1_1, ep1_2, ep1_3, ep4_1, ep4_2, ep4_3, ep10_1, ep20_1, ep35_1, ep50_1, ep10_2, ep10_3, ep20_2, ep20_3, ep35_2, ep35_3,
    ep50_2, ep50_3, ea1_1, ea1_2, ea1_3, ea4_1, ea4_2, ea4_3, ea10_1, ea20_1, ea35_1, ea50_1, ea10_2, ea10_3, ea20_2, ea20_3, ea35_2, ea35_3,
    ea50_2, ea50_3;
  
  private void Awake()
  {
    anim = GetComponentInChildren<Animator>();
    HP = GameObject.Find("Hero_Life").GetComponent<Slider>();
    MP = GameObject.Find("Hero_Mana").GetComponent<Slider>();
    Tabinven = GameObject.Find("Tab");
    TStr = GameObject.Find("Str").GetComponent<TextMeshProUGUI>();
    TDex = GameObject.Find("Dex").GetComponent<TextMeshProUGUI>();
    TInt = GameObject.Find("Int").GetComponent<TextMeshProUGUI>();
    Tlevel = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
    Tattack_speed = GameObject.Find("attack speed").GetComponent<TextMeshProUGUI>();
    Tattack = GameObject.Find("attack").GetComponent<TextMeshProUGUI>();
    Tdefence = GameObject.Find("defence").GetComponent<TextMeshProUGUI>();
    Tevade = GameObject.Find("evade").GetComponent<TextMeshProUGUI>();
    Tcrit = GameObject.Find("crit").GetComponent<TextMeshProUGUI>();
    Tskill_bonus = GameObject.Find("skill bonus").GetComponent<TextMeshProUGUI>();
    Tmagicresistence = GameObject.Find("magicresistence").GetComponent<TextMeshProUGUI>();
    Tskillpoint = GameObject.Find("skill point").GetComponent<TextMeshProUGUI>();
  }

  private void Start()
  {
    c_exp(0);
    atimer = stats["attackspeed"] + 1;
  }

  private void Update()
  {
    attack_cal();
  }

  #region stats change
  public void c_mealdamaged(float change)
  {
    stats["hp"] -= change - stats["defence"];
    HP.value = stats["hp"];
    HP.GetComponentInChildren<TextMeshProUGUI>().text = "HP: " + stats["hp"] + "/" + stats["maxhp"];
  }
  public void c_magicdamaged(float change)
  {
    stats["hp"] -= change;
    HP.value = stats["hp"];
    HP.GetComponentInChildren<TextMeshProUGUI>().text = "HP: " + stats["hp"] + "/" + stats["maxhp"];
  }
  public void c_heal(float change)
  {
    stats["hp"] += change;
    HP.value = stats["hp"];
    HP.GetComponentInChildren<TextMeshProUGUI>().text = "HP: " + stats["hp"] + "/" + stats["maxhp"];
  }
  public void c_maxhp(float change)
  {
    stats["maxhp"] += change;
    HP.maxValue = stats["maxhp"];
    HP.GetComponentInChildren<TextMeshProUGUI>().text = "HP: " + stats["hp"] + "/" + stats["maxhp"];
  }
  public void c_mp(float change)
  {
    stats["mp"] += change;
    MP.value = stats["mp"];
    MP.GetComponentInChildren<TextMeshProUGUI>().text = "MP: " + stats["mp"] + "/" + stats["maxmp"];
  }
  public void c_maxmp(float change)
  {
    stats["maxmp"] += change;
    MP.maxValue = stats["maxmp"];
    MP.GetComponentInChildren<TextMeshProUGUI>().text = "MP: " + stats["mp"] + "/" + stats["maxmp"];
  }
  public void c_hpplus(float change)
  {
    stats["hpplus"] += change;
  }
  public void c_mpplus(float change)
  {
    stats["mpplus"] += change;
  }
  public void c_Str(float change)
  {
    stats["Str"] += change;
    c_maxhp(stats["Str"] * 10);
    c_heal(stats["Str"] * 10);
    c_attack(stats["Str"] * 1);
    c_defence(stats["Str"] * 0.5f);
    c_hpplus(stats["Str"] * 0.5f);
    TStr.text = "Str: " + stats["Str"];
  }
  public void c_Dex(float change)
  {
    stats["Dex"] += change;
    c_attack_speed(stats["Dex"] * 0.05f);
    c_crit(stats["Dex"] * 0.5f);
    c_evade(stats["Dex"] * 0.1f);
    TDex.text = "Dex: " + stats["Dex"];
  }
  public void c_Int(float change)
  {
    stats["Int"] += change;
    c_maxmp(stats["Int"] * 5f);
    c_mp(stats["Int"] * 5f);
    c_skill_bonus(stats["Int"] * 0.05f);
    c_mpplus(stats["Int"] * 0.3f);
    TInt.text = "Int: " + stats["Int"];
  }
  public void c_attack(float change)
  {
    stats["attack"] += change;
    Tattack.text = "ATK: " + stats["attack"];
  }
  public void c_attack_speed(float change)
  {
    stats["attackspeed"] += change;
    Tattack_speed.text = "AS: " + stats["attackspeed"];
  }
  public void c_defence(float change)
  {
    stats["defence"] += change;
    Tdefence.text = "DF: " + stats["defence"];
  }
  public void c_evade(float change)
  {
    stats["evade"] += change;
    Tevade.text = "Eva: " + stats["evade"];
  }
  public void c_crit(float change)
  {
    stats["crit"] += change;
    Tcrit.text = "Cri: " + stats["crit"];
  }
  public void c_skill_bonus(float change)
  {
    stats["skillbonus"] += change;
    Tskill_bonus.text = "SB: " + stats["skillbonus"];
  }
  public void c_resistence(float change)
  {
    stats["resistence"] += change;
    Tmagicresistence.text = "MR: " + stats["resistence"];
  }
  public void c_exp(float change)
  {
    stats["exp"] += change;
    if (stats["maxexp"] <= stats["exp"])
    {
      stats["level"] += 1;
      skillpoint += 1;
      stats["maxexp"] = stats["level"] * stats["level"] * 100;
      if (stats["exp"] >= stats["maxexp"])
        stats["exp"] -= stats["maxexp"];
    }
    Tlevel.text = "Lv: " + stats["level"] + "\nExp: " + (stats["exp"] / stats["maxexp"]) * 100 + "%";
    Tskillpoint.text = "skill point: " + skillpoint;
    if (stats["level"] >= 1)
    {
      for (int j = 0; j < 3; j++)
      {
        skillpanel.passive[0, j].interactable = true;
        skillpanel.active[0, j].interactable = true;
      }
    }
    else if (stats["level"] >= 4)
    {
      for (int j = 0; j < 3; j++)
      {
        skillpanel.passive[1, j].interactable = true;
        skillpanel.active[1, j].interactable = true;
      }
    }
    else if (stats["level"] >= 10)
    {
      for (int j = 0; j < 3; j++)
      {
        skillpanel.passive[2, j].interactable = true;
        skillpanel.active[2, j].interactable = true;
      }
    }
    else if (stats["level"] >= 20)
    {
      for (int j = 0; j < 3; j++)
      {
        skillpanel.passive[3, j].interactable = true;
        skillpanel.active[3, j].interactable = true;
      }
    }
    else if (stats["level"] >= 35)
    {
      for (int j = 0; j < 3; j++)
      {
        skillpanel.passive[4, j].interactable = true;
        skillpanel.active[4, j].interactable = true;
      }
    }
    else if (stats["level"] >= 50)
    {
      for (int j = 0; j < 3; j++)
      {
        skillpanel.passive[5, j].interactable = true;
        skillpanel.active[5, j].interactable = true;
      }
    }
  }
  public bool useskillpoint()
  {
    if (skillpoint > 0)
    {
      skillpoint -= 1;
      Tskillpoint.text = "skill point: " + skillpoint;
      return true;
    }
    else
      return false;
  }
  public float getstat(string name)
  {
    return stats[name];
  }
  #endregion

  void attack_cal()
  {
    if (atimer > stats["attackspeed"])
    {
      if (Input.GetMouseButtonDown(0) && Tabinven.activeSelf == false)
      {
        isattack = true;
        atimer = 0;
        anim.SetTrigger("attack");
      }
      else
      {
        isattack = false;
      }
    }
    if (isattack == true)
    {
      atimer += 1 * Time.deltaTime;
    }
  }
}
