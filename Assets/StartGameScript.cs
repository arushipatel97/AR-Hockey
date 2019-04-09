using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    public Button StartGameButton;
    public GameObject NetworkManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        StartGameButton.onClick.AddListener(startGameFunc);
    }

    void startGameFunc()
    {
        StartGameButton.gameObject.SetActive(false);
        NetworkManagerObject.SetActive(true);
    }
}