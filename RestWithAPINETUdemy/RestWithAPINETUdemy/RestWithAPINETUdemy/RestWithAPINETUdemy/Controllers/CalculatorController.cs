using Microsoft.AspNetCore.Mvc;

namespace RestWithAPINETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
         public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
        
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
              }

            return BadRequest("Invalid Number");
        }


        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))

            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Number");
        }
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))

            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());

            }


            return BadRequest("Invalid Number");
        }
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
   
            {
                var sum = ConvertToDouble(firstNumber) / ConvertToDouble(secondNumber);
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Number");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Med(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))

            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber) / 2;
                return Ok(sum.ToString());

            }
            return BadRequest("Invalid Number");
        }
        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if (isNumeric(firstNumber))

            {
                var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Number");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
                return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;

            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;

        }
    }
}