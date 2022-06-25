using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class parts : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
{
  public Image image;
  public dragitem dragitem;
  public Item item;
  public string type;

  bool isDragging = false;

  void Awake()
  {
    dragitem = GameObject.Find("dragitem").GetComponent<dragitem>();
  }

  void Start()
  {
    image = GetComponent<Image>();
  }

  //�巡�׽���
  public void OnBeginDrag(PointerEventData eventData)
  {
    if (image == null)
    {
      return;
    }
    //�̵��̹��� �۵�
    dragitem.gameObject.SetActive(true);
    //�̹���, �����۵����� ����
    dragitem.image.sprite = image.sprite;
    dragitem.item = item;
    isDragging = true;
    item.unequipitem();
  }
  // �巡�� ��
  public void OnDrag(PointerEventData eventData)
  {
    if (isDragging)
    {
      dragitem.transform.position = eventData.position;
    }
  }
  // �巡�� ��
  public void OnEndDrag(PointerEventData eventData)
  {
    if (isDragging)
    {
      if (dragitem.image.sprite != null)
      {
        image.sprite = dragitem.image.sprite;
        item = dragitem.item;
      }
      else
      {
        image.sprite = null;
        item = null;
      }
    }

    isDragging = false;
    //�巡�� ������Ʈ �ʱ�ȭ
    dragitem.image.sprite = null;
    dragitem.item = null;
    dragitem.gameObject.SetActive(false);
  }

  // �巡���� ��ȯ
  public void OnDrop(PointerEventData eventData)
  {
    if(dragitem.item.type == type)
    {
      if (dragitem.image.sprite != null)
      {
        // keep data instance for swap 
        Sprite tempSprite = image.sprite;
        Item tempItem = item;

        // set data from drag object on Container
        image.sprite = dragitem.image.sprite;
        item = dragitem.item;

        // put data from drop object to Container.  
        dragitem.image.sprite = tempSprite;
        dragitem.item = tempItem;

        item.gameObject.SetActive(true);
        item.equipitem();
      }
      else
      {
        dragitem.image.sprite = null;
        dragitem.item = null;
      }
    }
  }
}