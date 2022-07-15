
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;

    private float _chargeTimer;
    private static readonly int IsCharging = Animator.StringToHash("IsCharging");
    private static readonly int IsChargingMax = Animator.StringToHash("IsChargingMax");
    private Animator _animator;
    private Animator _animator1;
    private Animator _animator2;
    private const float ChargeTimeMax = 2.0f;
    private const float ChargeTimeMin = 0.5f;


    private void Start()
    {
        _animator = FirePoint.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var go = ObjectPooler.SharedInstance.GetPooledObject(0);
            go.transform.position = FirePoint.position;
            go.transform.rotation = FirePoint.rotation;
            go.SetActive(true);
        }
        
        if(Input.GetButton("Fire1"))
        { 
            _chargeTimer += Time.deltaTime;
            if (_chargeTimer >= ChargeTimeMin)
            {
                _animator.SetBool(IsCharging, true);
            }

        }

        if (_chargeTimer >= ChargeTimeMax)
        {
            _animator.SetBool(IsChargingMax, true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (_chargeTimer >= ChargeTimeMin && _chargeTimer <= ChargeTimeMax)
            {
                var go = ObjectPooler.SharedInstance.GetPooledObject(0);
                go.transform.position = FirePoint.position;
                go.transform.rotation = FirePoint.rotation;
                go.SetActive(true);
            }

            if (_chargeTimer >= ChargeTimeMax)
            {
                var go = ObjectPooler.SharedInstance.GetPooledObject(1);
                go.transform.position = FirePoint.position;
                go.transform.rotation = FirePoint.rotation;
                go.SetActive(true);

            }

            _chargeTimer = 0.0f;
            _animator.SetBool(IsCharging, false);
            _animator.SetBool(IsChargingMax, false);
        }


       
    }

    private void OnBecameInvisible()
    {
        _chargeTimer = 0.0f;
    }
}
