using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private Rigidbody _rb;
    private float _moveX;
    private float _moveY;
    private int _count;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _moveX = movementVector.x;
        _moveY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();
        if (_count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_moveX, 0.0f, _moveY);
        _rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}
