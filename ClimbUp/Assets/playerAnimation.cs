using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class playerAnimation : MonoBehaviour
{
    Rigidbody2D rigidbody;
    SkeletonAnimation skeleton;
    bool isGround = false;
    bool isLookRIght = true;
    bool isCharging = false;
    const int size = 4;

    private AnimationReferenceAsset[] AnimClip;
    enum State { IDLE, MOVING, JUMPING, CHARGING };
    State accessAnim, currentAnim;
    playerControl control;
    Transform transform;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        skeleton = GetComponent<SkeletonAnimation>();
        control = GetComponent<playerControl>();
        transform = GetComponent<Transform>();
        currentAnim = State.IDLE;
        skeleton.skeleton.SetAttachment("[base]face", "side/face/[base]smile");
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = control.getIsGround();
        isCharging = control.getIsCharging();
        isLookRIght = control.getIsRight();

        if (!isGround)
        {
            accessAnim = State.JUMPING;
        }
        else if (isCharging)
        {
            accessAnim = State.CHARGING;
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            accessAnim = State.MOVING;
        }
        else
        {
            accessAnim = State.IDLE;
        }

        if (isLookRIght)
        {
            transform.localScale = new Vector3(x, y, z);
        }
        else
        {
            transform.localScale = new Vector3(-x, y, z);
        }

        _AsncAnim(accessAnim, true, 1f);
    }
    private void _AsncAnim(State Anim, bool loop, float timescale)
    {
        if (Anim == currentAnim) return;

        string x = "";
        switch (Anim)
        {
            case State.IDLE:
                x = "idle_side";
                break;
            case State.JUMPING:
                x = "get_side";
                break;
            case State.MOVING:
                x = "walk_side";
                break;
            case State.CHARGING:
                x = "boong_attack_ready_loop_side";
                break;
        }

        skeleton.state.SetAnimation(0, x, loop);
        skeleton.state.TimeScale = timescale;
        currentAnim = Anim;
    }
}
