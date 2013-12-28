using UnityEngine;
using System.Collections;

public class EvenManager : MonoBehaviour {

    void Awake()
    {
        //
        GameObject obj = GameObject.Find("btnPause");
        if (obj != null)
        {
            UIEventListener.Get(obj).onClick = Pause;
        }

        obj = GameObject.Find("btnReturn");
        if (obj != null)
        {
            UIEventListener.Get(obj).onClick = Return;
        }

        obj = GameObject.Find("btnContinue");
        if (obj != null)
        {
            UIEventListener.Get(obj).onClick = Continue;
        }

        obj = GameObject.Find("btnReStart");
        if (obj != null)
        {
            UIEventListener.Get(obj).onClick = ReStart;
        }
    }


    //暂停
    void Pause(GameObject obj)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            GameManager.SetCurrentGameState(GameState.PLAYING);
        }
        else
        {
            Time.timeScale = 0;
            GameManager.SetCurrentGameState(GameState.PAUSE);
        }
    }

    //返回
    void Return(GameObject obj)
    {
        Application.LoadLevel("");
    }

    //继续游戏
    void Continue(GameObject obj)
    {
        Time.timeScale = 1;
        GameManager.SetCurrentGameState(GameState.PLAYING);
    }

    //重新开始
    void ReStart(GameObject obj)
    {
        Application.LoadLevel("level0");
        Time.timeScale = 1;
        GameManager.SetCurrentGameState(GameState.PLAYING);
    }
}
