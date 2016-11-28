using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;// ←new!

public class player : MonoBehaviour
{
    float speed = 4f; //歩くスピード

    int kagi;
    int hp;

    private Rigidbody2D rigidbody2D;
    private Animator anim;

    void Start()
    {

        //各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        kagi = 0;
        hp = 3;
    }

    void OnCollisionEnter2D(Collision2D
       collision)
    {
        
        if (collision.gameObject.tag == "enemy_1")
        {
            hp = 2;
            print("体力1減少");
            SceneManager.LoadScene("new game");//scenechange
            print("enemy_1に当たっている");

            if (collision.gameObject.tag == "enemy_1")
            {
                hp = 1;
                print(hp);
                SceneManager.LoadScene("new game");//scenechange
                print("enemy_1に当たっている");

                if (collision.gameObject.tag == "enemy_1")
                {
                    hp = 0;
                    print(hp);
                    SceneManager.LoadScene("new game");//scenechange
                    print("enemy_1に当たっている");

                    if (hp == 0)
                    {
                        Destroy(this.gameObject);
                        hp = 3;
                        SceneManager.LoadScene("title");
                    }
                }
            }
        }
        if (collision.gameObject.tag == "enemy_2")
        {
            hp = 2;
            print(hp);
            SceneManager.LoadScene("2");//scenechange
            print("enemy_2に当たっている");

            if (collision.gameObject.tag == "enemy_2")
            {
                hp = 1;
                print(hp);
                SceneManager.LoadScene("2");//scenechange
                print("enemy_2に当たっている");

                if (collision.gameObject.tag == "enemy_2")
                {
                    hp = 0;
                    print(hp);
                    SceneManager.LoadScene("2");//scenechange
                    print("enemy_2に当たっている");
                    if (hp == 0)
                    {
                        Destroy(this.gameObject);
                        hp = 3;
                        SceneManager.LoadScene("title");
                    }
                }
            }
        }
        if (collision.gameObject.tag == "enemy_3")
        {
            hp = 2;
            print("hp");
            SceneManager.LoadScene("3");//scenechange
            print("enemy_3に当たっている");

            if (collision.gameObject.tag == "enemy_3")
            {
                hp = 1;
                print(hp);
                SceneManager.LoadScene("3");//scenechange
                print("enemy_3に当たっている");

                if (collision.gameObject.tag == "enemy_3")
                {
                    hp = 0;
                    print(hp);
                    SceneManager.LoadScene("3");//scenechange
                    print("enemy_3に当たっている");
                    if (hp == 0)
                    {
                        Destroy(this.gameObject);
                        hp = 3;
                        SceneManager.LoadScene("title");
                    }
                }
            }
        }




        if (collision.gameObject.tag == "tobira_1")
        {
            SceneManager.LoadScene("2");//scenechange
            hp = 3;
            print("scenechange");
        }

        if (collision.gameObject.tag == "tobira_2")
        {
            SceneManager.LoadScene("3");//scenechange
            hp = 3;
            print("scenechange");
        }

        if (collision.gameObject.tag == "tobira_3")
        {
            SceneManager.LoadScene("title");//scenechange
            hp = 3;
            print("scenechange");
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);//が回転

    //左キー: -1、右キー: 1
        float x = Input.GetAxisRaw("Horizontal");
        //左か右を入力したら
        if (x != 0)
        {
            //入力方向へ移動
            rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
            //localScale.xを-1にすると画像が反転する
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;

            //Wait→Dash
            anim.SetBool("Dash", true);
            //左も右も入力していなかったら
        }
        else
        {
            //横移動の速度を0にしてピタッと止まるようにする
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            //Dash→Wait
            anim.SetBool("Dash", false);
        }
    }
}
    
