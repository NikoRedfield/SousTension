using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public bool backward = true;
        public int backSpeed = -1;


        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool crouch;

        private bool authoriseInput = true;

        private GameObject controlRootUI;
        private GameObject keyboardControlsUI;
        private GameObject gamepadControlsUI;
        private GameObject ControlsUI;
        private ControllerStatus controller;
        private int controllerState;
        private GameObject book;

        private bool mAxis = false;


        

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            crouch = false;

            controlRootUI = GameObject.Find("ControlsUI");
            keyboardControlsUI = controlRootUI.transform.Find("KeyboardControls").gameObject; 
            gamepadControlsUI = controlRootUI.transform.Find("GamepadControls").gameObject;
            ControlsUI = keyboardControlsUI;
            book = GameObject.Find("NoteBook").transform.Find("BookUI").gameObject;

            controller = GameObject.Find("Manager").GetComponent<ControllerStatus>();
        }


        private void Update()
        {
            if (authoriseInput)
            {
                if (!m_Jump)
                {
                    // Read the jump input in Update so button presses aren't missed.
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
                if (CrossPlatformInputManager.GetButtonDown("CrouchController"))
                {
                    crouch = !crouch;
                    if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Ladder"))
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Crouch", crouch);

                    }
                    
                }
                if (CrossPlatformInputManager.GetButton("Stand") && !m_Character.CheckCeiling())
                {
                    crouch = false;
                    if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Ladder"))
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Crouch", false);
                    }
                }
                if (CrossPlatformInputManager.GetButtonDown("CrouchKey"))
                {
                    crouch = true;
                    if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Ladder"))
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Crouch", true);
                    }
                }
                if (CrossPlatformInputManager.GetButtonDown("Controls") && !book.activeSelf)
                {
                    Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                    // Boolean used to prevent error from switching input device while displaying Controls UI
                    if (!ControlsUI.activeSelf)
                    {
                        SelectControls();
                    }
                    ControlsUI.SetActive(!ControlsUI.activeSelf);
                }
                if (CrossPlatformInputManager.GetButtonDown("Book") )
                {
                    Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                    book.SetActive(!book.activeSelf);
                    if (book.activeSelf)
                    {
                        book.GetComponentInParent<AudioSource>().clip = book.GetComponent<Notebook>().open;
                        book.GetComponentInParent<AudioSource>().Play();
                    }
                    if (!book.activeSelf)
                    {
                        book.GetComponentInParent<AudioSource>().clip = book.GetComponent<Notebook>().close;
                        book.GetComponentInParent<AudioSource>().Play();
                    }
                }
                /*
                if(CrossPlatformInputManager.GetAxis("BookAxis") > 0)
                {
                    if (!mAxis)
                    {
                        mAxis = true;
                        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                        book.SetActive(!book.activeSelf);
                        if (book.activeSelf)
                        {
                            book.GetComponentInParent<AudioSource>().clip = book.GetComponent<Notebook>().open;
                            book.GetComponentInParent<AudioSource>().Play();
                        }
                        if (!book.activeSelf)
                        {
                            book.GetComponentInParent<AudioSource>().clip = book.GetComponent<Notebook>().close;
                            book.GetComponentInParent<AudioSource>().Play();
                        }
                    }
                }
                if (CrossPlatformInputManager.GetAxis("BookAxis") == 0)
                {
                    mAxis = false;
                }
                */
                if(book.activeSelf || ControlsUI.activeSelf)
                {
                    Time.timeScale = 0;
                }

            }
            else
            {
                if (backward)
                {
                   
                        m_Character.Move(backSpeed, false, false);                    
                }
                else
                {
                    m_Character.Move(0, false, false);
                    Debug.Log("Stop!");
                }
                
            }
        }

      

        private void FixedUpdate()
        {
            if (authoriseInput)
            {
                // Read the inputs.
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Jump);
                m_Jump = false;
              
            }
         
            
        }

        public void SetAuthorisation(bool access)
        {
            authoriseInput = access;
            Debug.Log("Access modified ! ");
        }

        public bool getAuthorisation()
        {
            return this.authoriseInput;
        }

        private void SelectControls()
        {
            controllerState = controller.ControllerCheck();
            switch (controllerState)
            {
                case 0:
                    ControlsUI = keyboardControlsUI;
                    break;
                case 1:
                    ControlsUI = gamepadControlsUI;
                    break;
                default:
                    Debug.Log("Error on controls display UI ! ");
                    break;
            }
        }

       

        
     
    }
}
