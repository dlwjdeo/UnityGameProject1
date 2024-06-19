using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public GameObject obj;
    public float moveSpeed;
    public float speed;
    public float addSpeed;
    public game_manager manager;
    public int hp;
    // Start is called before the first frame update
    private void Awake()
    {
        //addSpeed = obj.GetComponent<game_manager>().getScore();
        speed =  addSpeed + moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        Vector3 moveVelocity = new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        this.transform.position += moveVelocity;
    }


    public void getDamage()
    {
        hp = hp - 1;
    }


}
