using UnityEngine;
using System.Collections;

public class LifeUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_UI;

    PlayerLife playerLife;

    // Use this for initialization
    void Start()
    {
        playerLife = null;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var ui in m_UI)
        {
            ui.SetActive(false);
        }

        if ( playerLife == null)
        {
            var hoge = GameObject.FindGameObjectWithTag("Player");
            if( hoge != null)
            {
                playerLife = hoge.GetComponent<PlayerLife>();
            }

            return;
        }

        for( int nCnt = 0; nCnt < playerLife.GetLife(); nCnt++)
        {
            m_UI[nCnt].SetActive(true);
        }
    }
}
