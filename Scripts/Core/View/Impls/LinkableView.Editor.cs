#if UNITY_EDITOR
using UnityEditor;

namespace JCMG.EntitasRedux.Core.View.Impls
{
	public abstract partial class LinkableView
	{
		protected virtual void OnValidate()
		{
			EditorAttackEntityLink();
		}

		private void EditorAttackEntityLink()
		{
			var serializedObject = new SerializedObject(this);
			serializedObject.FindProperty(nameof(entityLink)).objectReferenceValue = GetComponent<EntityLink>();
			serializedObject.ApplyModifiedProperties();
		}
	}
}
#endif