using System.ComponentModel.DataAnnotations;

namespace CPS.Attributes
{
    public class MultipleOf1000Attribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var parsedValue = Convert.ToInt16(value);
            return parsedValue % 1000 == 0;
        }
    }
}
