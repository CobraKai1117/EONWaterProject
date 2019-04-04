using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterParticle : MonoBehaviour
{ public Mesh myMesh;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var sh = ps.shape;
        sh.enabled = true;
        sh.shapeType = ParticleSystemShapeType.Mesh;
        sh.mesh = myMesh;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
