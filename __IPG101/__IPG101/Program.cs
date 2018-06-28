using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __IPG101
{
    class Program
    {
        // البرنامج الجزئي الذي يجلب أصغر عدد في الجدول
        public static int getMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }
        
        // البرنامج الجزئي الذي يجلب أكبر عدد في الجدول
        public static int getMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;
        }
        /*
         * v يبحث عن قيمة 
         * fe ابتدائاً من العنصر ذو الدليل
         */
        public static int indexOf (int[] a, int v, int fe)
        {
            for (int i = fe; i < a.Length; i++)
            {
                if (a[i] == v)
                    return i;
            }
            return -1;
        }


        static void Main(string[] args)
        {
            // إدخال العدد الكلي للمرشحين
            Console.Write("Number of Candidates: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("_________________________________________________");
            // جدول المرشحين
            string[] candidates = new string[n];
            // جدول الأصوات
            int[] Voices = new int[n];

            // إدخال أسماء المرشحين
            for (int i = 0; i < n; i++)
            {
                Console.Write("Name of Candidate " + (i + 1) + " : ");
                candidates[i] = Console.ReadLine();
            }
            Console.WriteLine("_________________________________________________");
            // إدخال اصوات المرشحين كأعداد صحيحة موجبة, ينتهي بأدخال العدد 0
            int sumVoices = 0;
            do
            {
                Console.Write("Voice for : ");
                int voice = Convert.ToInt32(Console.ReadLine());
                if (voice == 0)
                    break;

                if (n >= voice && voice > 0)
                {
                    Voices[voice - 1] += 1;
                    // جمع عدد الاصوات الكلي في هذا المتحول
                    // ويتم الأستفادة من قيمتة في حساب النسبة المئوية
                    sumVoices += 1;
                }
                else
                {
                    // خطأ أدخال رقم مرشح غير موجود 
                    // يطلب البرنامج من المستخدم أعادة اخال قيمة صحيحه
                    Console.Write("Wrong input !");
                }

            } while (true);
            // اسماء المرشحين
            // عدد الاصوات التي حصل عليها كل مرشح
            // النسبة المئوية التي حصل عليها كل مرشح
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("{0, 15} {1, 15} {2, 15}", "NAMES", "VOICES", "PERCENTAGES");
            Console.WriteLine("_________________________________________________");
            for (int i = 0; i < candidates.Length; i++)
            {
                //  قانون حساب النسبة المئوية
                // عدد اصوات المرشح الحالي مقسوم على عدد الاصوات الكلي وهذا المقدار مضروب ب 100
                double percentage = 100 * Voices[i] / sumVoices;
                Console.WriteLine("{0, 15} {1, 15} {2, 15}%", candidates[i], Voices[i], percentage);
            }
            Console.WriteLine("_________________________________________________");            
            // أصغر عدد من الاصوات
            Console.WriteLine("minimum votes = " + getMin(Voices));
            Console.WriteLine("_________________________________________________");
            // أكبر عدد من الاصوات
            Console.WriteLine("maximum votes = " + getMax(Voices));
            Console.WriteLine("_________________________________________________");

            // اسماء المرشح أو المرشحين الفائزين أي: الحاصلين على اعلى نسبة تصويت
            int f = indexOf(Voices, getMax(Voices), 0);
            if (f != -1)
            {
                Console.WriteLine("First Candidates are : " + candidates[f]);
                for (int i = f; i < Voices.Length; i++)
                {
                    ++f;
                    f = indexOf(Voices, getMax(Voices), f);
                    if (f != -1)
                        Console.WriteLine("First Candidates are : " + candidates[f]);
                    else
                        break;

                }
            }
            Console.WriteLine("_________________________________________________");


            Console.ReadKey();
        }
    }
}
