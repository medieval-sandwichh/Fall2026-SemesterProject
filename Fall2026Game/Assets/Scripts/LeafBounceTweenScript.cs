using UnityEngine;
using DG.Tweening;

public class LeafBounceTweenScript : MonoBehaviour
{
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            transform.DOShakePosition(duration, strength, vibrato, randomness);
        }
    }
}

