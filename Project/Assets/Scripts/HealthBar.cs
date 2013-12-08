using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	private int TIMER_INC;
	private Material mMaterial;
	
	private CustomAnimator mAnimator;
	public float timer;
	
	private CustomEventManager eventMan;
	
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		TIMER_INC = 6;
		
		eventMan = GameObject.Find("Global Script Executor").GetComponent<CustomEventManager>();
		
		mMaterial = renderer.material;
		
		mAnimator = new CustomAnimator(ref mMaterial, 5,5);
		
		mAnimator.CreateAnimation("100",0,0,1);
		mAnimator.CreateAnimation ("0",20,20, 1);
		mAnimator.CreateAnimation("100-95", 0,1,1);
		mAnimator.CreateAnimation("95-90", 1,2,1);
		mAnimator.CreateAnimation("90-85", 2,3,1);
		mAnimator.CreateAnimation("85-80", 3,4,1);
		mAnimator.CreateAnimation("80-75", 4,5,1);
		mAnimator.CreateAnimation("75-70", 5,6,1);
		mAnimator.CreateAnimation("70-65", 6,7,1);
		mAnimator.CreateAnimation("65-60", 7,8,1);
		mAnimator.CreateAnimation("60-55", 8,9,1);
		mAnimator.CreateAnimation("55-50", 9,10,1);
		mAnimator.CreateAnimation("50-45", 10,11,1);
		mAnimator.CreateAnimation("45-40", 11,12,1);
		mAnimator.CreateAnimation("40-35", 12,13,1);
		mAnimator.CreateAnimation("35-30", 13,14,1);
		mAnimator.CreateAnimation("30-25", 14,15,1);
		mAnimator.CreateAnimation("25-20", 15,16,1);
		mAnimator.CreateAnimation("20-15", 16,17,1);
		mAnimator.CreateAnimation("15-10", 17,18,1);
		mAnimator.CreateAnimation("10-5", 18,19,1);
		mAnimator.CreateAnimation("5-0", 19,20,1);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		
		//mAnimator.PlayAnimation("100", true);
		if (timer <= TIMER_INC){
			mAnimator.PlayAnimation("100", true);	
		}	
		else if (timer >= TIMER_INC && timer < TIMER_INC*2){
			mAnimator.PlayAnimation("100-95",true);
		}
		else if (timer >= TIMER_INC*2 && timer < TIMER_INC*3){
			mAnimator.PlayAnimation("95-90",true);	
		}
		else if (timer >= TIMER_INC*3 && timer < TIMER_INC*4){
			mAnimator.PlayAnimation("90-85",true);
		}
		else if (timer >= TIMER_INC*4 && timer < TIMER_INC*5){
			mAnimator.PlayAnimation("85-80",true);
		}
		else if (timer >= TIMER_INC*5 && timer < TIMER_INC*6){
			mAnimator.PlayAnimation("80-75",true);
		}
		else if (timer >= TIMER_INC*6 && timer < TIMER_INC*7){
			mAnimator.PlayAnimation("75-70",true);
		}
		else if (timer >= TIMER_INC*7 && timer < TIMER_INC*8){
			mAnimator.PlayAnimation("70-65",true);
		}
		else if (timer >= TIMER_INC*8 && timer < TIMER_INC*9){
			mAnimator.PlayAnimation("65-60",true);
		}
		else if (timer >= TIMER_INC*9 && timer < TIMER_INC*10){
			mAnimator.PlayAnimation("60-55",true);
		}
		else if (timer >= TIMER_INC*10 && timer < TIMER_INC*11){
			mAnimator.PlayAnimation("55-50",true);
		}
		else if (timer >= TIMER_INC*11 && timer < TIMER_INC*12){
			mAnimator.PlayAnimation("50-45",true);
		}
		else if (timer >= TIMER_INC*12 && timer < TIMER_INC*13){
			mAnimator.PlayAnimation("45-40",true);
		}
		else if (timer >= TIMER_INC*13 && timer < TIMER_INC*14){
			mAnimator.PlayAnimation("40-35",true);
		}
		else if (timer >= TIMER_INC*14 && timer < TIMER_INC*15){
			mAnimator.PlayAnimation("35-30",true);
		}
		else if (timer >= TIMER_INC*15 && timer < TIMER_INC*16){
			mAnimator.PlayAnimation("30-25",true);
		}
		else if (timer >= TIMER_INC*16 && timer < TIMER_INC*17){
			mAnimator.PlayAnimation("25-20",true);
		}
		else if (timer >= TIMER_INC*17 && timer < TIMER_INC*18){
			mAnimator.PlayAnimation("20-15",true);
		}
		else if (timer >= TIMER_INC*18 && timer < TIMER_INC*19){
			mAnimator.PlayAnimation("15-10",true);
		}
		else if (timer >= TIMER_INC*19 && timer < TIMER_INC*20){
			mAnimator.PlayAnimation("10-5",true);
		}
		else if (timer >= TIMER_INC*20 && timer < TIMER_INC*21){
			mAnimator.PlayAnimation("5-0",true);
		}
		else if (timer >=TIMER_INC*21){
			mAnimator.PlayAnimation ("0", true);
			eventMan.PostEvent(new CustomEvent("Time Up"));
		}
		
		
	
	}
}
