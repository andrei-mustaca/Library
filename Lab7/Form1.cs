using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private DataGridView dgv;

        public Form1()
        {
            Text = "Таблица умножения 16×16";
            Width = 800;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            InitializeDataGridView();
            PopulateMultiplicationTable(16);
        }

        private void InitializeDataGridView()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = true,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                MultiSelect = false
            };

            // Чтобы числа красиво центрировались
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Controls.Add(dgv);
        }

        private void PopulateMultiplicationTable(int size)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            // Добавляем колонки (1..size)
            for (int c = 1; c <= size; c++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = $"c{c}",
                    HeaderText = c.ToString(),
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Width = 60
                };
                dgv.Columns.Add(col);
            }

            // Добавляем строки и заполняем значениями
            for (int r = 1; r <= size; r++)
            {
                object[] rowValues = new object[size];
                for (int c = 1; c <= size; c++)
                {
                    rowValues[c - 1] = r * c;
                }

                int rowIndex = dgv.Rows.Add(rowValues);
                dgv.Rows[rowIndex].HeaderCell.Value = r.ToString(); // заголовок строки
                dgv.Rows[rowIndex].Resizable = DataGridViewTriState.False;
            }

            // Небольшие настройки внешнего вида
            dgv.RowHeadersWidth = 60;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
        }
    }
}
