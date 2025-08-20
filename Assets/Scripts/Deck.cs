using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CardManager.Instance.Deal(1, 0);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            CardManager.Instance.Deal(1, 1);
        }
    }
}