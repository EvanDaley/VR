using UnityEngine;
using System.Collections;

public class KinematicHands : MonoBehaviour {

    private Animator m_Animator;
    private WeaponManager m_WeaponManager;
    public bool ikActive = true;

	// Use this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();
        m_WeaponManager = GetComponent<WeaponManager>();
    }
	
	// Update is called once per frame
	void OnAnimatorIK () {
	    if(m_Animator)
        {
            if (ikActive)
            {
                if (m_WeaponManager)
                {
                    if(m_WeaponManager.weapon != null)
                    {
                        m_Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                        m_Animator.SetIKPosition(AvatarIKGoal.RightHand, m_WeaponManager.weaponForm.m_rightHandle.position);

                        m_Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                        m_Animator.SetIKPosition(AvatarIKGoal.LeftHand, m_WeaponManager.weaponForm.m_leftHandle.position);
                    }
                }
            }
        }
	}
}
