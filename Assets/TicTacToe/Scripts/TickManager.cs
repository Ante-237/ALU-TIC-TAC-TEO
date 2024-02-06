using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace tic_tac
{

    /// <summary>
    /// enum for easy casting to integer for selection of strike type
    /// </summary>
    public enum STRIKETYPE
    {
        VERTSTRIKELEFT,
        VERTSTRIKEMIDDLE,
        VERTSTRIKERIGHT,
        HORIZONTALSTRIKEUP,
        HORIZONTALSTRIKEMIDDLE,
        HORIZONTALSTRIKEDOWN,
        CROSSTRIKERIGHT,
        CROSSTRIKELEFT
    };

    /// <summary>
    /// type of ticks to select with int casting
    /// </summary>
    public enum TICK
    {
        CIRCLE,
        CROSS,
        EMPTY
    };

    /// <summary>
    ///  tyope of playtype to select to casting
    /// </summary>
    public enum PLAYTIME
    {
        PLAYER,
        OPPONENT,
        AI
    };
    
    public class TickManager : MonoBehaviour
    {
    
    // reference to all buttons
    [FormerlySerializedAs("allButtons")] public List<Button> AllButtons = new();

    
    // keep reference to line strikes
    [SerializeField] private List<GameObject> AllStrikes = new();
    
    // determines how fast the letter should grow when activated.
    [SerializeField] [Range(1f, 10f)] private float GrowFactor = 5.0f;

    // current tick type during runtime.
    public TICK currentTick = TICK.CIRCLE;
    
    // reference to playing type
    [SerializeField] private TextMeshProUGUI PlayText;
    
    // tick types
    private readonly String[] TICKS = { "O", "X" , ""};
    
    // playing state types
    private readonly String[] PLAY = { "Player O Move", "Player X Move", "Player VS AI" };

    private TextMeshProUGUI TextHold;
    private bool canGrow = false;
    private float MaxGrowSize = 160.0f;
    private const float MinGrowSize = 20.0f;
    
    
    
    private void Update()
    {
        AnimateGrowth();
    }

    /// <summary>
    /// animate ticks for smooth transition
    /// </summary>
    private void AnimateGrowth()
    {
        if (canGrow)
        {
            TextHold.fontSize += Time.time * GrowFactor;
            if (TextHold.fontSize >= 160)
            {
                canGrow = false;
            }
        }
    }

    /// <summary>
    /// binds all listeners to buttons
    /// </summary>
    private void OnEnable()
    {
        AllButtons[0].onClick.AddListener(PlayerMove00);
        AllButtons[1].onClick.AddListener(PlayerMove01);
        AllButtons[2].onClick.AddListener(PlayerMove02);
        
        AllButtons[3].onClick.AddListener(PlayerMove10);
        AllButtons[4].onClick.AddListener(PlayerMove11);
        AllButtons[5].onClick.AddListener(PlayerMove12);
        
        AllButtons[6].onClick.AddListener(PlayerMove20);
        AllButtons[7].onClick.AddListener(PlayerMove21);
        AllButtons[8].onClick.AddListener(PlayerMove22);
    }

    /// <summary>
    ///  activates the line striking
    /// </summary>
    /// <param name="index"></param>
    public void StrikeLine(int index)
    {
        AllStrikes[index].SetActive(true);
    }

    /// <summary>
    /// updates thge current playing status
    /// </summary>
    /// <param name="index"></param>
    public void UpdatePlayType(int index)
    {
        PlayText.text = PLAY[index];
    }

    private void PlayerMove00()
    {
        Update_Button(AllButtons[0],(int)currentTick);
    }

    private void PlayerMove01()
    {
        Update_Button(AllButtons[1], (int)currentTick);
    }

    private void PlayerMove02()
    {
        Update_Button(AllButtons[2], (int)currentTick);
    }

    private void PlayerMove10()
    {
        Update_Button(AllButtons[3], (int)currentTick);
    }

    private void PlayerMove11()
    {
        Update_Button(AllButtons[4], (int)currentTick);
    }

    private void PlayerMove12()
    {
        Update_Button(AllButtons[5], (int)currentTick);
    }

    private void PlayerMove20()
    {
        Update_Button(AllButtons[6], (int)currentTick);
    }

    private void PlayerMove21()
    {
        Update_Button(AllButtons[7], (int)currentTick);
    }

    private void PlayerMove22()
    {
        Update_Button(AllButtons[8], (int)currentTick);
    }

    /// <summary>
    /// controls moves by the Ai
    /// </summary>
    /// <param name="position"></param>
    /// <param name="index"></param>
    public void AI_Move(int position, int index)
    {
        Update_Button(AllButtons[position], index);
        AllButtons[position].interactable = false;
    }
    
    /// <summary>
    /// update buttons controlled by the player
    /// </summary>
    /// <param name="_b"></param>
    /// <param name="index"></param>
    private void Update_Button(Button _b,int index)
    {
        
        TextHold = _b.GetComponentInChildren<TextMeshProUGUI>();
        TextHold.fontSize = MinGrowSize;
        _b.interactable = false;
        TextHold.text = TICKS[index];
        canGrow = true;
    }

    private void OnDisable()
    {
        AllButtons[0].onClick.RemoveListener(PlayerMove00);
        AllButtons[1].onClick.RemoveListener(PlayerMove01);
        AllButtons[2].onClick.RemoveListener(PlayerMove02);
        
        AllButtons[3].onClick.RemoveListener(PlayerMove10);
        AllButtons[4].onClick.RemoveListener(PlayerMove11);
        AllButtons[5].onClick.RemoveListener(PlayerMove12);
        
        AllButtons[6].onClick.RemoveListener(PlayerMove20);
        AllButtons[7].onClick.RemoveListener(PlayerMove21);
        AllButtons[8].onClick.RemoveListener(PlayerMove22);
    }
    
    }

}

