using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _UIDocument;
    
    private Button _button;

    private List<Button> _menuButtons = new List<Button>();

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _UIDocument = GetComponent<UIDocument>();

        _button = _UIDocument.rootVisualElement.Q("StartGameButton") as Button;

        _button.RegisterCallback<ClickEvent>(OnStartGameClick);

        _menuButtons = _UIDocument.rootVisualElement.Query<Button>().ToList();

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnStartGameClick);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }



    }

    private void OnStartGameClick(ClickEvent evt)
    { 
        Debug.Log("You Pressed the Start Button");    
    }

    private void OnAllButtonClick(ClickEvent evt)
    { 
        _audioSource.Play();
    }

}
