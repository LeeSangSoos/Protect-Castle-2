using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_attack : MonoBehaviour
{
  float attack;
  float atimer, attack_speed;
  public Animator anim;
  public GameObject shield;
  public GameObject inven;


  private void Start()
  {
    attack_speed = 3f;
    atimer = attack_speed+1;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
      if(inven.activeSelf==true)
        attack_cal();

    if (attack==1)
    {
      atimer += 1 * Time.deltaTime;
    }

    if (Input.GetKeyDown(KeyCode.Keypad1))
    {
      skill1();
    }
    else if (Input.GetKeyDown(KeyCode.Keypad2))
    {
      skill2();
    }
    else if (Input.GetKeyDown(KeyCode.Keypad3))
    {
      skill3();
    }
    else if (Input.GetKeyDown(KeyCode.Keypad4))
    {
      skill4();
    }
  }

  void attack_cal()
  {
    if (atimer> attack_speed)
    {
      attack = 1;
      atimer = 0;
      anim.SetTrigger("attack");
    }
  }

  
  void skill1()
  {

  }
  void skill2()
  {
  
  }
  void skill3()
  {

  }
  void skill4()
  {

  }
}
