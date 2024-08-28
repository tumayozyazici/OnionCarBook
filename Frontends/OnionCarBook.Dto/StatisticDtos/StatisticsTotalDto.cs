using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Dto.StatisticDtos
{
    public class StatisticsTotalDto
    {
        public ResultStatisticCountDto CarCount { get; set; }
        public ResultStatisticCountDto BlogCount { get; set; }
        public ResultStatisticCountDto AuthorCount { get; set; }
        public ResultStatisticCountDto BrandCount { get; set; }
        public ResultStatisticCountDto LocationCount { get; set; }
        public ResultStatisticCountDto AtomaticCarCount { get; set; }
        public ResultStatisticCountDto ElectricCarCount { get; set; }
        public ResultStatisticCountDto GasolineAndDieselCarCount { get; set; }
        public ResultStatisticCountDto Below1000KmCarCount { get; set; }
        public ResultStatisticPriceDto DailyRentPriceAvg { get; set; }
        public ResultStatisticPriceDto WeeklyRentPriceAvg { get; set; }
        public ResultStatisticPriceDto MonthlyRentPriceAvg { get; set; }
        public ResultStatisticNameDto BrandByCount { get; set; }
        public ResultStatisticNameDto BlogByComment { get; set; }
        public ResultStatisticNameDto BrandModelMaxDailyPrice { get; set; }
        public ResultStatisticNameDto BrandModelMinDailyPrice { get; set; }
    }
}
