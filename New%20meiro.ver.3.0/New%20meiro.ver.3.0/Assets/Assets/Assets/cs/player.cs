using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float speed = 4f; //歩くスピード
	private Rigidbody2D rigidbody2D;
	private Animator anim;

	void Start () {
		//各コンポーネントをキャッシュしておく
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D
       collision)
    {
        //衝突判定http://qiita.com/JunShimura/items/867179092a2a564bc88c
        if (collision.gameObject.tag == "enemy")
        {
            //相手のタグがenemyならば、自分を消す
            Destroy(this.gameObject);
            print("enemyに当たっている");
        }
    }

    void FixedUpdate (){
		transform.rotation = Quaternion.Euler (0, 0, 0);

		//左キー: -1、右キー: 1
		float x = Input.GetAxisRaw ("Horizontal");
		//左か右を入力したら
		if (x != 0) {
			//入力方向へ移動
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;

			//Wait→Dash
			anim.SetBool ("Dash", true);
			//左も右も入力していなかったら
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			//Dash→Wait
			anim.SetBool ("Dash", false);
		}
	}
}