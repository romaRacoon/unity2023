using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerChatView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private bool _isOpen;

    private void Start()
    {
        _isOpen = false;
        _panel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isOpen == false)
            {
                _isOpen = true;
                _panel.SetActive(true);
            }
            else if(_isOpen)
            {
                _isOpen = false;
                _panel.SetActive(false);
            }
        }
    }
}
