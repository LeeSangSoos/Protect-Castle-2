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
    explane = "������ ��Ÿ�Ͽ� (Str*2+attack)��ŭ�� �������� �ݴϴ�";
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
