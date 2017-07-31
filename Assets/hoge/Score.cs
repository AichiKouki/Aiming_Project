using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int m_Score;
    Text text;
    int nCombo;
    int nCntFrame;
    [SerializeField]
    int nComboTime;

    // Use this for initialization
    void Start()
    {
        m_Score = 0;
        text = gameObject.GetComponent<Text>();

        nCombo = 0;
        nCntFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = m_Score.ToString();

        if (nCombo > 0)
        {
            nCntFrame++;
            if( nCntFrame > nComboTime)
            {
                nCombo = 0;
                nCntFrame = 0;
            }
        }
    }

    public void AddScore( )
    {
        nCombo++;
        nCntFrame = 0;

        m_Score += 100 + nCombo * 20;
    }
}
