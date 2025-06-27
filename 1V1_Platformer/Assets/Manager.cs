using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject GameOverScene ;
    public void Exit(){
        Application.Quit();
    }
    public void restart(){
        SceneManager.LoadSceneAsync(1);
    }
    public void GameOver(){
        Debug.Log("gameover");
        GameOverScene.SetActive(true) ;
    }
}
