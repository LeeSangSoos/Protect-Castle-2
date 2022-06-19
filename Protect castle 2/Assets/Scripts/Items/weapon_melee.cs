using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_melee : MonoBehaviour
{
  public float damage;
  GameObject hero;
  float basedamage;

  private void Start()
  {
    hero = GameObject.Find("Warrior1_p");
  }

  private void Update()
  {
    basedamage = hero.GetComponent<Hero_status>().attack;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "enemy")
    {
      other.GetComponent<enemy1>().health -= basedamage + damage;
    }

  }
}
