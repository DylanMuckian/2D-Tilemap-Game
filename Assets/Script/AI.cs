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

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.forward);
        Vector2 direction = player.transform.position - transform.forward;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        EnemyOrientation();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player Enter: " + col.gameObject);
            sbr.size -= 0.1f;
            //call the animator and set the property for attack true
            animator.SetBool("IsAttacking", true);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player Exit");
            //call the animator and set the property for attack false
            animator.SetBool("IsAttacking", false);
        }
    }

    private void EnemyOrientation()
    {
        Vector3 scale = transform.localScale;
        
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
            //Debug.Log("enemy to left of player"); 
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            //Debug.Log("enemy to right of player");
        }
        transform.localScale = scale;
    }
}
