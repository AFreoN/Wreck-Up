using UnityEngine;
using UnityEditor;

public class LevelGanerator : EditorWindow
{
    Vector2 PlacePosition;
    int PlaceRotation;
    Transform Prefab;
    Transform current;

    public string[] Objects = { "w", "p", "c1", "c2" };
    public int index = 0;
    public Options op;

    public Movement MovementType;

    [MenuItem("Window/Level Generator")]
    public static void ShowWindow()
    {
        GetWindow<LevelGanerator>("Generate");
    }

    private void OnGUI()
    {
        op = (Options)EditorGUILayout.EnumPopup("Type of Object", op);
        GetPrefab(op);

        GUILayout.Label("Position and Rotation", EditorStyles.boldLabel);
        PlacePosition = EditorGUILayout.Vector2Field("Place Position", PlacePosition);
        PlaceRotation = EditorGUILayout.IntField("Rotation", PlaceRotation);

        if(GUILayout.Button("Generate"))
        {
            if (Prefab != null)
            {
                current = Instantiate(Prefab, new Vector3(PlacePosition.x, PlacePosition.y, 0), Quaternion.Euler( 0, 0 ,PlaceRotation));
                current.name = Prefab.name;
                Selection.activeGameObject = current.gameObject ;
            }
            else
            {
                Debug.LogWarning("Object not found");
            }
        }

        if (current != null)
        {
            if (GUILayout.Button("Undo"))
            {
                DestroyImmediate(current.gameObject);
            }
            if (current != null)
            {
                getComponent(current.gameObject);
            }
        }
    }

    void GetPrefab(Options op)
    {
        switch(op)
        {
            case Options.Wood:
                Prefab = Resources.Load("w", typeof(Transform)) as Transform;
                break;
            case Options.Plain:
                Prefab = Resources.Load("p", typeof(Transform)) as Transform;
                break;
            case Options.SemiCircle:
                Prefab = Resources.Load("c1", typeof(Transform)) as Transform;
                break;
            case Options.QuadCircle:
                Prefab = Resources.Load("c2", typeof(Transform)) as Transform;
                break;
            case Options.Triangle:
                Prefab = Resources.Load("t", typeof(Transform)) as Transform;
                break;
            case Options.Arrow:
                Prefab = Resources.Load("arrow", typeof(Transform)) as Transform;
                break;
            case Options.TwoJoints:
                Prefab = Resources.Load("tj", typeof(Transform)) as Transform;
                break;
            case Options.shooter:
                Prefab = Resources.Load("shooter", typeof(Transform)) as Transform;
                break;
        }
    }

    void getComponent(GameObject cur)
    {
        if (current.GetComponent<HVmovement>() != null)
        {
            if (GUILayout.Button("Remove HV Movement"))
            {
                DestroyImmediate(current.GetComponent<HVmovement>());
            }
        }
        else if(current.GetComponent<ArrowMovement>() != null)
        {
            if(GUILayout.Button("Remove ArrowMovement"))
            {
                DestroyImmediate(current.GetComponent<ArrowMovement>());
            }
        }
        else if (current.GetComponent<ZRotation>() != null)
        {
            if (GUILayout.Button("Remove Z Rotation"))
            {
                DestroyImmediate(current.GetComponent<ZRotation>());
            }
        }
        else if (current.GetComponent<TargetRot>() != null)
        {
            if (GUILayout.Button("Remove Target Rot"))
            {
                DestroyImmediate(current.GetComponent<ArrowMovement>());
            }
        }
        else
        {
            addComponent(cur);
        }
    }

    void addComponent(GameObject cur)
    {
        MovementType = (Movement)EditorGUILayout.EnumPopup("Component to add", MovementType);
        if (GUILayout.Button("ADD COMPONENT"))
        {
            getAddComponent(MovementType, cur);
        }
    }

    void getAddComponent(Movement m, GameObject cur)
    {
        switch(m)
        {
            case Movement.HVMovement:
                cur.AddComponent<HVmovement>();
                break;
            case Movement.ArrowMovement:
                cur.AddComponent<ArrowMovement>();
                break;
            case Movement.ZRotation:
                cur.AddComponent<ZRotation>();
                break;
            case Movement.TargetZRot:
                cur.AddComponent<TargetRot>();
                break;
        }
    }
}

public enum Options
{
    Wood,
    Plain,
    SemiCircle,
    QuadCircle,
    Triangle,
    Arrow,
    TwoJoints,
    shooter
}

public enum Movement
{
    HVMovement,
    ArrowMovement,
    ZRotation,
    TargetZRot
}
