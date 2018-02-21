using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        public GameObject canvasBoard;
        public AudioClip walk;
        public AudioClip run;
        public AudioClip crouchSfx;

        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .9f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private bool running = false;

        private float pastPosition = 0;

        private AudioSource source;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            source = this.GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Run"))
            {
                running = !running;
            }
           


        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
           

        }


        public void Move(float move, bool crouch, bool jump)
        {

            if (gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().getAuthorisation() || gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward)
            {

                // If crouching, check to see if the character can stand up
                if (!crouch && m_Anim.GetBool("Crouch"))
                {
                    // If the character has a ceiling preventing them from standing up, keep them crouching
                    if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                    {
                        crouch = true;
                        
                    }
                }

                // Set whether or not the character is crouching in the animator
                m_Anim.SetBool("Crouch", crouch);

                //only control the player if grounded or airControl is turned on
                if (m_Grounded || m_AirControl)

                {
                    // Reduce the speed if crouching by the crouchSpeed multiplier
                    move = (crouch ? move * m_CrouchSpeed : move);

                    // The Speed animator parameter is set to the absolute value of the horizontal input.
                    

                    // Move the character
                    m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                   

                    if (running)
                    {
                        m_MaxSpeed = 10f;
                        if (crouch)
                        {
                            source.clip = crouchSfx;
                        }
                        if (!crouch)
                        {
                            source.clip = run;
                        }
                        
                        if (!source.isPlaying)
                        {
                            source.Play();
                        }
                        if (jump || !m_Grounded)
                        {
                            source.Stop();
                        }
                       // PlayerData.sprint--;
                       // Debug.Log("Sprint: " + PlayerData.sprint);
                    }
                    else
                    {
                        m_MaxSpeed = 5f;
                        if (crouch)
                        {
                            source.clip = crouchSfx;
                        }
                        if (!crouch)
                        {
                            source.clip = walk;
                        }
                        
                        if (!source.isPlaying)
                        {
                            source.Play();
                        }
                        if (jump || !m_Grounded)
                        {
                            source.Stop();
                        }
                        //PlayerData.sprint++;
                    }

                    m_Anim.SetFloat("Speed", Mathf.Abs(move * m_MaxSpeed));



                    // If the input is moving the player right and the player is facing left...
                    if (move > 0 && !m_FacingRight)
                    {
                        // ... flip the player.
                        Flip();
                    }
                    // Otherwise if the input is moving the player left and the player is facing right...
                    else if (move < 0 && m_FacingRight)
                    {
                        // ... flip the player.
                        Flip();
                    }
                }
                // If the player should jump...
                if (m_Grounded && jump && m_Anim.GetBool("Ground"))
                {
                    // Add a vertical force to the player.
                    m_Grounded = false;
                    m_Anim.SetBool("Ground", false);
                    m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                }
            }
            
            else
            {
                m_Anim.SetFloat("Speed", 0);
                m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
            }
        }


        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            if(canvasBoard != null)
            {
                Vector3 theScaleCanvas = canvasBoard.transform.localScale;
                theScaleCanvas.x *= -1;
                canvasBoard.transform.localScale = theScaleCanvas;
            }
        }

        public bool IsFaceRight()
        {
            return m_FacingRight;
        }

        public bool IsMoving()
        {
            if (pastPosition == 0)
            {
                pastPosition = this.transform.position.x;
            }
            if (Math.Abs(this.transform.position.x - pastPosition) >= 0.001)
                //this.transform.position.x != pastPosition && !m_Anim.GetBool("Crouch"))
            {
                pastPosition = this.transform.position.x;
                Debug.Log("Moving" + pastPosition);
                return true;
                
            }
            else
            {
                source.Stop();
                return false;
            }
        }

        public bool IsSprinting()
        {
            return this.running;
        }

        public void SetSprint(bool value)
        {
            this.running = value;
        }

        public bool CheckCeiling()
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
