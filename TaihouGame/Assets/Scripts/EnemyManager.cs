using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SM;

namespace EnemySpace
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        List<Vector2> enemyList = new List<Vector2>();
        public static int enemyCount=1;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CreateStage());
        }

        // Update is called once per frame
        void Update()
        {
            if (enemyCount == 0)
            {
                enemyCount = 1;
                SceneManager.LoadScene("Clear");
            }
        }
        private IEnumerator CreateStage()
        {
            yield return new WaitForSeconds(0.01f);
            foreach(Vector2 vec in StageManager.stages[StageManager.stageNum - 1].enemyList)
            {
                Instantiate(enemy, vec, Quaternion.identity);
            }
            enemyCount = StageManager.stages[StageManager.stageNum - 1].enemyList.Count;
        }
    }
}