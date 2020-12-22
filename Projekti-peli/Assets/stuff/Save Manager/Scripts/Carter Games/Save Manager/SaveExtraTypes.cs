using UnityEngine;
using System;

/************************************************************************************
 * 
 *							           Save Manager
 *							  
 *				             Save Manager Alt Data Types Script
 *	     Stores a collection of additional save types that can't be saved by default.
 *			
 *			                        Script written by: 
 *			           Jonathan Carter (https://jonathan.carter.games)
 *			        
 *									Version: 1.0.2
 *						   Last Updated: 05/10/2020 (d/m/y)					
 * 
*************************************************************************************/

namespace CarterGames.Assets.SaveManager
{
    /// <summary>
    /// Holds the values required to save a Vector2
    /// </summary>
    [Serializable]
    public class SaveVector2
    {
        public float _x;
        public float _y;

        /// <summary>
        /// Get & Set the Vector 2 that is saved
        /// </summary>
        public Vector2 Vector2
        {
            get
            {
                return new Vector2(_x, _y);
            }
            set
            {
                _x = value.x;
                _y = value.y;
            }
        }
    }

    /// <summary>
    /// Holds the values required to save a Vector3
    /// </summary>
    [Serializable]
    public class SaveVector3
    {
        public float _x;
        public float _y;
        public float _z;

        /// <summary>
        /// Get & Set the Vector 3 that is saved
        /// </summary>
        public Vector3 Vector3
        {
            get
            {
                return new Vector3(_x, _y, _z);
            }
            set
            {
                _x = value.x;
                _y = value.y;
                _z = value.z;
            }
        }
    }

    /// <summary>
    /// Holds the values required to save a Vector4
    /// </summary>
    [Serializable]
    public class SaveVector4
    {
        public float _x;
        public float _y;
        public float _z;
        public float _w;

        /// <summary>
        /// Get & Set the Vector 4 that is saved
        /// </summary>
        public Vector4 Vector4
        {
            get
            {
                return new Vector4(_x, _y, _z, _w);
            }
            set
            {
                _x = value.x;
                _y = value.y;
                _z = value.z;
                _w = value.w;
            }
        }
    }

    /// <summary>
    /// Holds the values required to save a Color
    /// </summary>
    [Serializable]
    public class SaveColor
    {
        public float _r;
        public float _g;
        public float _b;
        public float _a;

        /// <summary>
        /// Get & Set the Color that is saved
        /// </summary>
        public Color Color
        {
            get
            {
                return new Color(_r, _g, _b, _a);
            }
            set
            {
                _r = value.r;
                _g = value.g;
                _b = value.b;
                _a = value.a;
            }
        }
    }
}