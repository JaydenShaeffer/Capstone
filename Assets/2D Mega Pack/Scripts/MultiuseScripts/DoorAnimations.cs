using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    private Animator doorAnimator;
    [SerializeField] private AudioClip openSound;

    private void Awake() {
        doorAnimator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        doorAnimator.SetBool("Open", true);
        SoundManager.instance.PlaySound(openSound);
    }

    public void CloseDoor() {
        doorAnimator.SetBool("Open", false);
    }

}
