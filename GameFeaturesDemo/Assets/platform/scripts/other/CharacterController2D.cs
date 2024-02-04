using UnityEngine;
using UnityEngine.Events;
#pragma warning disable 0649
public class CharacterController2D : MonoBehaviour
{
    //yeehaw

    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded

    [HideInInspector]
    public bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    // private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    
    //checking the direction of the player
    private Vector2 direction;

    //rotating the firepoint
    public GameObject point;
    private bool rotated;

    private bool right;
    private bool sw;

    private bool crouching;
    private bool check;
    

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    public Animator anim;

    private double heighty;
    private double directx;


    //playing running sound
    new public PlatAudio audio;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();

    }


    private void Update()
    {


        //Moving the firepoint UP and DOWN
            if (right == true && crouching == false)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    point.transform.localPosition = new Vector3(-0.163f, 0.221f);
                    point.transform.localRotation = Quaternion.Euler(0.0f, 180f, 35.0f);
                    anim.SetFloat("Up", 1f);
                }
                else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    point.transform.localPosition = new Vector3(-0.211f, 0.084f);
                    point.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
                    anim.SetFloat("Up", 0f);
                }
            }

              

            if (right == false && crouching == false)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    point.transform.localPosition = new Vector3(0.185f, 0.246f);
                    point.transform.localRotation = Quaternion.Euler(0.0f, 0f, 35.0f);
                    anim.SetFloat("Up", 1f);
            }
                else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    point.transform.localPosition = new Vector3(0.211f, 0.084f);
                    point.transform.localRotation = Quaternion.Euler(0.0f, 0f, 0.0f);
                    anim.SetFloat("Up", 0f);
                }
            }
        animate();

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
        

 
    }      

    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (crouch)
        {
            anim.SetFloat("Crouch", 1f);
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
                anim.SetFloat("Crouch", 1f);
            }
        }


        if(move != 0f && m_Grounded == true)
        {
            audio.playing2("Run");

            if (audio.isplaying2 == false)
            {
                audio.Play("Run");
            }
        }
        else
        {
            audio.Stop("Run");
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch && m_Grounded && move == 0f)
            {


                if (!m_wasCrouching)
                    {
                        m_wasCrouching = true;
                        OnCrouchEvent.Invoke(true);
                    }

                    // Reduce the speed by the crouchSpeed multiplier
                    move *= m_CrouchSpeed;

                    // Disable one of the colliders when crouching
                    if (m_CrouchDisableCollider != null)
                        m_CrouchDisableCollider.enabled = false;

                if (right == false)
                {
                    point.transform.localPosition = new Vector3(0.211f, -0.07f);
                    check = false;
                    point.transform.localRotation = Quaternion.Euler(0.0f, 0f, 0.0f);
                }


                if (right == true)
                {
                    point.transform.localPosition = new Vector3(-0.211f, -0.07f);
                    check = false;
                    point.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
                }
            }
                else
                {
                    // Enable the collider when not crouching
                    if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;
                    anim.SetFloat("Crouch", 0f);
                    

                if (right == false && check == false)
                {
                    point.transform.localPosition = new Vector3(0.211f, 0.084f);
                    check = true;
                }


                if (right == true && check == false)
                {
                    point.transform.localPosition = new Vector3(-0.211f, 0.084f);
                    check = true;
                }

                if (m_wasCrouching)
                    {
                        m_wasCrouching = false;
                        OnCrouchEvent.Invoke(false);                       
                }
                
            }
            crouching = crouch;


            // Move the character by finding the target velocity
             Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
             m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            


            

            direction.x = targetVelocity.x;
            direction.y = targetVelocity.y;


            //these are needed for the rigidbodyes to stop jittering
            directx = System.Math.Round(direction.x, 2);
            heighty = System.Math.Round(direction.y, 2);

            

            /*
			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				//Flip();
              
            }
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				//Flip();
              
            }
            */

        }

        // If the player should jump...
        if (m_Grounded && jump && !crouch)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

    }

    

    /*
private void Flip()
{
    // Switch the way the player is labelled as facing.
   

    // Multiply the player's x local scale by -1.

    transform.Rotate(0f, 180f, 0f);
}
*/

    private void animate()
    {
   
        if (directx > 0)
        {
            anim.SetFloat("Speed", 1f);
        }
        if(directx < 0)
        {
            anim.SetFloat("Speed", -1f);
        }
        else if(directx == 0)
        {
            anim.SetFloat("Speed", 0);
        }
            if (direction.normalized.x < 0 )
        {
            right = true;

            anim.SetFloat("Direction", -1);

            if (rotated == false)
            {
                point.transform.localPosition = new Vector3(-0.211f, 0.084f);
                point.transform.Rotate(0f, 180f, 0f);

                point.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
                anim.SetFloat("Up", 0f);
                rotated = true;
            }
        }
         else if (direction.normalized.x > 0 && direction.normalized.x < 1.1)
        {

            right = false;

            anim.SetFloat("Direction", 1);

            if (rotated == true)
            {
                point.transform.localPosition = new Vector3(0.211f, 0.084f);
                point.transform.Rotate(0f, 180f, 0f);

                point.transform.localRotation = Quaternion.Euler(0.0f, 0f, 0.0f);
                anim.SetFloat("Up", 0f);
                rotated = false;
            }
        }


                if (heighty > 0.1 )
                {
                    anim.SetFloat("Height", 1);
                }
                else if (heighty < -0.1)
                {
                    anim.SetFloat("Height", -1);
                }
                else if (heighty > -0.1 )
                {
                    anim.SetFloat("Height", 0);
                }
            
        


        

    }
}
#pragma warning disable 0649