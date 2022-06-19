using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy1 : MonoBehaviour
{
  public Animator anim;
  float attack_speed, time, distance;
  public float health, defense, shield, mana;
  public Transform target;
  NavMeshAgent nav;

  private void Start()
  {
    attack_speed = 3f;
    nav = GetComponent<NavMeshAgent>();
  }

  private void Update()
  {
    time += Time.deltaTime;
    nav.SetDestination(target.position);

    if (health <= 0)
      StartCoroutine(death());
  }

  private void LateUpdate()
  {
    //Å¸°Ù °¨Áö, °ø°Ý
    distance = Vector3.Distance(target.position, transform.position);
    if(distance <= 0.7f)
    {
      nav.isStopped = true;
      if (attack_speed < time)
      {
        anim.SetTrigger("attack");
        time = 0;
      }
    }
    else
    {
      nav.isStopped = false;
    }
  }

  //Å¸°Ùº¯°æÇÔ¼ö
  public void Set_target(Collider t)
  {
    target = t.transform;
  }

  //Á×À½
  IEnumerator death()
  {
    //anim.SetTrigger(death);
    yield return new WaitForSeconds(2f);
    Destroy(gameObject);
  }
}
