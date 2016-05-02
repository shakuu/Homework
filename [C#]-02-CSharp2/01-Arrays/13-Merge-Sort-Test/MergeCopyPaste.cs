using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSort
{
    class Program
    {

        static public void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        struct MergePosInfo
        {
            public int left;
            public int mid;
            public int right;
        };

        static public void MergeSort_Iterative(int[] numbers, int left, int right)
        {
            int mid;
            if (right <= left)
                return;

            List<MergePosInfo> list1 = new List<MergePosInfo>();
            List<MergePosInfo> list2 = new List<MergePosInfo>();

            MergePosInfo info;
            info.left = left;
            info.right = right;
            info.mid = -1;

            list1.Insert(list1.Count, info);

            while (true)
            {
                if (list1.Count == 0)
                    break;

                left = list1[0].left;
                right = list1[0].right;
                list1.RemoveAt(0);
                mid = (right + left) / 2;

                if (left < right)
                {
                    MergePosInfo info2;
                    info2.left = left;
                    info2.right = right;
                    info2.mid = mid + 1;
                    list2.Insert(list2.Count, info2);

                    info.left = left;
                    info.right = mid;
                    list1.Insert(list1.Count, info);

                    info.left = mid + 1;
                    info.right = right;
                    list1.Insert(list1.Count, info);
                }
            }


            for (int i = 0; i < list2.Count; i++)
            {
                DoMerge(numbers, list2[i].left, list2[2].mid, list2[2].right);
            }

        }



        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;

            Console.WriteLine("MergeSort By Iterative Method");
            MergeSort_Iterative(numbers, 0, len - 1);
            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);

        }
    }
}