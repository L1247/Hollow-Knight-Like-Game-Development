using UnityEngine;
using UnityEngine.UI;

public class Free_GM : MonoBehaviour
{
#region Public Variables

    public Animator[] anim;
    public float      clampPower = 10;
    public float      CurrPage   = 1;


    public float MaxPage   = 4;
    public float MoveSpeed = -7;

    public GameObject[] WearGroup;

    public int      CurrAnimPage;
    public string[] AnimName;

    public Text Text_AnimState;
    public Text Text_Page;
    public Text Text_Takeoff;

#endregion

#region Private Variables

    private bool    b_takeoff;
    private Vector3 tmptrans;

#endregion

#region Unity events

    // Use this for initialization
    private void Start()
    {
        tmptrans = transform.position;
        var tmpstring = CurrPage + "/" + MaxPage;
        Text_Page.text = tmpstring;

        for (var i = 0 ; i < anim.Length ; i++) anim[i].Play(AnimName[0]);
    }

#endregion

#region Public Methods

    public void TakeOff()
    {
        Debug.Log("TakeOff");


        if (!b_takeoff)
            for (var i = 0 ; i < WearGroup.Length ; i++)
            {
                WearGroup[i].SetActive(false);
                Text_Takeoff.text = "Take ON";
            }
        else
            for (var i = 0 ; i < WearGroup.Length ; i++)
            {
                WearGroup[i].SetActive(true);
                Text_Takeoff.text = "Take OFF";
            }

        b_takeoff = !b_takeoff;
    }

#endregion

#region Private Methods

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrPage <= 1)
                // tmptrans = new Vector3(this.transform.position.x, MaxHeight, this.transform.position.z);
                return;
            CurrPage--;
            var tmpstring = CurrPage + "/" + MaxPage;
            Text_Page.text = tmpstring;
            tmptrans       = new Vector3(transform.position.x , CurrPage * MoveSpeed , transform.position.z);

            Debug.Log("위");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrPage >= MaxPage) return;

            CurrPage++;
            var tmpstring = CurrPage + "/" + MaxPage;
            Text_Page.text = tmpstring;

            tmptrans = new Vector3(transform.position.x , CurrPage * MoveSpeed , transform.position.z);

            Debug.Log("아래");
        }


        transform.position = Vector3.Lerp(transform.position , tmptrans , Time.deltaTime * clampPower);


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurrAnimPage >= AnimName.Length - 1)
                return;

            Debug.Log("RightArrow");
            CurrAnimPage++;
            for (var i = 0 ; i < anim.Length ; i++)
            {
                anim[i].Play(AnimName[CurrAnimPage]);
                Text_AnimState.text = AnimName[CurrAnimPage];
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CurrAnimPage <= 0)
                return;

            Debug.Log("LeftArrow");
            CurrAnimPage--;
            for (var i = 0 ; i < anim.Length ; i++)
            {
                anim[i].Play(AnimName[CurrAnimPage]);
                Text_AnimState.text = AnimName[CurrAnimPage];
            }
        }
    }

#endregion
}