using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagGame
{

    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] private EventsManager eventsManager;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private GameObject prefabPlatform;
        [SerializeField] private GameObject prefabCrystal;
        [SerializeField] private OrderCrystal orderCrystal;
        [SerializeField] [Range(1, 3)] private int sizePlatform = 3;
        [SerializeField] private int maxPlatforms;
        [SerializeField] private List<Platform> listPlatforms = new List<Platform>();
        private bool isPlay = false;
        private Vector3 nextPositionPlatform;
        private int countPlatformsUse = 0;
        private Pool RedCrystalPool;

        private int randomPositionCrystal = 0;


        enum OrderCrystal
        {
            consistently,
            random
        }
        void Start()
        {
            RedCrystalPool = new Pool(prefabCrystal);
        }

        private void OnEnable()
        {
            EventsManager.Mode += this.UseGameMode;
            EventsManager.DisableCrystal += this.DisableCrystal;
        }

        private void OnDisable()
        {
            EventsManager.Mode -= this.UseGameMode;
            EventsManager.DisableCrystal -= this.DisableCrystal;
        }

        private void Update()
        {
            if (isPlay == true)
            {
                UpdatePlatforms();
            }
        }

        private void UseGameMode(GameManager.GameMode mode)
        {
            switch (mode)
            {
                case GameManager.GameMode.Start:
                    ResetPlatforms();
                    MadeStartWay();
                    break;

                case GameManager.GameMode.Game:
                    isPlay = true;
                    break;

                case GameManager.GameMode.Fail:
                    isPlay = false;
                    break;

            }
        }

        private void UpdatePlatforms()
        {
            int numPlatform = (countPlatformsUse + 1) % listPlatforms.Count;

            if (Vector3.Distance(listPlatforms[numPlatform].GetPosition(), cameraTransform.position) > 3)
            {
                AddCrystal(nextPositionPlatform, countPlatformsUse, RedCrystalPool, orderCrystal);
                MovePlatform(listPlatforms[numPlatform], false);
                countPlatformsUse++;
            }
        }
        private void MadeStartWay()
        {
            if (listPlatforms.Count == 0)
            {
                GeneratePlatforms();
            }

            nextPositionPlatform = new Vector3(0, 0, (3 + sizePlatform) * 0.5f);

            listPlatforms[0].SetPosition(Vector3.zero, true, 3);

            for (int i = 1; i < listPlatforms.Count; i++)
            {
                MovePlatform(listPlatforms[i], true);
                AddCrystal(listPlatforms[i].GetPosition(), countPlatformsUse, RedCrystalPool, orderCrystal);
                countPlatformsUse++;
            }
        }

        private void GeneratePlatforms()
        {
            for (int i = 0; i < maxPlatforms; i++)
            {
                Platform platform = Instantiate(prefabPlatform).GetComponent<Platform>();
                platform.SetScale(new Vector3(sizePlatform, 1, sizePlatform));
                listPlatforms.Add(platform);
            }
        }

        private void MovePlatform(Platform platform, bool isStartPosition)
        {

            RedCrystalPool.DisableCristal(platform.GetPosition());

            platform.SetPosition(nextPositionPlatform, isStartPosition, sizePlatform);


            if (Random.Range(0, 100) > 50)
            {
                nextPositionPlatform.x += sizePlatform;
            }
            else
            {
                nextPositionPlatform.z += sizePlatform;
            }
        }

        private void AddCrystal(Vector3 position, int countPlatforms, Pool poolCrystal, OrderCrystal order)
        {
            switch (order)
            {
                case OrderCrystal.consistently:

                    if ((countPlatforms / 5) % 5 == (countPlatforms % 5))
                    {
                        poolCrystal.GetCristal().transform.position = position;
                    }
                    break;

                case OrderCrystal.random:
                    int numSection = countPlatforms % 5;

                    if (numSection == 0)
                    {
                        randomPositionCrystal = Random.Range(0, 5);
                    }
                    if (numSection == randomPositionCrystal)
                    {
                        poolCrystal.GetCristal().transform.position = position;
                    }
                    break;
            }
        }

        private void DisableCrystal(GameObject crystal)
        {
            RedCrystalPool.DisableCristal(crystal);
        }

        private void ResetPlatforms()
        {
            countPlatformsUse = 0;
            RedCrystalPool.DisableAllCristal();
        }
    }
}
