using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragitem : MonoBehaviour
{
  public Image image;
  public Item item;

  private void Start()
  {
    gameObject.SetActive(false);
  }
}
