using UnityEngine;

public class Toilet : MonoBehaviour {
    private Animator animator;
    private GameController gameController;

    private bool playerChoice = false;
    private bool havePoop = false;

    void Start() {
        animator = GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        this.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void setPlayerChoice(bool playerChoice) {
        this.playerChoice = playerChoice;
    }

    public bool getPlayerChoice() {
        return this.playerChoice;
    }

    public void setHavePoop(bool havePoop) {
        this.havePoop = havePoop;
    }

    public bool getHavePoop() {
        return this.havePoop;
    }
}
