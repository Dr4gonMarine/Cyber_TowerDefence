using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "ScriptableObjects/EnemyDetails", order = 1)]

public class EnemyDetails : ScriptableObject{

    #region Header BASE EBENY DETAILS
    [Space (10)]
    [Header ("Base Enemy Details")]
    #endregion

    #region Tooltip
    [Tooltip ("The name of the enemy")]
    #endregion
    public string enemyName;

    #region ToolTip
    [Tooltip ("The enemy's settings")]
    #endregion
    public float moveSpeed;
    public float maxHealth;
    public int moneyDrop;
    public Sprite enemySprite;

    #region Validation
    #if UNITY_EDITOR
    //validade the scriptable object details entered
    private void OnValidate(){
        //check if the enemy name is empty
        if (enemyName == ""){
            //if it is empty, set the enemy name to "New Enemy"
            enemyName = "New Enemy";
        }
    }
    #endif
    #endregion
}