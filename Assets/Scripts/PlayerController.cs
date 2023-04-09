using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private int count;
    private int numPickups = 6;
    public Text scoreText;
    public Text winText;

    void Start()
    {
        count = 0;
        winText.text = " ";
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime );
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive( false ) ;
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = " Score : " + count.ToString() ;
        if(count >= numPickups )
        {
            winText.text = " You win ! " ;
        }
    }
}
