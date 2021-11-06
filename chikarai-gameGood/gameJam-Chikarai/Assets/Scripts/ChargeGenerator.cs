
using UnityEngine;


public class ChargeGenerator : MonoBehaviour
{

    [SerializeField] private float range = 5f;
    private Generator _generator;
    [SerializeField] private string generatorTag;
    private GameObject[] _generators;
    private float _pointerDownTimer = 0f;


    private void Start()
    {
        _generators = GameObject.FindGameObjectsWithTag(generatorTag);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _pointerDownTimer = Time.time;
            _generator =FindGeneratorToCharge();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            float timeHeld = Time.time - _pointerDownTimer;
            if (_generator != null)
            {
                _generator.ChargeGenerator(timeHeld);
                Reset();
            }
        }
    }

    private void Reset()
    {
        _pointerDownTimer = 0f;
    }


    private Generator FindGeneratorToCharge()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestGenerator = null;
        foreach (GameObject gen in _generators)
        {
            float distanceToGenerator = Vector3.Distance(gen.transform.position, transform.position);
            if (distanceToGenerator < shortestDistance)
            {
                shortestDistance = distanceToGenerator;
                nearestGenerator = gen;
            }
        }

        if (nearestGenerator != null && shortestDistance <= range)
        {
            _generator = nearestGenerator.GetComponent<Generator>();
            return _generator;
        }
        else
        {
            return null;
        }
    }
}
