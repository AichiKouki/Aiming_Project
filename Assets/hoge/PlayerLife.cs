using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    int m_nLife = 5;
    bool bDamage;
    int nCntFrame;
    [SerializeField]
    int nMutekiTime;
    GameObject ResultPrefab;

    // Use this for initialization
    void Start () {
        bDamage = false;

        ResultPrefab = GameObject.Find("ResultScoreUI");
        ResultPrefab.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if( m_nLife <= 0)
        {
            GameOver();
        }

        if (bDamage == true)
        {
            nCntFrame++;
            if( nCntFrame >= nMutekiTime)
            {
                bDamage = false;
            }
        }
	}

    public void Damage()
    {
        if( bDamage == true)
        {
            return;
        }

        bDamage = true;
        nCntFrame = 0;

        m_nLife--;
    }

    void GameOver( )
    {
        ResultPrefab.SetActive(true);
    }

    public int GetLife()
    {
        if( m_nLife < 0)
        {
            return 0;
        }

        return m_nLife;
    }
}
