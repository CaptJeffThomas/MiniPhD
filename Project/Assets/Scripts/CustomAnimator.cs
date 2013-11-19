using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomAnimator {
	
	private Material mMaterial;
	
	//private int mFrameSize;
	private int mNumCols; //number of frames horizontally in the texture
	private int mNumRows; //number of frames vertically in the texture
	
	private Dictionary<string, AnimationSet> mAniSets; //map containing all the animation sets so they can be referred to by name
	
	public CustomAnimator (ref Material mat, int numCols, int numRows) {
		
		mMaterial = mat;
		
		//mFrameSize = frameSize;
		mNumCols = numCols;
		mNumRows = numRows;
		
		mAniSets = new Dictionary<string, AnimationSet>();
	
	}
	
	// Update is called once per frame
	public void Update (double deltaTime) {
		
		foreach(KeyValuePair<string, AnimationSet> entry in mAniSets)
		{
			entry.Value.Update(deltaTime);
		}

	}
	
	public void CreateAnimation(string name, int firstFrame, int lastFrame, double animationSpeed)
	{
		
		AnimationSet ani = new AnimationSet(ref mMaterial, firstFrame, lastFrame, mNumCols, mNumRows, animationSpeed);
		
		mAniSets[name] = ani;
	}
	
	public int PlayAnimation(string name, bool looping)
	{
		
		if(!mAniSets.ContainsKey(name)) return 0; //no such animation
		
		
		if(mAniSets[name].IsRunning()) return 1; //animation already running
		
		//first stop all other animations
		foreach(KeyValuePair<string, AnimationSet> entry in mAniSets)
		{
			entry.Value.Stop();
		}
		
		mAniSets[name].Start(looping);
		
		return 3; //animation started succesfully
		
	}
	
	public int RestartAnimation(string name, bool looping)
	{
		if(!mAniSets.ContainsKey(name)) return 0; //no such animation
		
		mAniSets[name].Start(looping);
		
		return 1;
	}
	
	public int ResetAnimation(string name)
	{
		if(!mAniSets.ContainsKey(name)) return 0; //no such animation
		
		mAniSets[name].Reset();
		
		return 1;
	}
	
	public bool PauseAnimation(string name, double pauseInterval)
	{
		if(!mAniSets.ContainsKey(name)) return false; //no such animation
		
		mAniSets[name].Pause(pauseInterval);
		return true;
	}
	
	public bool StopAnimation(string name)
	{
		if(!mAniSets.ContainsKey(name)) return false;
		
		mAniSets[name].Stop();
		return true;
	}
	
	public void StopAll()
	{
		foreach(KeyValuePair<string, AnimationSet> entry in mAniSets)
		{
			entry.Value.Stop();
		}
	}
	
	public bool IsRunning(string name)
	{
		if(!mAniSets.ContainsKey(name)) return false;
		
		return mAniSets[name].IsRunning();
	}
	
}

public class AnimationSet {
	
	private int mCurrentFrame;
	private int mFirstFrame; //first frame in this animation
	private int mLastFrame; //last frame in this animation
	private int mNumCols;
	private int mNumRows;
	
	private float mXOffset; //size of each frame (1/numFrames)
	private float mYOffset; 
	
	private bool mLooping; //if true the animation will loop indefinitely
	private bool mStopped;
	private bool mPaused; //allows pausing the animation for a set time, then having it automatically resume
	
	private double mAnimationSpeed; //speed in seconds of each frame of the animation
	private double mCounter; //counts time elapsed since the last 
	private double mPauseInterval; //how long to sleep for when paused
	
	Material mMaterial;
	
	public AnimationSet(ref Material mat, int firstFrame, int lastFrame, int numCols, int numRows, double animationSpeed)
	{
		mMaterial = mat;
		mCurrentFrame = firstFrame;
		mFirstFrame = firstFrame;
		mLastFrame = lastFrame;
		mNumCols = numCols;
		mNumRows = numRows;
		mLooping = false;
		mStopped = true;
		mPaused = false;
		mAnimationSpeed = animationSpeed;
		mCounter = 0.0;
		mPauseInterval = 0.0;
		
		mXOffset = 1.0f / (float)mNumCols;
		mYOffset = 1.0f / (float)mNumRows;
		
	}
	
	public void Update(double deltaTime)
	{
		if(mStopped) return;
		if(mPaused)
		{
			if(mPauseInterval > 0) mPauseInterval -= deltaTime;
			else
			{
				deltaTime = -mPauseInterval; //set delta time so as not to lose time
				mPaused = false;
				mPauseInterval = 0;
			}
		}
		
		mCounter += deltaTime;
		
		if(mCounter > mAnimationSpeed)
		{
			mCounter -= mAnimationSpeed;
			NextFrame ();
		}
	}
	
	/*Starts the animation and specifies whether it should loop or not*/
	public void Start(bool looping)
	{
		mStopped = false;
		mCurrentFrame = mFirstFrame;
		mLooping = looping;
		SetFrame(mCurrentFrame);
	}
	
	/*Pauses the animation for the given amount of time, after which it will resume automatically*/
	public void Pause(double pauseInterval)
	{
		mPaused = true;
		mPauseInterval = pauseInterval;
	}
	
	public void Stop()
	{
		mStopped = true;
	}
	
	public void Reset()
	{
		mStopped = true;
		mCurrentFrame = mFirstFrame;
		SetFrame(mCurrentFrame);
	}
	
	public bool IsRunning() { return !mStopped; }
	
	private void NextFrame()
	{
		
		mCurrentFrame++;
		if(mCurrentFrame > mLastFrame)
		{
			if(mLooping)
				mCurrentFrame = mFirstFrame;
			else
			{
				this.Stop();
				this.Reset();
			}
		}
		
		SetFrame(mCurrentFrame);
		
	}
	
	private void SetFrame(int frameNumber)
	{
		float xPos = (frameNumber % mNumCols) * mXOffset;
		float yPos = (frameNumber / mNumCols) * mYOffset;
		
		Vector2 offset = new Vector2 (xPos, (float)(1.0 - mYOffset - yPos));
		mMaterial.SetTextureOffset("_MainTex", offset);
		
		mCurrentFrame = frameNumber;
	}
	
}