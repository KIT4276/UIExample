using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircularButtons : MonoBehaviour
{
    private bool _qPressed;
    private bool _isTweening;

    //[SerializeField]
    //private RectTransform _buttonPanel;
    [SerializeField]
    private List<RectTransform> _buttons;
    

    [Space, SerializeField, Tooltip("Button Panel params")]
    private float _emersionScale = 0.1f;
    [SerializeField]
    private float _emersionTime = 0.5f;
    [SerializeField]
    private float _emersionDelfy = 0.1f;

    private void Start()
    {
        foreach (var button in _buttons)
        {
            button.gameObject.SetActive(false);
            button.localScale = new Vector3(_emersionScale, _emersionScale, 1);
        }
        //_buttonPanel.gameObject.SetActive(false);
        //_buttonPanel.localScale = new Vector3(_emersionScale, _emersionScale, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !_isTweening)
        {
            if (_qPressed)
                StartCoroutine(OffPanel());
            else
                StartCoroutine(OnPanel());
        }
    }

    private IEnumerator OnPanel()
    {
        Tween tween = null;
        _isTweening = true;

        foreach (var button in _buttons)
        {
            button.gameObject.SetActive(true);
        }
        //_buttonPanel.gameObject.SetActive(true);

        foreach (var button in _buttons)
        {
            button.DOLocalMove(new Vector3(0, 0, 0), _emersionTime).From();
            tween = button.DOScale(new Vector3(1, 1, 1), _emersionTime);
            yield return new WaitForSeconds(_emersionDelfy);
        }
        yield return tween.WaitForCompletion();
        //Tween tween = _buttonPanel.DOScale(new Vector3(1, 1, 1), _emersionTime);
        //yield return tween.WaitForCompletion();
        _qPressed = true;
        _isTweening = false;
    }

    private IEnumerator OffPanel()
    {
        Tween tween = null;

        _isTweening = true;
        foreach (var button in _buttons)
        {
            tween = button.DOScale(new Vector3(_emersionScale, _emersionScale, _emersionScale), _emersionTime);
            yield return new WaitForSeconds(_emersionDelfy);
            button.gameObject.SetActive(false);
        }
        yield return tween.WaitForCompletion();
        // Tween tween = _buttonPanel.DOScale(new Vector3(0.1f, 0.1f, 0.1f), _emersionTime);
        //yield return tween.WaitForCompletion();
        //_buttonPanel.gameObject.SetActive(false);
        _qPressed = false;
        _isTweening = false;
    }
}
