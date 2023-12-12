using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    private Collider2D doorCollider;
    private DoorAnimations doorAnims;

    private void Awake() {
        doorAnims = GetComponent<DoorAnimations>();
        // Assuming the collider is a direct child of the door
        doorCollider = transform.GetChild(0).GetComponent<Collider2D>(); // Adjust the index accordingly
    }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        doorAnims.OpenDoor();
        // Disable the collider when the door opens
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
    }

}
