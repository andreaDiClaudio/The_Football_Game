using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("References")]

    [Header("Ball")]
    [Tooltip("The ball object")]
    public GameObject ball;
    [Tooltip("The ball rigidBody")]
    public Rigidbody ballRigidBody;

    [Header("Player")]
    [Tooltip("The player object")]
    public Player player;

    [Tooltip("The game object that represents the player")]
    public GameObject playerGameObject;

    public GameObject winScreen;
    public static bool isGoal = false;
    public Pause pause;
    public GoalCrowdSoundEffect goalCrowdSoundEffect;

    void Start()
    {
        winScreen.SetActive(false);
        isGoal = false;
    }

    //Detects if the ball touches the box collider for the goal
    private void OnTriggerEnter(Collider other)
    {
        //GameObject goal = gameObject;
        if (other.CompareTag("Ball"))
        {
            goalCrowdSoundEffect.PlayGoalCheering();
            Win();
        }
    }

    public void Win()
    {
        pause.enabled = false;

        /*TIMER*/
        Timer.StopTimer();

        /*PLAYER*/
        //set velocity to 0,0,0
        Player.movementVelocity = Vector3.zero;
        //Disable the component (script)
        player.enabled = false;
        //Disable characterController
        player.characterController.enabled = false;

        /*BALL*/
        //set velocity and rotation to 0,0,0
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        //Shows Win hud
        winScreen.SetActive(true);

        //
        ProgressionManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
