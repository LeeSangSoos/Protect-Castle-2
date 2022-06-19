using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public bool equipped;
  public string type;
  public Sprite sprite;
  public GameObject part;

  private void Start()
  {
    if (type == "head")
    {
      part = GameObject.Find("Head");
    }
    else if (type == "body")
    {
      part = GameObject.Find("Body");
    }
    else if (type == "Rarm")
    {
      part = GameObject.Find("arm.R_end");
    }
    else if (type == "Larm")
    {
      part = GameObject.Find("arm.L_end");
    }
  }

  public void equipitem()
  {
    equipped = true;
    gameObject.transform.position = part.transform.position;
    gameObject.transform.parent = part.transform;
    if (type == "head")
    {
      
    }
    else if (type == "body")
    {
      
    }
    else if (type == "Rarm")
    {
      
    }
    else if (type == "Larm")
    {
      
    }
  }

  public void unequipitem()
  {
    equipped = false;
    gameObject.SetActive(false);
    gameObject.transform.parent = null;
  }
}
