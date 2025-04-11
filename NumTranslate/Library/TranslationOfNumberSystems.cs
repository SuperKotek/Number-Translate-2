namespace TtranslationOfNumberSystemsClassLibrary1
{
    public class TranslationOfNumberSystems
    {
        /// <summary>
        /// Для перевода числа из системы P в систему Q
        /// Выводиться число в системе Q
        /// </summary>
        /// <param name="N">Число
        /// должно быть задано действительным числом, от двоичной до 36 разрядной системы, типа string</param>
        /// <param name="p">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// <param name="q">Система исчисления Q
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// <param name="m">Количество знаков после запятой
        /// должно быть задано положительным числом типа int</param>
        /// returns>Число в степени Q</returns>
        public static string TranslateNumberFromToQ(string N, int p, int q, int m)
        {
            (string intPart, string fractionPart) = Split(N);   // Разделение цисла на целую и дробную часть
            string resInt = "";
            string resFraction = "";
            if (p > 10)
            {
                string IntPartConv = ConvertToDecimal(intPart, p).ToString();
                resInt = TranslateInt(IntPartConv, 10, q);  // Обработка целого значения числа система числа которого больше 10.
                if (fractionPart != "")
                {
                    string FractionPartConv = ConvertToDecimalFr(fractionPart, p);
                    resFraction = TranslateFraction(FractionPartConv, 10, q, m);
                } // Обработка дробного значения числа система числа которого больше 10.
                else
                { resFraction = ""; }
            }
            else
            {
                resInt = TranslateInt(intPart, p, q);        // Перевод целой части из системы P в  систему Q
                resFraction = TranslateFraction(fractionPart, p, q, m);  // Перевод дробной части из системы P в систему Q
            }
            return Join(resInt, resFraction);
        }

        /// <summary>
        /// Для раделения числа на целую и дробную часть
        /// </summary>
        /// <param name="number">Число
        /// должно быть задано действительным числом типа string</param>
        /// returns>Целая и дробная части в разных строках</returns>
        private static (string, string) Split(string number)
        {
            var parts = number.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);  // Разделение цисла на целую и дробную часть
            return (parts[0].Trim(), parts.Length > 1 ? parts[1].Trim() : string.Empty);
        }

        /// <summary>
        /// Для перевода целой части числа из системы P в систему Q
        /// Выводиться целая часть числа в системе Q
        /// </summary>
        /// <param name="intPart">Целая часть числа
        /// должно быть задано действительным числом, от двоичной до 36 разрядной системы, типа string</param>
        /// <param name="p">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// <param name="q">Система исчисления Q
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// returns>Целая часть числа в степени Q</returns>
        private static string TranslateInt(string intPart, int p, int q)
        {
            int decimalValue = 0;

            // Перевод из системы p в десятичную
            for (int i = 0; i < intPart.Length; i++)
            {
                decimalValue = decimalValue * p + GetDigitValue(intPart[i]);
            }

            // Перевод из десятичной в систему q
            return ConvertToBase(decimalValue, q);
        }

        /// <summary>
        /// Для перевода дробной части числа из системы P в систему Q
        /// Выводиться дробная часть числа в системе Q
        /// </summary>
        /// <param name="fractionPart">Дробная часть числа
        /// должно быть задано действительным числом, от двоичной до 36 разрядной системы, типа string</param>
        /// <param name="p">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// <param name="q">Система исчисления Q
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// <param name="m">Количество знаков после запятой
        /// должно быть задано положительным числом типа int</param>
        /// returns>Дробная часть числа в степени Q</returns>
        private static string TranslateFraction(string fractionPart, int p, int q, int m)
        {
            double decimalValue = 0;

            // Перевод дробной части из системы p в десятичную
            for (int i = 0; i < fractionPart.Length; i++)
            {
                decimalValue += GetDigitValue(fractionPart[i]) * Math.Pow(p, -(i + 1));
            }

            // Перевод из десятичной в систему q
            return ConvertFractionToBase(decimalValue, q, m);
        }

        /// <summary>
        /// Для соединения целой и дробной части числа
        /// Выводиться число
        /// </summary>
        /// <param name="intPart">Целая часть числа
        /// должно быть задано целым числом, от двоичной до 36 разрядной системы, типа string</param>
        /// <param name="fractionPart">Дробная часть числа
        /// должно быть задано действительным числом, от двоичной до 36 разрядной системы, типа string</param>
        /// returns>Число типа string</returns>
        private static string Join(string intPart, string fractionPart)
        {
            return fractionPart != "" ? $"{intPart},{fractionPart}" : intPart;
        }

        /// <summary>
        /// Для перевода целой части числа из десятичной системы в систему Q
        /// Выводиться целая часть числа в системе Q
        /// </summary>
        /// <param name="decimalValue">Целая часть числа
        /// должно быть задано целым числом в десятичной системе типа int</param>
        /// <param name="q">Система исчисления Q
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// returns>Целая часть числа в степени Q</returns>
        private static string ConvertToBase(int decimalValue, int q)
        {
            if (decimalValue == 0)
                return "0";   // Если в десятичной системе число равно 0 то возвращаем 0
            string result = "";  // Объявление переменной результата 

            // Перевод числа из десятичной системы в систему Q
            while (decimalValue > 0)
            {
                result = GetDigitChar(decimalValue % q) + result;   // Перевод части числа из десятичной системы в систему Q
                decimalValue /= q;   // Переход к следующей части числа
            }

            return result;
        }

        /// <summary>
        /// Для перевода дробной части числа из десятичной системы в систему Q
        /// Выводиться дробная часть числа в системе Q
        /// </summary>
        /// <param name="decimalValue">Дробная часть числа
        /// должно быть задано действительным числом в десятичной системе типа double</param>
        /// <param name="q">Система исчисления Q
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// <param name="m">Количество знаков после запятой
        /// должно быть задано положительным числом типа int</param>
        /// returns>Дробная часть числа в степени Q</returns>
        private static string ConvertFractionToBase(double decimalValue, int q, int m)
        {
            string result = "";   // Объявление переменной результата 

            // Перевод числа из десятичной системы в систему Q, пока количество знаков после запятой не станет удовлетворительным
            while (m-- > 0)
            {
                decimalValue *= q;
                int digit = (int)decimalValue;
                result += GetDigitChar(digit);
                decimalValue -= digit;
            }

            return result;
        }
        /// <summary>
        /// Проверка на то, выходит ли цифра за пределы десятичной системы
        /// Вывод числа с буквенными значениями
        /// </summary>
        /// <param name="c">Число
        /// должно быть задано действительным числом в десятичной системе типа char</param>
        /// returns>Число с буквенными значениями</returns>
        private static int GetDigitValue(char c)
        {
            if (char.IsDigit(c)) return c - '0';
            return char.ToUpper(c) - 'A' + 10;
        }

        /// <summary>
        /// Перевод числа в буквенное значение
        /// Вывод буквенного значения
        /// </summary>
        /// <param name="value">Число
        /// должно быть задано действительным числом в десятичной системе типа char</param>
        /// returns>Буквенное значение</returns>
        private static char GetDigitChar(int value)
        {
            return value < 10 ? (char)(value + '0') : (char)(value - 10 + 'A');
        }

        /// <summary>
        /// Перевод числа (в системе счисления больше, чем десятичная) в десятичную систему счисления
        /// Вывод числа в десятичной системе
        /// </summary>
        /// <param name="numberStr">Целая или дробная часть числа
        /// должно быть задано целым числом типа string</param>
        /// <param name="baseValue">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// returns>Числовое значение</returns>
        private static int ConvertToDecimal(string numberStr, int baseValue)
        {
            int decimalValue = 0;
            int length = numberStr.Length;

            for (int i = 0; i < length; i++)
            {
                char digit = numberStr[length - 1 - i]; // Получаем цифру с конца
                int value;

                if (char.IsDigit(digit))
                {
                    value = digit - '0'; // Преобразуем цифры
                }
                else
                {
                    value = char.ToUpper(digit) - 'A' + 10; // Преобразуем буквы в числа
                }

                decimalValue += value * (int)Math.Pow(baseValue, i);
            }

            return decimalValue;
        }
        /// <summary>
        /// Перевод числа (в системе счисления больше, чем десятичная) в десятичную систему счисления
        /// Вывод числа в десятичной системе
        /// </summary>
        /// <param name="numberStr">Целая или дробная часть числа
        /// должно быть задано целым числом типа string</param>
        /// <param name="baseValue">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// returns>Числовое значение</returns>
        static string ConvertToDecimalFr(string numberStr, int baseValue)
        {
            double decimalValue = 0;
            int length = numberStr.Length;

            for (int i = 0; i < length; i++)
            {
                char digit = numberStr[length - 1 - i]; // Получаем цифру с конца
                int value;

                if (char.IsDigit(digit))
                {
                    value = digit - '0'; // Преобразуем цифры
                }
                else
                {
                    value = char.ToUpper(digit) - 'A' + 10; // Преобразуем буквы в числа
                }

                decimalValue += value * Math.Pow(baseValue, (i - length));
            }
            string demic = decimalValue.ToString().Substring(2);
            return demic;
        }
        /// <summary>
        /// Проверка на подленность введенного числа его системе исчисления
        /// Вывод 1 или 0 (True/False)
        /// </summary>
        /// <param name="number">Введенное число
        /// должно быть задано действительным числом типа string</param>
        /// <param name="p">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// returns>Число 1 или 0</returns>
        public static int CheckSystem(string number, int p)
        {
            int kod = 0;
            char[] alf = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < number.Length; i++)
            {
                kod = 0;
                for (int j = 0; j < p; j++)
                {

                    if (number[i] == alf[j])
                    {
                        kod = 1;
                    }
                    else if (number[i] == ',')
                    {
                        kod = 1;
                        break;
                    }
                }
                if (kod == 0)
                {
                    return 0;
                }
            }
            return 1;
        }
        /// <summary>
        /// Проверка на подленность введенного числа на символы в нем
        /// Вывод 1 или 0 (True/False)
        /// </summary>
        /// <param name="number">Введенное число
        /// должно быть задано действительным числом типа string</param>
        /// <param name="p">Система исчисления P
        /// должно быть задано положительным числом, в диапазоне от 2 до 36, типа int</param>
        /// returns>Число 1 или 0</returns>
        public static int CheckSymbol(string number, int p)
        {
            int kod = 0;
            char[] alf = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < number.Length; i++)
            {
                kod = 0;
                for (int j = 0; j < alf.Length; j++)
                {

                    if (number[i] == alf[j])
                    {
                        kod = 1;
                    }
                    else if (number[i] == ',')
                    {
                        kod = 1;
                        break;
                    }
                }
                if (kod == 0)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
