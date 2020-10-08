
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameStateEnum
{
    MAINMENU,
    PAUSEMENU,
    MAINGAME,
    INVENTORY,
    SETTINGS
}
public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    public static GameStateManager Instance{get { return _instance; } }
    public  GameStateEnum gameState;
    public  GameStateEnum previousGameState;
    public GameObject mainMenuCanvas;
    public GameObject InventoryCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject settingMenuCanvas;
    public GameObject loadingScreen;
    public Text loadingText;
    public Slider loadingBar;

    public void Awake()
    {
        _instance = this;
    }
    public void ChangeGameState(int state)
    {
        gameState = (GameStateEnum)state;
        GameStateTransition();
        previousGameState = gameState;
    }
    public void ChangeGameState(GameStateEnum state)
    {
        gameState = state;
        GameStateTransition();
        previousGameState = gameState;
    }

    private void GameStateTransition()
    {
        switch(gameState)
            {
            case GameStateEnum.MAINGAME:
                if(previousGameState == GameStateEnum.INVENTORY)
                {
                    InventoryCanvas.SetActive(false);
                }
                else if(previousGameState == GameStateEnum.MAINMENU)
                {
                    StartCoroutine(LoadScene("MainGame"));
                }
                else if(previousGameState == GameStateEnum.PAUSEMENU)
                {
                    pauseMenuCanvas.SetActive(false);
                }
                break;
            case GameStateEnum.INVENTORY:
                InventoryCanvas.SetActive(true);
                break;
            case GameStateEnum.MAINMENU:
                if (previousGameState == GameStateEnum.PAUSEMENU)
                {
                    StartCoroutine(LoadScene("MainMenu"));
                }
                break;
            case GameStateEnum.PAUSEMENU:
                pauseMenuCanvas.SetActive(true);
                break;
            }
    }
    private IEnumerator LoadScene(string scene)
    {
        yield return null;
        
        if (scene == "MainGame")
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            loadingScreen.SetActive(true);
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                loadingText.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";
                loadingBar.value = asyncOperation.progress;

                yield return null;
            }
            loadingScreen.SetActive(false);
            mainMenuCanvas.SetActive(false);
        }
        else if (scene == "MainMenu")
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        }
    }
}
