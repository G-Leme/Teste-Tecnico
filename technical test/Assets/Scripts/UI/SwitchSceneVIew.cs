using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSceneVIew : MonoBehaviour
{
    [SerializeField] private Button playButton;

    [SerializeField] private GameObject mainMenuSceneView;

    [SerializeField] private GameObject mainGameSceneView;
    void Awake()
    {
        playButton.onClick.AddListener(OnButtonPlayTouch);
    }
   

    private void OnButtonPlayTouch()
    {
        mainMenuSceneView.SetActive(false);

        mainGameSceneView.SetActive(true);
    }
}
