using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressKey : MonoBehaviour
{
    int nCntFrame;
    [SerializeField]
    string NextStageName;

    Text text;

    // Use this for initialization
    void Start()
    {
        nCntFrame = 0;

        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        nCntFrame++;
        if( Input.GetKeyDown(KeyCode.Space))
        {
            if( nCntFrame > 30)
            {
                SceneManager.LoadScene(NextStageName);
            }
        }

        if( nCntFrame % 100 < 70)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
