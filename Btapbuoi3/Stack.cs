using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CTDLGT_Btapbuoi3
{
    internal class Stack
    {
        static void Main1()
        {
            Console.Write(" Nhap so phan tu mang a (n): ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Console.Write("Nhap cac phan tu cua mang (cach nhau boi khoang trang): ");
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(tokens[i]);
            }
            stack(a, n);
        }
        static void stack(int[] a, int n)
        {
            int[] result = new int[n];
            // Stack dùng để lưu 'chỉ số' của các ngày đang chờ tìm ngày nóng hơn
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                // So sánh nhiệt độ với ngày đang nằm trên đỉnh Stack 
                while (stack.Count > 0 && a[i] > a[stack.Peek()])
                {
                    // Lấy ngày chờ ra khỏi đỉnh Stack
                    int waitingdayIndex = stack.Pop();
                    // Khoảng cách chờ = Vị trí ngày hiện tại - Vị trí ngày chờ
                    result[waitingdayIndex] = i - waitingdayIndex;
                }
                // Đưa ngày hiện tại vào Stack 
                stack.Push(i);
            }
            // In kết quả
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
