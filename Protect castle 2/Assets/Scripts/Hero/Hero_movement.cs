using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hero_movement : MonoBehaviour
{
  public Animator anim;
  float moveV, moveH;
  public Rigidbody rbody;
  float speed, jump_power, turn_speed;
  public bool jump;
  bool constmove;
  public Vector3 rotation, move_Vector;
  TextMeshProUGUI movespeed;

  private void Awake()
  {
    movespeed = GameObject.Find("movespeed").GetComponent<TextMeshProUGUI>();
  }


  void Start()
  {
    turn_speed = 100f;
    c_speed(25f);
    jump_power = 5f;
    rotation = transform.eulerAngles;
  }

  void Update()
  {
    //이동방향 변수처리
    if (constmove == false)
    {
      moveV = Input.GetAxis("Vertical");
    }
    moveH = Input.GetAxis("Horizontal");
    anim.SetFloat("walk", moveV);

    //X키 클릭시 자동이동
    if (Input.GetKeyDown(KeyCode.X) && constmove == false)
    {
      moveV = 1;
      constmove = true;
    }
    else if (Input.GetKeyDown(KeyCode.X) && constmove == true)
    {
      moveV = 0;
      constmove = false;
    }
    else if (Input.GetAxis("Vertical") != 0 && constmove == true)
    {
      moveV = 0;
      constmove = false;
    }

    //회전벡터
    move_Vector = new Vector3(Mathf.Sin(rotation.y * Mathf.Deg2Rad), 0,
            Mathf.Cos(rotation.y * Mathf.Deg2Rad)).normalized;

    //점프
    if (Input.GetButtonDown("Jump") && jump == false)
    {
      GetComponent<Rigidbody>().AddForce(Vector3.up * jump_power, ForceMode.Impulse);
      jump = true;
    }

  }

  private void FixedUpdate()
  {
    //회전
    rotation += new Vector3(0, moveH * turn_speed * Time.deltaTime, 0);
    Quaternion rot = Quaternion.Euler(rotation);

    rbody.MoveRotation(rot);

    //이동시에만 속도부여
    if (Iswalk())
    {
     if (Mathf.Abs(rbody.velocity.x) + Mathf.Abs(rbody.velocity.z) <= 2.5f)
      {
        rbody.AddForce(moveV*move_Vector * speed * Time.deltaTime, ForceMode.Impulse);
      }
    }
  }

  //걷기 체크
  bool Iswalk()
  {
    if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk")&&
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.01f)
      return true;
    return false;
  }

  public void c_speed(float change)
  {
    speed += change;
    movespeed.text = "MSP: " + speed;
  }
}