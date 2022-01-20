using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 300f;


    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private bool _isJumping = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!_isJumping)
        { 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

            _direction = transform.right * x + transform.forward * z;
        }


        if(Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        transform.position += _direction * Time.fixedDeltaTime * speed;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce);
        _isJumping = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
        {
            _isJumping = false;
        }
    }
}
