using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class ArtifactPopup : MonoBehaviour
{
    public UIDocument Artifact;
    
    public Label artifacttext;
    public Label header;
    public Button back;



    public float proximity = 3.0f;
    private string[] Artifact_Text;
    private string[] Artifact_Header;

    public GameObject Player;

    public GameObject Artifact_After;
    public GameObject Artifact_Hope;
    public GameObject Artifact_Defiance;
    public GameObject Artifact_Fear;



    public void Start()
    {
        Artifact = GetComponent<UIDocument>();
    }
    public void Update()
    {
   

            
            
            var ArtAft = Vector2.Distance(Artifact_After.transform.position, Player.transform.position);
        var ArtHope = Vector2.Distance(Artifact_Hope.transform.position, Player.transform.position);
        var ArtDef = Vector2.Distance(Artifact_Defiance.transform.position, Player.transform.position);
        var ArtFear = Vector2.Distance(Artifact_Fear.transform.position, Player.transform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (ArtAft <= proximity)
            {
                ShowMenu1();
                ArtifactText();
                artifacttext.text = Artifact_Text[0];

                ArtifactHeadings();
                header.text = Artifact_Header[2];
            }

            if (ArtHope <= proximity)
            {
                ShowMenu1();
                ArtifactText();
                artifacttext.text = Artifact_Text[1];

                ArtifactHeadings();
                header.text = Artifact_Header[1];
            }

            if (ArtDef <= proximity)
            {
                ShowMenu1();
                ArtifactText();
                artifacttext.text = Artifact_Text[2];

                ArtifactHeadings();
                header.text = Artifact_Header[0];

            }

            if (ArtFear <= proximity)
            {
                ShowMenu1();
                ArtifactText();
                artifacttext.text = Artifact_Text[3];

                ArtifactHeadings();
                header.text = Artifact_Header[3];
            }
        }
    }

    void ShowMenu1()
    {
        Artifact.enabled = true;
        Time.timeScale = 0.0f;
        if (Artifact != null)
        {
            var root = Artifact.rootVisualElement;
            back = root.Q<Button>("BackToGame");
            artifacttext = root.Q<Label>("ArtifactText");
            header = root.Q<Label>("Header");
        }
        back.RegisterCallback<ClickEvent>(BackButtonOnClick);

    }
    
    void BackButtonOnClick(ClickEvent evt)
    {
        Artifact.enabled = false;
        Time.timeScale = 1.0f;
    } 
    void ArtifactText()
        {
            Artifact_Text = new string[4];
            Artifact_Text[0] = "Locked the bunker down… couldn’t be helped.  Not my fault that they died… right? Got to keep our clients safe.  Our job. My job.  Outsiders just don’t get it… the clients are our hope… our future. Had to be done… Yeah. I had to. No choice.  They had to die.  Yeah. For us… our clients to survive.";
            Artifact_Text[1] = "This is ludicrous… how was I to be expected to compile a global archive?  One week? One week is not even close to enough time. Still, however. I managed to compile the majority of all relevant data into these databanks… The ‘how to rebuild's… The ‘so you need penicillin’s… Our cultural histories… Our great successes and failures… The road that brought us to this moment. We can learn from this. Please let us learn from this. Please. ";
            Artifact_Text[2] = "We could do it, you know… Swap with them, I mean. I’m being serious. Yeah sure. Good one. If we waited until everyone was asleep, we could sneak into Security to disable the safeguards. We’ve all had the protocol training. We know how. Why not! Why should some fossils make it to the Rebuilding and not us? We have earned this. We deserve to be there just as much as them. More even. If we time it right, they’ll be too far along re-warming to go back under. We’ll have taken their places by then. \r\nSure everyone will be mad, but that won’t be our problem anymore. Next time we wake would be for the Rebuilding. Of… Of course. I was just messing with you haha. You know how I am. Gotcha. Good thing yeah ahah. Oh gods… You are being serious this time. You are scaring me. No… Please no. You’re joking right? Tell me you’re joking. Oh thank the Builders. I was worried there for a moment. I did not want to call an Overseer. They are always so… Unblinking. Or who knows… Maybe I’d have helped";
            Artifact_Text[3] = "They turned on us.I don’t know why they turned on us, but they did. Our maintenance robots… I suppose it doesn’t matter now. Everyone is dead. The protocols were deactivated. I’m stuck here. Alone. They are waiting for me. I know it. But I won’t let them. They won’t get me. ";


            }

        void ArtifactHeadings()
        {
        Artifact_Header = new string[4];
        Artifact_Header[0] = "Defiance"; 
        Artifact_Header[1] = "Hope";
        Artifact_Header[2] = "After";
        Artifact_Header[3] = "Fear";
        }

        
    }

