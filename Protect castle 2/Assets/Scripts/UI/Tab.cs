using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
  GameObject stat_button, skill_button, inventory_button, quest_button, map_button, setting_button,
    stat, skills, inventory, quest, map, setting;

  private void Awake()
  {
    stat_button = transform.GetChild(0).gameObject;
    skill_button = transform.GetChild(1).gameObject;
    inventory_button = transform.GetChild(2).gameObject;
    quest_button = transform.GetChild(3).gameObject;
    map_button = transform.GetChild(4).gameObject;
    setting_button = transform.GetChild(5).gameObject;
    stat = transform.GetChild(6).gameObject;
    skills = transform.GetChild(7).gameObject;
    inventory = transform.GetChild(8).gameObject;
    quest = transform.GetChild(9).gameObject;
    map = transform.GetChild(10).gameObject;
    setting = transform.GetChild(11).gameObject;
  }

  private void Start()
  {
    stat.SetActive(true);
    skills.SetActive(false);
    inventory.SetActive(false);
    quest.SetActive(false);
    map.SetActive(false);
    setting.SetActive(false);
  }
  public void act_stat()
  {
    stat.SetActive(true);
    skills.SetActive(false);
    inventory.SetActive(false);
    quest.SetActive(false);
    map.SetActive(false);
    setting.SetActive(false);
  }
  public void act_skills()
  {
    stat.SetActive(false);
    skills.SetActive(true);
    inventory.SetActive(false);
    quest.SetActive(false);
    map.SetActive(false);
    setting.SetActive(false);
  }
  public void act_inventory()
  {
    stat.SetActive(false);
    skills.SetActive(false);
    inventory.SetActive(true);
    quest.SetActive(false);
    map.SetActive(false);
    setting.SetActive(false);
  }
  public void act_quest()
  {
    stat.SetActive(false);
    skills.SetActive(false);
    inventory.SetActive(false);
    quest.SetActive(true);
    map.SetActive(false);
    setting.SetActive(false);
  }
  public void act_map()
  {
    stat.SetActive(false);
    skills.SetActive(false);
    inventory.SetActive(false);
    quest.SetActive(false);
    map.SetActive(true);
    setting.SetActive(false);
  }
  public void act_setting()
  {
    stat.SetActive(false);
    skills.SetActive(false);
    inventory.SetActive(false);
    quest.SetActive(false);
    map.SetActive(false);
    setting.SetActive(true);
  }
}
