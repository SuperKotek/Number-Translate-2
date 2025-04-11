using System;
using System.Windows.Forms;

namespace NumTranslate
{
    public partial class Form1 : Form
    {
        private TextBox numberInputBox;
        private TextBox resultTextBox;

        double numberValue = 0;
        /// <summary>
        /// Добавляет на форму текстовое поле для ввода числа.
        /// Поле располагается в указанной позиции, имеет фиксированный размер и стиль границы.
        /// Шрифт текста — Arial, размер 12, выравнивание по центру.
        /// </summary>
        private void AddNumberInputField()
        {
            
            numberInputBox = new TextBox
            {
                Location = new System.Drawing.Point(680, 100), 
                Size = new System.Drawing.Size(200, 30), 
                BorderStyle = BorderStyle.FixedSingle, 
                Font = new Font("Arial", 12, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center, 

            };
            this.Controls.Add(numberInputBox);
            if (numberInputBox.Text == "")
            {
                numberValue = 0;    // Обрабатывается исключение, если пользователь ничего не ввел
            }
            else
            {
                try
                {
                    numberValue = double.Parse(numberInputBox.Text);   // Если пользователь что-то ввел
                }
                catch (FormatException)
                {
                }
            }
        }

        /// <summary>
        /// Добавляет на форму текстовое поле для отображения результата.
        /// Поле располагается в указанной позиции, имеет фиксированный размер и стиль границы.
        /// Шрифт текста — Arial, размер 14, выравнивание по центру.
        /// Поле доступно только для чтения, чтобы пользователь не мог изменить результат.
        /// </summary>
        private void AddResultTextBox()
        {
            resultTextBox = new TextBox
            {
                Location = new Point(680, 500), 
                Size = new Size(250, 50), 
                Font = new Font("Arial", 14, FontStyle.Regular),
                ReadOnly = true, 
                BorderStyle = BorderStyle.FixedSingle, 
                TextAlign = HorizontalAlignment.Center 
                
            };
            this.Controls.Add(resultTextBox);
        }
    }
}
