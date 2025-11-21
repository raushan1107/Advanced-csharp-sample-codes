using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppLearning.Controls
{
    public class DateTimePicker : Control
    {
        static DateTimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DateTimePicker),
                new FrameworkPropertyMetadata(typeof(DateTimePicker)));
        }
        // HOURS (0–23)
        public int Hour
        {
            get => (int)GetValue(HourProperty);
            set => SetValue(HourProperty, value);
        }

        public static readonly DependencyProperty HourProperty =
            DependencyProperty.Register(
                nameof(Hour),
                typeof(int),
                typeof(DateTimePicker),
                new PropertyMetadata(0, OnTimeChanged));


        // MINUTES (0–59)
        public int Minute
        {
            get => (int)GetValue(MinuteProperty);
            set => SetValue(MinuteProperty, value);
        }

        public static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register(
                nameof(Minute),
                typeof(int),
                typeof(DateTimePicker),
                new PropertyMetadata(0, OnTimeChanged));
        private static void OnTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DateTimePicker;
            if (control?.Value == null) return;

            var date = control.Value.Value.Date;

            control.Value = new DateTime(
                date.Year, date.Month, date.Day,
                control.Hour, control.Minute, 0);
        }


        // SELECTED DATE/TIME (Dependency Property)
        public DateTime? Value
        {
            get => (DateTime?)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(DateTime?),
                typeof(DateTimePicker),
                new FrameworkPropertyMetadata(DateTime.Now, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        // FORMAT PROPERTY
        public string Format
        {
            get => (string)GetValue(FormatProperty);
            set => SetValue(FormatProperty, value);
        }

        public static readonly DependencyProperty FormatProperty =
            DependencyProperty.Register(
                nameof(Format),
                typeof(string),
                typeof(DateTimePicker),
                new PropertyMetadata("dd/MM/yyyy HH:mm"));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var textBox = GetTemplateChild("PART_TextBox") as TextBox;
            var button = GetTemplateChild("PART_Button") as Button;
            var calendar = GetTemplateChild("PART_Calendar") as Calendar;

            var hourCombo = GetTemplateChild("PART_HourCombo") as ComboBox;
            var minuteCombo = GetTemplateChild("PART_MinuteCombo") as ComboBox;

            // ================================
            // INITIAL SYNC WITH Current Value
            // ================================
            if (Value != null)
            {
                Hour = Value.Value.Hour;
                Minute = Value.Value.Minute;
            }

            // DISPLAY DATE+TIME IN TEXTBOX
            if (textBox != null)
            {
                textBox.Text = Value?.ToString(Format);
            }

            // ================================
            // CALENDAR DATE CHANGED
            // ================================
            if (calendar != null)
            {
                calendar.SelectedDate = Value;
                calendar.SelectedDatesChanged += (s, e) =>
                {
                    if (calendar.SelectedDate != null)
                    {
                        Value = new DateTime(
                            calendar.SelectedDate.Value.Year,
                            calendar.SelectedDate.Value.Month,
                            calendar.SelectedDate.Value.Day,
                            Hour,
                            Minute,
                            0);

                        if (textBox != null)
                            textBox.Text = Value?.ToString(Format);
                    }
                };
            }

            // ================================
            // DROPDOWN BUTTON CLICK (Toggle)
            // ================================
            if (button != null)
            {
                button.Click += (s, e) =>
                {
                    if (calendar != null)
                    {
                        calendar.Visibility =
                            calendar.Visibility == Visibility.Visible
                            ? Visibility.Collapsed
                            : Visibility.Visible;
                    }
                };
            }

            // ================================
            // HOUR COMBO BOX UPDATED
            // ================================
            if (hourCombo != null)
            {
                hourCombo.SelectionChanged += (s, e) =>
                {
                    if (hourCombo.SelectedIndex >= 0)
                    {
                        Hour = hourCombo.SelectedIndex;

                        if (Value != null)
                        {
                            Value = new DateTime(
                                Value.Value.Year,
                                Value.Value.Month,
                                Value.Value.Day,
                                Hour,
                                Minute,
                                0);

                            if (textBox != null)
                                textBox.Text = Value?.ToString(Format);
                        }
                    }
                };
            }

            // ================================
            // MINUTE COMBO BOX UPDATED
            // ================================
            if (minuteCombo != null)
            {
                minuteCombo.SelectionChanged += (s, e) =>
                {
                    if (minuteCombo.SelectedItem is int selectedMinute)
                    {
                        Minute = selectedMinute;

                        if (Value != null)
                        {
                            Value = new DateTime(
                                Value.Value.Year,
                                Value.Value.Month,
                                Value.Value.Day,
                                Hour,
                                Minute,
                                0);

                            if (textBox != null)
                                textBox.Text = Value?.ToString(Format);
                        }
                    }
                };
            }
        }


    }
}
