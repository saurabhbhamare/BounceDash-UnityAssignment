using UnityEngine;

public class BallView : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D ballRigidBody;
    private BallController ballController;
    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void SetBallController(BallController ballController)
    {
        this.ballController = ballController;
    }
    private void Update()
    {
        float lowestVisibleY = mainCamera.transform.position.y - ballController.GetBallModel().gameOverThreshold;
        if (transform.position.y < lowestVisibleY)
        {
            Time.timeScale = 0;
            ballController.levelUI.ShowGameOverScreen();
        }
        if (transform.position.y > ballController.GetBallModel().highestYReached)
        {
            ballController.GetBallModel().highestYReached = transform.position.y;
            ballController.scoreService.IncreaseScore();
        }
        HandleInput();
        ballController.CheckBallPositionOnTheScreen();
    }
    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ballController.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            ballController.MoveRight();
        }
    }
    public Rigidbody2D GetRigidbody()
    {
        return ballRigidBody;
    }
    //Collision Detection 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformView>())
        {
            Vector2 collisionNormal = collision.contacts[0].normal;

            if (collisionNormal.y > ballController.GetBallModel().yCollisionNormalBounce)
            {
                if (ballController == null)
                {
                    return;
                }
                ballController.Bounce();
            }
        }
        else if (collision.gameObject.CompareTag("BasePlatform"))
        {
            ballController.ExtendedBounce();
            Destroy(collision.gameObject);
        }

    }
    //If Collsion happens with the  Available Spawn items
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            SpawnItemType itemType = collision.gameObject.GetComponent<Item>().itemType;
            if (itemType == SpawnItemType.COIN)
            {
                ballController.scoreService.IncreaseCoins();
                Destroy(collision.gameObject);
            }
            else if (itemType == SpawnItemType.OBSTACLE)
            {
                Time.timeScale = 0;
                ballController.levelUI.ShowGameOverScreen();

            }
            else if (itemType == SpawnItemType.EXTENDEDBOUNCE)
            {
                if (ballRigidBody.linearVelocity.y < 0)
                {
                    ballController.ExtendedBounce();
                }
            }
        }

    }
}
