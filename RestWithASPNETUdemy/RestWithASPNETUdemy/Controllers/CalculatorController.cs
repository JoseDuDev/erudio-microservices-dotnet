using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
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
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertParaDecimal(firstNumber) + ConvertParaDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input invalid");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetMinus(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertParaDecimal(firstNumber) - ConvertParaDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Input invalid");
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult GetTimes(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var times = ConvertParaDecimal(firstNumber) * ConvertParaDecimal(secondNumber);
                return Ok(times.ToString());
            }
            return BadRequest("Input invalid");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivide(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertParaDecimal(firstNumber) / ConvertParaDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Input invalid");
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult GetAverage(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var avg = (ConvertParaDecimal(firstNumber) + ConvertParaDecimal(secondNumber)) / 2;
                return Ok(avg.ToString());
            }
            return BadRequest("Input invalid");
        }

        [HttpGet("squ/{firstNumber}")]
        public IActionResult GetSquare(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var avg = Math.Sqrt(ConvertParaDouble(firstNumber));
                return Ok(avg.ToString());
            }
            return BadRequest("Input invalid");
        }

        private double ConvertParaDouble(string strNumber)
        {
            if (double.TryParse(strNumber, out double number))
                return number;
            return 0;
        }

        private decimal ConvertParaDecimal(string strNumber)
        {
            if (decimal.TryParse(strNumber, out decimal number))
                return number;
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNum = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double number);
            return isNum;
        }
    }
}