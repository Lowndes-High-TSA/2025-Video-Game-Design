using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public bool isInfected { get; private set; }

    private Rigidbody _rigidbody;
    private SpringJoint joint;
    private LineRenderer _lineRenderer;

    private Vector3 _swingPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    public void Infect()
    {
        isInfected = true;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
        if (isInfected)
            transform.localScale = Vector3.one * 2.0f;
        else
            transform.localScale = Vector3.one;
    }

    void LateUpdate()
    {
        DrawRope();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
        }
    }

    private Vector3 _currentGrapplePosition;
    
    public void DrawRope()
    {
        if (!joint)
        {
            return;
        }
        
        _currentGrapplePosition = Vector3.Lerp(_currentGrapplePosition, _swingPoint, Time.deltaTime * 8.0f);
        
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _swingPoint);
    }

    public void StartSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 25.0f, LayerMask.GetMask("Attach Points")))
        {
            _swingPoint = hit.point;
            joint = gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = _swingPoint;
            
            _lineRenderer.positionCount = 2;
        }
    }

    public void StopSwing()
    {
        _lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInfected = !isInfected && other.gameObject.GetComponent<Player>().isInfected;
            print(isInfected);
        }
        if (other.gameObject.CompareTag("Bouncy Platform"))
        {
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            _rigidbody.AddForce(other.gameObject.transform.forward * 20.0f, ForceMode.VelocityChange);
        }
    }
}
