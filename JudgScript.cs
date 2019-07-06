using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class JudgScript : MonoBehaviour
{
    public Text correct_word,correct_word_En; //正解の単語。Enは英語ローマ字表記
    public Text time_limit; //タイムリミットを表示するテキストオブジェクト
    public Text score_text;
    public InputField Player_inputfield; //プレイヤーが文字を入力するフォーム
    public int score_point,misstype_count;//score_point：スコアの値（1回の正解で10ずつ増える）
    public int word_quantity;
    public string[,] words_list = { { "さかな","sakana" },{"ねこ","neko" },{"いぬ", "inu" },{"いばらきこうせん","ibarakikousen" } }; //単語リストの二次元配列。日本語、英語の順に格納
    public float countTime, timer;
 
    //初期動作
    //InputFieldをアクティベートする
    //スコアを0にする
    //正解の単語を設定
    //単語リストの
    void Start()
    {
        //Read_Words_File();
        Player_inputfield.ActivateInputField();
        score_point = 0;
        int word_nm;
        word_nm = UnityEngine.Random.Range(0, 3);
        correct_word.text = words_list[word_nm, 0];
        correct_word_En.text = words_list[word_nm, 1];
        countTime = 0;
        misstype_count = 0;
    }

    void Update()
    {
        //enterキーが押されたときに判定開始
        if (Input.GetKeyDown("return"))
        {
            Debug.Log("input enter"); //デバッグ用

            //入力内容が正解なら10点を加え、文字を変更
            if (Player_inputfield.text == correct_word_En.text)
            {
                Debug.Log("Player input is true");
                score_point += 10;
                ChangeCorrectWord();
                Debug.Log("Change Correct Word.");
            }
            else
            {
                misstype_count += 1;
            }
            Player_inputfield.text = "";
            //Enterを押すとInputFieldが非アクティブになるため
            //再びアクティベートする
            Player_inputfield.ActivateInputField();
        }



        //スコア更新
        score_text.text = "スコア：" + score_point.ToString() + "\nミスした数：" + misstype_count.ToString();

        //タイマー機能
        countTime += Time.deltaTime;
        timer = 30 - Mathf.FloorToInt(countTime); //時間制限の設定はここ
        time_limit.text = timer.ToString();
        if (timer == 0)
        {
            StartScript.score_P = score_point;
            SceneManager.LoadScene("Result");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartScript.miss_count = misstype_count;
            StartScript.score_P = score_point;
            SceneManager.LoadScene("Result");
        }
    }

    //単語のランダム選出
    void ChangeCorrectWord()
    {
        int word_nm;
        word_nm = UnityEngine.Random.Range(0,4); //ワード数を入れる
        while(correct_word.text == words_list[word_nm,0])
        {
            Debug.Log("Re:sellect");
            word_nm = UnityEngine.Random.Range(0, 4); //ワード数を入れる

        }
        correct_word.text = words_list[word_nm, 0];
        correct_word_En.text = words_list[word_nm, 1];
    }
}
