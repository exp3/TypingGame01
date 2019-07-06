using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public static int score_P,most_hight_score = 0;
    public Text hight_score;
    public static int miss_count;
    // Start is called before the first frame update
    void Start()
    {
        score_P = 0;
        hight_score.text = "ハイスコア：　" + most_hight_score.ToString();
        miss_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) SceneManager.LoadScene("main");
    }
}
