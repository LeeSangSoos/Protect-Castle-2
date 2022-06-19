using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
  public GameObject enemy;
  public GameObject castle;

  private void OnTriggerStay(Collider col)
  {
    if(col.tag=="Player")
      enemy.GetComponent<enemy1>().Set_target(col);
  }

  private void OnTriggerExit(Collider col)
  {
    if (col.tag == "Player")
      enemy.GetComponent<enemy1>().Set_target(castle.GetComponent<Collider>());
  }
}
