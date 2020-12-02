using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveCell : MonoBehaviour
{
    public float speed;
    private int points;
    public Text pointsLabel;
    private Rigidbody rb;

    void Start() {
        points = 0;
        pointsLabel.text = "Pontos: " + points.ToString ();
        rb = GetComponent<Rigidbody> ();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 1, moveVertical);

        rb.AddForce (movement * speed);        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            pointsLabel.text = "Game Over";
            Destroy(this.gameObject);
            
        } else if (other.gameObject.CompareTag("Food")) {
            Destroy(other.gameObject);
            points++;
            pointsLabel.text = "Pontos: " + points.ToString ();
        }
    }
}
