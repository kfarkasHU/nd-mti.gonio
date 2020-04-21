using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;
using ND.MTI.Gonio.Service.Helper;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.RouteGenerator
{
    public partial class Form_RouteGenerator : Form
    {
        private static IList<Segment> _xSegments;
        private static IList<Segment> _ySegments;

        private static IIOWorker _ioWorker;

        public Form_RouteGenerator()
        {
            InitializeComponent();

            _xSegments = new List<Segment>();
            _ySegments = new List<Segment>();

            var xBindingList = new BindingList<Segment>(_xSegments);
            var yBindingList = new BindingList<Segment>(_ySegments);

            dataGridViewXSegments.DataSource = xBindingList;
            dataGridViewYSegments.DataSource = yBindingList;

            _ioWorker = new IOWorker();
        }

        private void buttonClose_Click(object sender, EventArgs e) => Close();

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var xVect = new List<double>();
            var yVect = new List<double>();

            CreateAxisVect(xVect, _xSegments.OrderBy(m => m.Start).ToList());
            CreateAxisVect(yVect, _ySegments.OrderBy(m => m.Start).ToList());

            var matrix = PositionMatrixHelper.MergeVectors(xVect, yVect);

            _ioWorker.SaveFile(matrix.ToArray(), IOWorker_Filter.RouteFile);
        }

        private void CreateAxisVect(IList<double> listRef, IList<Segment> segments)
        {
            for (var i = 0; i < segments.Count; i++)
                CreateAxisVect(listRef, segments[i]);
        }

        private void CreateAxisVect(IList<double> listRef, Segment segment)
        {
                (listRef as List<double>).AddRange(
                    PositionMatrixHelper.CreateAxisVect(
                        segment.Start,
                        segment.End,
                        segment.Step
                    )
                );
        }

        private void buttonClearBoth_Click(object sender, EventArgs e)
        {
            _xSegments.Clear();
            _ySegments.Clear();

            var xBindingList = new BindingList<Segment>(_xSegments);
            dataGridViewXSegments.DataSource = xBindingList;

            var yBindingList = new BindingList<Segment>(_ySegments);
            dataGridViewYSegments.DataSource = yBindingList;
        }

        private void buttonClearX_Click(object sender, EventArgs e)
        {
            _xSegments.Clear();

            var xBindingList = new BindingList<Segment>(_xSegments);
            dataGridViewXSegments.DataSource = xBindingList;
        }

        private void buttonClearY_Click(object sender, EventArgs e)
        {
            _ySegments.Clear();

            var yBindingList = new BindingList<Segment>(_ySegments);
            dataGridViewYSegments.DataSource = yBindingList;
        }

        private void buttonAddX_Click(object sender, EventArgs e)
        {
            _xSegments.Add(CreateSegment());

            var xBindingList = new BindingList<Segment>(_xSegments);
            dataGridViewXSegments.DataSource = xBindingList;
        }

        private void buttonAddY_Click(object sender, EventArgs e)
        {
            _ySegments.Add(CreateSegment());

            var yBindingList = new BindingList<Segment>(_ySegments);
            dataGridViewYSegments.DataSource = yBindingList;
        }

        private Segment CreateSegment()
        {
            var start = Parser.StringToDouble(textBoxStart.Text);
            var end = Parser.StringToDouble(textBoxEnd.Text);
            var step = Parser.StringToDouble(textBoxStep.Text);

            if (start < -174 || start > 174)
                throw new Exception("Start coordinate must be between -174 and 174");

            if (end < -174 || end > 174)
                throw new Exception("End coordinate must be between -174 and 174");

            if (step < 0.1 && start != end)
                throw new Exception("Step must be greater than 0.1");

            return new Segment(start, end, step);
        }

        private Segment GetSelectedSegmentX() => GetSelectedSegment(dataGridViewXSegments);
        private Segment GetSelectedSegmentY() => GetSelectedSegment(dataGridViewYSegments);

        private Segment GetSelectedSegment(DataGridView dgView)
        {
            var selectedRows = dgView.SelectedRows;

            if (selectedRows.Count == 1)
                return dgView.SelectedRows[0].DataBoundItem as Segment;

            return null;
        }

        private void buttonDeleteX_Click(object sender, EventArgs e)
        {
            var seg = GetSelectedSegmentX();

            if (seg is null)
                return;

            _xSegments.Remove(seg);

            var xBindingList = new BindingList<Segment>(_xSegments);
            dataGridViewXSegments.DataSource = xBindingList;
        }

        private void buttonDeleteY_Click(object sender, EventArgs e)
        {
            var seg = GetSelectedSegmentY();

            if (seg is null)
                return;

            _ySegments.Remove(seg);

            var yBindingList = new BindingList<Segment>(_ySegments);
            dataGridViewYSegments.DataSource = yBindingList;
        }
    }
}
