using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Pendulum : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float leftAngle;

    [SerializeField] private float rightAngle;

    private bool _movingClockwise;
    
    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _movingClockwise = true;
    }
    
    private void Update()
    {
        Move();
    }

    private void ChangeDirection()
    {
        if (transform.rotation.z > rightAngle)
        {
            _movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            _movingClockwise = true;
        }
    }

    private void Move()
    {
        ChangeDirection();

        _rigidbody.angularVelocity = _movingClockwise ? new Vector3(0f,0f,moveSpeed) : new Vector3(0f,0f,-moveSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
