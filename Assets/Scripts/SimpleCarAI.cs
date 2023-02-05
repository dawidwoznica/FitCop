using System.Collections;
using UnityEngine;

public class SimpleCarAI : MonoBehaviour {

    public float fromX;
    public float toX;
    public float enemyCarPositionZ;
    public float fromDriftDuration;
    public float toDriftDuration;
    public float fromWaitDuration;
    public float toWaitDuration;
    public GameObject[] skills;
    public float skillIntervalFrom;
    public float skillIntervalTo;


    private void Start()
    {
        StartCoroutine(SimpleCarMovementAI());
        StartCoroutine(SimpleCarAttackAI());
    }

    IEnumerator SimpleCarMovementAI()
    {
        while (GameManager.Instance.isEnemyAlive)
        {
            float t = 0;
            Vector3 newPosition = GetNewPosition();
            Vector3 startingPosition = GameManager.Instance.enemyCarObject.transform.position;
            while (t < 1)
            {
                GameManager.Instance.enemyCarObject.transform.position = Vector3.Lerp(startingPosition, newPosition, t);
                t += Time.deltaTime / Random.Range(fromDriftDuration, toDriftDuration);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(Random.Range(fromWaitDuration, toWaitDuration));
        }
    }

    IEnumerator SimpleCarAttackAI()
    {
        yield return new WaitForSeconds(4);

        while (GameManager.Instance.isEnemyAlive)
        {
            Instantiate(skills[Random.Range(0, skills.Length)], GameManager.Instance.enemyGunTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(skillIntervalFrom, skillIntervalTo));
        }
    }



    private Vector3 GetNewPosition()
    {
        return new Vector3(Random.Range(fromX, toX), 0, enemyCarPositionZ);
    }

}
