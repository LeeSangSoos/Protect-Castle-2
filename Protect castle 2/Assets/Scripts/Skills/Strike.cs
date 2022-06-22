using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
  public string explane;
  float damage;

  public void set(float str, float attack, float skillbonus)
  {
    damage = (str * 2 + attack) * skillbonus;
  }
  private void Start()
  {
    explane = "전방을 강타하여 (Str*2+attack)만큼의 데미지를 줍니다";
  }

  private void OnTriggerEnter(Collider collision)
  {
    if (collision.tag == "enemy")
    {
      collision.GetComponent<enemy1>().c_hp(-damage);
    }
    StartCoroutine(destroy());
  }

  IEnumerator destroy()
  {
    yield return new WaitForSeconds(0.3f);
    gameObject.SetActive(false);
  }
}
