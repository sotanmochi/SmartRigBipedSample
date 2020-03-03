using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartRigInitializer : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        SmartRigBiped smartRig = GetComponent<SmartRigBiped>();

        // Hip_hi: 軽く膝が曲がる程度に調整
        Transform hip = animator.GetBoneTransform(HumanBodyBones.Hips);
        smartRig.hip_hi = hip.position.y; // Hipの高さ

        // Foot_up: 足が地面にめり込まないように調整
        Transform toe = animator.GetBoneTransform(HumanBodyBones.LeftToes);
        smartRig.foot_up = toe.position.y + 0.05f; // つま先の高さ + α

        // *************************************************
        // Bias: 
        //   Bias = 1.0f：膝を上げて脚を振るような動きになる
        //   Bias = 0.0f：すり足のような動きになる
        // *************************************************
        smartRig.bias = 1.0f;

        // Foot_wide: 両足の間隔を調整
        smartRig.foot_wide = 0.03f;

        // Arm_rot_fix: 腕の角度を調整
        smartRig.arm_rot_fix.z = 5.0f;
        smartRig.hand_rot_fix.z = 10.0f;

        // *************************************************
        // Arm_rotate: 歩く時の腕の振りを調整
        //   Arm_rotate > 0：踏み出す足と逆側の腕を前に振る
        //   Arm_rotate < 0：踏み出す足と同じ側の腕を前に振る
        // *************************************************
        smartRig.arm_rotate = 30.0f;

        // *************************************************
        // Spine_rot: 歩く時の上半身をひねる動きを調整
        //   Spine_rot.y > 0：踏み出す足と逆側の肩が前に出る
        //   Spine_rot.y < 0：踏み出す足と同じ側の肩が前に出る
        //   Spine_rot.z < 0：踏み出す足と逆側の肩が上がる
        //   Spine_rot.z > 0：踏み出す足と同じ側の肩が上がる
        // *************************************************
        smartRig.upper_animation.spine_rot.y = 60.0f;
        smartRig.upper_animation.spine_rot.z = -5.0f;

        // *************************************************
        // Head_rot: 歩く時の頭が揺れる動きを調整
        //   上半身をひねるように動かす時に頭を揺らしたくない場合、
        //   Spine_rotと近い値に設定しておくと打ち消す感じになる。
        //   Head_rot.y > 0：踏み出す足と逆の方向を見る（右足を踏み出す時に頭は左を向く）
        //   Head_rot.z < 0：前に出した足と逆の方向に頭が下がる（右足を踏み出す時に頭が左に下がる）
        // *************************************************
        smartRig.upper_animation.head_rot.y = 45.0f;
        smartRig.upper_animation.head_rot.z = -20.0f;
    }

    // void Start()
    // {
    //     Animator animator = GetComponent<Animator>();
    //     SmartRigBiped smartRig = GetComponent<SmartRigBiped>();

    //     // Hip_hi: 軽く膝が曲がる程度に調整
    //     Transform hip = animator.GetBoneTransform(HumanBodyBones.Hips);
    //     smartRig.hip_hi = hip.position.y; // Hipの高さ

    //     // Foot_up: 足が地面にめり込まないように調整
    //     Transform toe = animator.GetBoneTransform(HumanBodyBones.LeftToes);
    //     smartRig.foot_up = toe.position.y + 0.05f; // つま先の高さ + α

    //     smartRig.bias = 1.0f;

    //     smartRig.foot_wide = 0.03f;

    //     smartRig.arm_rot_fix.z = 15.0f;

    //     smartRig.arm_rotate = 60.0f;

    //     smartRig.spine_rot.y = 60.0f;
    //     smartRig.spine_rot.z = -5.0f;

    //     smartRig.head_rot.y = 45.0f;
    //     smartRig.head_rot.z = -20.0f;
    // }
}
