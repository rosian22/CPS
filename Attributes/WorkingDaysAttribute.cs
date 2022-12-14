using System.ComponentModel.DataAnnotations;

namespace CPS.Attributes
{
    public class WorkingDaysAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);

            var businessDays = GetBusinessDays(DateTime.Now, date);
            if (businessDays >= 10)
            {
                return true;
            }

            return false;
        }

        private double GetBusinessDays(DateTime startD, DateTime endD)
        {
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }

    }
}
