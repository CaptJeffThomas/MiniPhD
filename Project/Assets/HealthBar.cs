using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	
	Material mMaterial;
	
	CustomAnimator mAnimator;
	
	// Use this for initialization
	void Start () {
		
		mMaterial = renderer.material;
		
		mAnimator = new CustomAnimator(ref mMaterial, 5,5);
		
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
		mAnimator.PlayAnimation("100-95",true);
		mAnimator.PlayAnimation("95-90",true);
		mAnimator.PlayAnimation("90-85",true);
		mAnimator.PlayAnimation("85-80",true);
		mAnimator.PlayAnimation("80-75",true);
		mAnimator.PlayAnimation("75-70",true);
		mAnimator.PlayAnimation("70-65",true);
		mAnimator.PlayAnimation("65-60",true);
		mAnimator.PlayAnimation("60-55",true);
		mAnimator.PlayAnimation("55-50",true);
		mAnimator.PlayAnimation("50-45",true);
		mAnimator.PlayAnimation("45-40",true);
		mAnimator.PlayAnimation("40-35",true);
		mAnimator.PlayAnimation("35-30",true);
		mAnimator.PlayAnimation("30-25",true);
		mAnimator.PlayAnimation("25-20",true);
		mAnimator.PlayAnimation("20-15",true);
		mAnimator.PlayAnimation("15-10",true);
		mAnimator.PlayAnimation("10-5",true);
		mAnimator.PlayAnimation("5-0",true);
		
		
		
	
	}
}
