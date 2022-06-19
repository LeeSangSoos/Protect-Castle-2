using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
  Item[] items;
  int inven;
  public GameObject invenUI;
  slot[] slots;
  public GameObject pickitem;
  public GameObject TabUI;
  GameObject item;

  private void Awake()
  {
    slots = invenUI.GetComponentsInChildren<slot>();
  }

  private void Start()
  {
    items = new Item[slots.Length];
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E)&& pickitem.activeSelf==true)
    {
      inven += 1;
      for (int i = 0; i < slots.Length; i++)
      {
        if (items[i] == null)
        {
          items[i] = item.GetComponent<Item>();
          slots[i].image.sprite = item.GetComponentInChildren<Image>().sprite;
          slots[i].item = items[i];
          break;
        }
      }
      item.gameObject.SetActive(false);
      pickitem.SetActive(false);
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "item"&&other.GetComponent<Item>().equipped==false&&inven<slots.Length)
    {
      item = other.gameObject;
      if (TabUI.activeSelf==false)
      {
        pickitem.SetActive(true);
      }
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "item" && other.GetComponent<Item>().equipped == false && inven < slots.Length)
    {
      if (TabUI.activeSelf == false)
      {
       pickitem.SetActive(false);
      }
    }
  }

}
