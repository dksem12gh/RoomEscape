using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_PasswordLockRotate : MonoBehaviour
{
    public Transform _passwordTrs;
    public int number = 0;

    float duration = 1;

    float angle = 36.0f;

    private bool isAlreadyRotating;
    
    public void RotateUp()
    {            
        // if aready rotating do nothing
        if (isAlreadyRotating)
        {
            Debug.Log("회전 코루틴 실행중 업");
            return;
        }
        
        // start a rottaion            
        StartCoroutine(RotateRoutineUp());
    }

    public void RotateDown()
    {
        // if aready rotating do nothing
        if (isAlreadyRotating)
        {
            Debug.Log("회전 코루틴 실행중 다운");
            return;
        }

        // start a rottaion            
        StartCoroutine(RotateRoutineDown());
    }

    private IEnumerator RotateRoutineUp()
    {
        // set the flag to prevent multiple callse
        isAlreadyRotating = true;

        Quaternion start = new Quaternion();
        Quaternion end = new Quaternion();

        number++;

        if (number >= 10)
            number = 0;

        if (number == 1)
        {
            angle = 34.2f;
        }
        else if (number == 2)
        {
            angle = 33.9f;
        }
        else if (number == 3)
        {
            angle = 34.2f;
        }
        else if (number == 4)
        {
            angle = 34.5f;
        }
        else if (number == 5)
        {
            angle = 34.8f;
        }
        else if (number == 6)
        {
            angle = 35.51f;
        }
        else if (number == 7)
        {
            angle = 35.4f;
        }
        else if (number == 8)
        {
            angle = 35.7f;
        }
        else if (number == 9)
        {
            angle = 36f;
        }
        else if (number == 0)
        {
            angle = 34.2f;
        }


        start = _passwordTrs.localRotation;
        end = start * Quaternion.Euler(new Vector3(_passwordTrs.localRotation.x - angle, 0, 0));

        float timePassed = 0.0f;
        float nomalizationFactor = 1.0f / 1.0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime * nomalizationFactor;

            _passwordTrs.localRotation = Quaternion.Slerp(start, end, timePassed);

            yield return null;
        }

        if (number == 0)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (number == 1)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-36, 0, 0));
        else if (number == 2)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-72, 0, 0));
        else if (number == 3)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-108, 0, 0));
        else if (number == 4)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-144, 0, 0));
        else if (number == 5)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-180, 0, 0));
        else if (number == 6)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-216, 0, 0));
        else if (number == 7)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-252, 0, 0));
        else if (number == 8)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-288, 0, 0));
        else if (number == 9)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(-324, 0, 0));

        isAlreadyRotating = false;
    }

    private IEnumerator RotateRoutineDown()
    {
          
        // set the flag to prevent multiple callse
        isAlreadyRotating = true;

        Quaternion start = new Quaternion();
        Quaternion end = new Quaternion();

        number--;

        if (number <= -1)
            number = 9;

        if (number == 9)
        {
            angle = 36;
        }
        else if (number == 8)
        {
            angle = 35.7f;
        }
        else if (number == 7)
        {
            angle = 35.4f;
        }
        else if (number == 6)
        {
            angle = 35.1f;
        }
        else if (number == 5)
        {
            angle = 34.8f;
        }
        else if (number == 4)
        {
            angle = 34.5f;
        }
        else if (number == 3)
        {
            angle = 34.2f;
        }
        else if (number == 2)
        {
            angle = 33.9f;
        }
        else if (number == 1)
        {
            angle = 34.2f;
        }
        else if (number == 0)
        {
            angle = 34.2f;
        }


        start = _passwordTrs.localRotation;
        end = start * Quaternion.Euler(new Vector3(_passwordTrs.localRotation.x + angle, 0, 0));

        float timePassed = 0.0f;
        float nomalizationFactor = 1.0f / 1.0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime * nomalizationFactor;

            _passwordTrs.localRotation = Quaternion.Slerp(start, end, timePassed);

            yield return null;
        }

        if (number == 0)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (number == 1)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(324, 0, 0));
        else if (number == 2)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(288, 0, 0));
        else if (number == 3)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(252, 0, 0));
        else if (number == 4)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(216, 0, 0));
        else if (number == 5)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
        else if (number == 6)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(144, 0, 0));
        else if (number == 7)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(108, 0, 0));
        else if (number == 8)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(72, 0, 0));
        else if (number == 9)
            _passwordTrs.localRotation = Quaternion.Euler(new Vector3(36, 0, 0));

        isAlreadyRotating = false;
    }
}
