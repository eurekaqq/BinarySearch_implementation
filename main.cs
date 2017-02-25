using IComparable = System.IComparable;
using Console = System.Console;
using GC = System.GC;

namespace BinarySearch {
    class main {
        private static void swap<T>(ref T item1, ref T item2) {
            var temp = item1;
            item1 = item2;
            item2 = temp;
            GC.Collect();
        }

        private static void quickSort<T>(T[] target, int left, int right) where T : IComparable {
            if (left < right) {
                var pivot = target[(left + right) / 2];
                int i = left - 1;
                int j = right + 1;

                while (i < j) {
                    do ++i; while (target[i].CompareTo(pivot) < 0);//pivot < target[i]
                    do --j; while (target[j].CompareTo(pivot) > 0);//pivot > target[j]
                    if (i < j) swap(ref target[i], ref target[j]);

                }

                quickSort(target, left, i - 1);
                quickSort(target, j + 1, right);
            }
        }

        private static int binarySearch<T>(T[] array,T target) where T : IComparable {
            int left = 0;
            int right = array.Length - 1;
            
            while (left<=right) {
                int middle = (left + right) / 2;

                if (target.Equals(array[middle]))
                    return middle;
                else if (target.CompareTo(array[middle]) > 0)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1;
        }

        static void Main(string[] args) {
            int[] a = { 1, 5, 4, 9, 7, 2, 4, 6 };
            quickSort<int>(a, 0, a.Length - 1);
            foreach (int i in a)
                Console.Write(i+" ");
            Console.WriteLine("\n3 is in index:" + binarySearch<int>(a, 3));
            Console.WriteLine("2 is in index:" + binarySearch<int>(a, 2));
            Console.WriteLine("9 is in index:" + binarySearch<int>(a, 9));
            Console.ReadKey();
        }
    }
}
