using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	private float lastInputTime = 0.0f;

	public const float InputGap = 0.25f;

	public delegate void InputEvent(Direction d);
	public static event InputEvent OnInputEvent;
	
	void Update()
	{
		#if UNITY_ANDROID
		if (Input.touchCount > 0){
			
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
					
				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;
					
				case TouchPhase.Ended :
					
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}
						
						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								setPacmanDirection(Direction.RIGHT);
							}else{
								setPacmanDirection(Direction.LEFT);
							}
						}
						
						if(swipeType.y != 0.0f ){
							if(swipeType.y > 0.0f){
								setPacmanDirection(Direction.UP);
							}else{
								setPacmanDirection(Direction.DOWN);
							}
						}
						
					}
					
					break;
				}
			}
		}
		#endif

		#if UNITY_STANDALONE || UNITY_EDITOR
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");
		if (System.Math.Abs (horizontalMove - 0.0f) > 0.01f) {
			if (horizontalMove > 0.0f) {
				setPacmanDirection (Direction.RIGHT);
			} else {
				setPacmanDirection (Direction.LEFT);
			}
		} else if (System.Math.Abs (verticalMove - 0.0f) > 0.01f) {
			if (verticalMove > 0.0f) {
				setPacmanDirection (Direction.UP);
			} else {
				setPacmanDirection (Direction.DOWN);
			}
		}
		#endif
	}

	void setPacmanDirection(Direction d) {
		if (OnInputEvent != null && Time.time - lastInputTime >= InputGap)
		{
			lastInputTime = Time.time;
			OnInputEvent(d);
		}
	}
}
