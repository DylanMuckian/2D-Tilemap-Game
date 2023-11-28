using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Scrollbar sbr;
    private float distance;


    void Start()
    {
        
    }

    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.forward);
        Vector2 direction = player.transform.position - transform.forward;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit Player");
        if (col.gameObject.tag == "Player")
        {
            sbr.size -= 0.1f; 
        }
    }

    /*private void update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x) {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    } */
}
