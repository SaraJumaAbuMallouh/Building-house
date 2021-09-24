using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Levels()
    {
        SceneManager.LoadScene(3);
    }
    public void About_us()
    {
        SceneManager.LoadScene(8);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void sure()
    {
        SceneManager.LoadScene(7);
    }
    public void no()
    {
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        SceneManager.LoadScene(6);
    }

  /*  public void Store1()
    {
        SceneManager.LoadScene(7);
    }*/
    public void Music()
    {
        SceneManager.LoadScene(4);
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
    public void setting ()
    {
        SceneManager.LoadScene(4);
    }
}
