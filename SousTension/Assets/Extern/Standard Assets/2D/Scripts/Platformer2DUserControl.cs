using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool crouch;

        public GameObject ControlsUi;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            crouch = false;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (CrossPlatformInputManager.GetButtonDown("CrouchController"))
            {
                crouch = !crouch;
            }
            if (CrossPlatformInputManager.GetButton("Stand"))
            {
                crouch = false;
            }
            if (CrossPlatformInputManager.GetButtonDown("CrouchKey"))
            {
                crouch = true;
            }
                if (CrossPlatformInputManager.GetButtonDown("Select"))
            {
                Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                ControlsUi.SetActive(!ControlsUi.activeSelf);
            }
           
        }

      

        private void FixedUpdate()
        {
             // Read the inputs.
                    
            
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
