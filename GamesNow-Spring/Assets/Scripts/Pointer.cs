using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverArrowUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject arrow;

    private void Start()
    {
        arrow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        arrow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        arrow.SetActive(false);
    }
}
