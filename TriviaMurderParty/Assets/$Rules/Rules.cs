using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class Rules : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] RuleButtons;
    public KMSelectable StartNowIGuessFuckYouImTerryDavis;
    public TextMesh[] Options;
    public TextMesh TheRuleTM;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    string[] WordsOfAids = {
"ACID","BUST","CODE","DAZE","ECHO","FILM","GOLF","HUNT","ITCH","JURY","KING","LIME","MONK","NUMB","ONLY","PREY","QUIT","RAVE","SIZE","TOWN","URGE","VERY","WAXY","XYLO","YARD","ZERO","ABORT","BLEND","CRYPT","DWARF","EQUIP","FANCY","GIZMO","HELIX","IMPLY","JOWLS","KNIFE","LEMON","MAJOR","NIGHT","OVERT","POWER","QUILT","RUSTY","STOMP","TRASH","UNTIL","VIRUS","WHISK","XERIC","YACHT","ZEBRA","ADVICE","BUTLER","CAVITY","DIGEST","ELBOWS","FIXURE","GOBLET","HANDLE","INDUCT","JOKING","KNEADS","LENGTH","MOVIES","NIMBLE","OBTAIN","PERSON","QUIVER","RACHET","SAILOR","TRANCE","UPHELD","VANISH","WALNUT","XYLOSE","YANKED","ZODIAC","ALREADY","BROWSED","CAPITOL","DESTROY","ERASING","FLASHED","GRIMACE","HIDEOUT","INFUSED","JOYRIDE","KETCHUP","LOCKING","MAILBOX","NUMBERS","OBSCURE","PHANTOM","QUIETLY","REFUSAL","SUBJECT","TRAGEDY","UNKEMPT","VENISON","WARSHIP","XANTHIC","YOUNGER","ZEPHYRS","ADVOCATE","BACKFLIP","CHIMNEYS","DISTANCE","EXPLOITS","FOCALIZE","GIFTWRAP","HOVERING","INVENTOR","JEALOUSY","KINSFOLK","LOCKABLE","MERCIFUL","NOTECARD","OVERCAST","PERILOUS","QUESTION","RAINCOAT","STEALING","TREASURY","UPDATING","VERTICAL","WISHBONE","XENOLITH","YEARLONG","ZEALOTRY","ABHORRENT","BACCARATS","CULTIVATE","DAMNINGLY","EFFLUXION","FUTURISTS","GYROSCOPE","HAZARDOUS","ILLOGICAL","JUXTAPOSE","KILOBYTES","LANTHANUM","MATERIALS","NIHILISTS","OBSCENITY","PAINFULLY","QUEERNESS","RESTROOMS","SABOTAGED","TYRANNOUS","UMPTEENTH","VEXILLATE","WAYLAYERS","XENOBLAST","YTTERBIUM","ZIGZAGGER"
};
    string[] Introtexts = {"You will fail", "The timer is ticking", "It is inevitable", "Better flee", "Give up", "There is no hope"};
    string[] RulesIGuess = {"Press a word\nwith the letter\n", "Press the\nshortest word", "Press the\nlongest word", "Press an\neven number", "Press an\nodd number", "Press the\n{0} button"};
    string[] NotRulesIGuess = {"Don't press a\nword with the\nletter ", "Don't press\nthe shortest\nword", "Don't press\nthe longest\nword", "Don't press\nan even\nnumber", "Don't press\nan odd number", "Don't press\nthe {0}\nbutton"};
    bool[] Validity = {false, false, false, false};
    string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string PossibilitiesForLetters = "";
    string ForMrsKwan = "https://www.youtube.com/watch?v=7ExEXoTm4Dc";

    bool Activate = false;
    int Fatass = 0;
    int Retard = 0;
    string ShutTheFuckUp = "";
    char LuckyLetter = ' ';
    string ShortestSlashLongest = "";
    int[] NumbersForThing = {0, 0, 0, 0};
    int Counter = 0;
    float Weed = 0f;
    float Weedtwo = 0f;
    int ThresshyBoy = 0;
    float NowINeedATimerFuck = 0f;
    #pragma warning disable 0649
        bool TwitchPlaysActive;
    #pragma warning restore 0649

    void Awake () {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable RuleButton in RuleButtons) {
            RuleButton.OnInteract += delegate () { RuleButtonPress(RuleButton); return false; };
        }
        StartNowIGuessFuckYouImTerryDavis.OnInteract += delegate () { TerryPress(); return false; };
    }

    void Start () {
      UselessShit();
      Weed = Bomb.GetTime();
    }

    void UselessShit () {
      Introtexts.Shuffle();
      for (int i = 0; i < 4; i++) {
        Options[i].text = Introtexts[i];
      }
      TheRuleTM.text = "Don't Mess up.";
    }

    void TerryPress () {
      if (!Activate) {
        Activate = true;
        if (Weedtwo <= 1) {
          ThresshyBoy = 1;
        }
        else if (Weedtwo / Weed >= .81f) {
          ThresshyBoy = 20;
        }
        else if (Weedtwo / Weed >= .61f) {
          ThresshyBoy = 16;
        }
        else if (Weedtwo / Weed >= .41f) {
          ThresshyBoy = 12;
        }
        else if (Weedtwo / Weed >= .21f) {
          ThresshyBoy = 8;
        }
        else if (Weedtwo / Weed >= .01f) {
          ThresshyBoy = 4;
        }
        else {
          ThresshyBoy = 1;
        }
        Debug.LogFormat("[Rules #{0}] {1} module(s) need to be solved.", moduleId, ThresshyBoy);
        RulePicker();
      }
    }

    void RuleButtonPress (KMSelectable RuleButton) {
      if (!Activate) {
        return;
      }
      else {
        for (int i = 0; i < 4; i++) {
          if (RuleButton == RuleButtons[i]) {
            if (Validity[i]) {
              Audio.PlaySoundAtTransform("BiggerDick 1", RuleButton.transform);
              Counter += 1;
              for (int j = 0; j < 4; j++) {
                Validity[j] = false;
              }
              RulePicker();
            }
            else {
              GetComponent<KMBombModule>().HandleStrike();
            }
          }
        }
      }
    }

    void RulePicker () {
      Retard = UnityEngine.Random.Range(0,2);
      if (Retard == 0) {
        Fatass = UnityEngine.Random.Range(0, RulesIGuess.Length);
        TheRuleTM.text = RulesIGuess[Fatass];
      }
      else {
        Fatass = UnityEngine.Random.Range(0, NotRulesIGuess.Length);
        TheRuleTM.text = NotRulesIGuess[Fatass];
      }
      switch (Fatass) {
        case 0:
        how:
        for (int i = 0; i < 4; i++) {
          Options[i].text = WordsOfAids[UnityEngine.Random.Range(0, WordsOfAids.Length)];
          ShutTheFuckUp += Options[i].text;
        }
        for (int i = 0; i < Alphabet.Length; i++) {
          int WeedChungus = 0;
          for (int j = 0; j < 4; j++) {
            if (Options[j].text.Contains(Alphabet[i])) {
              WeedChungus += 1;
            }
          }
          if (WeedChungus == 4) {
            PossibilitiesForLetters += ".";
          }
          else if (WeedChungus == 0) {
            PossibilitiesForLetters += ".";
          }
          else {
            PossibilitiesForLetters += Alphabet[i].ToString();
          }
        }
        if (PossibilitiesForLetters == "..........................") {
          goto how;
        }
        LuckyLetter = PossibilitiesForLetters[UnityEngine.Random.Range(0,PossibilitiesForLetters.Length)];
        while (LuckyLetter == '.' || LuckyLetter == ' ') {
          LuckyLetter = PossibilitiesForLetters[UnityEngine.Random.Range(0,PossibilitiesForLetters.Length)];
        }
        for (int i = 0; i < 4; i++) {
          if (Options[i].text.Contains(LuckyLetter)) {
            Validity[i] = true;
          }
        }
        if ((!Validity[0] && !Validity[1] && !Validity[2] && !Validity[3]) || (Validity[0] && Validity[1] && Validity[2] && Validity[3])) {
          goto how;
        }
        Inverter();
        TheRuleTM.text += LuckyLetter;
        PossibilitiesForLetters = "";
        ShutTheFuckUp = "";
        break;
        case 1:
        Bitch:
        for (int i = 0; i < 4; i++) {
          Options[i].text = WordsOfAids[UnityEngine.Random.Range(0, WordsOfAids.Length)];
        }
        if ((Options[0].text.Length == Options[1].text.Length || Options[0].text.Length == Options[2].text.Length || Options[0].text.Length == Options[3].text.Length)
        || (Options[1].text.Length == Options[2].text.Length || Options[1].text.Length == Options[3].text.Length) || Options[2].text.Length == Options[3].text.Length) {
          goto Bitch;
        }
        ShortestSlashLongest = Options[0].text;
        for (int i = 1; i < 4; i++) {
          if (ShortestSlashLongest.Length > Options[i].text.Length) {
            ShortestSlashLongest = Options[i].text;
          }
        }
        for (int i = 0; i < 4; i++) {
          if (Options[i].text == ShortestSlashLongest) {
            Validity[i] = true;
          }
        }
        if ((!Validity[0] && !Validity[1] && !Validity[2] && !Validity[3]) || (Validity[0] && Validity[1] && Validity[2] && Validity[3])) {
          goto Bitch;
        }
        Inverter();
        break;
        case 2:
        BitchButLong:
        for (int i = 0; i < 4; i++) {
          Options[i].text = WordsOfAids[UnityEngine.Random.Range(0, WordsOfAids.Length)];
        }
        if ((Options[0].text.Length == Options[1].text.Length || Options[0].text.Length == Options[2].text.Length || Options[0].text.Length == Options[3].text.Length)
        || (Options[1].text.Length == Options[2].text.Length || Options[1].text.Length == Options[3].text.Length) || Options[2].text.Length == Options[3].text.Length) {
          goto BitchButLong;
        }
        ShortestSlashLongest = Options[0].text;
        for (int i = 1; i < 4; i++) {
          if (ShortestSlashLongest.Length < Options[i].text.Length) {
            ShortestSlashLongest = Options[i].text;
          }
        }
        for (int i = 0; i < 4; i++) {
          if (Options[i].text == ShortestSlashLongest) {
            Validity[i] = true;
          }
        }
        if ((!Validity[0] && !Validity[1] && !Validity[2] && !Validity[3]) || (Validity[0] && Validity[1] && Validity[2] && Validity[3])) {
          goto BitchButLong;
        }
        Inverter();
        break;
        case 3:
        Asswipe:
        int FuckerDumbass = 0;
        for (int i = 0; i < 4; i++) {
          Validity[i] = false;
        }
        for (int i = 0; i < 4; i++) {
          NumbersForThing[i] = UnityEngine.Random.Range(1,50);
          Options[i].text = NumbersForThing[i].ToString();
          if (NumbersForThing[i] % 2 == 0) {
            FuckerDumbass += 1;
            Validity[i] = true;
          }
        }
        if (FuckerDumbass == 4 || (!Validity[0] && !Validity[1] && !Validity[2] && !Validity[3]) || (Validity[0] && Validity[1] && Validity[2] && Validity[3])) {
          goto Asswipe;
        }
        Inverter();
        break;
        case 4:
        AsswipeButShutUp:
        int PenileGland = 0;
        for (int i = 0; i < 4; i++) {
          Validity[i] = false;
        }
        for (int i = 0; i < 4; i++) {
          NumbersForThing[i] = UnityEngine.Random.Range(1,50);
          Options[i].text = NumbersForThing[i].ToString();
          if (NumbersForThing[i] % 2 == 1) {
            PenileGland += 1;
            Validity[i] = true;
          }
        }
        if (PenileGland == 4 || (!Validity[0] && !Validity[1] && !Validity[2] && !Validity[3]) || (Validity[0] && Validity[1] && Validity[2] && Validity[3])) {
          goto AsswipeButShutUp;
        }
        Inverter();
        break;
        case 5:
        if (Retard == 0) {
          for (int i = 0; i < 4; i++) {
            Validity[i] = false;
            Options[i].text = "Button";
          }
          TheRuleTM.text = "Press the\n";
          switch (UnityEngine.Random.Range(0,4)) {
            case 0:
            TheRuleTM.text += "first button";
            break;
            case 1:
            TheRuleTM.text += "second button";
            break;
            case 2:
            TheRuleTM.text += "third button";
            break;
            case 3:
            TheRuleTM.text += "fourth button";
            break;
          }
          switch (TheRuleTM.text[11]) {
            case 'i':
            Validity[0] = true;
            break;
            case 'e':
            Validity[1] = true;
            break;
            case 'h':
            Validity[2] = true;
            break;
            case 'o':
            Validity[3] = true;
            break;
          }
        }
        else {
          for (int i = 0; i < 4; i++) {
            Validity[i] = true;
            Options[i].text = "Button";
          }
          TheRuleTM.text = "Don't press the\n";
          switch (UnityEngine.Random.Range(0,4)) {
            case 0:
            TheRuleTM.text += "first button";
            break;
            case 1:
            TheRuleTM.text += "second button";
            break;
            case 2:
            TheRuleTM.text += "third button";
            break;
            case 3:
            TheRuleTM.text += "fourth button";
            break;
          }
          switch (TheRuleTM.text[17]) {
            case 'i':
            Validity[0] = false;
            break;
            case 'e':
            Validity[1] = false;
            break;
            case 'h':
            Validity[2] = false;
            break;
            case 'o':
            Validity[3] = false;
            break;
          }
        }
        break;
      }
      Debug.LogFormat("[Rules #{0}] The current rule is \"{1}\".", moduleId, TheRuleTM.text.Replace("\n", " "));
      if (Fatass != 5) {
        Debug.LogFormat("[Rules #{0}] The options are {1}, {2}, {3}, and {4}.", moduleId, Options[0].text, Options[1].text, Options[2].text, Options[3].text);
      }
    }

    void Inverter () {
      if (Retard == 1) {
        for (int i = 0; i < 4; i++) {
          Validity[i] = !Validity[i];
        }
      }
    }

    void Update(){
      Weedtwo = Bomb.GetTime();
      if (Activate) {
        NowINeedATimerFuck += Time.deltaTime;
        if (NowINeedATimerFuck >= 30f && !TwitchPlaysActive) {
          Activate = false;
          StartCoroutine(Check());
        }
        else if (NowINeedATimerFuck >= 100f && TwitchPlaysActive) {
          Activate = false;
          StartCoroutine(Check());
        }
      }
    }

    IEnumerator Check () {
      for (int i = 0; i < 4; i++) {
        Options[i].text = "";
      }
      TheRuleTM.text = Counter.ToString() + " out of " + ThresshyBoy.ToString();
      yield return new WaitForSecondsRealtime(3f);
      if (Counter >= ThresshyBoy) {
        GetComponent<KMBombModule>().HandlePass();
        Debug.LogFormat("[Rules #{0}] You followed {1} rules correctly out of the required minimum of {2}. Module disarmed.", moduleId, Counter.ToString(), ThresshyBoy.ToString());
      }
      else {
        Counter = 0;
        ThresshyBoy = 0;
        GetComponent<KMBombModule>().HandleStrike();
        Debug.LogFormat("[Rules #{0}] You followed {1} rules correctly out of the required minimum of {2}. Strike, Blan!", moduleId, Counter.ToString(), ThresshyBoy.ToString());
        UselessShit();
      }
    }

    IEnumerator ProcessTwitchCommand (string Command) {
      Command = Command.Trim();
      if (Command.ToString().ToUpper() == "START") {
        yield return null;
        StartNowIGuessFuckYouImTerryDavis.OnInteract();
      }
      else if (Command.ToString().ToUpper() == "1") {
        yield return null;
        RuleButtons[0].OnInteract();
      }
      else if (Command.ToString().ToUpper() == "2") {
        yield return null;
        RuleButtons[1].OnInteract();
      }
      else if (Command.ToString().ToUpper() == "3") {
        yield return null;
        RuleButtons[2].OnInteract();
      }
      else if (Command.ToString().ToUpper() == "4") {
        yield return null;
        RuleButtons[3].OnInteract();
      }
      else {
        yield return "sendtochaterror I don't understand!";
        yield break;
      }
    }
}
