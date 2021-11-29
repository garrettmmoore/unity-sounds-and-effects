using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatterParticle;
    private AudioSource _playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 15;
    public float gravity;
    public bool isOnGround = true;
    public bool isGameOver;

    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");

    // Start is called before the first frame update
    void Start()
    {
        // Rigid body is force
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravity;
    }

    // Update is called once per frame
    private void Update()
    {
        // Player jumps
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && isGameOver == false)
        {
            // Configure jump force
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Player is in the air and not on the ground
            isOnGround = false;

            // Play "Jump" sound
            _playerAudio.PlayOneShot(jumpSound, 1.0f);

            // Set up a jump animation
            _playerAnim.SetTrigger(JumpTrig);

            // Stop dirt splatter particles
            dirtSplatterParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Display dirt particles if player is colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtSplatterParticle.Play();
        }
        // Display explosion particles if player collides with the fence obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");

            // Toggle game state to GameOver
            isGameOver = true;

            // Trigger fall forward/fall backward animation
            if (isOnGround)
            {
                _playerAnim.SetBool(DeathB, true);
                _playerAnim.SetInteger(DeathTypeINT, 1);
            }
            else
            {
                _playerAnim.SetBool(DeathB, true);
                _playerAnim.SetInteger(DeathTypeINT, 2);
            }

            // Play "Crash" audio clip
            _playerAudio.PlayOneShot(crashSound, 1.0f);

            // Stop dirt particles as the game is over
            dirtSplatterParticle.Stop();

            // Show Explosion particles
            explosionParticle.Play();
        }
    }
}
