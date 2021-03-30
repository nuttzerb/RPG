using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    int horizonal;
    int vertical;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizonal = Animator.StringToHash("Horizonal");
        vertical = Animator.StringToHash("Vertical");
    }
    public void UpdateAnimatorValues(float horizonalMovement, float verticalMovement)
    {
        // animation snapping
        float snappedHorizonal;
        float snappedVertical;
        #region Snapped Horizonal // make sure animation go smoothly
        if (horizonalMovement > 0 && horizonalMovement < 0.55f) 
        {
            snappedHorizonal = 0.5f;
        }
        else if (horizonalMovement > 0.55f)
        {
            snappedHorizonal = 1;
        }
        else if (horizonalMovement < 0 && horizonalMovement > -0.55f)
        {
            snappedHorizonal = -0.5f;
        }
        else if (horizonalMovement < -0.55f)
        {
            snappedHorizonal = -1;
        }
        else snappedHorizonal = 0;
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f) // make sure animation go smoothly
        {
            snappedVertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snappedVertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVertical = -1;
        }
        else snappedVertical = 0;
        #endregion
        animator.SetFloat(horizonal, snappedHorizonal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }
}
