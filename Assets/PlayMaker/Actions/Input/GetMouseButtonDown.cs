// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Sends an Event when the specified Mouse Button is pressed. Optionally store the button state in a bool variable.")]
	public class GetMouseButtonDown : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The mouse button to test.")]
		public MouseButton button;

        [Tooltip("Event to send if the mouse button is down.")]
		public FsmEvent sendEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("Store the button state in a Bool Variable.")]
        public FsmBool storeResult;

        [Tooltip("Uncheck to run when entering the state.")]
	    public bool inUpdateOnly;
		
		public override void Reset()
		{
			button = MouseButton.Left;
			sendEvent = null;
			storeResult = null;
		    inUpdateOnly = true;
		}

        public override void OnEnter()
        {
            if (!inUpdateOnly)
            {
                DoGetMouseButtonDown();
            }
        }

        public override void OnUpdate()
        {
            DoGetMouseButtonDown();
        }

        private void DoGetMouseButtonDown()
		{
			bool buttonDown = Input.GetMouseButtonDown((int)button);
		    if (buttonDown)
			{
			    Fsm.Event(sendEvent);
			}
			
			storeResult.Value = buttonDown;
		}

#if UNITY_EDITOR
        public override string AutoName()
        {
            return string.Format("GetMouseButtonDown: {0} {1}",
                sendEvent != null ? sendEvent.Name : "",
                storeResult.IsNone ? "" : storeResult.Name);
        }
#endif
    }
}