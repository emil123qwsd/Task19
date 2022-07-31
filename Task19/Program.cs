using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<VideoCard> videoCards = new List<VideoCard>()
            {
                new VideoCard(){Brand="HP",Type="Intel", Frequency=9, Ram=16, HDD=1000, VC=8, Price=3000 , Num=5},
                new VideoCard(){Brand="ACER",Type="AMD", Frequency=8, Ram=12, HDD=500, VC=6, Price=2500 , Num=30},
                new VideoCard(){Brand="Lenovo",Type="AMD", Frequency=7, Ram=8, HDD=256, VC=4, Price=2000 , Num=45},
                new VideoCard(){Brand="AZUZ",Type="AMD", Frequency=5, Ram=8, HDD=128, VC=2, Price=1500 , Num=50},
                new VideoCard(){Brand="Apple",Type="Intel", Frequency=9, Ram=8, HDD=500, VC=4, Price=4000 , Num=5},
                new VideoCard(){Brand="Honor",Type="Intel", Frequency=8, Ram=10, HDD=500, VC=3, Price=2700 , Num=20},

            };
            Console.WriteLine("Форма таблицы:");
            Console.WriteLine("1 ст. Название марки компьютера");
            Console.WriteLine("2 ст. Тип процессора");
            Console.WriteLine("3 ст. Частота работы процессора");
            Console.WriteLine("4 ст. Объем оперативной памяти");
            Console.WriteLine("5 ст. Объем жесткого диска");
            Console.WriteLine("6 ст. Объем памяти видеокарты");
            Console.WriteLine("7 ст. Стоимость компьютера в условных единицах");
            Console.WriteLine("8 ст. Количество экземпляров, имеющихся в наличии");
            Console.WriteLine();
            //все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.WriteLine("Введите название процессора (Intel, AMD)");
            string type = Console.ReadLine();
            if (type == "AMD" || type == "Intel")
            {
                List<VideoCard> videoCards1 = videoCards.Where(x => x.Type == type).ToList();
                Print(videoCards1);
            }
            else
                Console.WriteLine("Некорректные данные");
            Console.WriteLine();

            //все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
            Console.WriteLine("Введите частоту в Ггц");
            int frequency = Convert.ToInt32(Console.ReadLine());
            if (frequency > 5 && frequency < 9)
            {
                List<VideoCard> videoCards2 = videoCards.Where(x => x.Frequency >= frequency).ToList();
                Print(videoCards2);
            }
            else
                Console.WriteLine("Некорректные данные");
            Console.WriteLine();

            //вывести весь список, отсортированный по увеличению стоимости;
            Console.WriteLine("Сортировка по увеличению стоимости:");
            List<VideoCard> videoCards3 = videoCards.OrderBy(x => x.Price).ToList();
            Print(videoCards3);

            //Вывести весь список, сгруппированный по типу процессора;
            Console.WriteLine("Сортировка по типу процессора");
            IEnumerable<IGrouping<string, VideoCard>> videoCards4 = videoCards.GroupBy(x => x.Type);
            foreach (IGrouping<string, VideoCard> gr in videoCards4)
            {
                Console.WriteLine(gr.Key);
                foreach (VideoCard e in gr)
                {
                    Console.WriteLine($"{e.Brand} {e.Type} {e.Frequency} {e.Ram} { e.HDD} { e.VC} {e.Price} {e.Num}");
                }
            }
            Console.WriteLine();
            //найти самый дорогой компьютер;
            Console.WriteLine("Самый дорогой компьютер:");
            VideoCard VideoCard5 = videoCards.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{VideoCard5.Brand} { VideoCard5.Type} { VideoCard5.Frequency} { VideoCard5.Ram} { VideoCard5.HDD} { VideoCard5.VC} { VideoCard5.Price} { VideoCard5.Num}");
            Console.WriteLine();
            //найти самый бюджетный компьютер;
            Console.WriteLine("Самый бюджетный компьютер:");
            VideoCard VideoCard6 = videoCards.OrderByDescending(x => x.Price).LastOrDefault();
            Console.WriteLine($"{VideoCard6.Brand} { VideoCard6.Type} { VideoCard6.Frequency} { VideoCard6.Ram} { VideoCard6.HDD} { VideoCard6.VC} { VideoCard6.Price} { VideoCard6.Num}");
            Console.WriteLine();
            Console.WriteLine("Введите количество штук: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Есть ли хотя бы один компьютер в количестве не менее {0} штук? ", n);
            Console.WriteLine(videoCards.Any(x => x.Num > n));
            Console.ReadKey();
        }
        static void Print(List<VideoCard> VideoCards)
        {
            foreach (VideoCard e in VideoCards)
            {
                Console.WriteLine($"{e.Brand} { e.Type} {e.Frequency} {e.Ram} {e.HDD} { e.VC} {e.Price} {e.Num}");
            }
            Console.WriteLine();
        }
}   }
   

