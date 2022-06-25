using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : MonoBehaviour
{
  Strike strike;
  Raise_Shield raise_Shield;
  public skillpanel skillpanel;
  Image sprite1, sprite2, sprite3, sprite4;
  public Sprite sksp1, sksp2, sksp3, sksp4;
  Player parent;
  Animator anim;
  string ep1_1 = "increase attack by (skill level * 5) " + "(level:" + 0 + "/3)";
  string ep1_2 = "increase defence by (skill level * 5) " + "(level:" + 0 + "/3)";

  private void Awake()
  {
    anim = GetComponent<Animator>();
    sprite1 = GameObject.Find("skill1").GetComponent<Image>();
    sprite2 = GameObject.Find("skill2").GetComponent<Image>();
    sprite3 = GameObject.Find("skill3").GetComponent<Image>();
    sprite4 = GameObject.Find("skill4").GetComponent<Image>();
    strike = GetComponentInChildren<Strike>();
    raise_Shield = GetComponentInChildren<Raise_Shield>();
    parent = GetComponentInParent<Player>();

    #region stats setting
    parent.c_maxhp(500);
    parent.c_maxmp(100);
    parent.c_attack(5);
    parent.c_attack_speed(4);
    parent.c_crit(0);
    parent.c_defence(1);
    parent.c_Dex(5);
    parent.c_evade(0);
    parent.c_heal(parent.stats["maxhp"]);
    parent.c_mp(parent.stats["maxmp"]);
    parent.c_hpplus(0.5f);
    parent.c_mpplus(0.3f);
    parent.c_skill_bonus(0);
    parent.c_Str(10);
    parent.c_Int(5);
    parent.c_resistence(0);
    #endregion
  }
  private void Start()
  {
    strike.gameObject.SetActive(false);
    raise_Shield.gameObject.SetActive(false);

    #region  active sprite, name, skill text
    sprite1.sprite = sksp1;
    sprite2.sprite = sksp2;
    sprite3.sprite = sksp3;
    sprite4.sprite = sksp4;
    GameObject.Find("skill1 text").GetComponent<TextMeshProUGUI>().text = "Strike(1)";
    GameObject.Find("skill2 text").GetComponent<TextMeshProUGUI>().text = "Raise Shield(2)";
    GameObject.Find("skill3 text").GetComponent<TextMeshProUGUI>().text = "Defend/Slash(3)";
    GameObject.Find("skill4 text").GetComponent<TextMeshProUGUI>().text = "Thunder Light(4)";
    parent.sk1ex = strike.explain;
    parent.sk2ex = raise_Shield.explain;
    #endregion

    #region passive sprite, onclick, explain
    skillpanel.passive[0, 0].image.sprite = Resources.Load<Sprite>("sprite/skill/attackup");
    skillpanel.passive[0, 1].image.sprite = Resources.Load<Sprite>("sprite/skill/defenceup");
    skillpanel.passive[0, 0].onClick.AddListener(P_attackup);
    skillpanel.passive[0, 1].onClick.AddListener(P_defenceup);
    parent.ep1_1 = ep1_1;
    #endregion
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1) && parent.stats["mp"] >= 50)
    {
      skill1();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2) && parent.stats["mp"] >= 80)
    {
      skill2();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3) && parent.stats["mp"] >= 100)
    {
      skill3();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4) && parent.stats["mp"] >= 500)
    {
      skill4();
    }
  }

  #region active skill
  void skill1()
  {
    anim.SetTrigger("skill1");
    strike.gameObject.SetActive(true);
    strike.set(parent.stats["Str"], parent.stats["attack"], parent.stats["skillbonus"]);
  }
  void skill2()
  {
    anim.SetTrigger("skill2");
    raise_Shield.gameObject.SetActive(true);
    raise_Shield.set(parent.stats["Str"], parent.stats["attack"], parent.stats["skillbonus"]);
  }
  void skill3()
  {

  }
  void skill4()
  {

  }
  #endregion

  #region passive skill
  void P_attackup()
  {
    if (parent.useskillpoint() && parent.pa1_1L < 3)
    {
      parent.c_attack(5);
      parent.pa1_1L += 1;
      ep1_1 = "increase attack by (skill level * 5) " + "(level:" + parent.pa1_1L + "/3)";
      parent.ep1_1 = ep1_1;
    }
  }
  void P_defenceup()
  {
    if (parent.useskillpoint() && parent.pa1_2L < 3)
    {
      parent.c_defence(5);
      parent.pa1_2L += 1;
      ep1_2 = "increase defence by (skill level * 5) " + "(level:" + parent.pa1_2L + "/3)";
      parent.ep1_2 = ep1_2;
    }
  }
  #endregion
}