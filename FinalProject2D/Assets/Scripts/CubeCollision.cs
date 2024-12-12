using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    Collider2D collidore;
    public GameObject ParentCube;

    // Start is called before the first frame update
    void Start()
    {
        collidore = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ParentCube.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitbox"))
        {
            if (ParentCube.transform.position.y >= collision.gameObject.transform.position.y - 0.5f)
            {
                collidore.isTrigger = true;
            }
            else
            {
                collidore.isTrigger = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collidore.isTrigger = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitbox"))
        {
            collidore.isTrigger = false;
        }
    }
}
