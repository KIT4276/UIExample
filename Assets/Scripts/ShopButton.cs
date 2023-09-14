using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private GameObject _additionalButtons;

    private void Start()
    {
        _additionalButtons.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _additionalButtons.SetActive(true);
    }
}
