using UnityEngine;

namespace ZigZagGame
{
    public class AnimationPlatform : Platform
    {
        [SerializeField] private Animation animationVisualPlatform;
        [SerializeField] private AnimationClip ClipOutIn;
        private Vector3 newPositon;
        private int sizePlatform;

        public override void SetPosition(Vector3 position, bool isStartPosition, int size)
        {
            newPositon = position;
            sizePlatform = size;
            if (isStartPosition == true)
            {
                GoToNewPosition();
            }
            else
            {
                animationVisualPlatform.Play("PlatformAnimation", PlayMode.StopAll);
            }
        }

        public void GoToNewPosition()
        {
            if (GetScale().z != sizePlatform) SetScale(new Vector3(sizePlatform, 1, sizePlatform));
            _transform.position = this.newPositon;
        }


    }
}
