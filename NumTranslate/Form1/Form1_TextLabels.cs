using System.Drawing;
using System.Windows.Forms;

namespace NumTranslate
{
    public partial class Form1 : Form
    {
        // Изменение 2
        // Изменение
        /// <summary>
        /// Метод для добавления текстовых меток на форму.
        /// Создает и настраивает несколько элементов Label, которые отображают текст на форме.
        /// </summary>
        private void AddTextLabels()
        {
            /// <summary>
            /// Метка с текстом "Введите число:", расположенная в координатах (430, 100).
            /// Размер метки — 230x30, шрифт — Arial, 14pt, жирный, цвет текста — черный.
            /// </summary>
            
            Label InputNum = new Label
            {
                Text = "Введите число:",
                Location = new Point(430, 100),
                Size = new Size(230, 30),
                Font = new Font("Monotype Corsiva", 20, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(InputNum);
            
            /// <summary>
            /// Метка с текстом "Его система счисления:", расположенная в координатах (330, 200).
            /// Размер метки — 330x30, шрифт — Arial, 14pt, жирный, цвет текста — черный.
            /// </summary>
            
            Label FromWhitch = new Label
            {
                Text = "Его система счисления:",
                Location = new Point(360, 200),
                Size = new Size(290, 30),
                Font = new Font("Monotype Corsiva", 20, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(FromWhitch);
            
            /// <summary>
            /// Метка с текстом "Перевести в:", расположенная в координатах (680, 200).
            /// Размер метки — 230x30, шрифт — Arial, 14pt, жирный, цвет текста — черный.
            /// </summary>
            
            Label ToWhitch = new Label
            {
                Text = "Перевести в:",
                Location = new Point(680, 200),
                Size = new Size(230, 30),
                Font = new Font("Monotype Corsiva", 20, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(ToWhitch);
            
            /// <summary>
            /// Метка с текстом "Результат:", расположенная в координатах (500, 500).
            /// Размер метки — 150x30, шрифт — Arial, 14pt, жирный, цвет текста — черный.
            /// </summary>
            
            Label Result = new Label
            {
                Text = "Результат:",
                Location = new Point(500, 500),
                Size = new Size(150, 30),
                Font = new Font("Monotype Corsiva", 20, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(Result);
        }
    }
}