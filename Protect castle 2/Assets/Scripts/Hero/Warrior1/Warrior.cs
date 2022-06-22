using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Warrior : MonoBehaviour
{
  Slider HP, MP;
  Dictionary<string, float> stats =
    new Dictionary<string, float>() { { "maxhp", 0 }, {"maxmp",0},{ "maxexp",0},{ "hp", 0 },{ "mp", 0 },{ "hpplus", 0 },{ "mpplus", 0 },
    {"Str",0 },{"Dex",0 },{"Int",0 },{"exp",0 },{"attackspeed",0 },{"attack",0 },{"defence",0 },{"evade",0 },{"crit",0 },{"skillbonus",0 },{"level",0 } };
  bool isattack;
  float atimer;
  Animator anim;
  GameObject Tabinven;
  TextMeshProUGUI TStr, TDex, TInt, Tlevel, Tattack_speed, Tattack, Tdefence, Tevade, Tcrit, Tskill_bonus;
  Strike strike;

  Hero_movement hero_Movement;
  Image sprite1, sprite2, sprite3, sprite4;
  public Sprite sksp1, sksp2, sksp3,sksp4;

  private void Awake()
  {
    anim = GetComponent<Animator>();
    HP = GameObject.Find("Hero_Life").GetComponent<Slider>();
    MP = GameObject.Find("Hero_Mana").GetComponent<Slider>();
    Tabinven = GameObject.Find("Tab");
    TStr= GameObject.Find("Str").GetComponent<TextMeshProUGUI>();
    TDex = GameObject.Find("Dex").GetComponent<TextMeshProUGUI>();
    TInt = GameObject.Find("Int").GetComponent<TextMeshProUGUI>();
    Tlevel = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
    Tattack_speed = GameObject.Find("attack speed").GetComponent<TextMeshProUGUI>();
    Tattack = GameObject.Find("attack").GetComponent<TextMeshProUGUI>();
    Tdefence = GameObject.Find("defence").GetComponent<TextMeshProUGUI>();
    Tevade = GameObject.Find("evade").GetComponent<TextMeshProUGUI>();
    Tcrit = GameObject.Find("crit").GetComponent<TextMeshProUGUI>();
    Tskill_bonus = GameObject.Find("skill bonus").GetComponent<TextMeshProUGUI>();
    strike = GetComponentInChildren<Strike>();
    hero_Movement = GameObject.Find("Player").GetComponent<Hero_movement>();
    sprite1 = GameObject.Find("skill1").GetComponent<Image>();
    sprite2 = GameObject.Find("skill2").GetComponent<Image>();
    sprite3 = GameObject.Find("skill3").GetComponent<Image>();
    sprite4 = GameObject.Find("skill4").GetComponent<Image>();
  }
  private void Start()
  {
    c_exp(0);
    c_maxhp(500);
    c_maxmp(100);
    c_attack(5);
    c_attack_speed(4);
    c_crit(0);
    c_defence(1);
    c_Dex(5);
    c_evade(0);
    c_heal(stats["maxhp"]);
    c_mp(stats["maxmp"]);
    c_hpplus(0.5f);
    c_mpplus(0.3f);
    c_skill_bonus(0);
    c_Str(10);
    c_Int(5);
    atimer = stats["attackspeed"] + 1;
    strike.gameObject.SetActive(false);
    sprite1.sprite = sksp1;
    sprite2.sprite = sksp2;
    sprite3.sprite = sksp3;
    sprite4.sprite = sksp4;
    sprite1.GetComponentInChildren<TextMeshProUGUI>().text = "Strike(1)";
    sprite2.GetComponentInChildren<TextMeshProUGUI>().text = "Raise Shield(2)";
    sprite3.GetComponentInChildren<TextMeshProUGUI>().text = "defend/slash(3)";
    sprite4.GetComponentInChildren<TextMeshProUGUI>().text = "Thunder light(4)";
  }

  private void Update()
  {
    attack_cal();

    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      skill1();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      skill2();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      skill3();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      skill4();
    }
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
  void c_hpplus(float change)
  {
    stats["hpplus"] += change;
  }
  void c_mpplus(float change)
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
    TInt.text= "Int: " + stats["Int"];
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
    Tevade.text= "Eva: " + stats["evade"];
  }
  public void c_crit(float change)
  {
    stats["crit"] += change;
    Tcrit.text= "Cri: " + stats["crit"];
  }
  public void c_skill_bonus(float change)
  {
    stats["skillbonus"] += change;
    Tskill_bonus.text= "SB: " + stats["skillbonus"];
  }
  public void c_exp(float change)
  {
    stats["exp"] += change;
    if (stats["maxexp"] <= stats["exp"])
    {
      stats["level"] += 1;
      stats["maxexp"] = stats["level"] * stats["level"] * 100;
      if(stats["exp"] >= stats["maxexp"])
        stats["exp"] -= stats["maxexp"];
    }
    Tlevel.text = "Lv: " + stats["level"] +"\nExp: "+ (stats["exp"] / stats["maxexp"])*100 + "%";
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

  void skill1()
  {
    anim.SetTrigger("skill1");
    strike.gameObject.SetActive(true);
    strike.set(stats["Str"], stats["attack"], stats["skillbonus"]);
    strike.transform.position = transform.position + hero_Movement.move_Vector.normalized*0.3f;
  }
  void skill2()
  {
    anim.SetTrigger("skill2");
    strike.gameObject.SetActive(true);
    strike.set(stats["Str"], stats["attack"], stats["skillbonus"]);
    strike.transform.position = transform.position + hero_Movement.move_Vector.normalized * 0.1f;
  }
  void skill3()
  {

  }
  void skill4()
  {

  }
}