using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raise_Shield : MonoBehaviour
{
  public string explain = "Encrease defence by (10+Str*5), magic resistence by (10+Str*4+Int*1) for 10 seconds.";
  Player player;

  private void Awake()
  {
    player = GameObject.Find("Player").GetComponent<Player>();
  }

  private void OnEnable()
  {
    transform.localPosition = new Vector3(0, -0.00219f, 0.003f);
    StartCoroutine(destroy());
  }

  public void set(float str, float Int, float skillbonus)
  {
    player.c_defence((10 + str * 5) * skillbonus);
    player.c_resistence((10 + str * 4 + Int * 1) * skillbonus);
  }

  IEnumerator destroy()
  {
    while (transform.localPosition.y <= 0.002f)
    {
      yield return null;
      transform.localPosition = transform.localPosition + new Vector3(0, 0.0001f, 0);
    }
    yield return new WaitForSeconds(0.7f);
    gameObject.SetActive(false);
  }
}
