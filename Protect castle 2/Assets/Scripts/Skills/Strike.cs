using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
  public string explain = "Deal damage in front (Str*2+attack)";
  float damage;

  public void set(float str, float attack, float skillbonus)
  {
    damage = (str * 2 + attack) * skillbonus;
  }

  private void OnEnable()
  {
    StartCoroutine(destroy());
  }

  private void OnTriggerEnter(Collider collision)
  {
    if (collision.tag == "enemy")
    {
      collision.GetComponent<enemy1>().c_hp(-damage);
    }
  }

  IEnumerator destroy()
  {
    yield return new WaitForSeconds(0.3f);
    gameObject.SetActive(false);
  }
}
