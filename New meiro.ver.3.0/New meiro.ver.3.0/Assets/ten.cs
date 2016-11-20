using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//参考 http://detail.chiebukuro.yahoo.co.jp/qa/question_detail/q10152460355

public class ten : MonoBehaviour
{
    int tenmetu = 0;
    Text text;
    void Start()
    {
        // テキストコンポーネントを取得
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }

    void Update()
    {
        // Textからアルファ値を取り出す
        float alpha = text.color.a;
        
       
        if (tenmetu == 0)
        {
            alpha -= 0.02f;
            if (alpha <= 0) {
                tenmetu = 1;
            }
        }
        if (tenmetu == 1)
        {
             alpha += 0.02f;
            if (alpha >= 1)
            {
                tenmetu =0;
            }
        }

        // 0～1.0fに収まるようにする
        alpha = Mathf.Clamp(alpha, 0, 1.0f);

        Color c = text.color;
        c.a = alpha;
        text.color = c;
    }
}