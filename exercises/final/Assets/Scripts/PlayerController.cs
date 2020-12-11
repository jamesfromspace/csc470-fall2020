using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    public float playerHealth;

    float enemyDamage = 0.1f;
    float cameraPitch = 0.0f;
    float yVelocity = 0.0f;
    float jumpForce = 2.0f;
    float gravityModifier = 0.2f;

    bool prevIsGrounded = true;

    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    void Start()
    {
        playerHealth = 1.0f;

        controller = GetComponent<CharacterController>();
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();

        //--- DEALING WITH GRAVITY ---
		if (!controller.isGrounded)
        { //If we go in this block of code, cc.isGrounded is false (that's what the ! does)
			//If we're not on the ground, apply "gravity" to yVelocity
			yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

			//If we are moving upward (yVelocity > 0), and the player has released the jump button
			//start falling downward (by setting the yVelocity to 0)
			if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0) 
            {
				yVelocity = 0;
			}
		} 
        else 
        {
			if (!prevIsGrounded) {
				//By being in this if statement, we know we JUST landed.
				//NOTE: We know we just landed because cc.isGrounded is true (meaning
				//		on the last cc.Move() call we collided with something. This condition also
				//		required previousIsGroundedValue to be false which means we were not colliding
				//		with the ground on the previous Update.

				//Set the yVelocity to zero right when we hit the ground so that we don't accumulate 
				//a bunch of yVelocity. The CharacterController will prevent us from moving through
				//the floor, but we are managing the yVelocity ourselves, so we need to make sure
				//that it is zero when we start to fall. This is where we do that.
				yVelocity = 0;
			}

			//JUMP. When the player presses space, set yVelocity to the jump force. This will immediately
			//make the player start moving upwards, and gravity will start slowing the movement upward
			//and eventually make the player hit the ground (thus landing in the 'if' statment above)
			if (Input.GetKeyDown(KeyCode.Space)) 
            {
				yVelocity = jumpForce;
            }
		}
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
            yVelocity = 0.0f;

        yVelocity += gravity * Time.deltaTime;
		
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * yVelocity;

        controller.Move(velocity * Time.deltaTime);


    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            playerHealth -= enemyDamage;
            Debug.Log(playerHealth);

        }
    }
}