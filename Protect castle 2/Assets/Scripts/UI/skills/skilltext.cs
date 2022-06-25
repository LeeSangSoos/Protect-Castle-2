using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skilltext : MonoBehaviour
{
  public TextMeshProUGUI explain;
  public Player player;

  private void Start()
  {
    explain.gameObject.SetActive(false);
  }

  public void outexplain()
  {
    explain.gameObject.SetActive(false);
  }

  #region active explain
  public void onsk1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.sk1ex;
  }
  
  public void onsk2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.sk2ex;
  }
  public void onsk3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.sk3ex;
  }
  public void onsk4()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.sk4ex;
  }
  #endregion

  #region passive explain
  public void onpa1_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep1_1;
  }
  public void onpa1_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep1_2;
  }
  public void onpa1_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep1_3;
  }

  public void onpa4_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep4_1;
  }
  public void onpa4_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep4_2;
  }
  public void onpa4_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep4_3;
  }

  public void onpa10_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep10_1;
  }
  public void onpa10_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep10_2;
  }
  public void onpa10_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep10_3;
  }

  public void onpa20_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep20_1;
  }
  public void onpa20_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep20_2;
  }
  public void onpa20_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep20_3;
  }

  public void onpa35_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep35_1;
  }
  public void onpa35_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep35_2;
  }
  public void onpa35_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep35_3;
  }

  public void onpa50_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep50_1;
  }
  public void onpa50_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep50_2;
  }
  public void onpa50_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ep50_3;
  }
  #endregion

  #region passive2 explain
  public void onac1_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea1_1;
  }
  public void onac1_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea1_2;
  }
  public void onac1_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea1_3;
  }

  public void onac4_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea4_1;
  }
  public void onac4_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea4_2;
  }
  public void onac4_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea4_3;
  }

  public void onac10_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea10_1;
  }
  public void onac10_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea10_2;
  }
  public void onac10_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea10_3;
  }

  public void onac20_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea20_1;
  }
  public void onac20_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea20_2;
  }
  public void onac20_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea20_3;
  }

  public void onac35_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea35_1;
  }
  public void onac35_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea35_2;
  }
  public void onac35_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea35_3;
  }

  public void onac50_1()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea50_1;
  }
  public void onac50_2()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea50_2;
  }
  public void onac50_3()
  {
    explain.gameObject.SetActive(true);
    explain.text = player.ea50_3;
  }
  #endregion
}