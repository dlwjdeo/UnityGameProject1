using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public enemy_move enemyObj;
    public game_manager manager;
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public Transform pos;
    public Vector2 BoxSize;

    private float curTime;
    public float coolTime = 0.5f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (Mathf.Abs(rigid.velocity.x) < 0.1)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        if(curTime <= 0)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, BoxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        Debug.Log(collider.tag);
                        manager.plus_score();
                        collider.GetComponent<enemy_move>().getDamage();
                    }
                }
                anim.SetTrigger("isAttack");
            }
            curTime = coolTime;
        }
        else
        {
            curTime -= Time.deltaTime; 
        }


    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        if(rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, BoxSize);
    }
}
