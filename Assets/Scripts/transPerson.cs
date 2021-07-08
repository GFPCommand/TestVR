using UnityEngine;
using UnityEngine.UI;

public class transPerson : MonoBehaviour {
    private Rigidbody rb;
    private bool isControllVR;
    public Text info;
    public GameObject infoGO;
    private float xMov, zMov, yRot;
    private float speed = 3f;
    private bool isGrounded;
    [SerializeField] private Transform camRot;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isControllVR = controllUI.controllerVR;
    }

    private void Update()
    {
        if (isControllVR) PlayWithController();
        else PlayWithoutController();
    }

    private void PlayWithController()
    {
        yRot = camRot.rotation.y;
        xMov = Input.GetAxis("Horizontal");
        zMov = Input.GetAxis("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * speed;
        Vector3 rotation = new Vector3(0, yRot, 0) * speed;

        Vector3 lookDirection = moveDirection + transform.position;

        transform.LookAt(new Vector3(lookDirection.x, transform.position.y, lookDirection.z));

        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void PlayWithoutController()
    {
        if (camRot.rotation.x > 10)
        {
            yRot = camRot.rotation.x;

            Vector3 movVer = transform.forward * camRot.rotation.y;
            Vector3 movHor = transform.right * camRot.rotation.y;

            Vector3 velocity = (movVer + movHor).normalized * speed;
            Vector3 rotation = new Vector3(0, yRot, 0) * speed;

            Vector3 lookDirection = moveDirection + transform.position;

            transform.LookAt(new Vector3(lookDirection.x, transform.position.y, lookDirection.z));

            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
}
