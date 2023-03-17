using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private Image image;
    [HideInInspector]public Item item { get; private set; }

    public void SetupItemUI(Item item)
    {
        this.item = item;
        image.sprite = item.Icon;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        GameUI.Instance.IsDragging = true;
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 localPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.root.transform as RectTransform, mousePos, transform.root.GetComponent<Canvas>().worldCamera, out localPos))
        {
            transform.localPosition = localPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        GameUI.Instance.IsDragging = false;
        image.raycastTarget = true;
    }
}
