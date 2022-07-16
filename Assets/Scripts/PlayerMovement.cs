using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 5f;
    private float playerRunning = 10f;
    private float rotationSpeed = 250f;
    public Animator moveAnim;

    public GameObject firstCam;
    public GameObject polaroidCam; 
    void Update()
    {
        Movement();
        Cams();
    }

    void Movement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(0, 0, ver);

        transform.Translate(move * playerSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0,hor,0) * rotationSpeed * Time.deltaTime);
        

        if (move == Vector3.zero)
        {
            moveAnim.SetBool("isWalking", false);
        } else
        {
            moveAnim.SetBool("isWalking", true);
        }
        
        
        float run = Input.GetAxis("LeftShift");
        
        if (run > 0)
        {
            transform.Translate(move * playerRunning * Time.deltaTime);
        }
    }

    void Cams()
    {
        if (Input.GetMouseButton(1))
        {
            polaroidCam.SetActive(true);
            firstCam.SetActive(false);
        }
        else
        {
            polaroidCam.SetActive(false);
            firstCam.SetActive(true);
        }
        
        
    }
}
