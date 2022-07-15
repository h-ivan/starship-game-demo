using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    private Animator _animator;
    private const float Speed = 1.5f;
    public Ghost ghost;
    private static readonly int MovingUp = Animator.StringToHash("MovingUp");
    private static readonly int MovingDown = Animator.StringToHash("MovingDown");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.X))
        {
            ghost.makeGhost = true;
            transform.position += new Vector3(x * Speed * 2 * Time.deltaTime,y * Speed * 2 * Time.deltaTime ,0);
        }
        else
        {
            ghost.makeGhost = false;
            transform.position += new Vector3(x * Speed * Time.deltaTime,y * Speed * Time.deltaTime ,0);
        }
        
        
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _animator.SetBool(MovingUp, true);
            _animator.SetBool(MovingDown, false);
        }
        else
        {
            _animator.SetBool(MovingUp, false);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetBool(MovingUp, false);
            _animator.SetBool(MovingDown, true);
        }
        else
        {
            _animator.SetBool(MovingDown, false);
        }


        
        
    }
}
