using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TargetAi : MonoBehaviour {

    Animator anim;
    public enum State
    {
        SIT,IDLE,WALK,RUN,WAIT,DEATH,STAND,WARM,SLEEPING,LEAN,SITIDLE,SCARE
    }
    public State state;
    State tempState;
    public bool headshot;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StateChange();
    }
    public void StateChange()
    {
        switch (state)
        {
            case State.IDLE:
                Idle();
                break;
            case State.WALK:
                Walk();
                break;
            case State.RUN:
                Run();
                break;
            case State.DEATH:
                Death();
                break;
            case State.STAND:
                Stand();
                break;
            case State.SLEEPING:
                Sleep();
                break;
            case State.LEAN:
                Lean();
                break;
            case State.WAIT:
                Wait();
                break;
            case State.WARM:
                Warm();
                break;
            case State.SIT:
                Sit();
                break;
            case State.SITIDLE:
                SitIdle();
                break;
            case State.SCARE:
                Scared();
                break;
        }
    }
    void TurnOffAll()
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }
    }
    public void Sleep()
    {
        state = State.SLEEPING;
        TurnOffAll();
        anim.SetBool("Sleeping", true);
    }
    public void Walk()
    {
        state = State.WALK;
        TurnOffAll();
        anim.SetBool("Walk", true);
    }
    public void Run()
    {
        state = State.RUN;
        TurnOffAll();
        anim.SetBool("Run", true);
    }
    public void Wait()
    {
        state = State.WAIT;
        TurnOffAll();
        anim.SetBool("Waiting", true);
    }
    public void Idle()
    {
        state = State.IDLE;
        TurnOffAll();
        anim.SetBool("Idle", true);
    }
    public void Warm()
    {
        state = State.WARM;
        TurnOffAll();
        anim.SetBool("WarmFire", true);
    }
    public void Lean()
    {
        state = State.LEAN;
        TurnOffAll();
        anim.SetBool("Lean", true);
    }
    public void Death()
    {
        TurnOffAll();
        if(headshot)
        anim.SetBool("HeadShot", true);
        else
            anim.SetBool("BodyShot", true);
    }
    public void Sit()
    {
        TurnOffAll();
        state = State.SIT;
        anim.SetBool("Sit", true);
    }
    public void SitIdle()
    {
        TurnOffAll();
        state = State.SITIDLE;
        anim.SetBool("SitIdle", true);
    }
    public void Stand()
    {
        state = State.STAND;
        TurnOffAll();
        anim.SetBool("Stand", true);
    }
    public void Scared()
    {
        if (state != State.SCARE)
        {
            tempState = state;
        }
        state = State.SCARE;
        TurnOffAll();
        anim.SetBool("Scared", true);
        if (GetComponent<splineMove>())
        {
            GetComponent<splineMove>().Pause();
        }
        StartCoroutine("ResetState", 7f);
    }
    public void setaninew(float waitTime) {
        StartCoroutine("startanimagain", waitTime);
    }

    IEnumerator ResetState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (GetComponent<splineMove>())
        {
            GetComponent<splineMove>().Resume();
        }
        TurnOffAll();
        state = tempState;
        StateChange();
    }

    IEnumerator startanimagain(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        state = State.WALK;
        StateChange();
        gameObject.GetComponent<splineMove>().Resume();
    }
    public void WaitKill()
    {
        this.GetComponent<DamageManager>().DontKill = !this.GetComponent<DamageManager>().DontKill;
    }


}
