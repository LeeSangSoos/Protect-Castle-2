using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public Transform tofollow;
  public float followSpeed = 10f;
  public float sensitivity = 1500f;
  public float xchange = 70f;
  public float follow_speed = 10f;

  float rotZ;
  float rotY;

  public Transform realCamera;
  public Vector3 dirNormalized;
  public Vector3 finalDir;
  public float minDistance;
  public float maxDistance;
  public float finalDistance;

  void Start()
  {
    rotZ = transform.localRotation.eulerAngles.z;
    rotY = transform.localRotation.eulerAngles.y;

    dirNormalized = realCamera.localPosition.normalized;
    finalDistance = realCamera.localPosition.magnitude;
  }

  void Update()
  {
    rotZ += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

    rotZ = Mathf.Clamp(rotZ, -xchange, xchange);//z�� ȸ�� ����(���Ʒ�)
    Quaternion rot = Quaternion.Euler(0, rotY, rotZ);//ȸ����ġ
    transform.rotation = rot;//ȸ��
  }
  private void LateUpdate()//��ֹ� ���� ī�޶� �Ÿ�����
  {
    transform.position = Vector3.MoveTowards(transform.position, tofollow.position, followSpeed * Time.deltaTime);
    finalDir = transform.TransformPoint(dirNormalized * maxDistance);

    RaycastHit hit;

    if (Physics.Linecast(transform.position, finalDir, out hit))
    {
      finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
    }
    else
    {
      finalDistance = maxDistance;
    }
    realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * follow_speed);
  }
}
