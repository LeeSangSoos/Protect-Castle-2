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
    explane = "방패를 올려 10초간 defence를(10+Str*5), magic resistence를(10+Str*4+Int*1)만큼 올립니다.";


    StartCoroutine(destroy());
  }

  IEnumerator destroy()
  {
    yield return new WaitForSeconds(0.3f);
    gameObject.SetActive(false);
  }
}
