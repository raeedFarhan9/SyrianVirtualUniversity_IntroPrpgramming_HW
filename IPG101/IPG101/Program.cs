using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG101
{
    class Program
    {
        static void Main(string[] args)
        {
            // إدخال العدد الكلي للمرشحين
            Console.Write("Number of Candidates: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("_________________________________________________");
            // مصفوفة المرشحين
            string[] candidates = new string[n];
            // مصفوفة الأصوات
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
            int min = Voices[0];
            for (int i = 1; i < Voices.Length; i++)
            {
                if (Voices[i] < min)
                    min = Voices[i];
            }
            Console.WriteLine("minimum votes = " + min);
            Console.WriteLine("_________________________________________________");

            // أكبر عدد من الاصوات
            int max = Voices[0];
            for (int i = 1; i < Voices.Length; i++)
            {
                if (Voices[i] > max)
                    max = Voices[i];
            }
            Console.WriteLine("maximum votes = " + max);
            Console.WriteLine("_________________________________________________");

            // اسماء المرشح أو المرشحين الفائزين أي: الحاصلين على اعلى نسبة تصويت
            for (int i = 0; i < Voices.Length; i++)
            {
                if (Voices[i] == max)
                    Console.WriteLine("First Candidates are : " + candidates[i]);
            }
            Console.WriteLine("_________________________________________________");


            Console.ReadKey();
        }
    }
}
