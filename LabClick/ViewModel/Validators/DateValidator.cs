using System;
using System.ComponentModel.DataAnnotations;

namespace LabClick.ViewModel.Validators
{
    public class DateValidator : ValidationAttribute
    {
        public DateTime Minimum { get; set; }
        public DateTime Maximum { get; set; }

        public DateValidator()
        {
            this.Minimum = DateTime.Parse("01-01-1900");
            this.Maximum = DateTime.Now;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                return (date >= Minimum && date <= Maximum);
            }

            return false;
        }
    }
}