using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    public Text hight_score,score,missN;
    // Start is called before the first frame update
    void Start()
    {
        missN.text = "ミスした数　：　" + StartScript.miss_count.ToString();
        hight_score.text = "ハイスコア　：　" + StartScript.most_hight_score.ToString();
        score.text = "今回のスコア　：　" + StartScript.score_P.ToString();
        if (StartScript.most_hight_score < StartScript.score_P)
        {
            StartScript.most_hight_score = StartScript.score_P;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Button click!");

        SceneManager.LoadScene("start");
    }
}
