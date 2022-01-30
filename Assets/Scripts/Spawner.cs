using UnityEngine;

 public class Spawner : MonoBehaviour
 {

        [Header("Instantiator State")]
        [Tooltip("Turn on/off the instatiator")]
        [SerializeField] private bool isActivated = true;
        private bool allowInstantiate = true;

        [Header("Game Object(s) settings")]
        [Tooltip("The times which every game object is going to be instantiated")] 
		[SerializeField] private float iterations = 1;
        
        private enum currentTypeOfInstantiation
        {
            instanceAll = 0,
            instanceARandomOne,
        }
        [SerializeField] private currentTypeOfInstantiation typeOfInstantiation = currentTypeOfInstantiation.instanceAll;

        [Tooltip("Object(s) to instantiate")]
        [SerializeField] private GameObject[] elements;

        [Header("Area settings")]
        [Tooltip("The axis where the game object(s) going to be instantiated")]
        private Vector3 pivotCenter = new Vector3(0, 0, 0);
        private Vector3 objectPosition; 
        [Tooltip("The area where the game object(s) going to be instantiated")]
        [SerializeField] private Vector3 instantiationArea = new Vector3(1, 1, 1);
        
        [Header("Gizmos settings")]
        [Tooltip("Enable/Disable the gizmo of the area of instantiation")]
        [SerializeField] private bool showGizmo = true;
        private enum gizmoSelectedColor
        {
            blue = 0,
            cyan,
            green,
            yellow,
            red,
            magenta,
            white,
            gray,
            black,
        }
        [SerializeField] private gizmoSelectedColor gizmoColor = gizmoSelectedColor.yellow;

        private uint number = 0;
        private uint randomNumber = 0;
        [Header("Segundos en los que spawneara")]
        [SerializeField] private bool spawnAtNight = false;
        private bool tokensAvailable = true;
        
        private void Awake()
        {
            pivotCenter = transform.position;
            randomNumber = GetARandomNumber(elements.Length);
        }
        
        private void FixedUpdate()
        {
            ObjectInstantiator();
        }

        private void ObjectInstantiator()
        {
            if(GameManager.GameManagerInstance.isDay && !spawnAtNight && tokensAvailable)
            {
                allowInstantiate = true;
            }
            else if(!GameManager.GameManagerInstance.isDay && spawnAtNight && tokensAvailable)
            {
                allowInstantiate = true;
            }
            else if (!GameManager.GameManagerInstance.isDay && !spawnAtNight)
            {
                tokensAvailable = true;
            }
            else if (GameManager.GameManagerInstance.isDay && spawnAtNight)
            {
                tokensAvailable = true;
            }
            
            
            if (!isActivated)
            {
                return;
            }
            else
            {
                if (!allowInstantiate)
                {
                    return;
                }
                else
                {
                    if (typeOfInstantiation == currentTypeOfInstantiation.instanceAll)
                    {
                        for (uint i = 0; i < elements.Length; i++)
                        {
                            Instantiator(i);
                        }
                    }
                    else if (typeOfInstantiation == currentTypeOfInstantiation.instanceARandomOne)
                    {
                        randomNumber = GetARandomNumber(elements.Length -1);
                        for (uint i = 0; i < randomNumber; i++)
                        {
                            Instantiator(randomNumber);
                            i = randomNumber;
                        }
                    }
                    allowInstantiate = false;
                    tokensAvailable = false;
                }
            }
        }

        private void Instantiator(uint elementID)
        {
            for (uint j = 0; j<iterations; j++)
            {
                objectPosition = pivotCenter + new Vector3 (Random.Range(0, instantiationArea.x / 2), 0, (Random.Range(0, instantiationArea.z / 2)));
                Instantiate(elements[elementID], objectPosition, Quaternion.identity);
            }
        }
        
        private uint GetARandomNumber(int length)
        {
            number = (uint)Random.Range(1, length+1);
            return number;
        }

        #region Gizmos
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (showGizmo == true)
            {
                switch (gizmoColor)
                {
                    case gizmoSelectedColor.blue:
                        Gizmos.color = Color.blue;
                        break;
                    case gizmoSelectedColor.cyan:
                        Gizmos.color = Color.cyan;
                        break;
                    case gizmoSelectedColor.green:
                        Gizmos.color = Color.green;
                        break;
                    case gizmoSelectedColor.red:
                        Gizmos.color = Color.red;
                        break;
                    case gizmoSelectedColor.magenta:
                        Gizmos.color = Color.magenta;
                        break;
                    case gizmoSelectedColor.white:
                        Gizmos.color = Color.white;
                        break;
                    case gizmoSelectedColor.gray:
                        Gizmos.color = Color.gray;
                        break;
                    case gizmoSelectedColor.black:
                        Gizmos.color = Color.black;
                        break;
                    default: Gizmos.color = Color.red + Color.yellow;
                        break;
                }
                Gizmos.DrawCube(transform.position /*transform.localPosition*/, instantiationArea);
            }
        }
#endif
        #endregion
}