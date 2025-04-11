using System;
using System.Drawing;
using System.Windows.Forms;

namespace NumTranslate
{
    public partial class Form1 : Form
    {
        private ComboBox currentSystemComboBox; 
        private ComboBox targetSystemComboBox;  
        private TextBox currentCustomBaseTextBox; 
        private TextBox targetCustomBaseTextBox;  

        /// <summary>
        /// Добавляет на форму два комбобокса для выбора исходной и целевой систем счисления,
        /// а также текстовые поля для ввода пользовательских систем счисления.
        /// Исходный комбобокс позволяет выбрать стандартные системы (двоичная, троичная и т.д.) или указать "Другая".
        /// Целевой комбобокс аналогичен, но позволяет выбрать систему, в которую будет выполнено преобразование.
        /// Текстовые поля для пользовательских систем счисления изначально скрыты и отображаются только при выборе "Другая" или "Другую".
        /// </summary>
        private void AddComboBoxes()
        {
            
            currentSystemComboBox = new ComboBox
            {
                Location = new Point(370, 260),
                Size = new Size(250, 30),
                Font = new Font("Arial", 14, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList 
            };
            currentSystemComboBox.Items.AddRange(new object[]
            {
                "Двоичная",
                "Троичная",
                "Восьмеричная",
                "Десятичная",
                "Шестнадцатеричная",
                "Другая"
            });
            currentSystemComboBox.SelectedIndexChanged += CurrentSystemComboBox_SelectedIndexChanged; 
            this.Controls.Add(currentSystemComboBox);

            
            targetSystemComboBox = new ComboBox
            {
                Location = new Point(680, 260),
                Size = new Size(250, 30),
                Font = new Font("Arial", 14, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            targetSystemComboBox.Items.AddRange(new object[]
            {
                "Двоичную",
                "Троичную",
                "Восьмеричную",
                "Десятичную",
                "Шестнадцатеричную",
                "Другую"
            });
            targetSystemComboBox.SelectedIndexChanged += TargetSystemComboBox_SelectedIndexChanged; // Обработчик изменения выбора
            this.Controls.Add(targetSystemComboBox);

            
            currentCustomBaseTextBox = new TextBox
            {
                Location = new Point(370, 300), 
                Size = new Size(250, 30),
                Font = new Font("Arial", 14, FontStyle.Regular),
                Visible = false // Сначала скрыто
            };
            this.Controls.Add(currentCustomBaseTextBox);

            
            targetCustomBaseTextBox = new TextBox
            {
                Location = new Point(680, 300), 
                Size = new Size(250, 30),
                Font = new Font("Arial", 14, FontStyle.Regular),
                Visible = false 
            };
            this.Controls.Add(targetCustomBaseTextBox);
        }

        /// <summary>
        /// Обработчик события изменения выбора в комбобоксе исходной системы счисления.
        /// Если выбрана опция "Другая", отображается текстовое поле для ввода пользовательской системы счисления.
        /// В противном случае текстовое поле скрывается.
        /// </summary>
        private void CurrentSystemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentSystemComboBox.SelectedItem?.ToString() == "Другая")
            {
                currentCustomBaseTextBox.Visible = true; 
                currentCustomBaseTextBox.Text = "";      
            }
            else
            {
                currentCustomBaseTextBox.Visible = false; 
            }
        }

        /// <summary>
        /// Обработчик события изменения выбора в комбобоксе целевой системы счисления.
        /// Если выбрана опция "Другую", отображается текстовое поле для ввода пользовательской системы счисления.
        /// В противном случае текстовое поле скрывается.
        /// </summary>
        private void TargetSystemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (targetSystemComboBox.SelectedItem?.ToString() == "Другую")
            {
                targetCustomBaseTextBox.Visible = true; 
                targetCustomBaseTextBox.Text = "";      
            }
            else
            {
                targetCustomBaseTextBox.Visible = false; 
            }
        }

        /// <summary>
        /// Определяет выбранную систему счисления на основе выбора в комбобоксе и текстового поля.
        /// Если выбрана стандартная система (например, двоичная), возвращает соответствующее значение.
        /// Если выбрана опция "Другая" или "Другую", проверяет корректность введенного значения в текстовом поле.
        /// В случае некорректного значения выбрасывает исключение.
        /// </summary>
        private int GetSelectedBase(ComboBox comboBox, TextBox customTextBox)
        {
            string selectedSystem = comboBox.SelectedItem?.ToString();

            if (selectedSystem == "Другая" || selectedSystem == "Другую")
            {
                
                if (int.TryParse(customTextBox.Text, out int customBase) && customBase > 1)
                {
                    return customBase;
                }
                else
                {
                    return 0;
                }
            }

            return selectedSystem switch
            {
                "Двоичная" or "Двоичную" => 2,
                "Троичная" or "Троичную" => 3,
                "Восьмеричная" or "Восьмеричную" => 8,
                "Десятичная" or "Десятичную" => 10,
                "Шестнадцатеричная" or "Шестнадцатеричную" => 16,
                _ => 0
            };
        }

        /// <summary>
        /// Возвращает кортеж с выбранными исходной и целевой системами счисления.
        /// Использует метод GetSelectedBase для определения значений.
        /// </summary>
        private (int currentBase, int targetBase) GetSelectedBases()
        {
            int currentBase = GetSelectedBase(currentSystemComboBox, currentCustomBaseTextBox);
            int targetBase = GetSelectedBase(targetSystemComboBox, targetCustomBaseTextBox);
            return (currentBase, targetBase);
        }
    }
}