﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TelCo.ColorCoder
{
    internal class DriverMethods
    {
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = ColorMaps.colorMapMinor.Length;
            int majorSize = ColorMaps.colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            // Construct the return val from the arrays
            ColorPair pair = new ColorPair()
            {
                majorColor = ColorMaps.colorMapMajor[majorIndex],
                minorColor = ColorMaps.colorMapMinor[minorIndex]
            };

            // return the value
            return pair;
        }
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        public static int GetPairNumberFromColor(ColorPair pair)
        {
            // Find the major color in the array and get the index
            int majorIndex = -1;
            for (int i = 0; i < ColorMaps.colorMapMajor.Length; i++)
            {
                if (ColorMaps.colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }

            // Find the minor color in the array and get the index
            int minorIndex = -1;
            for (int i = 0; i < ColorMaps.colorMapMinor.Length; i++)
            {
                if (ColorMaps.colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            // Compute pair number and Return  
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * ColorMaps.colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}
