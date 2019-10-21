using SlurryReactor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class LiquidPhaseData : Form
    {
        private FiniteComponentReactor reactor;

        public LiquidPhaseData(FiniteComponentReactor reactor)
        {
            InitializeComponent();
            this.reactor = reactor;
            BuildDataGrid();
        }

        private void BuildDataGrid()
        {
            var arrayHeader = new string[] { "c(H2)", "c(CO)", "c(CO2)", "c(H2O)" };
            var column = new DataGridViewColumn();
            column.HeaderText = "Time";
            //column1.Width = 100;
            column.ReadOnly = true;
            column.CellTemplate = new DataGridViewTextBoxCell();
            dgvReactor.Columns.Add(column);
            for (int i = 0; i < reactor.component.M; i++)
            {
                column = new DataGridViewColumn();
                column.HeaderText = i >= arrayHeader.Length ? $"C{i-3}" : arrayHeader[i];
                //column1.Width = 100;
                column.ReadOnly = true;
                column.CellTemplate = new DataGridViewTextBoxCell();
                dgvReactor.Columns.Add(column);
            }

            for (int i = 0; i < reactor.component.EndTime; i++)
            {
                dgvReactor.Rows.Add();
                for (int j = 0; j < reactor.component.M + 1; j++)
                {
                    dgvReactor[j, i].Value = j == 0 ? i : reactor.cLiquidComponent[j - 1, i];
                }
            }

            dgvReactor.AllowUserToAddRows = false;
        }
    }
}
