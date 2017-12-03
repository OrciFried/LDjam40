using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    string gameScene = "Main";

    [SerializeField]
    GameObject instructions;

    public void EnterGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void InitializeInstructions()
    {
        instructions.SetActive(!instructions.activeSelf);
    }
}
