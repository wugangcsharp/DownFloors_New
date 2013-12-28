using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    public static float terrainSpeed;
    private static GameState currentGameState;
 
    UILabel lableScore;
    float score;
    float timer;

	void Awake () {
        timer = 1;
        score = 0;
        terrainSpeed = 50000f * Time.deltaTime;
        lableScore = GameObject.Find("lblScore").GetComponent<UILabel>();
        currentGameState = GameState.PLAYING;
	}
    void Start()
    {

        Animator m_animator = this.GetComponent<Animator>();
        m_animator.Play("");//没试过这个，不确定能不能正常切换动画并播放
        m_animator.SetBool("动画参数", true);//播放动画
        m_animator.SetBool("动画参数", false);//停止动画


        AnimatorStateInfo stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);


    }
    void Update()
    {
        switch (currentGameState)
        {
            case GameState.PLAYING:
                 timer -= Time.deltaTime;
                 if (timer <= 0)
                 {
                     timer = 0.1f;
                     score++;
                     lableScore.text = "得分:" + score;
                 }
                break;
            case GameState.PAUSE:
                break;
            case GameState.GAMEOVER:
                Time.timeScale = 0;
                break;
           
            default:
                break;
        }
    }
	 
    void OnTriggerEnter2D(Collider2D _Collider2D)
    {
        if (_Collider2D.CompareTag("terrain"))
        {
            float x = Random.Range(-309.3755f, 313f);
            float y = -608.2737f;
            _Collider2D.transform.localPosition = new Vector3(x, y, 0);
        }
        else if (_Collider2D.CompareTag("Player"))
        {
            Player.SetLife(-0.1f);
        }

    }

    public static void SetCurrentGameState(GameState changeGaneState)
    {
        currentGameState = changeGaneState;
    }
     
}

public enum GameState
{
    /// <summary>
    /// 正常游戏中
    /// </summary>
    PLAYING,
    /// <summary>
    /// 暂停
    /// </summary>
    PAUSE,
    /// <summary>
    /// 游戏结束
    /// </summary>
    GAMEOVER
}
