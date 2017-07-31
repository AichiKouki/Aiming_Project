using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public int m_Score;
    Text text;
    [SerializeField]
    GameObject Press;

    // Use this for initialization
    void Start()
    {
        m_Score = GameObject.Find("ScoreUI").GetComponent<Score>().m_Score;
        text = gameObject.GetComponent<Text>();
        GameObject hoge = Instantiate(Press);
        hoge.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        m_Score = GameObject.Find("ScoreUI").GetComponent<Score>().m_Score;
        text.text = m_Score.ToString();
    }
}
