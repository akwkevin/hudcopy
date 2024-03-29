﻿
namespace Kent.Boogaart.Truss.Fluent
{
	/// <summary>
	/// Allows a binding to be activated.
	/// </summary>
	public interface IActivation : IHideObjectMembers
	{
		/// <summary>
		/// Activates the binding, bringing the fluent expression to a close.
		/// </summary>
		void Activate();
	}
}