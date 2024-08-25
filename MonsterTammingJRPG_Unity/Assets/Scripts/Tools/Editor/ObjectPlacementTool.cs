using System.Collections.Generic;
using System.Linq;
using Jrpg.GameCore.Extendables.General;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Jrpg.Tools.Editor
{
    public class ObjectPlacementTool : OdinEditorWindow
    {
        [SerializeField] private Transform _objectsContainer;
        [SerializeField] private GameObjectWeight[] _objects;
        [SerializeField] private int _amount;

        [SerializeField] private Vector3 _lowerBounds;
        [SerializeField] private Vector3 _upperBounds;

        [SerializeField] private int _seed;
        
        [MenuItem("Tools/Object Placement Tool")]
        private static void OpenWindow()
        {
            GetWindow<ObjectPlacementTool>().Show();
        }

        [Button("Place objects")]
        private void PlaceObjects()
        {
            Debug.Log($"destroying {_objectsContainer.childCount}");
            
            foreach (Transform child in _objectsContainer)
            {
                DestroyImmediate(child.gameObject);
            }

            var amountPerObject = GetObjectsAmount();
            
            CreateObjects(amountPerObject);

            VariateScale();
            VariatePositions();

            EditorUtility.SetDirty(_objectsContainer);
        }

        private IEnumerable<int> GetObjectsAmount()
        {
            int lastAmount = _amount;

            foreach (var item in _objects)
            {
                if (lastAmount <= 0)
                {
                    yield break;
                }

                int objectAmount = Mathf.RoundToInt(item.ObjectWeight * _amount);
                lastAmount -= objectAmount;

                yield return objectAmount;
            }
            
            Debug.Log($"spawned {_amount - lastAmount} objects");
        }
        
        private void CreateObjects(IEnumerable<int> amountPerObject)
        {
            var objectsToInstantiate = amountPerObject.Zip(_objects, (amount, prefab) => (amount, prefab));

            foreach (var prefabsAmount in objectsToInstantiate)
            {
                for (int i = 0; i < prefabsAmount.amount; i++)
                {
                    Instantiate(prefabsAmount.prefab.ObjectPrefab, _objectsContainer);
                }
            }
        }
        
        private void VariateScale()
        {
            var random = new System.Random(_seed);
            
            foreach (Transform child in _objectsContainer)
            {
                float randomScale = random.NextFloat(0.85f, 1.25f).RoundToNumbersAfterDot(1);
                child.localScale = Vector3.one * randomScale;
            }
        }
        
        private void VariatePositions()
        {
            var random = new System.Random(_seed);

            foreach (Transform child in _objectsContainer)
            {
                child.localPosition = random.NextVector3(_lowerBounds, _upperBounds);
            }
        }
    }

    [System.Serializable]
    public class GameObjectWeight
    {
        [PreviewField(60), HideLabel] 
        [HorizontalGroup("Split", 60)]
        [SerializeField]
        private GameObject _objectPrefab;
        
        [HorizontalGroup("Split"), LabelWidth(100)]
        [SerializeField, Range(0,1)] private float _objectWeight;
        
        public GameObject ObjectPrefab => _objectPrefab;
        public float ObjectWeight => _objectWeight;
    }
}