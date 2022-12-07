using System;
using System.Collections.Generic;

namespace App.Tools
{
	public static class SizeToolConverter
	{
        private static readonly Dictionary<string, int> Sizes = new Dictionary<string, int> {
            { "XS", 1 },
            { "S", 2 },
            { "M", 3 },
            { "L", 4 },
            { "XL", 5 },
            { "XXL", 6 },
            { "O/S", 7 },
        };

        public static int ConvertSizeToId(string size)
        {
            return Sizes[size];
        }  

        public static List<string> GetSizes()
        {
            return Sizes.Keys.ToList();
        }
    }
}