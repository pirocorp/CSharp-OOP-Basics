﻿using System;
using System.Linq;

struct BitArray32
{
    public const int BitsCount = 32;

    private uint bitValues;

    // Indexer declaration
    public int this[int index]
    {
        get
        {
            if (0 <= index && index < BitsCount)
            {
                // Check the bit at position index
                if ((this.bitValues & (1 << index)) == 0)
                {
                    return 0;
                }

                return 1;
            }

            throw new IndexOutOfRangeException(string.Format(
                "Index {0} is invalid!",
                index));
        }

        set
        {
            if (index < 0 || index > BitsCount - 1)
            {
                throw new IndexOutOfRangeException(string.Format(
                    "Index {0} is invalid!",
                    index));
            }

            if (value < 0 || value > 1)
            {
                throw new ArgumentException(string.Format(
                    "Value {0} is invalid!",
                    value));
            }

            // Clear the bit at position index
            this.bitValues &= ~((uint)(1 << index));

            // Set the bit at position index to value
            this.bitValues |= (uint)(value << index);
        }
    }

    private int[] ReturnNumAsArrayOfBit()
    {
        var result = new int[BitsCount];

        for (var i = 0; i < BitsCount; i++)
        {
            result[i] = this[i];
        }

        return result;
    }

    public override string ToString()
    {
        return $"[{string.Join("", this.ReturnNumAsArrayOfBit().Reverse().ToArray())}]";
    }
}