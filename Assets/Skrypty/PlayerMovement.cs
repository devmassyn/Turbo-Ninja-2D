using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	public bool crouch = false;
    private SpriteRenderer Obroc;
    public Animator animator;
    bool attack = false;
    void Awake()
    {
        
    }
    void Start()
    {
        Obroc = GetComponent<SpriteRenderer>();
    }
    // Aktualizacja jest wywo³ywana raz na klatkê
    void Update ()
    {
        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
            jump = true;
        }

		if (CrossPlatformInputManager.GetButton("Crouch"))
		{
			crouch = true;
		}
        else
		{
			crouch = false;
		}

	}

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("crouch", isCrouching);
    }
    void FixedUpdate ()
	{
		// Poruszamy nasz¹ postaci¹
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, attack);
		jump = false;
    }
}
