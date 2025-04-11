using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using TtranslationOfNumberSystemsClassLibrary1;

namespace NumTranslate
{
    public partial class Form1 : Form
    {
        private Label helpLabel;
        
        string resultNumber = "";
        
        /// <summary>
        /// Создает кнопку "Инструкция" с обработчиком события нажатия.
        /// При нажатии на кнопку отображается или скрывается Label с инструкцией.
        /// Если Label еще не создан, он создается и добавляется на форму.
        /// </summary>
        private void DefaultClippyButton()
        {
            Button defaultClippyButton = new Button
            {
                Text = "Инструкция",
                Size = new Size(250, 50),
                Location = new Point(50, 535),
                Font = new Font("Monotype Corsiva", 16, FontStyle.Bold)
            };
            defaultClippyButton.Click += (sender, e) =>
            {
                clippyPictureBox.Image = clippyFrames[1];
                StopAnimation();
                
                /// <summary>
                /// Если label уже существует просто переключаем его видимость
                /// </summary>
                

                if (helpLabel != null)
                {
                    helpLabel.Visible = !helpLabel.Visible; 
                    return;
                }

                /// <summary>
                /// Создание нового label с инструкцией
                /// </summary>
                
                helpLabel = new Label
                {
                    Text = "Инструкция: Введите число в верхнее поле, выберите исходную и целевую системы счисления, затем нажмите 'Перевести'.",
                    Location = new Point(50, 40), 
                    Size = new Size(260, 230),     
                    Font = new Font("Monotype Corsiva", 16, FontStyle.Italic),
                    ForeColor = Color.Black, 
                    BackColor = Color.FromArgb(191,191,191),       
                    BorderStyle = BorderStyle.FixedSingle, 
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter 
                };

                this.Controls.Add(helpLabel); 
            };
            this.Controls.Add(defaultClippyButton);
        }
        /// <summary>
        /// Создает кнопку "Перевести" с обработчиком события нажатия.
        /// При нажатии на кнопку получает выбранные системы счисления и отображает результат в текстовом поле.
        /// Также изменяет изображение в clippyPictureBox и останавливает анимацию.
        /// </summary>
        private void NiceButton()
        {
            Button niceButton = new Button
            {
                Text = "Перевести",
                Size = new Size(250, 50),
                Location = new Point(550, 380),
                Font = new Font("Monotype Corsiva", 16, FontStyle.Bold)
            };
            niceButton.Click += (sender, e) =>
            {
                string number = numberInputBox.Text;
                (int p, int q) = GetSelectedBases();
                string resultNumber = "";
                if (numberInputBox.Text == "")
                {
                    numberInputBox.Text = "0";    // Если пользователь ничего не ввел, то автоматически периметр берется за ноль и это выводиться
                    number = "0";
                }
                if (p < 2 || q < 2 || p > 36 || q > 36)
                {
                    resultTextBox.Text = "Система счисления некорректна!";
                }
                else
                {
                    if (TranslationOfNumberSystems.CheckSymbol(number, p) == 0)
                    {
                        resultTextBox.Text = "Недопустимый символ";
                    }
                    else
                    {
                        if (TranslationOfNumberSystems.CheckSystem(number, p) == 0)
                        {
                            resultTextBox.Text = "Число вне системы " + p;
                        }
                        else
                        {
                            resultNumber = TranslationOfNumberSystems.TranslateNumberFromToQ(number, p, q, 4);  // Перевод числа из p в q
                            resultTextBox.Text = resultNumber;     // Здесь выводиться результат - получившияся число в системе q
                            clippyPictureBox.Image = clippyFrames[2];
                            StopAnimation();
                        }
                    }
                }
            };
            this.Controls.Add(niceButton);
        }
    }
}