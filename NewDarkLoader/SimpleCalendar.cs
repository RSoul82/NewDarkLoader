using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NewDarkLoader
{
    public partial class SimpleCalendar : UserControl
    {
        public SimpleCalendar()
        {
            InitializeComponent();

            //for (int i = 1899; i <= 2525; i++)
            //{
            //    cbYear.Items.Add(i);
            //}

            cbMonth.SelectedIndexChanged += this.HandleMonthChanged;
            cbYear.SelectedIndexChanged += this.HandleYearChanged;
        }

        #region Month Changed event
        public event EventHandler MonthChanged;
        
        private void HandleMonthChanged(object sender, EventArgs e)
        {
            this.OnMonthChanged(EventArgs.Empty);
        }

        protected virtual void OnMonthChanged(EventArgs e)
        {
            EventHandler handler = this.MonthChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Year Changed event
        public event EventHandler YearChanged;

        private void HandleYearChanged(object sender, EventArgs e)
        {
            this.OnYearChanged(EventArgs.Empty);
        }

        protected virtual void OnYearChanged(EventArgs e)
        {
            EventHandler handler = this.YearChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        /// <summary>
        /// Returns the text the user selected.
        /// </summary>
        public string MonthString
        {
            get
            {
                return cbMonth.Items[cbMonth.SelectedIndex].ToString();
            }
        }

        /// <summary>
        /// Gets or sets the month number. Jan = 1.
        /// </summary>
        public int MonthInt
        {
            get
            {
                return cbMonth.SelectedIndex + 1;
            }
            set
            {
                cbMonth.SelectedIndex = value - 1;
            }
        }

        /// <summary>
        /// Gets or sets the actual year shown to the user. E.g. 1999, not index 0.
        /// </summary>
        public int Year
        {
            get
            {
                if (cbYear.SelectedIndex != -1)
                    return (int)cbYear.Items[cbYear.SelectedIndex];
                else return 0;
            }
            set
            {
                int realYear = value;
                for (int i = 0; i < cbYear.Items.Count; i++)
                {
                    if ((int)cbYear.Items[i] == realYear)
                    {
                        cbYear.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #region Designer Properties
        [Category("Appearance")]
        public int MonthIndex
        {
            get
            {
                return cbMonth.SelectedIndex;
            }
            set
            {
                cbMonth.SelectedIndex = value;
            }
        }

        [Category("Appearance")]
        public int YearIndex
        {
            get
            {
                return cbYear.SelectedIndex;
            }
            set
            {
                cbYear.SelectedIndex = (int)value;
            }
        }

        private bool thisMonth;

        [Category("Appearance")]
        public bool ShowThisMonth
        {
            get
            {
                return thisMonth;
            }
            set
            {
                thisMonth = value;
                if (thisMonth)
                {
                    cbMonth.SelectedIndex = DateTime.Today.Month - 1;
                    
                    for (int i = 0; i < cbYear.Items.Count; i++)
                    {
                        int testYear = (int)cbYear.Items[i];
                        if (testYear == DateTime.Today.Year)
                        {
                            cbYear.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private string tip;
        [Category("Appearance")]
        public string ShowTip
        {
            get
            {
                return tip;
            }
            set
            {
                tip = value;
                toolTip1.SetToolTip(cbMonth, tip);
                toolTip1.SetToolTip(cbYear, tip);
            }
        }

        #endregion
    }
}
