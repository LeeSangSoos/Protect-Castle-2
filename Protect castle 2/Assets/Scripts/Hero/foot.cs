using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot : MonoBehaviour
{
  public Hero_movement h_move;

  private void OnTriggerEnter(Collider collision)
  {
    if (collision.gameObject.tag == "Floor")
      h_move.jump = false;
  }
}
