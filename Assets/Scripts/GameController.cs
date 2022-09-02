using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject toiletPrefab;
    [SerializeField] private Slider timeSlider;

    // position that the first cabin will spawn on the scene
    public float originalPosition;
    // distance between the cabins
    private int toiletDistance = 3;
    // this changes after each cabin is instantiated
    private float actualPosition;

    [SerializeField] private Image sliderImage;



    [SerializeField] private float totalTime = 5f;
    private float timeLeft;

    [SerializeField] private int toiletCount = 6;
    private int toiletsLeft;
    private bool toiletIsSelected = false;

    private bool startTimer = false;

    [SerializeField] private ScreenController _screenController;

    void Start()
    {
        actualPosition = originalPosition;
        toiletsLeft = toiletCount;
        timeLeft = totalTime;
        timeSlider.value = timeLeft;
        timeSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForClick();

        if (startTimer) {
            RunCountDown();
        }

        TimeOut();
    }

    private void TimeOut()
    {
        if (timeLeft <= 0 && startTimer) {
            startTimer = false;

            if (!toiletIsSelected) {
                Debug.Log("Open Chicken Screen");
                // run chcken animation
                ResetGame();
                _screenController.ActivateScreen("Chicken");
                return;
            }

            // play some kind of animation of the toilet exploding
            // maybe use coroutine to make the game wait for the end of the animation before continue

            if (checkToilets()) {
                Debug.Log("Open Game Over Screen");
                // run Game Over animation
                ResetGame();
                _screenController.ActivateScreen("GameOver");
                return;
            }

            if (toiletsLeft - 1 == 1) {
                Debug.Log("Open Win Screen");
                // run Win animation
                ResetGame();
                _screenController.ActivateScreen("Win");
                return;
            }

            toiletsLeft -= 1;
            deleteToilets();
            actualPosition = originalPosition;
            spawnToilets(toiletsLeft);
            StartCountDown();
        }
    }

    public void StartGame()
    {
        timeSlider.gameObject.SetActive(true);
        spawnToilets(toiletsLeft);
        StartCountDown();
        Debug.Log(Random.Range(0, toiletsLeft));
    }

    private void StartCountDown()
    {
        startTimer = true;
        toiletIsSelected = false;
        timeLeft = totalTime;
        timeSlider.value = timeLeft;
    }

    private void RunCountDown()
    {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timeSlider.value = timeLeft;
            sliderImage.color = Color.Lerp(Color.red, Color.green, timeSlider.value / 5);
        }
    }

    private void CheckForClick()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            RaycastHit2D raycastHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.GetTouch(0).position));

            if (raycastHit.collider != null && raycastHit.collider.CompareTag("Toilet")) {
                Toilet toilet = raycastHit.collider.gameObject.GetComponent<Toilet>();

                if (!toiletIsSelected) {
                    raycastHit.collider.GetComponent<Animator>().SetBool("empty", false);
                    toilet.setPlayerChoice(true);
                    toiletIsSelected = true;
                }
            }
        }
    }

    private void ResetGame()
    {
        deleteToilets();
        toiletsLeft = toiletCount;
        timeSlider.gameObject.SetActive(false);
        actualPosition = originalPosition;
    }







    bool checkToilets() {
        foreach (var toilet in GameObject.FindGameObjectsWithTag("Toilet")) {
            if (toilet.GetComponent<Toilet>().getHavePoop() && toilet.GetComponent<Toilet>().getPlayerChoice()) {
                return true;
            }
        }

        return false;
    }

    void deleteToilets() {
        foreach (var toilet in GameObject.FindGameObjectsWithTag("Toilet")) {
            Destroy(toilet);
        }
    }

    void spawnToilets(int number) {
        int cabinNumber = Random.Range(0, number);
        // Debug.Log(cabinNumber);

        for (int i = 0; i < number; i++) {
            GameObject toilet = Instantiate(toiletPrefab, new Vector3(actualPosition, -1f, 0), Quaternion.identity);
            actualPosition += toiletDistance;

            if (i == cabinNumber) {
                toilet.GetComponent<Toilet>().setHavePoop(true);
            }
        }
    }
}
