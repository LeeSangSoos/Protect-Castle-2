using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillpanel : MonoBehaviour
{
  public Button[,] passive = new Button[6,3];
  public Button[,] active = new Button[6, 3];
  public GameObject player;

  private void Awake()
  {
    int a=0;
    for (int i = 0; i < 6; i++)
    {
      for(int j = 0; j < 3; j++)
      {
        passive[i,j] = transform.GetChild(a).GetComponent<Button>();
        a += 1;
      }
    }
    for (int i = 0; i < 6; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        active[i, j] = transform.GetChild(a).GetComponent<Button>();
        a += 1;
      }
    }
  }

  private void Start()
  {
    for (int i = 0; i < 6; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        passive[i, j].interactable=false;
        active[i, j].interactable = false;
      }
    }
  }
}
