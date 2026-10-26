using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CTDLGT_Btapbuoi3
{
    internal class Queue
    {
        static void Main()
        {
            Console.Write("Nhap n va k (cach nhau boi khoang trang): ");
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2) return;
            int n = int.Parse(tokens[0]);
            int k = int.Parse(tokens[1]);
            SolveJosephus(n, k);
        }
        static void SolveJosephus(int n, int k)
        {
            Queue<int> queue = new Queue<int>();
            // Nạp n người vào hàng đợi
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }
            List<int> eliminated = new List<int>();
            // Quá trình loại người
            while (queue.Count > 1)
            {
                // Bỏ qua (k - 1) người đầu tiên
                for (int i = 1; i < k; i++)
                {
                    int skip = queue.Dequeue();
                    queue.Enqueue(skip);
                }
                // Loại người thứ k
                eliminated.Add(queue.Dequeue());
            }
            // In kết quả trực tiếp bên trong hàm
            Console.WriteLine("Thu tu nhung nguoi bi loai: " + string.Join(" ", eliminated));
            Console.WriteLine("Nguoi cuoi cung con lai: " + queue.Dequeue());
        }
    }
}
