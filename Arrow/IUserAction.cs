using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { START, RUNNING, PAUSE, FINISH};

public interface IUserAction {

    void GameOver();
    void Hit();
    float getPower();
    bool getArrow();
    int getGoal();
}
