using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raise_Shield : MonoBehaviour
{
  public string explane;
  float defence, resistence;

  public void set(float str, float attack, float Int, float skillbonus)
  {
    defence = (10 + str * 5) * skillbonus;
    resistence= (10 + str * 4 + Int * 1) * skillbonus;
  }
  private void Start()
  {
    explane = "���и� �÷� 10�ʰ� defence��(10+Str*5), magic resistence��(10+Str*4+Int*1)��ŭ �ø��ϴ�.";


    StartCoroutine(destroy());
  }

  IEnumerator destroy()
  {
    yield return new WaitForSeconds(0.3f);
    gameObject.SetActive(false);
  }
}
