using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator anim;
    // Use this for initialization
    void Start()
    {//各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 temp = transform.localScale;
        temp.x = x;
        transform.localScale = temp;
    }
}