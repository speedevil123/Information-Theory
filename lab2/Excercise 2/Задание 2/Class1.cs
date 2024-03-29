using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Задание_2
{
    internal class Class1
    {
        class ShowMatr
        {
            //Метод для создания визуальной пустоты при выводе матриц
            public static void GetSpace()
            {
                for(int i = 0; i < 10; i++)
                    Console.WriteLine();
            }

            //Метод для вывода матрицы на экран
            public static void ShowMatrix(double[,] matr)
            {
                string[] alphabet = {"а","б","в","г","д","е",
                "ж","з","и","й","к","л","м","н","о","п","р"
                ,"с","т","у","ф","х","ц","ч","ш","щ","ь","ы"
                ," ","э","ю","я"};
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    Console.Write("|");
                    if (i == 0)
                    {
                        Console.Write(" a/a\t|");
                        for (int h = 0; h < matr.GetLength(1); h++)
                        {
                            Console.Write(" " + alphabet[h] + "\t|");
                        }
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-------------------");
                        Console.Write("|");
                    }
                    Console.Write(" " + alphabet[i] + "\t|");



                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        Console.Write(Math.Round(matr[i, j], 4) + "\t|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-------------------");
                }
            }

            //Метод для вывода матрицы с суммами столбцов/строк
            public static void ShowMatrixBottomSum(double[,] matr)
            {
                string[] alphabet = {"а","б","в","г","д","е",
                "ж","з","и","й","к","л","м","н","о","п","р"
                ,"с","т","у","ф","х","ц","ч","ш","щ","ь","ы"
                ," ","э","ю","я"};
                double[] array = new double[32];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    double temp = 0;
                    Console.Write("|");
                    if (i == 0)
                    {
                        Console.Write(" a/a\t|");
                        for (int h = 0; h < matr.GetLength(1) + 1; h++)
                        {
                            if (h == 32)
                            {
                                Console.Write(" P(Y)" + "\t");
                            }
                            else
                                Console.Write(" " + alphabet[h] + "\t|");
                        }
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "--------------------------------------------------------------------------" +
                            "-------------------");
                        Console.Write("|");
                    }
                    Console.Write(" " + alphabet[i] + "\t|");



                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        temp += matr[i, j];
                        array[i] += matr[j, i];
                        Console.Write(Math.Round(matr[i, j], 4) + "\t|");
                        if (j == 31)
                        {
                            Console.Write(" " + Math.Round(temp, 4) + "\t");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------" +
                            "---------------------------------------------------------------------" +
                            "-----------------------------------------------------------------" +
                            "----------------------------------------------------------------------" +
                            "-------------------");
                }
                Console.Write("| P(X)" + "\t|");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(Math.Round(array[i], 4) + "\t|");
                }
                Console.WriteLine();
            }
        }

 
        static void Main()
        {
            double[,] bukva_meets = new double[32, 32];
            string text = "- Я слышал, что один дайвер... - я отвел глаза, - при этом бормочет глупую \r\nфразу." +
                "\r\n- Какую?\r\n- Глубина-глубина, я не твой.\r\n- И все?\r\n- Иногда он еще добавляет:" +
                " \"Отпусти меня, глубина\".\r\n- И все? - уныло спросил Маньяк.\r\n- Да.\r\n- Просто-то как...\r\n" +
                "Маньяк порылся в карманах, достал пачку \"Лаки Страйк\", закурил. С легкой обидой \r\nсказал:\r\n- " +
                "Раньше было просто. Есть хакеры, есть честные чайники, есть ламеры. Первые - \r\nумеют все. Вторые - учатся. " +
                "Третьи - дураки, над ними и поиздеваться не грех. \r\nВот ты... как был чайником, так им и остался!\r\n- Да, - " +
                "согласился я.\r\n- Но вот появилась глубина... казалось - все наши мечты сбываются.\r\nМаньяк горько засмеялся." +
                "\r\n- А на деле - фиг! Я, крутой хакер, - с вызовом заявил он, - в виртуальности \r\nодин из миллионов! Ну, посмышленее," +
                " наверное. Опыт есть какой-никакой! А все \r\nравно... порой такое бывает...\r\nОн замолчал, вертя в руках сосиску. Потом " +
                "сообщил:\r\n- Я на днях мышь съел.\r\n- Что?!\r\n- Мышь. Компьютерную. Ну, не саму мышь, она твердая... провод перекусил.\r\n-" +
                " Зачем? - тупо спросил я.\r\n- Случайно. Был в глубине. Сидели с ребятами в \"Радуге\", пиво пили с копченой \r\nрыбкой... " +
                "Ну, у меня рыбка кончилась, взял с тарелки у Макса...\r\n- Макс ведь пива не пьет!\r\n- А он \"Фиесту\" пил.\r\n- " +
                "С копченой рыбой?!\r\n- Чтобы не выделяться... - Маньяк вздохнул. - Ну, видно тянуться далеко было... \r\nвот и дернулся в реальности. " +
                "Когда вышел - смотрю, у мышки провод перекушен! И, \r\nвроде, немножко его не хватает...\r\n- Живот не болит?\r\n- Нет, пока ничего...\r\n" +
                "Мы наполнили бокалы.\r\n- Или вот, - продолжил Маньяк. - \"Лабиринт Смерти\" знаешь?\r\n- Да, - я мигом протрезвел.\r\n- " +
                "Недавно решил развеяться, заглянул сразу на семнадцатый уровень. Там сейчас \r\nтакого понаделали! Кошмар, а не игрушка... в общем, я завяз" +
                ".\r\n- То есть?\r\n- Не смог пройти на следующий уровень. А без этого меню выхода не появляется.\r\n- И что?\r\n- Сидел полтора суток, - зло" +
                " сказал Маньяк. - Нас там целая компания \r\nсобралась... идиотов. Раз по десять нас пристрелили, потом мы просто \r\nзабаррикадировались, сидели в одном" +
                " подвальчике, песни пели, от монстров \r\nотстреливались... пока у нас таймеры не сработали.\r\n- У тебя непрерывное пребывание в глубине - тридцать шесть " +
                "часов?\r\n- Теперь - двадцать четыре.\r\n- А что же Галька?\r\n- Да... она у тещи была... Ленька, а у тебя какое ограничение по времени?\r\n- " +
                "Я снял запрет, - признался я.\r\n- Понятно... дайвер... - Шурка принужденно засмеялся. - Черт! Никогда не верил в \r\nвас до конца, хоть и подозревал!\r\n- " +
                "Меня, что ли?\r\n- Конечно. Нафиг чайнику боевые вирусы и противоядия?\r\nМне немножко грустно. Что-то изменилось в наших отношениях. И слишком резко. \r\n" +
                "Может быть, со временем это пройдет...\r\n- Шурка, я все равно ни черта не умею - кроме как выходить из виртуальности. Для \r\nменя " +
                "любая программа - это куча бессмысленных символов и пусковой файлик.\r\nМаньяк кивнул.\r\n- Понимаю. Но скажи - ты бы поменялся со мной местами? " +
                "Что интереснее\r\n- творить глубину или повелевать ей?\r\nЯ молчу.\r\n- Наливай... - со вздохом сказал Маньяк. \r\n100\r\nУ Маньяка я просидел до " +
                "позднего вечера. \"Гиннес\" сменился \"Балтикой\" номер \r\nшесть, а на десерт Шурка откопал банку рождественского \"Кроненбурга\". Ни \r\nирландское, " +
                "ни питерское, ни французское пиво не подкачали.\r\nВ глубине души я был рад, что хоть кому-то открылся. Мои друзья-хакеры делятся \r\nна две группы - одна хранит " +
                "тайны до первой бутылки пива, вторая, после этой \r\nсамой бутылки, ее как бы забывает. Шурка - из второй.\r\nПо крайней мере теперь он будет знать, для чего мне" +
                " весь разнообразный вирусный \r\nсофт, который я правдами и неправдами выманиваю у него.\r\nНасколько проще было бы, не затягивай глубина так сильно, думал " +
                "я в такси по \r\nдороге к дому. Насколько правильнее и легче.\r\nНе было бы деления на счастливчиков и неудачников, которое ничем не сломать. Не \r\nбыло бы " +
                "этого безумия - великолепных программистов, неспособных перейти грань \r\nмежду иллюзией и явью, и неумех вроде меня, не замечающих этого барьера.\r\nНе было " +
                "бы зависти друг к другу - и вечной охоты.\r\nНо разве я виноват? Я и сам не знаю, почему так происходит, какая ошибка \r\nсознания, а ведь это именно ошибка - " +
                "мы в меньшинстве, - делает из человека \r\nдайвера. Не пользоваться своей способностью глупо. Предлагать ее для всеобщего \r\nизучения - страшно.\r\nТак уж " +
                "получилось. Кто-то прыгает на восемь метров в длину, кто-то пишет стихи, \r\nкто-то неподвластен виртуальности. Но почему нас так, так мало? Настолько, " +
                "что \r\nсчитать приходится не в процентах, а поголовно...\r\n- Здесь? - спросил водитель.\r\n- Да, спасибо.\r\nЯ расплатился, выбрался из машины, пошел к " +
                "подъезду, чувствуя себя раздутым, как \r\nвоздушный шарик. Сейчас надо либо завалиться спать, смирившись с утренней \r\nразбитостью, или нырять в глубину. " +
                "Она хорошо снимает похмелье.\r\nНа втором этаже подъезда, там у нас почему-то всегда горит лампочка, сидело \r\nчеловек пять подростков. Перекидывались " +
                "картишками прямо на полу, о чем-то \r\nвполголоса разговаривали... нет, скорее не разговаривали - перерыкивались. Двоих \r\nя знал, трое казались незнакомыми. " +
                "Маленькая стая мелких хищников. Такая с \r\nудовольствием загрызет одиночку в темной подворотне. Но здесь я в безопасности. \r\nВозле норы хищники не охотятся." +
                "\r\n- Здравствуйте, - буркнул парнишка, который живет надо мной. В точно такой же \r\nоднокомнатной, с родителями и старшей сестрой, частенько приходящей только " +
                "под \r\nутро. Слышимость у нас прекрасная, я в курсе всех их проблем и скандалов.\r\n";
            string[] alphabet = {"а","б","в","г","д","е",
                "ж","з","и","й","к","л","м","н","о","п","р"
                ,"с","т","у","ф","х","ц","ч","ш","щ","ь","ы"
                ," ","э","ю","я"};

            string[] copy_alphabet = new string[alphabet.Length];
            Array.Copy(alphabet, copy_alphabet, alphabet.Length);
            int cnt;

            //Перебираем все двухбуквенные сочетания для исходного текста
            for (int i = 0; i < alphabet.Count(); i++)
            {
                for (int j = 0; j < alphabet.Count(); j++)
                {
                    cnt = 0;
                    string line = alphabet[i] + copy_alphabet[j];
                    for(int h = 0; h < text.Length-1; h++)
                    {
                        if (line.ToLower() == (text[h].ToString() + text[h + 1].ToString()).ToLower() || line.ToUpper() == (text[h].ToString() + text[h + 1].ToString()).ToUpper())
                            cnt++;

                    }
                    bukva_meets[i, j] = cnt;
                }
            }

            //Выводим матрицу и задаем матрицу вероятностей P(i,j)
            ShowMatr.ShowMatrix(bukva_meets);
            double sum = bukva_meets.Cast<double>().Sum();
            double[,] matr_Pij = new double[alphabet.Length, alphabet.Length];

            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                for (int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    if (bukva_meets[i,j] == 0)
                        matr_Pij[i,j] = 0;
                    else
                        matr_Pij[i, j] = bukva_meets[i,j]/sum;
                }
            }
            ShowMatr.GetSpace();
            ShowMatr.ShowMatrix(matr_Pij);

            ShowMatr.GetSpace();

            //Находим P(xi) и P(Yj)
            double[] Pxi = new double[matr_Pij.GetLength(0)];
            double[] Pyj = new double[matr_Pij.GetLength(1)];
            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                double sum_row = 0;
                double sum_col = 0;
                for (int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    sum_row += matr_Pij[i, j];
                    sum_col += matr_Pij[j, i];
                }
                Pxi[i] = sum_col;
                Pyj[i] = sum_row;
            }

            for (int i = 0; i < alphabet.Count(); i++)
            {
                Console.WriteLine("P(Xi) = " + Math.Round(Pxi[i], 4) + " P(Yj) = " + Math.Round(Pyj[i], 4));
            }

            //Составляем канальные матрицы
            double[,] canal_matrPYjXi = new double[alphabet.Count(), alphabet.Count()];
            double[,] canal_matrPXiYj = new double[alphabet.Count(), alphabet.Count()];

            for (int i = 0; i < alphabet.Count(); i++)
            {
                for (int j = 0; j < alphabet.Count(); j++)
                {
                    if (Pxi[i] == 0)
                        canal_matrPYjXi[j, i] = 0;
                    else
                        canal_matrPYjXi[j, i] = matr_Pij[j, i] / Pxi[i];

                    if (Pyj[i] == 0)
                        canal_matrPXiYj[i, j] = 0;
                    else
                        canal_matrPXiYj[i, j] = matr_Pij[i, j] / Pyj[i];
                }
            }

            Console.WriteLine("\nКанальная матрица P(Yj/Xi): ");
            ShowMatr.ShowMatrixBottomSum(canal_matrPYjXi);

            Console.WriteLine("\nКанальная матрица P(Xi/Yj): ");
            ShowMatr.ShowMatrixBottomSum(canal_matrPXiYj);

            //Вычисляем энтропию строк кан. матрицы H_X_yj и энтропию столбцов кан. матрицы H_Y_xi
            double[] H_X_yj = new double[alphabet.Count()], H_Y_xi = new double[alphabet.Count()];

            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                for (int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    if (canal_matrPYjXi[j, i] == 0)
                        H_Y_xi[i] += 0;
                    else
                        H_Y_xi[i] += canal_matrPYjXi[j, i] * Log(canal_matrPYjXi[j, i], 2);
                    if (canal_matrPXiYj[i, j] == 0)
                        H_X_yj[i] += 0;
                    else
                        H_X_yj[i] += canal_matrPXiYj[i, j] * Log(canal_matrPXiYj[i, j], 2);
                }
                H_Y_xi[i] = -H_Y_xi[i];
                H_X_yj[i] = -H_X_yj[i];
            }


            for (int i = 0; i < alphabet.Count(); i++)
            {
                Console.WriteLine("H(Y/Xi) = " + Math.Round(H_Y_xi[i], 2) + " H(X/Yj) = " + Math.Round(H_X_yj[i], 2));
            }
            double H_Y_X = 0;
            double H_X_Y = 0;

            //Находим потери H(X/Y) и H(Y/X)
            for (int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                H_X_Y += Pyj[i] * H_X_yj[i];
                H_Y_X += Pxi[i] * H_Y_xi[i];
            }

            Console.WriteLine("H(X/Y) = " + H_X_Y + " H(Y/X) = " + H_Y_X);

            double H_X = 0, H_Y = 0;
            for(int i = 0; i < alphabet.Count(); i++)
            {
                if (Pxi[i] == 0)
                    H_X += 0;
                else
                    H_X += Pxi[i] * Log(Pxi[i],2);

                if (Pyj[i] == 0)
                    H_Y += 0; 
                else
                    H_Y += Pyj[i] * Log(Pyj[i], 2);
            }

            H_Y = -H_Y; 
            H_X = -H_X;
            Console.WriteLine("H(X) = " + H_X + " ,H(Y) = " + H_Y);

            //Выводим результаты
            double H_XX_YY = H_X + H_Y_X;

            double H_XX_YY_2 = 0;
            for(int i = 0; i < matr_Pij.GetLength(0); i++)
            {
                for(int j = 0; j < matr_Pij.GetLength(1); j++)
                {
                    if (matr_Pij[i, j] == 0)
                        H_XX_YY_2 += 0;
                    else
                        H_XX_YY_2 += matr_Pij[i,j] * Log(matr_Pij[i,j],2);
                }
            }
            H_XX_YY_2 = -H_XX_YY_2;
            Console.WriteLine("H(X) + H(Y/X) = H(X,Y) = " + H_XX_YY + "\n" +
                "En(i=1)Em(j=1*pij*log2(pij) = H(X,Y) = " + H_XX_YY_2 + "\n" +
                "H(X) + H(Y) = " + (H_X + H_Y));           
        }
    }

}
