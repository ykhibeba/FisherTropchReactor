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
    public partial class GasPhaseData : Form
    {
        private FiniteComponentReactor reactor;

        public GasPhaseData(FiniteComponentReactor reactor)
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
            column.ReadOnly = true;
            column.CellTemplate = new DataGridViewTextBoxCell();
            dgvReactor.Columns.Add(column);
            for (int i = 0; i < reactor.component.M; i++)
            {
                column = new DataGridViewColumn();
                column.HeaderText = i >= arrayHeader.Length ? $"C{i - 3}" : arrayHeader[i];
                column.ReadOnly = true;
                column.CellTemplate = new DataGridViewTextBoxCell();
                dgvReactor.Columns.Add(column);
            }

            for (int i = 0; i < reactor.component.EndTime; i++)
            {
                dgvReactor.Rows.Add();
                for (int j = 0; j < reactor.component.M + 1; j++)
                {
                    dgvReactor[j, i].Value = j == 0 ? i : reactor.cGasComponent[j - 1, i];
                }
            }

            dgvReactor.AllowUserToAddRows = false;
        }
    }
}
