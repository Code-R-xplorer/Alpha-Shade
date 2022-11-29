using TheKiwiCoder;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    private BehaviourTreeRunner _behaviourTreeRunner;

    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
        _player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
