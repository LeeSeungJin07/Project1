using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Action onClickHandler = null;
    public Action onPressedHandler = null;
    public Action onPointerDownHandler = null;
    public Action onPointerUpHandler = null;
    public Action<BaseEventData> onDragHandler = null;
    public Action<BaseEventData> onBeginDragHandler = null;
    public Action<BaseEventData> onEndDragHandler = null;

    private bool _pressed = false;
    private bool _dragged = false;

    private void Update()
    {
        if (_pressed)
            onPressedHandler?.Invoke();
    }

    public void Reset()
    {
        onClickHandler = null;
        onPressedHandler = null;
        onPointerDownHandler = null;
        onPointerUpHandler = null;
        onDragHandler = null;
        onBeginDragHandler = null;
        onEndDragHandler = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_dragged == false)
            onClickHandler?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
        onPointerDownHandler?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
        onPointerUpHandler?.Invoke();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragged = true;
        onDragHandler?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        onBeginDragHandler?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragged = false;
        onEndDragHandler?.Invoke(eventData);
    }
}
