using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    [SerializeField] private float m_radius = 1.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CheckBounceClick(Vector2 click_position)
    {
        Vector2 pos = this.transform.position;

        if (Vector2.Distance(click_position, pos) < m_radius)
        {
            var dir = new Vector2(pos.x - click_position.x, pos.y - click_position.y);

            dir.Normalize();
            var rb2d = this.GetComponent<Rigidbody2D>();

            rb2d.AddForce(dir * Time.deltaTime * 100.0f);
        }
    }
}
