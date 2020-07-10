using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    private Rigidbody arrow;
    public float speed;

    private Vector3 mousePos;

    // Use this for initialization
    void Start () {
        arrow = GetComponent<Rigidbody> ();
    }

	void FixedUpdate () {
        //arrow.position += Vector3.up * speed;
        /*Vector2 direction = target - myPos;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, myPos, Quaternion.identity);
        projectile.rigidbody2D.velocity = direction * speed;*/

        //--arrow.transform.LookAt(Input.mousePosition);
        //--arrow.AddRelativeForce(Vector3.forward * speed);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // arrow.velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y) * speed;
        //arrow.AddForce(new Vector3(Input.mousePosition.) * speed);

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Borders")
            Destroy(gameObject);
    }
}
