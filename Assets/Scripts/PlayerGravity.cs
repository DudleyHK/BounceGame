using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private bool m_reverse_gravity = false;
    // Use this for initialization


    void Start()
    {
        if (m_reverse_gravity)
        {
            var rigidbody = this.GetComponent<Rigidbody2D>();
            if (!rigidbody)
            {
                Debug.Log("No Rigidbody on " + this.name);
                return;
            }

            rigidbody.gravityScale *= -1;
        }
    }

    private void Update()
    {
        if (m_reverse_gravity)
        {
            var rigidbody = this.GetComponent<Rigidbody2D>();
            if (!rigidbody)
            {
                Debug.Log("No Rigidbody on " + this.name);
                return;
            }

            rigidbody.gravityScale = -1;
        }
        else
        {
            var rigidbody = this.GetComponent<Rigidbody2D>();
            if (!rigidbody)
            {
                Debug.Log("No Rigidbody on " + this.name);
                return;
            }

            rigidbody.gravityScale = 1;
        }
    }
}
