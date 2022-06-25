using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
  public GameObject Tabinven;
  public GameObject MainUI;
  private void Awake()
  {
    Application.targetFrameRate = 60;
  }

  private void Start()
  {
    Tabinven.SetActive(false);
    Cursor.lockState = CursorLockMode.Confined;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab)&&Tabinven.activeSelf==false)
    {
      Tabinven.SetActive(true);
      //Cursor.visible = true;
    }
    else if(Input.GetKeyDown(KeyCode.Tab) && Tabinven.activeSelf == true)
    {
      Tabinven.SetActive(false);
      //Cursor.visible = false;
    }
  }
}
