using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player player;
    public float moveSpeed;
     

    Transform m_transform;
    static UISlider slider;
    void Awake()
    {
        player = this;
        m_transform = this.transform;
        slider = GameObject.Find("HealthBar").GetComponent<UISlider>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        if (m_transform.localPosition.y <= -550.5847f)
        {
            GameManager.SetCurrentGameState(GameState.GAMEOVER);
        }
    }

    public static void SetLife(float damange)
    {
        if (slider.value <= 0)
        {
            GameManager.SetCurrentGameState(GameState.GAMEOVER);
        }
        else
        {
            slider.value += damange;
        }

    }

    void Control()
    {
        if (Application.isEditor || Application.isWebPlayer)
        {
            m_transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);
        }
        else
        {
            #if UNITY_ANDROID
                   m_transform.Translate(Input.acceleration.x * Time.deltaTime * moveSpeed, 0, 0);
            #endif

            #if UNITY_IPHONE
			       _transform.Translate(Input.acceleration.x * Time.deltaTime * moveSpeed, 0, 0);
            #endif

            #if UNITY_STANDALONE_WIN
			       m_transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);
            #endif
        }


        if (m_transform.localPosition.x < -317.2856f)
        {
            m_transform.localPosition = new Vector3(310.9737f, m_transform.localPosition.y, m_transform.localPosition.z);
        }
        if (m_transform.localPosition.x > 317.6707f)
        {
            m_transform.localPosition = new Vector3(-309.6505f, m_transform.localPosition.y, m_transform.localPosition.z);
        }
    }
}
