using UnityEngine;

public class Latajaca_Platforma_Ale_Taka_Fajna : MonoBehaviour
{
    public GameObject Platform;    
    public float MoveSpeed;
    public Transform CurrentPoint;
    public Transform[] points;
    public int PointSelection;
    [Header("Obracanie")]
    public bool CzyMaSieObracac=false;
    public Rigidbody2D CoMaSieObracacRigidbody2D;
    public SpriteRenderer CoMaSieObracacSpriteRenderer;
    private bool lewo;
    private void Start()
    {
        CurrentPoint = points[PointSelection];
    }
    private void Update()
    {
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position,CurrentPoint.position,Time.deltaTime*MoveSpeed);
        if (Platform.transform.position==CurrentPoint.position)
        {
            PointSelection++;
            if (PointSelection==points.Length)
            {
                PointSelection = 0;
            }
            CurrentPoint = points[PointSelection];
        }
        if (CzyMaSieObracac)
        {
            if (CoMaSieObracacRigidbody2D.position.x < CurrentPoint.position.x)
            {
                lewo = false;
            }
            else if (CoMaSieObracacRigidbody2D.position.x > CurrentPoint.position.x)
            {
                lewo = true;
            }
            if (lewo == true)
            {
                CoMaSieObracacSpriteRenderer.flipX = false;
            }
            else if (lewo == false)
            {
                CoMaSieObracacSpriteRenderer.flipX = true;
            }
        }
    }
}
