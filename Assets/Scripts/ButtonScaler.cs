using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    private Vector3 _startPos;

    [SerializeField]
    private float _scaleTime = 0.2f;
    [SerializeField]
    private float _scale = 2f;
    [SerializeField]
    private Vector3 _scalePositipn;
    [SerializeField]
    private bool _changePos;


    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPos = _rectTransform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rectTransform.DOScale(new Vector3(_scale, _scale, _scale), _scaleTime);
        if(_changePos)
        _rectTransform.DOLocalMove(_scalePositipn, _scaleTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.DOScale(new Vector3(1, 1, 1), _scaleTime);
        if(_changePos)
        _rectTransform.DOLocalMove(_startPos, _scaleTime);
    }
}
