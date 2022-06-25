using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skilltext : MonoBehaviour
{
  public TextMeshProUGUI explain;
  string hitname;
  public GameObject player;
  public Camera maincam;
  Ray ray;
  RaycastHit hit; 

  private void Update()
  {
    ray = maincam.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray,out hit))
    {
      if (hit.transform.gameObject.tag == "skill")
      {
        explain.gameObject.SetActive(true);
        hitname = hit.transform.gameObject.name;
        if (hitname == "pa1-1")
        {
          explain.text= player.GetComponent<Player>().ep1;
        }
      }
      else
      {
        explain.gameObject.SetActive(false);
      }
    }
  }
}
