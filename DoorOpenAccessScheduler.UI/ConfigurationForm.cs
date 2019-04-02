using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DoorOpenAccessScheduler.Data;
using DoorOpenAccessScheduler.Helpers;

namespace DoorOpenAccessScheduler.UI
{
    public partial class ConfigurationForm : Form
    {
        private DoorOpenSchedule _doorOpenSchedule;

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            _doorOpenSchedule = ConfigurationHelper.DoorOpenSchedule;

            //Day of the week Tab
            SetComboBox(cmbDayOfTheWeek, _doorOpenSchedule.DayOfTheWeekSlots);

            //Holiday tab
            SetComboBox(cmbHolidaySchedule, _doorOpenSchedule.HolidayExclusions);
        }

        private static void SetComboBox<T>(ComboBox comboBox, IEnumerable<T> objects)
        {
            comboBox.Items.Clear();
            foreach (var objectSingle in objects)
            {
                comboBox.Items.Add(objectSingle);
            }

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        private void cmbDayOfTheWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            var slots = ((DaySlot) cmbDayOfTheWeek.SelectedItem).Slots;
            var slotDisplay = GetSlotDisplays(slots);
            dgvAccessSchedules.DataSource = null;
            dgvAccessSchedules.DataSource = slotDisplay;            
        }

        private static List<SlotDisplay> GetSlotDisplays(IEnumerable<Slot> slots)
        {
            var slotDisplay = new List<SlotDisplay>();
            if (slots != null) 
                slotDisplay.AddRange(slots.Select(t => new SlotDisplay(t)));

            return slotDisplay;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var slots = AddRow(dgvAccessSchedules);                        

            UpdateSettingsFileStandardSchedule(slots);
        }

        private static IEnumerable<SlotDisplay> AddRow(DataGridView dgv)
        {
            var slots = (List<SlotDisplay>)dgv.DataSource;
            if (slots.Count == 0)
                slots = new List<SlotDisplay>();
            if (slots.Count == 10)
            {
                MessageBox.Show("A maximum of 10 slots can be added per day");
                return slots;
            }

            slots.Add(new SlotDisplay {StartTime = "12:00 AM", EndTime = "11:59 PM"});

            //Refresh Grid
            dgv.DataSource = null;
            dgv.DataSource = slots;

            return slots;
        }

        private void UpdateSettingsFileStandardSchedule(IEnumerable<SlotDisplay> slots)
        {
            //Update Settings
            var daySlot = (DaySlot) cmbDayOfTheWeek.SelectedItem;
            daySlot.Slots = new List<Slot>();
            foreach (var slotDisplay in slots)
            {
                daySlot.Slots.Add(slotDisplay.GetBase());
            }

            _doorOpenSchedule.DayOfTheWeekSlots.First(i => i.DayOfWeek == daySlot.DayOfWeek).Slots = daySlot.Slots;
            ConfigurationHelper.DoorOpenSchedule = _doorOpenSchedule;
        }

        private void UpdateSettingsFileHolidaySchedule(IEnumerable<SlotDisplay> slots = null)
        {
            //Update Settings
            var exclusion = (Exclusion)cmbHolidaySchedule.SelectedItem;

            exclusion.Name = txtHolidayName.Text;
            exclusion.StartDateTime = dtHolidayStart.Value;
            exclusion.EndDateTime = dtHolidayEnd.Value;

            if (slots == null)
            {
                slots = (List<SlotDisplay>)dgvHolidaySlots.DataSource;
            }

            exclusion.Slots = new List<Slot>();
            if (slots != null)
            {                
                foreach (var slotDisplay in slots)
                {
                    exclusion.Slots.Add(slotDisplay.GetBase());
                }
            }

            _doorOpenSchedule.HolidayExclusions.First(i => i.Id == exclusion.Id).Name = exclusion.Name;
            _doorOpenSchedule.HolidayExclusions.First(i => i.Id == exclusion.Id).StartDateTime = exclusion.StartDateTime;
            _doorOpenSchedule.HolidayExclusions.First(i => i.Id == exclusion.Id).EndDateTime = exclusion.EndDateTime;
            _doorOpenSchedule.HolidayExclusions.First(i => i.Id == exclusion.Id).Slots = exclusion.Slots;

            ConfigurationHelper.DoorOpenSchedule = _doorOpenSchedule;
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            var slots = RemoveRow(dgvAccessSchedules);
            UpdateSettingsFileStandardSchedule(slots);
        }

        private IEnumerable<SlotDisplay> RemoveRow(DataGridView dgv)
        {
            var slots = (List<SlotDisplay>)dgv.DataSource;

            if (dgvAccessSchedules.SelectedRows.Count == 0)
                return slots;
            
            slots.RemoveAt(dgv.SelectedRows[0].Index);

            //Refresh Grid
            dgv.DataSource = null;
            dgv.DataSource = slots;
            return slots;
        }

        private void dgvAccessSchedules_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var validated = ValidateSlot(e, (DataGridView)sender);
            if (!validated) e.Cancel=true;                                 
        }

        private static bool ValidateSlot(DataGridViewCellValidatingEventArgs e, DataGridView dgv)
        {
            try
            {
                if (e.FormattedValue.ToString() == string.Empty)
                {
                }
                else
                {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    DateTime.Parse(e.FormattedValue.ToString(), CultureInfo.InvariantCulture);
                }
                
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                return true;
            }
            catch (FormatException)
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText =
                    "You did not enter a valid time (hh:mm AM/PM).";
                return false;
            }
        }

        private void cmbHolidaySchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            var exclusion = (Exclusion) cmbHolidaySchedule.SelectedItem;
            txtHolidayName.Text = exclusion.Name;
            dtHolidayStart.Value = exclusion.StartDateTime;
            dtHolidayEnd.Value = exclusion.EndDateTime;
            //Data Grid
            
            var slotDisplay = GetSlotDisplays(exclusion.Slots);
            dgvHolidaySlots.DataSource = slotDisplay;
        }

        private void dgvHolidaySlots_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var validated = ValidateSlot(e, (DataGridView)sender);
            if (!validated) e.Cancel = true;            
        }

        private void btnAddHolidaySlot_Click(object sender, EventArgs e)
        {
            var slots = AddRow(dgvHolidaySlots);
            UpdateSettingsFileHolidaySchedule(slots);
        }

        private void btnDeleteHolidaySlot_Click(object sender, EventArgs e)
        {
            var slots = RemoveRow(dgvHolidaySlots);
            UpdateSettingsFileHolidaySchedule(slots);
        }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            var exclusions = new List<Exclusion>();
            foreach (var item in cmbHolidaySchedule.Items)
            {
                exclusions.Add((Exclusion)item);
            }

            var dateTime = DateTime.Now;
            uint lastId = 0;
            if (exclusions.Count > 0)
            {
                lastId = exclusions.Last().Id + 1;
            }

            exclusions.Add(new Exclusion
            {
                Id = lastId, Name = $"New Holiday {lastId}",
                StartDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0),
                EndDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59)
            });

            //Update combobox
            cmbHolidaySchedule.Items.Clear();
            foreach (var exclusion in exclusions)
            {
                cmbHolidaySchedule.Items.Add(exclusion);
            }

            if (cmbHolidaySchedule.Items.Count > 0)
                cmbHolidaySchedule.SelectedIndex = cmbHolidaySchedule.Items.Count - 1;

            _doorOpenSchedule.HolidayExclusions = exclusions;
            ConfigurationHelper.DoorOpenSchedule = _doorOpenSchedule;
        }

        private void btnRemoveHoliday_Click(object sender, EventArgs e)
        {
            var exclusions = new List<Exclusion>();
            foreach (var item in cmbHolidaySchedule.Items)
            {
                exclusions.Add((Exclusion)item);
            }
            exclusions.RemoveAt(cmbHolidaySchedule.SelectedIndex);            

            //Update combobox
            cmbHolidaySchedule.Items.Clear();
            foreach (var exclusion in exclusions)
            {
                cmbHolidaySchedule.Items.Add(exclusion);
            }

            if (cmbHolidaySchedule.Items.Count > 0)
                cmbHolidaySchedule.SelectedIndex = 0;

            _doorOpenSchedule.HolidayExclusions = exclusions;
            ConfigurationHelper.DoorOpenSchedule = _doorOpenSchedule;
        }

        private void dtHolidayStart_CloseUp(object sender, EventArgs e)
        {
            UpdateSettingsFileHolidaySchedule();
        }

        private void dtHolidayEnd_CloseUp(object sender, EventArgs e)
        {
            UpdateSettingsFileHolidaySchedule();
        }

        private void dtHolidayEnd_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSettingsFileHolidaySchedule();
        }

        private void dtHolidayStart_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSettingsFileHolidaySchedule();
        }

        private void txtHolidayName_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSettingsFileHolidaySchedule();
            cmbHolidaySchedule.Items[cmbHolidaySchedule.SelectedIndex] = cmbHolidaySchedule.SelectedItem;
        }

        private void btnSaveHoliday_Click(object sender, EventArgs e)
        {
            var slots = (List<SlotDisplay>)dgvHolidaySlots.DataSource;
            UpdateSettingsFileHolidaySchedule(slots);
            MessageBox.Show("Slots Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveWeekSchedule_Click(object sender, EventArgs e)
        {
            var slots = (List<SlotDisplay>)dgvAccessSchedules.DataSource;
            UpdateSettingsFileStandardSchedule(slots);
            MessageBox.Show("Slots Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
