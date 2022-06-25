using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_melee : MonoBehaviour
{
  public float damage;
  GameObject hero;

  private void Start()
  {
    hero = GameObject.Find("Player");
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "enemy")
    {
      other.GetComponent<enemy1>().c_hp(-hero.GetComponentInChildren<Player>().getstat("attack")-damage);
    }
  }
}
