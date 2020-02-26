using System.Collections.Generic;
using UnityEngine;

namespace ZigZagGame
{
    public class Pool
    {
        public Pool(GameObject prefab)
        {
            this.prefabCristal = prefab;
            this.ActiveCristals = new List<GameObject>();
            this.DisableCristals = new List<GameObject>();
        }
        private GameObject prefabCristal;
        private List<GameObject> ActiveCristals;
        private List<GameObject> DisableCristals;

        public GameObject GetCristal()
        {
            GameObject cristal = null;

            if (DisableCristals.Count == 0)
            {
                cristal = InstCrystal();
            }
            else
            {
                cristal = DisableCristals[0];
                ActiveCristals.Add(cristal);
                DisableCristals.Remove(cristal);
                cristal.SetActive(true);
            }

            return cristal;
        }

        public void DisableCristal(GameObject crystal)
        {
            ActiveCristals.Remove(crystal);
            DisableCristals.Add(crystal);
            crystal.SetActive(false);
        }

        public void DisableCristal(Vector3 position)
        {
            for (int i = 0; i < ActiveCristals.Count - 1; i++)
            {
                if (ActiveCristals[i].transform.position == position)
                {
                    ActiveCristals[i].SetActive(false);
                    DisableCristals.Add(ActiveCristals[i]);
                    ActiveCristals.Remove(ActiveCristals[i]);
                }
            }

        }

        public void DisableAllCristal()
        {
            if (ActiveCristals.Count == 0) return;
            foreach (GameObject item in ActiveCristals)
            {
                DisableCristals.Add(item);
                item.SetActive(false);
            }

            ActiveCristals.Clear();
        }

        private GameObject InstCrystal()
        {
            GameObject cristal = MonoBehaviour.Instantiate(prefabCristal);
            ActiveCristals.Add(cristal);
            return cristal;
        }

    }
}

