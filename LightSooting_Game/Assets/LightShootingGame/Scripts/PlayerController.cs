using UnityEngine;

public class PlayerController : MonoBehaviour
{
#region INPUT

    public CharacterController characterController;
    public float speed = 5f;

#endregion

#region UNITY METHODS

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);

        characterController.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }

#endregion
}