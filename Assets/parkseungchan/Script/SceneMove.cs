using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMove : MonoBehaviour
{
    public void StartBtnMove()
    {
        SceneManager.LoadScene("ingame");
    }

    public void HowToPlayBtnMove()
    {
        SceneManager.LoadScene("HowToPlay");
    }


    public void ReturnBtnMove()
    {
        SceneManager.LoadScene("Main");
    }

    public void EndBtnMove()
    { 
        Application.Quit();  
        Debug.Log("게임 종료");
    }

}
