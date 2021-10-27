using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VehicleController : MonoBehaviour
{
    
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider rearRight;
    [SerializeField] private WheelCollider rearLeft;
    [SerializeField] private GameObject forks;
    [SerializeField] private float torque;
    public Text fuelText;
    public Image fuelImage;
    public float fuelAmount = 100f;
    private bool _forkUpPressed;
    private bool _forkDownPressed;
    private bool _gasPressed;
    private bool _brakePressed;
    private float _speed;

    private void Update()
    {
        //SimpleInput from steering wheel
        float inputHorizontal = SimpleInput.GetAxis("Horizontal") * torque;
        
        //Wheel colliders steer angle
        frontLeft.steerAngle = inputHorizontal;
        frontRight.steerAngle = inputHorizontal;

        //Vehicle Movement
        if (_gasPressed)
        {
            _speed = 500f;
            rearLeft.motorTorque = _speed;
            rearRight.motorTorque = _speed;
            BurnFuel();
        }
        else
        {
            rearLeft.motorTorque = _speed;
            rearRight.motorTorque = _speed;
        }
        if (_brakePressed)
        {
            _speed = -500f;
            rearLeft.motorTorque = _speed;
            rearRight.motorTorque = _speed;
        }

        //Fork movement with touch buttons
        if (_forkUpPressed)
        {
            ForkUp();
        }
        
        if (_forkDownPressed)
        {
            ForkDown();
        }

        //Update fuel amount
        UpdateUI();
        
    }
    
    public void ForkUpButtonPressed()
    {
        _forkUpPressed = true;
    }
    public void ForkUpButtonReleased()
    {
        _forkUpPressed = false;
    }
    public void ForkDownButtonPressed()
    {
        _forkDownPressed = true;
    }
    public void ForkDownButtonReleased()
    {
        _forkDownPressed = false;
    }
    public void GasPedalPressed()
    {
        _gasPressed = true;
    }
    public void GasPedalReleased()
    {
        _speed = 0f;
        _gasPressed = false;
    }
    public void BrakePedalPressed()
    {
        _brakePressed = true;
    }
    public void BrakePedalReleased()
    {
        _brakePressed = false;
    }

    //Detect collision with fuels. Change this to trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Fuel")) return;
        Destroy(collision.collider.gameObject);
        fuelAmount = 100f;
    }

    //Create empty object for maxForkHeight change with 1.8f
    private void ForkUp()
    {
        if (!(forks.transform.position.y < 1.8f)) return;
        var position = forks.transform.position;
        position = new Vector3(position.x, position.y + 0.01f, position.z);
        forks.transform.position = position;
    }
    
    //Same as ForkUp
    private void ForkDown()
    {
        if (!(forks.transform.position.y > 0.1f)) return;
        var position = forks.transform.position;
        position = new Vector3(position.x, position.y - 0.01f, position.z);
        forks.transform.position = position;
    }

    private void UpdateUI()
    {
        fuelImage.fillAmount = fuelAmount / 100;
        fuelText.text =  ((int)fuelAmount).ToString() + "%";   
    }

    private void BurnFuel()
    {
        fuelAmount -= 0.01f;
        if (fuelAmount <= 0)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    
}
