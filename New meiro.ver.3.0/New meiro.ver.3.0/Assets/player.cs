using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;// ←new!

public class player : MonoBehaviour
{

    public float speed = 4f; //歩くスピード
    private Rigidbody2D rigidbody2D;
    private Animator anim;

    void Start()
    {
        //各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D
       collision)
    {
        /*
         * //衝突判定http://qiita.com/JunShimura/items/867179092a2a564bc88c
         if (collision.gameObject.tag == "enemy")
         {
             //相手のタグがenemyならば、自分を消す
             Destroy(this.gameObject);
             SceneManager.LoadScene("title");
             //scenechange
             print("enemyに当たっている");
         }
         */

        if (collision.gameObject.tag == "enemy_1")
        {
            SceneManager.LoadScene("new game");//scenechange
            print("enemy_1に当たっている");
        }
            if (collision.gameObject.tag == "enemy_2")
            {
                SceneManager.LoadScene("2");//scenechange
                print("enemy_2に当たっている");
            }
            if (collision.gameObject.tag == "enemy_3")
            {
                SceneManager.LoadScene("3");//scenechange
                print("enemy_3に当たっている");
            }


            if (collision.gameObject.tag == "tobira_1")
            {
                SceneManager.LoadScene("2");//scenechange
                print("scenechange");
            }

            if (collision.gameObject.tag == "tobira_2")
            {
                SceneManager.LoadScene("3");//scenechange
                print("scenechange");
            }

            if (collision.gameObject.tag == "tobira_3")
            {
                // if (text.Text.pixelOffset.x > 1)
                //{
                //  text.Text.pixelOffset -= new Vector2(10.0f, 0);
                //}
                //Time.timeScale = 0;

                SceneManager.LoadScene("title");//scenechange
                print("scenechange");
            }
        }
 void Update()
            {
            transform.rotation = Quaternion.Euler(0, 0, 0);

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

            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("new game");
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene("2");
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("3");
            }
        }
    }
