using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UpdatableData : ScriptableObject
{

	public event System.Action OnValuesUpdated;
	public bool autoUpdate;



	protected virtual void OnValidate()
	{
		if (autoUpdate)
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.update += NotifyOfUpdatedValues;
#endif
		}
	}
	public void NotifyOfUpdatedValues()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.update -= NotifyOfUpdatedValues;
#endif
		if (OnValuesUpdated != null)
		{
			OnValuesUpdated();
		}
	}

}