using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationStrings
{
    // 정적 변수로 선언해서
    // 어떤 객체든 편하게 접근이 가능하도록 설계
    public static string IsMovingparameterName = "IsMoving";
    public static string IsRunningparameterName = "IsRunning";
    public static string JumpparameterName = "Jump";
    public static string yVelocityparameterName = "yVelocity";
    
    // 해쉬값 통해서 제어
        public static int IsMoving = Animator.StringToHash(IsMovingparameterName);
        public static int IsRunning = Animator.StringToHash(IsRunningparameterName);
        public static int Jump = Animator.StringToHash(JumpparameterName);
        public static int yVelocity = Animator.StringToHash(yVelocityparameterName);
}
